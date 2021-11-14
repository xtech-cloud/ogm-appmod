call "D:\ProgramFiles\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
msbuild .\actor\vs2019\ogm-actor.sln /t:Rebuild /p:Configuration=Release
msbuild .\file\vs2019\ogm-file.sln /t:Rebuild /p:Configuration=Release


