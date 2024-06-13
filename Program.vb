Imports RestSharp

Module Module1
    Sub Main()
        ' Defina a URL da API
        Dim apiUrl As String = "https://api.plugzapi.com.br/instances/SUA_INSTANCIA/token/SEU_TOKEN/send-text"

        Dim client As New RestClient(apiUrl)

        Dim request As New RestRequest("", Method.Post)

        request.AddHeader("content-type", "application/json")
        request.AddHeader("client-token", "{{security-token}}")

        ' Crie um objeto JSON com os dados do usuário a serem enviados
        Dim newUser As Object = New With {
               .phone = "5544999999999",
               .message = "Demo Visual Basic .net "
        }

        request.AddJsonBody(newUser)

        Dim response As RestResponse = client.Execute(request)

        If response.StatusCode = System.Net.HttpStatusCode.OK Then
            Console.WriteLine("Mensagem enviada com sucesso!")
            Console.WriteLine("Resposta da API: " & response.Content)
        Else
            Console.WriteLine("Erro: " & response.StatusCode)
            Console.WriteLine("Detalhes do erro: " & response.Content)
        End If

        Console.ReadLine()
    End Sub
End Module
