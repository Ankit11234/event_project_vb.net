Imports System.Data.SqlClient
Imports System.Web.Optimization
Imports Microsoft.Extensions.DependencyInjection
Imports MySqlConnector
Imports Microsoft.EntityFrameworkCore
Imports WebApplication1.WebApplication1.Models

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ' Register DbContext with Dependency Injection
        RegisterDbContext()
    End Sub

    Private Sub RegisterDbContext()
        Dim connectionString As String = "Server=localhost;Database=event_project;User=root;Password=Ankit@#123"

        Dim services As New ServiceCollection()

        ' Register DbContext with MySqlConnection
        services.AddDbContext(Of ApplicationDbContext)

        ' services.AddDbContext(Of ApplicationDbContext)(Sub(options) options.UseMySql(connectionString))

        ' Build the service provider
        Dim serviceProvider As IServiceProvider = services.BuildServiceProvider()

        ' Resolve ApplicationDbContext to ensure it's correctly configured
        Using scope = serviceProvider.CreateScope()
            Dim dbContext = scope.ServiceProvider.GetRequiredService(Of ApplicationDbContext)()

            ' Ensure the database is created/updated
            '  dbContext.Database.Migrate()
        End Using
    End Sub
End Class
