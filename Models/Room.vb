Imports System.ComponentModel.DataAnnotations

Namespace WebApplication1.Models
    Public Class Room
        <Key>
        Public Property room_id As Integer
        <Required>
        <StringLength(50)>
        Public Property room_name As String
        Public Property user_id As Integer
    End Class
End Namespace
