[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")),

    [Parameter()]
    [switch]$IncludeSourceMaterial
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-ValidationError {
    param([string]$Message)
    Write-Host "ERROR: $Message" -ForegroundColor Red
}

function Write-ValidationWarning {
    param([string]$Message)
    Write-Host "WARNING: $Message" -ForegroundColor Yellow
}

function Get-TrackedMarkdownFiles {
    param([string]$Root)

    $paths = Get-ChildItem -Path $Root -Recurse -File -Filter "*.md" -Force -ErrorAction SilentlyContinue |
        Where-Object {
            $_.FullName -notmatch '\\.git\\' -and
            $_.FullName -notmatch '\\node_modules\\' -and
            $_.FullName -notmatch '\\docs\\review-reports\\' -and
            ($IncludeSourceMaterial -or $_.FullName -notmatch '\\source-material\\')
        } |
        Sort-Object -Property FullName -Unique

    return $paths
}

function Get-YamlFrontmatter {
    param([string[]]$Lines)

    $inFrontmatter = $false
    $frontmatterLines = @()
    $lineIndex = 0

    foreach ($line in $Lines) {
        if ($lineIndex -eq 0 -and $line -match '^---\s*$') {
            $inFrontmatter = $true
            $lineIndex++
            continue
        }

        if ($inFrontmatter) {
            if ($line -match '^---\s*$') {
                break
            }
            $frontmatterLines += $line
        }

        $lineIndex++
    }

    return $frontmatterLines -join "`n"
}

function Parse-YamlReferences {
    param([string]$YamlContent, [string]$FilePath)

    $references = @()

    # Check for prerequisites, builds_upon, enables, related_topics
    $referenceKeys = @('prerequisites', 'builds_upon', 'enables', 'related_topics')

    foreach ($key in $referenceKeys) {
        $pattern = "$key\s*:\s*(.+?)(?:\s*$|\s*#)"
        if ($YamlContent -match $pattern) {
            $value = $matches[1].Trim()
            # Handle array format: - file.md or [file1.md, file2.md]
            if ($value -match '^\[(.+)\]$') {
                $items = $matches[1] -split ',' | ForEach-Object { $_.Trim().Trim("'`"") }
                foreach ($item in $items) {
                    if (-not [string]::IsNullOrWhiteSpace($item)) {
                        $references += [PSCustomObject]@{
                            Type = 'yaml'
                            Key = $key
                            Target = $item
                            File = $FilePath
                        }
                    }
                }
            } elseif ($value -match '^-\s*(.+)$') {
                $item = $matches[1].Trim().Trim("'`"")
                if (-not [string]::IsNullOrWhiteSpace($item)) {
                    $references += [PSCustomObject]@{
                        Type = 'yaml'
                        Key = $key
                        Target = $item
                        File = $FilePath
                    }
                }
            } else {
                $item = $value.Trim().Trim("'`"")
                if (-not [string]::IsNullOrWhiteSpace($item)) {
                    $references += [PSCustomObject]@{
                        Type = 'yaml'
                        Key = $key
                        Target = $item
                        File = $FilePath
                    }
                }
            }
        }
    }

    return $references
}

function Parse-MarkdownLinks {
    param([string[]]$Lines, [string]$FilePath)

    $references = @()
    $linkRegex = [regex]'\[([^\]]+)\]\(([^\)]+)\)'

    for ($i = 0; $i -lt $Lines.Count; $i++) {
        $line = $Lines[$i]
        foreach ($match in $linkRegex.Matches($line)) {
            $target = $match.Groups[2].Value.Trim()
            if ([string]::IsNullOrWhiteSpace($target)) { continue }
            if ($target.StartsWith('#')) { continue } # Anchor link
            if ($target -match '^(https?://|mailto:|tel:)') { continue } # External link
            if ($target -match '^<.*>$') { continue } # Auto-link

            $targetNoAnchor = $target.Split('#')[0]
            $targetNoQuery = $targetNoAnchor.Split('?')[0]
            if ([string]::IsNullOrWhiteSpace($targetNoQuery)) { continue }

            # Skip image files
            if ($targetNoQuery -match '\.(png|jpg|jpeg|gif|svg|webp)$') { continue }

            $references += [PSCustomObject]@{
                Type = 'markdown'
                Key = 'link'
                Target = $targetNoQuery
                File = $FilePath
                Line = $i + 1
            }
        }
    }

    return $references
}

function Resolve-FileReference {
    param(
        [string]$ReferencePath,
        [string]$SourceFile
    )

    $sourceDir = Split-Path -Path $SourceFile -Parent
    $resolved = Join-Path -Path $sourceDir -ChildPath $ReferencePath
    $resolved = [System.IO.Path]::GetFullPath($resolved)

    return $resolved
}

$repoRootPath = (Resolve-Path $RepoRoot).Path
Write-Host "Validating file references in: $repoRootPath" -ForegroundColor Cyan
Write-Host ""

$mdFiles = Get-TrackedMarkdownFiles -Root $repoRootPath
Write-Host "Found $($mdFiles.Count) markdown files to check" -ForegroundColor Cyan
Write-Host ""

$allReferences = @()
$errors = @()
$warnings = @()

foreach ($file in $mdFiles) {
    try {
        $content = Get-Content -LiteralPath $file.FullName -Raw -ErrorAction Stop
        $lines = Get-Content -LiteralPath $file.FullName -ErrorAction Stop

        # Parse YAML frontmatter
        $yamlContent = Get-YamlFrontmatter -Lines $lines
        if ($yamlContent) {
            $yamlRefs = Parse-YamlReferences -YamlContent $yamlContent -FilePath $file.FullName
            $allReferences += $yamlRefs
        }

        # Parse markdown links
        $mdRefs = Parse-MarkdownLinks -Lines $lines -FilePath $file.FullName
        $allReferences += $mdRefs
    }
    catch {
        Write-ValidationWarning "Failed to read file: $($file.FullName) - $($_.Exception.Message)"
    }
}

Write-Host "Checking $($allReferences.Count) file references..." -ForegroundColor Cyan
Write-Host ""

foreach ($ref in $allReferences) {
    $resolved = Resolve-FileReference -ReferencePath $ref.Target -SourceFile $ref.File

    if (-not (Test-Path -LiteralPath $resolved)) {
        $relativePath = $ref.File.Replace($repoRootPath, '').TrimStart('\')
        $lineInfo = if ($ref.Line) { " (line $($ref.Line))" } else { "" }
        $errors += "  - $relativePath$lineInfo : References '$($ref.Target)' (resolved: $resolved)"
    }
}

# Summary
Write-Host "=" * 60 -ForegroundColor Cyan
if ($errors.Count -eq 0) {
    Write-Host "SUCCESS: All file references are valid" -ForegroundColor Green
    Write-Host ""
    exit 0
} else {
    Write-Host "FAILED: Found $($errors.Count) broken file reference(s)" -ForegroundColor Red
    Write-Host ""
    foreach ($error in $errors) {
        Write-ValidationError $error
    }
    Write-Host ""
    exit 1
}

