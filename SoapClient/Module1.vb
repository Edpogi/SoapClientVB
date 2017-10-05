Imports SoapClient.TestSOAP
Module Module1

    Sub Main()
        Using Context As New Screen
            Context.CookieContainer = New Net.CookieContainer()
            Context.Url = My.Settings.SoapClient_TestSOAP_Screen
            Context.Login(My.Settings.Login, My.Settings.Password)

            Try

            Catch ex As Exception
                Console.WriteLine(ex)
                Console.WriteLine()
                Console.WriteLine("Press Any key to continue")
                Console.ReadLine()

            Finally
                Context.Logout()
            End Try
        End Using
    End Sub

End Module
