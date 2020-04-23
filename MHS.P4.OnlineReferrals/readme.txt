 to update entities:
 
 EntityFrameworkCore\Scaffold-DbContext "Server=pcs-db01;Database=P4OnlineReferrals;user id=P4OnlineReferrals;password=forReferrals2020;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models\Database

 EntityFrameworkCore\Add-Migration -Name "TestTypeAdded" -OutputDir "Migrations" -Context "P4OnlineReferralsContext"

