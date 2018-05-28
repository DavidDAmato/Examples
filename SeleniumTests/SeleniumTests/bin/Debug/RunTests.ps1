# runs the console runner from the debug folder, all you need is the relative path to the runner and test .dll
$runnerPath = "..\..\..\lib\NUnit.3.10.1\bin\net45\nunitlite-runner.exe"
if(-not(Test-Path $runnerPath)) {
	Write-Console "Runner path not found, do you need to cd to the build debug folder?"
}

Start-Process -FilePath "$runnerPath" -ArgumentList "SeleniumTests.dll"