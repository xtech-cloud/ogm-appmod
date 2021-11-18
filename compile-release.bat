@echo off
call "D:\ProgramFiles\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
for /d %%d in (*) do (
    if exist "%%d\vs2019" (
        for %%f in (%%d\vs2019\*.sln) do (
            msbuild "%%f" /t:Rebuild /p:Configuration=Release
        )
    )
)
pause


