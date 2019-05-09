$msbuild = Resolve-Path "C:\*\Microsoft Visual Studio\*\*\MSBuild\*\bin\MSBuild.exe"

echo "----------------------------------------------------------------------------"
echo "Criando diretorio de log..."
$logdir = New-Item -Path .\.logs -ItemType Directory -Force -ErrorAction Ignore

echo "Criando diretorio do NuGet"
$nugetDir = New-Item -Path .\.nuget -ItemType Directory -Force -ErrorAction Ignore
$nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$nugetPath = "$($nugetDir)\nuget.exe"

if (-not (Test-Path $nugetPath)) { Start-BitsTransfer -Source $nugetUrl -Destination $nugetPath }

Set-Alias msb $msbuild
Set-Alias nuget $nugetPath

echo "Restaurando pacotes..."
nuget restore ".\TesteMutacao.sln" >> "$($logdir)\packages_restore.log"

echo "Compilando aplicação..."
& msb ".\TesteMutacao.sln" /t:Build >> "$($logdir)\build.log"

echo "----------------------------------------------------------------------------"
echo "Executando testes unitários..."
dotnet vstest TesteMutacao.Tests\bin\Debug\TesteMutacao.Tests.dll

echo "----------------------------------------------------------------------------"
echo "Mutar assembly..."
& TesteMutacao\bin\Debug\TesteMutacao.exe (Resolve-Path "TesteMutacao.Tests\bin\Debug\TesteMutacao.Exemplo.dll")

echo "----------------------------------------------------------------------------"
echo "Executando testes de mutaçao..."
dotnet vstest TesteMutacao.Tests\bin\Debug\TesteMutacao.Tests.dll

