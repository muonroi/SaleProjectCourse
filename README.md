# Setting up repository

1. **Add setting to WebSale:** 
   - Add `<GenerateRuntimeConfigurationFiles>True</GenerateRuntimeConfigurationFiles>` inside PropertyGroup in the WebSale project file.

2. **Set startup WebSale:**
   - Configure WebSaleapi as the startup project in your development environment.

3. **Set default project:**
   - Set "WebSaleAPI" as the default project in your development environment.

4. **Run command to add migrations:**
   - Execute the command `dotnet ef migrations add initDb -p .\WebSaleRepository --startup-project .\WebSaleAPI --output-dir Persistance/Migrations`.

5. **Run command to update the database:**
   - Execute the command `dotnet ef database update --project .\WebSaleAPI`.
