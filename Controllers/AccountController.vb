Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Authentication
Imports Microsoft.AspNetCore.Authentication.Cookies
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.VisualBasic.ApplicationServices
Imports WebApplication1.WebApplication1.Models
Imports User = WebApplication1.WebApplication1.Models.User

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Private ReadOnly _context As ApplicationDbContext

        Public Sub New(context As ApplicationDbContext)
            _context = context
        End Sub

        Public Sub New()
            ' No initialization needed
        End Sub
        ' GET: Account/Register
        <HttpGet>
        Public Function Register() As ActionResult
            Return View()
        End Function

        <HttpGet>
        Public Function Admin() As ActionResult
            Console.WriteLine(_context)
            Console.WriteLine(_context.Users)


            Dim userss = _context.Users.ToList()

            Return View()
        End Function

        ' POST: Account/Register
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Async Function Register(user As User) As Task(Of ActionResult)
            If ModelState.IsValid Then
                user.AdminOverride = If(user.Role = "Teacher", True, False)
                _context.Users.Add(user)
                Await _context.SaveChangesAsync()
                Return RedirectToAction("Login")
            End If
            Return View(user)
        End Function

        ' GET: Account/Login
        <HttpGet>
        Public Function Login() As ActionResult
            Return View()
        End Function

        ' POST: Account/Login
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Async Function Login(us As User) As Task(Of ActionResult)
            Dim user = Await _context.Users.FirstOrDefaultAsync(Function(u) u.Username = us.Username AndAlso u.Password = us.Password)
            If user IsNot Nothing Then
                Dim claims = New List(Of Claim) From {
                    New Claim(ClaimTypes.Name, user.Username),
                    New Claim(ClaimTypes.Role, user.Role.ToString())
                }
                Dim claimsIdentity = New ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
                Dim authProperties = New AuthenticationProperties With {
                    .IsPersistent = True ' Persist the cookie
                }
                'Dim value = Await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, New ClaimsPrincipal(claimsIdentity), authProperties)
                Return RedirectToAction("FullCalendar1", "Events")
            End If
            ModelState.AddModelError(String.Empty, "Invalid username or password")
            Return View()
        End Function

        ' POST: Account/Logout
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Async Function Logout() As Task(Of ActionResult)
            ' Await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
            Return RedirectToAction("Login")
        End Function

        ' Other action methods can be added here

    End Class
End Namespace
