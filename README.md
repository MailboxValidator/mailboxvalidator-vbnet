MailboxValidator VB.NET Libary
==============================

This VB.NET libary provides an easy way to call the MailboxValidator API which validates if an email address is a valid one.

This class can be used in many types of projects such as:

 - validating a user's email during sign up
 - cleaning your mailing list prior to an email marketing campaign
 - a form of fraud check

Compilation
===========

Just open the solution file in Visual Studio 2012 or later and compile:

Dependencies
============

An API key is required for this class to function.

Go to http://www.mailboxvalidator.com/plans#api to sign up for a FREE API plan and you'll be given an API key.

Sample Usage
============

```vbnet
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
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

End Class
```

Copyright
=========

Copyright (C) 2017 by MailboxValidator.com, support@mailboxvalidator.com
