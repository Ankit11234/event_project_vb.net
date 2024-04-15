Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.VisualBasic.ApplicationServices

Namespace WebApplication1.Models
    Public Class ApplicationDbContext
        Inherits DbContext
        Private _configuration As IConfiguration
        Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

        Public Sub New(configuration As IConfiguration)
            MyBase.New()
            _configuration = configuration
        End Sub

        Public Property Users As DbSet(Of User)
        Public Property Events As DbSet(Of [Event])
        Public Property Rooms As DbSet(Of Room)




        Public Sub New(ByVal options As DbContextOptions(Of ApplicationDbContext))
            MyBase.New(options)

        End Sub


    End Class
End Namespace
