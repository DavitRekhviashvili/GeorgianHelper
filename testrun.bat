dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit*]\*" /p:CoverletOutput="./"
reportgenerator "-reports:GeorgianHelper.Tests/coverage.cobertura.xml" "-targetdir:HtmlTestReport" -reporttypes:Html
HtmlTestReport\index.html