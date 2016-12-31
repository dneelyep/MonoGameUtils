function AssemblyInfoFileName
{
    $CurrentDir = (Get-Item -Path ".\" -Verbose).FullName
    $AssemblyInfoFile = $CurrentDir + "\MonoGameUtils\Properties\AssemblyInfo.cs"
    return $AssemblyInfoFile
}

function AssemblyVersionLine
{
    foreach($line in $AssemblyContent)
    {
        if($line.StartsWith("[assembly: AssemblyVersion("))
        {
            return $line
        }
    }
}

$AssemblyContent = Get-Content (AssemblyInfoFileName)
$AssemblyVersionLine = AssemblyVersionLine

$VersionPrefixLength = "[assembly: AssemblyVersion(""".Length
$VersionSuffixLength = """)]".Length

$AssemblyVersionWithoutPrefix = $AssemblyVersionLine.Substring($VersionPrefixLength)
$AssemblyVersion = $AssemblyVersionWithoutPrefix.Substring(0, $AssemblyVersionWithoutPrefix.Length - $VersionSuffixLength)

$FormattedAssemblyVersion = "v" + $AssemblyVersion

git tag $FormattedAssemblyVersion