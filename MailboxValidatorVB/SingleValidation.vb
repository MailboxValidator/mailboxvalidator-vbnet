Imports System.Net
Imports System.IO
Imports System.Uri
Imports System.Web.Script.Serialization

Public Class SingleValidation
    Private api_key As String = ""

    Public Sub New(ByVal apikey As String)
        api_key = apikey
    End Sub

    Public Function ValidateEmail(ByVal email As String) As MBVResult
        Dim record As MBVResult = New MBVResult(email)

        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing

        Dim data As New Dictionary(Of String, String)

        data.Add("format", "json")
        data.Add("email", email)
        data.Add("key", api_key)
        Dim datastr As String = String.Join("&", data.[Select](Function(x) x.Key & "=" & EscapeDataString(x.Value)).ToArray())

        request = Net.WebRequest.Create("http://api.mailboxvalidator.com/v1/validation/single?" & datastr.TrimStart("&"))

        request.Method = "GET"
        response = request.GetResponse()

        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())

        Dim output = reader.ReadToEnd
        Dim jss As New JavaScriptSerializer()
        Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(output)

        record.Domain = dict("domain")
        record.IsFree = dict("is_free")
        record.IsSyntax = dict("is_syntax")
        record.IsDomain = dict("is_domain")
        record.IsSMTP = dict("is_smtp")
        record.IsVerified = dict("is_verified")
        record.IsServerDown = dict("is_server_down")
        record.IsGreylisted = dict("is_greylisted")
        record.IsDisposable = dict("is_disposable")
        record.IsSuppressed = dict("is_suppressed")
        record.IsRole = dict("is_role")
        record.IsHighRisk = dict("is_high_risk")
        record.IsCatchall = dict("is_catchall")
        record.MailboxValidatorScore = IIf(dict("mailboxvalidator_score") = "", 0.0, dict("mailboxvalidator_score"))
        record.TimeTaken = dict("time_taken")
        record.Status = dict("status")
        record.CreditsAvailable = IIf(dict("credits_available") = "", 0, dict("credits_available"))
        record.ErrorCode = dict("error_code")
        record.ErrorMessage = dict("error_message")

        Return record
    End Function
End Class