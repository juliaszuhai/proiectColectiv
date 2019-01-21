# proiectColectiv
.NET Webapp

Step 1:
Get latest release from github at the link bellow:
https://github.com/stefandelibas/proiectColectiv 
Step 2:
Make sure the correct versions are installed for each of the used products:
    • Visual Studio 2017 15.7x+
        ◦ You can find the release notes here: https://docs.microsoft.com/en-us/visualstudio/releasenotes/vs2017-relnotes-v15.7
        ◦ To download the latest stable version, visit the link: https://visualstudio.microsoft.com/downloads/
    • Entity Framework Core 2.1
        ◦ You can find the release notes here: https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-2.1  
        ◦ To download the 2.1 version, follow the steps from: https://docs.microsoft.com/en-us/ef/core/get-started/install/ and specify -Version 2.1.0
    • Angular version 6
        ◦ How to install and release notes can be found here: https://angular.io/docs 
    • MySQL Community or SQLServer latest versions:
        ◦ MySQL 
            ▪ You can find the full documentation here: https://dev.mysql.com/doc/ 
            ▪ To download the latest stable version, visit the link: https://dev.mysql.com/downloads/ 
        ◦ SQLServer
            ▪ You can find the full documentation here: https://docs.microsoft.com/en-us/sql/sql-server/sql-server-technical-documentation?view=sql-server-2017
            ▪ To download the latest stable version, visit the link: https://www.microsoft.com/en-us/sql-server/sql-server-downloads 


Step 3:
Other checks to make sure it’s working properly:
    • If you download SQL Server, in the project proiectColectiv\AcademicInfoServer\AcademicInfoServer\appsettings.json need to change ConnectionString for DatabaseContext to "Server=.\\SQLEXPRESS;Database=DatabaseContext;Trusted_Connection=True;MultipleActiveResultSets=true"
    • Check the json to be the same as the one given bellow in proiectColectiv\AcademicInfoServer\AcademicInfoServer\Properties\launchSettings.json. 
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:34887",
      "sslPort": 44354
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "AcademicInfoServer": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "api/Students",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "applicationUrl": "http://localhost:53087/"
    }
  }
}

    • Create the database by running the following command in Package Manager Console:
PM> Update-Database




How to populate your db with some data:
Run the sql script: https://github.com/stefandelibas/proiectColectiv/blob/master/AcademicInfoServerEF22/PopulateDB.sql on the database AcademicInfoContext
!Pay attention at the instructions there!
In StudentController constructor decomment the function //updateAllPasswords(); ,run the server once, call https://localhost:44354/api/Students in your browser and wait for a while to update all password encryption.
Then close the server and comment back that function //updateAllPasswords().
This whole process will fill your database with some data, where all users have pass as password
