@echo off
set input=
set /p input=intput dir:
cd %input%
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

pause