@echo off
@echo Create Directories
mkdir ..\Latest\
mkdir ..\Latest\Binaries_1.6
mkdir ..\Latest\Binaries_1.6\Data
mkdir ..\Latest\Binaries_1.6\Deploy

::updateInstaller
mkdir ..\Source\Administration\bin\Release\Data

::updateLog
mkdir ..\Latest\Binaries_1.6\updateLog
mkdir ..\Source\Administration\bin\Release\updateLog

@echo Complile Solution
if defined ProgramFiles(x86) (
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com" /Rebuild Release ..\Source\UpdateSystem.Net.sln
) else (
"C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com" /Rebuild Release ..\Source\UpdateSystem.Net.sln
)

@echo Copy Libs
xcopy "..\Libs" "..\Latest\Binaries_1.6" /E /Y

@echo Copy additional Resources
xcopy "..\Setupressources" "..\Latest\Binaries_1.6" /E /Y

copy /Y ..\Source\updateInstaller\bin\Release\Updater.exe ..\Latest\Binaries_1.6\Data\updateInstaller.exe
copy /Y ..\Latest\Binaries_1.6\Data\updateInstaller.exe ..\Source\Administration\bin\Release\Data\updateInstaller.exe
copy /Y ..\Source\Administration\bin\Release\updateSystemDotNet.Administration.exe ..\Latest\Binaries_1.6\updateSystemDotNet.Administration.exe
copy /Y ..\Source\Administration\bin\Release\updateSystemDotNet.Administration.pdb ..\Latest\Binaries_1.6\updateSystemDotNet.Administration.pdb
copy /Y ..\Source\updateController\bin\Release\updateSystemDotNet.Controller.dll ..\Latest\Binaries_1.6\updateSystemDotNet.Controller.dll
copy /Y ..\Source\updateController\bin\Release\updateSystemDotNet.Controller.pdb ..\Latest\Binaries_1.6\updateSystemDotNet.Controller.pdb
copy /Y ..\Source\updateController\bin\Release\updateSystemDotNet.Controller.dll ..\Latest\Binaries_1.6\Deploy\updateSystemDotNet.Controller.dll
copy /Y ..\Source\updateController\bin\Release\updateSystemDotNet.Controller.xml ..\Latest\Binaries_1.6\Deploy\updateSystemDotNet.Controller.xml
copy /Y ..\Source\updateController\bin\Release\updateSystemDotNet.Controller.pdb ..\Latest\Binaries_1.6\Deploy\updateSystemDotNet.Controller.pdb


::Copy updateLog
xcopy "..\Source\updateLog" "..\Latest\Binaries_1.6\updateLog" /E /Y
xcopy "..\Source\updateLog" "..\Source\Administration\bin\Release\updateLog" /E /Y

@echo Sign Files
signtool.exe sign /a /d "updateSystem.NET updateInstaller" /du "http://updatesystem.net" /t "http://timestamp.comodoca.com/authenticode" "..\Latest\Binaries_1.6\Data\updateInstaller.exe"
signtool.exe sign /a /d "updateSystem.NET Administration" /du "http://updatesystem.net" /t "http://timestamp.comodoca.com/authenticode" ..\Latest\Binaries_1.6\updateSystemDotNet.Administration.exe
signtool.exe sign /a /d "updateSystem.NET UpdateController" /du "http://updatesystem.net" /t "http://timestamp.comodoca.com/authenticode" ..\Latest\Binaries_1.6\updateSystemDotNet.Controller.dll
signtool.exe sign /a /d "updateSystem.NET UpdateController" /du "http://updatesystem.net" /t "http://timestamp.comodoca.com/authenticode" ..\Latest\Binaries_1.6\Deploy\updateSystemDotNet.Controller.dll

@echo Create Setup
..\Source\Tools\setupDataBuilder\bin\Release\setupDataBuilder.exe "..\Latest\Binaries_1.6" ..\Source\Setup\setup.package
if defined ProgramFiles(x86) (
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com" /Rebuild Release ..\Source\UpdateSystem.Net.sln
) else (
"C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com" /Rebuild Release ..\Source\UpdateSystem.Net.sln
)

signtool sign /a /d "updateSystem.NET Setup" /du "http://updatesystem.net" /t "http://timestamp.comodoca.com/authenticode" "..\Source\Setup\bin\Release\updateSystemDotNet.Setup.exe"
copy /Y "..\Source\Setup\bin\Release\updateSystemDotNet.Setup.exe" "..\Latest\updateSystem.NET.Setup.exe"


@echo Cleanup Solution
if defined ProgramFiles(x86) (
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com"  /Clean Release ..\Source\UpdateSystem.Net.sln
) else (
"C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.com"  /Clean Release ..\Source\UpdateSystem.Net.sln
)