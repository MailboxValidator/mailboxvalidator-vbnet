Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Uri

Public Class SingleValidation
    Private api_key As String = ""
    Private Shared ReadOnly client As New HttpClient()

    Public Sub New(apikey As String)
        api_key = apikey
    End Sub

    Public Function GetVersion()
        Dim Ver = Reflection.Assembly.GetExecutingAssembly().GetName().Version()
        Return Ver.Major & "." & Ver.Minor & "." & Ver.Build
    End Function

    Public Async Function ValidateEmailAsync(email As String) As Task(Of JObject)
        Dim data As New Dictionary(Of String, String) From {
        {"format", "json"},
        {"email", email},
        {"key", api_key}
    }
        Dim datastr As String = String.Join("&", data.[Select](Function(x) x.Key & "=" & EscapeDataString(x.Value)).ToArray())
        Dim url As String = "http://api.mailboxvalidator.com/v2/validation/single?" & datastr.TrimStart("&")
        Dim response As HttpResponseMessage = Await client.GetAsync(url)

        If response.StatusCode = HttpStatusCode.OK Then
            Dim rawjson As String = Await response.Content.ReadAsStringAsync()
            Dim results As JObject = JsonConvert.DeserializeObject(Of JObject)(rawjson)
            Return results
        ElseIf response.StatusCode = HttpStatusCode.Unauthorized OrElse response.StatusCode = HttpStatusCode.BadRequest Then
            Dim rawjson As String = Await response.Content.ReadAsStringAsync()
            If rawjson.Contains("error_message") Then
                Dim results As JObject = JsonConvert.DeserializeObject(Of JObject)(rawjson)
                Throw New Exception(results("error")("error_message").ToString)
            End If
        End If
        Throw New Exception("Error connecting to API.")
    End Function

    Public Async Function DisposableEmailAsync(email As String) As Task(Of JObject)
        Dim data As New Dictionary(Of String, String) From {
        {"format", "json"},
        {"email", email},
        {"key", api_key}
    }
        Dim datastr As String = String.Join("&", data.[Select](Function(x) x.Key & "=" & EscapeDataString(x.Value)).ToArray())

        Dim url As String = "http://api.mailboxvalidator.com/v2/email/disposable?" & datastr.TrimStart("&")
        Dim response As HttpResponseMessage = Await client.GetAsync(url)

        If response.StatusCode = HttpStatusCode.OK Then
            Dim rawjson As String = Await response.Content.ReadAsStringAsync()
            Dim results As JObject = JsonConvert.DeserializeObject(Of JObject)(rawjson)
            Return results
        ElseIf response.StatusCode = HttpStatusCode.Unauthorized OrElse response.StatusCode = HttpStatusCode.BadRequest Then
            Dim rawjson As String = Await response.Content.ReadAsStringAsync()
            If rawjson.Contains("error_message") Then
                Dim results As JObject = JsonConvert.DeserializeObject(Of JObject)(rawjson)
                Throw New Exception(results("error")("error_message").ToString)
            End If
        End If
        Throw New Exception("Error connecting to API.")
    End Function

    Public Async Function FreeEmailAsync(email As String) As Task(Of JObject)
        Dim data As New Dictionary(Of String, String) From {
        {"format", "json"},
        {"email", email},
        {"key", api_key}
    }
        Dim datastr As String = String.Join("&", data.[Select](Function(x) x.Key & "=" & EscapeDataString(x.Value)).ToArray())

        Dim url As String = "http://api.mailboxvalidator.com/v2/email/free?" & datastr.TrimStart("&")
        Dim response As HttpResponseMessage = Await client.GetAsync(url)

        If response.StatusCode = HttpStatusCode.OK Then
            Dim rawjson As String = Await response.Content.ReadAsStringAsync()
            Dim results As JObject = JsonConvert.DeserializeObject(Of JObject)(rawjson)
            Return results
        ElseIf response.StatusCode = HttpStatusCode.Unauthorized OrElse response.StatusCode = HttpStatusCode.BadRequest Then
            Dim rawjson As String = Await response.Content.ReadAsStringAsync()
            If rawjson.Contains("error_message") Then
                Dim results As JObject = JsonConvert.DeserializeObject(Of JObject)(rawjson)
                Throw New Exception(results("error")("error_message").ToString)
            End If
        End If
        Throw New Exception("Error connecting to API.")
    End Function
End Class