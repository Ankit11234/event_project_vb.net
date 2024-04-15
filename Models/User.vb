Imports System.ComponentModel.DataAnnotations

Namespace WebApplication1.Models

    Public Class User
        Public Property Id As Integer
        <Required>
        <StringLength(50)>
        Public Property Username As String
        <Required>
        <StringLength(50)>
        Public Property Password As String
        Public Property AdminOverride As Boolean
        <Required>
        Public Property Role As String
    End Class
End Namespace
