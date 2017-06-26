$msbuild = 'C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe'
$mstest = 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe'

$projectFileAbsPath = $PSScriptRoot+"\..\..\Grosvenor.Restaurant.sln"

& $msbuild $projectFileAbsPath

if ($LastExitCode -eq 0)
{
    write-host "build success" -foregroundcolor Green
}
else
{
    write-host "Error on build application" -foregroundcolor Red
    Return
}


$testsFile = $PSScriptRoot+"\..\..\Grosvenor.Restaurant.DomainTests\bin\Debug\Grosvenor.Restaurant.DomainTests.dll"

& $mstest /testcontainer:$testsFile 

if ($LastExitCode -eq 0)
{
    write-host "test success" -foregroundcolor Green
}
else
{
    write-host "Error on test application" -foregroundcolor Red
    Return
}