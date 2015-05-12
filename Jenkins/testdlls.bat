SetLocal EnableDelayedExpansion
echo ----- DIR
dir /s *Tests.dll /b | find "release" /i
dir /s *Tests.dll /b | find "release" /i > temp.txt
echo ----- LIST
set L=1
for /F "delims=" %%a in (temp.txt) do (
  set list=!list! %%a
  set  /a  L=!L!+1
)
echo %list%
echo ----- 
