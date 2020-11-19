This is a simple ASP.NET Core MVC form that saves data in DB as well as sends out a confirmation email if option is checked.


 to update entities:
 
 EntityFrameworkCore\Scaffold-DbContext "Server=localhost\MSSQLSERVER01;Database=RegistrationDemo;user id=UFRegistrationDemo;password=regDemo1234$;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models\Database

 EntityFrameworkCore\Add-Migration -Name "KeysAdded" -OutputDir "Migrations" -Context "RegistrationDemoContext"

