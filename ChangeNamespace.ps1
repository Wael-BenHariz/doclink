# ChangeNamespace.ps1
param (
    [string]$oldNamespace,
    [string]$newNamespace,
    [string]$path = "."
)

# Get all C# source files
$files = Get-ChildItem -Path $path -Recurse -Include *.cs,*.cshtml,*.razor

foreach ($file in $files) {
    (Get-Content $file.FullName) |
        ForEach-Object { $_ -replace $oldNamespace, $newNamespace } |
        Set-Content $file.FullName
}

# Optional: Update .csproj files with new <RootNamespace>
$csprojFiles = Get-ChildItem -Path $path -Recurse -Include *.csproj

foreach ($proj in $csprojFiles) {
    (Get-Content $proj.FullName) |
        ForEach-Object {
            if ($_ -match "<RootNamespace>(.*)</RootNamespace>") {
                $_ -replace "<RootNamespace>.*</RootNamespace>", "<RootNamespace>$newNamespace</RootNamespace>"
            } else {
                $_
            }
        } | Set-Content $proj.FullName
}

Write-Host "Namespace changed from '$oldNamespace' to '$newNamespace' in all files."
