[CmdletBinding()]
param(
  [string]$RepoRoot,
  [int]$LongLineThreshold = 220,
  [int]$Top = 30
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($RepoRoot)) {
  $scriptDir = if (-not [string]::IsNullOrWhiteSpace($PSScriptRoot)) { $PSScriptRoot } else { Split-Path -Parent $MyInvocation.MyCommand.Path }
  $RepoRoot = (Resolve-Path (Join-Path $scriptDir "..\.." )).Path
}

$excludedDirNames = @('.git', 'node_modules', '.venv', '.idea', '.vscode', 'bin', 'obj', '.vs')

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

Write-Host "Detect Potential Copied Content - Heuristic Scanner" -ForegroundColor Cyan
Write-Host "RepoRoot: $RepoRoot"
Write-Host ""
Write-Host "Note: This is a heuristic scan only. It does NOT prove plagiarism." -ForegroundColor Yellow
Write-Host "It helps find hotspots that MAY contain verbatim pasted text." -ForegroundColor Yellow
Write-Host ""

$mdFiles = @(Get-MarkdownFiles)

# Heuristics only: this does NOT prove plagiarism.
# It helps find hotspots that MAY contain verbatim pasted text.

$blockquoteFindings = New-Object System.Collections.Generic.List[object]
$longLineFindings = New-Object System.Collections.Generic.List[object]
$urlCounts = New-Object System.Collections.Generic.List[object]

$urlRegex = [regex]'https?://'

foreach ($file in $mdFiles) {
  $lines = @(Get-Content -LiteralPath $file.FullName -ErrorAction Stop)

  $blockquoteCount = 0
  $maxLen = 0
  $maxLenLine = 0
  $maxLenText = ''
  $longLineCount = 0

  for ($i = 0; $i -lt $lines.Count; $i++) {
    $line = $lines[$i]

    if ($line -match '^>' ) { $blockquoteCount++ }

    $len = $line.Length
    if ($len -gt $maxLen) {
      $maxLen = $len
      $maxLenLine = $i + 1
      $maxLenText = $line
    }

    if ($len -ge $LongLineThreshold) {
      $longLineCount++
      $preview = if ($len -gt 140) { $line.Substring(0, 140) } else { $line }
      $longLineFindings.Add([pscustomobject]@{
        Path = $file.FullName
        Line = ($i + 1)
        Length = $len
        Preview = $preview
      })
    }
  }

  if ($blockquoteCount -gt 0) {
    $blockquoteFindings.Add([pscustomobject]@{
      Path = $file.FullName
      BlockquoteLines = $blockquoteCount
    })
  }

  $urlCount = 0
  foreach ($m in $urlRegex.Matches(($lines -join "`n"))) { $urlCount++ }
  if ($urlCount -gt 0) {
    $urlCounts.Add([pscustomobject]@{
      Path = $file.FullName
      UrlCount = $urlCount
    })
  }
}

Write-Host "Heuristic scan results (NOT a plagiarism check):" -ForegroundColor Cyan
Write-Host ""

Write-Host "1) Files with blockquotes (often used for quotes/definitions):" -ForegroundColor Yellow
if ($blockquoteFindings.Count -eq 0) {
  Write-Host "- None" -ForegroundColor Green
} else {
  $blockquoteFindings | Sort-Object BlockquoteLines -Descending | Select-Object -First $Top | Format-Table -AutoSize
}
Write-Host ""

Write-Host "2) Long lines (>= $LongLineThreshold chars) — review these for pasted paragraphs/quotes:" -ForegroundColor Yellow
if ($longLineFindings.Count -eq 0) {
  Write-Host "- None" -ForegroundColor Green
} else {
  $longLineFindings |
    Sort-Object Length -Descending |
    Select-Object -First $Top |
    Select-Object Path, Line, Length, Preview |
    Format-List
}
Write-Host ""

Write-Host "3) Files with many external URLs (often indicates well-attributed summaries):" -ForegroundColor Yellow
if ($urlCounts.Count -eq 0) {
  Write-Host "- None" -ForegroundColor Green
} else {
  $urlCounts | Sort-Object UrlCount -Descending | Select-Object -First $Top | Format-Table -AutoSize
}

Write-Host ""
Write-Host "Next steps if you find a hotspot:" -ForegroundColor Cyan
Write-Host "- Review the content to ensure it's original or properly attributed."
Write-Host "- If keeping a short quote, add a 'Source:' link immediately below it."
Write-Host "- Avoid large verbatim blocks from docs/blogs unless licensing clearly allows it."
Write-Host "- For code examples, ensure they're original or properly attributed."

