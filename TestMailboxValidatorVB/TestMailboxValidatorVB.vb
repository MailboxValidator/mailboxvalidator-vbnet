Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TestMailboxValidatorVB

    <TestMethod()> Public Sub TestMethod1()
        Dim mbv = New MailboxValidator.SingleValidation("PASTE_YOUR_API_KEY_HERE")

        Dim results As String = ""
        Try
            Dim rec = mbv.ValidateEmail("example@example.com")

            If rec.ErrorCode = "" Then
                results += "email_address: " & rec.EmailAddress & vbCrLf
                results += "domain: " & rec.Domain & vbCrLf
                results += "is_free: " & rec.IsFree & vbCrLf
                results += "is_syntax: " & rec.IsSyntax & vbCrLf
                results += "is_domain: " & rec.IsDomain & vbCrLf
                results += "is_smtp: " & rec.IsSMTP & vbCrLf
                results += "is_verified: " & rec.IsVerified & vbCrLf
                results += "is_server_down: " & rec.IsServerDown & vbCrLf
                results += "is_greylisted: " & rec.IsGreylisted & vbCrLf
                results += "is_disposable: " & rec.IsDisposable & vbCrLf
                results += "is_suppressed: " & rec.IsSuppressed & vbCrLf
                results += "is_role: " & rec.IsRole & vbCrLf
                results += "is_high_risk: " & rec.IsHighRisk & vbCrLf
                results += "is_catchall: " & rec.IsCatchall & vbCrLf
                results += "mailboxvalidator_score: " & rec.MailboxValidatorScore & vbCrLf
                results += "time_taken: " & rec.TimeTaken & vbCrLf
                results += "status: " & rec.Status & vbCrLf
                results += "credits_available: " & rec.CreditsAvailable & vbCrLf
            Else
                results += "error_code: " & rec.ErrorCode & vbCrLf
                results += "error_message: " & rec.ErrorMessage & vbCrLf
            End If

            results += "version: " & rec.Version & vbCrLf
            MsgBox(results)

            results = ""

            Dim rec2 = mbv.DisposableEmail("example@example.com")

            If rec2.ErrorCode = "" Then
                results += "email_address: " & rec2.EmailAddress & vbCrLf
                results += "is_disposable: " & rec2.IsDisposable & vbCrLf
                results += "credits_available: " & rec2.CreditsAvailable & vbCrLf
            Else
                results += "error_code: " & rec2.ErrorCode & vbCrLf
                results += "error_message: " & rec2.ErrorMessage & vbCrLf
            End If

            results += "version: " & rec2.Version & vbCrLf
            MsgBox(results)

            results = ""

            Dim rec3 = mbv.FreeEmail("example@example.com")

            If rec3.ErrorCode = "" Then
                results += "email_address: " & rec3.EmailAddress & vbCrLf
                results += "is_free: " & rec3.IsFree & vbCrLf
                results += "credits_available: " & rec3.CreditsAvailable & vbCrLf
            Else
                results += "error_code: " & rec3.ErrorCode & vbCrLf
                results += "error_message: " & rec3.ErrorMessage & vbCrLf
            End If

            results += "version: " & rec3.Version & vbCrLf
            MsgBox(results)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

End Class