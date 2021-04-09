@echo off
cd account
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

cd analytics
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

cd approval
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

cd file
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

cd group
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

cd license
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

cd tag
IF EXIST vs2019 DEL /Q/S vs2019
python ..\generator.py
cd ..

pause