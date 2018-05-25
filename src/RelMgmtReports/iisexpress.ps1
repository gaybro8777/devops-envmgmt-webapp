Write-Host $PSScriptRoot 

$env:APP_POOL_CONFIG = "C:\Dev\Git\devops-envmgmt-webapp\.vs\config\applicationhost.config"
$env:APP_POOL_ID = "Clr4IntegratedAppPool"
$env:DEV_ENVIRONMENT = "1"
$env:IIS_DRIVE = "C:\Program Files (x86)\IIS Express"
$env:IIS_DRIVE = "C:"
$env:IIS_SITES_HOME = "C:\Users\richard.nunez\Documents\My Web Sites"
$env:IIS_USER_HOME = "C:\Users\richard.nunez\Documents\IISExpress"
$env:IISEXPRESS_SITENAME = "WebApp"

$env:LAUNCHER_ARGS = "-p ""C:\Program Files\dotnet\dotnet.exe"" -a ""exec \""$PSScriptRoot\bin\Release\netcoreapp2.0\DevOpsEnvMgmt.dll\"""" -pidFile $([System.IO.Path]::GetTempFileName()) -wd ""$PSScriptRoot"" -pr WebApp -env ASPNETCORE_CONTENTROOT=C:\Dev\Git\devops-envmgmt-webapp\src\WebApp ASPNETCORE_ENVIRONMENT=Development"
#$env:LAUNCHER_ARGS = "-argFile IISExeLauncherArgs.txt"

$env:LAUNCHER_PATH = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\Microsoft\Web Tools\ProjectSystem\VSIISExeLauncher.exe"
#$env:LAUNCHER_PATH = "bin\IISSupport\VSIISExeLauncher.exe"

& "C:\Program Files\IIS Express\IISExpress.exe" /config:"C:\Dev\Git\devops-envmgmt-webapp\.vs\config\applicationhost.config" /site:"WebApp" /apppool:"Clr4IntegratedAppPool"
#  /config:"<path to applicationhost.config>"
