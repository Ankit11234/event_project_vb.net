Imports System.ComponentModel.DataAnnotations

Namespace WebApplication1.Models
    Public Class [Event]
        Public Property EventId As Integer
        <Required>
        Public Property UserId As Integer
        <Required>
        <StringLength(100)>
        Public Property Title As String
        Public Property Description As String
        <Required>
        Public Property StartTime As DateTime
        <Required>
        Public Property EndTime As DateTime
        <Required>
        <StringLength(50)>
        Public Property Recurrence As String
        Public Property RecurrenceInterval As Integer? = 1
        <StringLength(50)>
        Public Property RecurrenceFrequency As String = "daily"
        <StringLength(50)>
        Public Property RecurrenceEndType As String = "occurrences"
        Public Property EndDate As DateTime? = Nothing
        Public Property Occurrences As Integer? = Nothing
        Public Property RoomId As Integer? = Nothing
    End Class
End Namespace
