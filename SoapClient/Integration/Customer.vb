﻿Option Infer On
Imports SoapClient.TestSOAP
Imports PX.Soap.Helper
Public Class Customer

    Friend CustomerID As String = ""
    Friend CustomerName As String = ""
    Friend CustomerEmail As String = ""
    Friend CustomerAddress As String = ""

    Public Sub CreateCustomer(ByRef Context As Screen)

        Console.WriteLine("Creating Customer Record...")

        Dim CustSchema As RB202000Content = PX.Soap.Helper.GetSchema(Of RB202000Content)(Context)

        Dim commands = New Command() {
            New Value() With
            {.Value = CustomerID, .LinkedCommand = CustSchema.Customers.CustomerID},
            New Value() With
            {.Value = CustomerName, .LinkedCommand = CustSchema.Customers.CompanyName},
            New Value() With
            {.Value = CustomerAddress, .LinkedCommand = CustSchema.Customers.Address},
            CustSchema.Actions.Save, CustSchema.Customers.CustomerID
        }

        Dim Customer As RB202000Content = Context.RB202000Submit(commands)(0)


        Console.WriteLine("Customer ID: " +
        Customer.Customers.CustomerID.Value)
        Console.WriteLine()
        Console.WriteLine("Press any key to continue")
        Console.Read()
    End Sub

    Public Sub UpdateCustomer(ByRef Context As Screen, ByVal CustomerID As String)
        Console.WriteLine("Updating Customer Data of: ")
        Dim CustomerSchema As RB202000Content = PX.Soap.Helper.GetSchema(Of RB202000Content)(Context)

        Dim InitialCustomerIDFieldName As String = CustomerSchema.Customers.CustomerID.FieldName
        Dim CustomerIDSelector As Field = CustomerSchema.Customers.CustomerID
        CustomerIDSelector.FieldName += "!" + CustomerSchema.Customers.ServiceCommands.KeyCustomerID.FieldName

        Dim Commands = New Command() {
            New Value() With
            {.Value = CustomerID, .LinkedCommand = CustomerIDSelector},
            New Value() With
            {.Value = CustomerName, .LinkedCommand = CustomerSchema.Customers.CompanyName},
            New Value() With
            {.Value = "Yes", .LinkedCommand = CustomerSchema.Customers.ServiceCommands.DialogAnswer},
            CustomerSchema.Actions.Save
        }

        Context.RB202000Submit(Commands)
        Console.WriteLine("Updated Successfully!")
        Console.ReadLine()
        'Commands here

    End Sub

    Public Sub GetCustomer(ByRef Context As Screen, ByVal CustomerID As String)
        Console.WriteLine("Getting Customer Data of: " + CustomerID)
        Dim CustomerSchema As RB202000Content = PX.Soap.Helper.GetSchema(Of RB202000Content)(Context)

        Dim Commands = New Command() {
            New Value() With
            {.Value = CustomerID, .LinkedCommand = CustomerSchema.Customers.CustomerID},
             CustomerSchema.Customers.CustomerID,
             CustomerSchema.Customers.CompanyName,
             CustomerSchema.Customers.ContactName,
             CustomerSchema.Customers.City
        }
        Dim ExecuteCommand As RB202000Content = Context.RB202000Submit(Commands)(0)

        Console.WriteLine("Customer ID: " + ExecuteCommand.Customers.CustomerID.Value)
        Console.WriteLine("Company Name: " + ExecuteCommand.Customers.CompanyName.Value)
        Console.WriteLine("Contact Name: " + ExecuteCommand.Customers.ContactName.Value)
        Console.WriteLine("City: " + ExecuteCommand.Customers.City.Value)
        Console.ReadLine()
    End Sub

    Public Sub DeleteCustomer(ByRef Context As Screen, ByVal CustomerID As String)
        Console.WriteLine("Deleting Customer Data of: " + CustomerID)
        Dim CustomerSchema As RB202000Content = PX.Soap.Helper.GetSchema(Of RB202000Content)(Context)

        Dim Commands = New Command() {
            New Value() With
            {.Value = CustomerID, .LinkedCommand = CustomerSchema.Customers.CustomerID},
            CustomerSchema.Actions.Delete
        }

        Context.RB202000Submit(Commands)
        Console.WriteLine("Deleted Successfully!")
        Console.ReadLine()
    End Sub

End Class
