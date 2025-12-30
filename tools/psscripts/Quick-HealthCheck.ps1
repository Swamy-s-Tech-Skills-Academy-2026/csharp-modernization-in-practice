[CmdletBinding()]
param(
  [string]$RepoRoot
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
  $scriptDir = if (-not [string]::IsNullOrWhiteSpace($PSScriptRoot)) { $PSScriptRoot } else { Split-Path -Parent $MyInvocation.MyCommand.Path }
  $RepoRoot = (Resolve-Path (Join-Path $scriptDir "..\\.." )).Path
}

$excludedDirNames = @('.git', 'node_modules', '.venv', '.idea', '.vscode')

function Test-IsExcludedPath {
  param([string]$FullName)
  foreach ($dir in $excludedDirNames) {
    if ($FullName -match ([regex]::Escape("\\$dir\\"))) { return $true }
  }
  return $false
}

function Get-MarkdownFiles {
  Get-ChildItem -Path $RepoRoot -Recurse -File -Filter '*.md' | Where-Object { -not (Test-IsExcludedPath $_.FullName) }
}

Write-Host "RepoRoot: $RepoRoot" 

# 1) Forbidden file naming: 00_ prefix
$bad00 = @(Get-ChildItem -Path $RepoRoot -Recurse -File -Filter '*00_*' | Where-Object { -not (Test-IsExcludedPath $_.FullName) })
Write-Host "" 
Write-Host "Check: Forbidden '*00_*' files" 
if ($bad00.Count -eq 0) {
  Write-Host "- OK: none found" 
} else {
  Write-Host "- FAIL: found $($bad00.Count) file(s):" 
  $bad00 | ForEach-Object { Write-Host "  - $($_.FullName)" }
}

# 2) Relative markdown links to missing files (best-effort)
$mdFiles = @(Get-MarkdownFiles)
$missingLinks = New-Object System.Collections.Generic.List[object]
$linkRegex = [regex]'\[[^\]]+\]\(([^\)]+)\)'

foreach ($file in $mdFiles) {
  $content = Get-Content -LiteralPath $file.FullName -ErrorAction Stop
  for ($i = 0; $i -lt $content.Count; $i++) {
    $line = $content[$i]
    foreach ($m in $linkRegex.Matches($line)) {
      $target = $m.Groups[1].Value.Trim()
      if ([string]::IsNullOrWhiteSpace($target)) { continue }
      if ($target.StartsWith('#')) { continue }
      if ($target -match '^(https?://|mailto:|tel:)' ) { continue }
      if ($target -match '^<.*>$') { continue }

      $targetNoAnchor = $target.Split('#')[0]
      $targetNoQuery = $targetNoAnchor.Split('?')[0]
      if ([string]::IsNullOrWhiteSpace($targetNoQuery)) { continue }

      # ignore images, keep simple
      if ($targetNoQuery -match '\.(png|jpg|jpeg|gif|svg)$') { continue }

      $resolved = Join-Path -Path $file.Directory.FullName -ChildPath $targetNoQuery
      if (-not (Test-Path -LiteralPath $resolved)) {
        $missingLinks.Add([pscustomobject]@{
          File = $file.FullName
          Line = ($i + 1)
          Target = $target
          Resolved = $resolved
        })
      }
    }
  }
}

Write-Host "" 
Write-Host "Check: Markdown links to missing files (best-effort)" 
if ($missingLinks.Count -eq 0) {
  Write-Host "- OK: no missing relative links detected" 
} else {
  Write-Host "- WARN: found $($missingLinks.Count) potentially missing link(s)" 
  $missingLinks | Select-Object -First 25 | ForEach-Object {
    Write-Host ("  - {0} (L{1}): {2}" -f $_.File, $_.Line, $_.Target)
  }
  if ($missingLinks.Count -gt 25) {
    Write-Host "  - ... (truncated)" 
  }
}

# 3) Duplicate headings across markdown (high-signal only)
$headingRegex = [regex]'^(#{1,6})\s+(.+?)\s*$'
$headingMap = @{}

foreach ($file in $mdFiles) {
  $content = Get-Content -LiteralPath $file.FullName -ErrorAction Stop
  for ($i = 0; $i -lt $content.Count; $i++) {
    $line = $content[$i]
    $hm = $headingRegex.Match($line)
    if (-not $hm.Success) { continue }

    $text = $hm.Groups[2].Value.Trim()
    if ([string]::IsNullOrWhiteSpace($text)) { continue }

    $key = $text.ToLowerInvariant()
    if (-not $headingMap.ContainsKey($key)) {
      $headingMap[$key] = New-Object System.Collections.Generic.List[object]
    }

    $headingMap[$key].Add([pscustomobject]@{ File=$file.FullName; Line=($i+1); Heading=$text })
  }
}

$dupes = @($headingMap.GetEnumerator() | Where-Object { $_.Value.Count -gt 3 } | Sort-Object { $_.Value.Count } -Descending)

Write-Host "" 
Write-Host "Check: Heavily duplicated headings (appears in >3 files)" 
if ($dupes.Count -eq 0) {
  Write-Host "- OK: none found" 
} else {
  Write-Host "- INFO: found $($dupes.Count) repeated heading(s)" 
  $dupes | Select-Object -First 10 | ForEach-Object {
    Write-Host ("  - '{0}' appears {1} times" -f $_.Value[0].Heading, $_.Value.Count)
  }
  if ($dupes.Count -gt 10) { Write-Host "  - ... (truncated)" }
}

Write-Host "" 
Write-Host "Quick-HealthCheck complete." 
