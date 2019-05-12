$msbuild = Resolve-Path "C:\*\Microsoft Visual Studio\*\*\MSBuild\*\bin\MSBuild.exe"

Write-Host "----------------------------------------------------------------------------"
Write-Host "Criando diretorio de log..." -ForegroundColor Green
$logdir = New-Item -Path .\.logs -ItemType Directory -Force -ErrorAction Ignore

Write-Host "Criando diretorio do NuGet" -ForegroundColor Green
$nugetDir = New-Item -Path .\.nuget -ItemType Directory -Force -ErrorAction Ignore
$nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$nugetPath = "$($nugetDir)\nuget.exe"

if (-not (Test-Path $nugetPath)) { Start-BitsTransfer -Source $nugetUrl -Destination $nugetPath }

Set-Alias msb $msbuild
Set-Alias nuget $nugetPath

Write-Host "Restaurando pacotes..." -ForegroundColor Green
nuget restore ".\TesteMutacao.sln" >> "$($logdir)\packages_restore.log"

Write-Host "Compilando aplicação..." -ForegroundColor Green
& msb ".\TesteMutacao.sln" /t:Build >> "$($logdir)\build.log"

Write-Host "----------------------------------------------------------------------------"
Write-Host "Executando testes unitários..." -ForegroundColor Green
dotnet vstest TesteMutacao.Tests\bin\Debug\TesteMutacao.Tests.dll

Write-Host "(Pressione qualquer tecla para continuar)" -ForegroundColor Yellow
$x = $host.ui.RawUI.ReadKey("NoEcho,IncludeKeyDown")
		
Write-Host "----------------------------------------------------------------------------"
Write-Host "Mutar assembly..." -ForegroundColor Green
& TesteMutacao\bin\Debug\TesteMutacao.exe (Resolve-Path "TesteMutacao.Tests\bin\Debug\TesteMutacao.Exemplo.dll")

Write-Host "----------------------------------------------------------------------------"
Write-Host "Executando testes de mutaçao..." -ForegroundColor Green
dotnet vstest TesteMutacao.Tests\bin\Debug\TesteMutacao.Tests.dll

