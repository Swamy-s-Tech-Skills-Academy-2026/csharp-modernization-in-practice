[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")),

    [Parameter()]
    [switch]$IncludeSourceMaterial
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-ComplianceError {
    param([string]$Message)
    Write-Host "ERROR: $Message" -ForegroundColor Red
}

function Get-TrackedTextFiles {
    param([string]$Root)

    $include = @('*.md', '*.mdc', '*.yml', '*.yaml')

    $paths = foreach ($pattern in $include) {
        Get-ChildItem -Path $Root -Recurse -File -Filter $pattern -Force -ErrorAction SilentlyContinue
    }

    $paths |
        Where-Object {
            $_.FullName -notmatch '\\.git\\' -and
            $_.FullName -notmatch '\\node_modules\\' -and
            $_.FullName -notmatch '\\docs\\review-reports\\' -and
            ($IncludeSourceMaterial -or $_.FullName -notmatch '\\source-material\\')
        } |
        Sort-Object -Property FullName -Unique
}

function Get-FirstNonEmptyLine {
    param([string[]]$Lines)
    foreach ($line in $Lines) {
        if ($null -ne $line -and $line.Trim().Length -gt 0) {
            return $line
        }
    }
    return $null
}

$repoRootPath = (Resolve-Path $RepoRoot).Path
Write-Host "Running content compliance checks in: $repoRootPath"

$failed = $false

# Rule: No 00_ prefix anywhere
$bad00 = Get-ChildItem -Path $repoRootPath -Recurse -Force -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -like '00_*' -or $_.FullName -match '[/\\]00_' }
if ($bad00) {
    $failed = $true
    Write-ComplianceError "Found disallowed '00_' prefix in paths (must start at 01_)."
    $bad00 | ForEach-Object { Write-Host "  - $($_.FullName)" }
}

# Rule: Avoid interview language
$textFiles = Get-TrackedTextFiles -Root $repoRootPath
$interviewHits = @()
foreach ($file in $textFiles) {
    $content = Get-Content -LiteralPath $file.FullName -Raw -ErrorAction Stop
    if ($content -match '(?i)\binterview(s)?\b') {
        $interviewHits += $file.FullName
    }
}
if ($interviewHits.Count -gt 0) {
    $failed = $true
    Write-ComplianceError "Found disallowed interview-language occurrences (use senior technical evaluation contexts framing)."
    $interviewHits | Sort-Object -Unique | ForEach-Object { Write-Host "  - $_" }
}

# Rule: All src markdown files start with an H1
$srcPath = Join-Path $repoRootPath 'src'
if (Test-Path -LiteralPath $srcPath) {
    $srcMarkdown = Get-ChildItem -Path $srcPath -Recurse -File -Filter '*.md' -ErrorAction SilentlyContinue
    foreach ($file in $srcMarkdown) {
        $lines = Get-Content -LiteralPath $file.FullName -ErrorAction Stop
        $first = Get-FirstNonEmptyLine -Lines $lines
        if ($null -eq $first -or $first -notmatch '^#\s+\S') {
            $failed = $true
            Write-ComplianceError "File must start with an H1 heading: $($file.FullName)"
        }
    }
}

# Rule: Architecture Decision Records (ADRs) compliance
$adrPath = Join-Path $repoRootPath 'docs\architecture-decisions'
if (Test-Path -LiteralPath $adrPath) {
    $adrFiles = Get-ChildItem -Path $adrPath -File -Filter '*.md' -ErrorAction SilentlyContinue

    foreach ($file in $adrFiles) {
        $lines = Get-Content -LiteralPath $file.FullName -ErrorAction Stop
        $first = Get-FirstNonEmptyLine -Lines $lines
        if ($null -eq $first -or $first -notmatch '^#\s+\S') {
            $failed = $true
            Write-ComplianceError "ADR file must start with an H1 heading: $($file.FullName)"
        }
    }
}

if ($failed) {
    Write-Host "\nContent compliance: FAILED" -ForegroundColor Red
    exit 1
}

Write-Host "\nContent compliance: PASSED" -ForegroundColor Green
exit 0
