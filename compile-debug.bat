call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
msbuild .\assloud\vs2019\meex-assloud.sln /t:Rebuild /p:Configuration=Debug
msbuild .\theloud\vs2019\meex-theloud.sln /t:Rebuild /p:Configuration=Debug
msbuild .\catalog\vs2019\meex-catalog.sln /t:Rebuild /p:Configuration=Debug
msbuild .\meetouch\vs2019\meex-meetouch.sln /t:Rebuild /p:Configuration=Debug
msbuild .\digitalwall\vs2019\meex-digitalwall.sln /t:Rebuild /p:Configuration=Debug

