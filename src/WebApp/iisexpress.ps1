Write-Host $PSScriptRoot 

$env:LAUNCHER_ARGS = "-p ""C:\Program Files\dotnet\dotnet.exe"" -a ""exec \""$PSScriptRoot\bin\Release\netcoreapp2.0\DevOpsEnvMgmt.dll\"""" -pidFile $([System.IO.Path]::GetTempFileName()) -wd ""$PSScriptRoot"" -pr WebApp -env ASPNETCORE_CONTENTROOT=C:\Dev\Git\devops-envmgmt-webapp\src\WebApp ASPNETCORE_ENVIRONMENT=Development"
$env:LAUNCHER_PATH = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\Microsoft\Web Tools\ProjectSystem\VSIISExeLauncher.exe"
& "C:\Program Files\IIS Express\IISExpress.exe" /config:"C:\Dev\Git\devops-envmgmt-webapp\.vs\config\applicationhost.config" /site:"WebApp" /apppool:"Clr4IntegratedAppPool"
#  /config:"<path to applicationhost.config>"
