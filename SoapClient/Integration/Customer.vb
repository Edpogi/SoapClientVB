Option Infer On
Imports SoapClient.TestSOAP
Imports PX.Soap.Helper
Public Class Customer
    Public Sub Customer(ByRef Context As Screen)
        Dim CustomerID As String = "EDPADI"
        Dim CustomerName As String = "Ed Padilla"
        Dim CustomerEmail As String = "edpadilla2@yahoo.com"
        Dim CustomerAddress As String = "San Juan City"

        Console.WriteLine("Creating Customer Record...")

        Dim CustSchema As RB202000Content = PX.Soap.Helper.GetSchema(Of RB202000Content)(Context)

        Dim Save_CustomerID As Command = New Command()



    End Sub

End Class
