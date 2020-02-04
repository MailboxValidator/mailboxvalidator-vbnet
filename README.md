MailboxValidator VB.NET Libary
==============================

This VB.NET library enables user to easily validate if an email address is valid, a type of disposable email or free email.

This module can be useful in many types of projects, for example

 - to validate an user's email during sign up
 - to clean your mailing list prior to email sending
 - to perform fraud check
 - and so on

Compilation
===========

Just open the solution file in Visual Studio 2012 or later and compile:

Dependencies
============

An API key is required for this library to function.

Go to https://www.mailboxvalidator.com/plans#api to sign up for a FREE API plan and you'll be given an API key.

Functions
=========

## SingleValidation(api_key)

Creates a new instance of the MailboxValidator object with the API key.

## ValidateEmail(email_address)

Performs email validation on the supplied email address.

### Return Fields

| Field Name | Description |
|-----------|------------|
| email_address | The input email address. |
| domain | The domain of the email address. |
| is_free | Whether the email address is from a free email provider like Gmail or Hotmail. Return values: True, False |
| is_syntax | Whether the email address is syntactically correct. Return values: True, False |
| is_domain | Whether the email address has a valid MX record in its DNS entries. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_smtp | Whether the mail servers specified in the MX records are responding to connections. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_verified | Whether the mail server confirms that the email address actually exist. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_server_down | Whether the mail server is currently down or unresponsive. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_greylisted | Whether the mail server employs greylisting where an email has to be sent a second time at a later time. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_disposable | Whether the email address is a temporary one from a disposable email provider. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_suppressed | Whether the email address is in our blacklist. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_role | Whether the email address is a role-based email address like admin@example.net or webmaster@example.net. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_high_risk | Whether the email address contains high risk keywords. Return values: True, False, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| is_catchall | Whether the email address is a catch-all address. Return values: True, False, Unknown, -&nbsp;&nbsp;&nbsp;(- means not applicable) |
| mailboxvalidator_score | Email address reputation score. Score > 0.70 means good; score > 0.40 means fair; score <= 0.40 means poor. |
| time_taken | The time taken to get the results in seconds. |
| status | Whether our system think the email address is valid based on all the previous fields. Return values: True, False |
| credits_available | The number of credits left to perform validations. |
| error_code | The error code if there is any error. See error table in the below section. |
| error_message | The error message if there is any error. See error table in the below section. |

## DisposableEmail(email_address)

Check if the supplied email address is from a disposable email provider.

### Return Fields

| Field Name | Description |
|-----------|------------|
| email_address | The input email address. |
| is_disposable | Whether the email address is a temporary one from a disposable email provider. Return values: True, False |
| credits_available | The number of credits left to perform validations. |
| error_code | The error code if there is any error. See error table in the below section. |
| error_message | The error message if there is any error. See error table in the below section. |

## FreeEmail(email_address)

Check if the supplied email address is from a free email provider.

### Return Fields

| Field Name | Description |
|-----------|------------|
| email_address | The input email address. |
| is_free | Whether the email address is from a free email provider like Gmail or Hotmail. Return values: True, False |
| credits_available | The number of credits left to perform validations. |
| error_code | The error code if there is any error. See error table in the below section. |
| error_message | The error message if there is any error. See error table below. |

Sample Codes
============

## Validate email

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

## Check if an email is from a disposable email provider

```vbnet
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TestMailboxValidatorVB

    <TestMethod()> Public Sub TestMethod1()
        Dim mbv = New MailboxValidator.SingleValidation("PASTE_YOUR_API_KEY_HERE")
        Dim results As String = ""
        Try
            Dim rec = mbv.DisposableEmail("example@example.com")

            If rec.ErrorCode = "" Then
                results += "email_address: " & rec.EmailAddress & vbCrLf
                results += "is_disposable: " & rec.IsDisposable & vbCrLf
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

## Check if an email is from a free email provider

```vbnet
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TestMailboxValidatorVB

    <TestMethod()> Public Sub TestMethod1()
        Dim mbv = New MailboxValidator.SingleValidation("PASTE_YOUR_API_KEY_HERE")
        Dim results As String = ""
        Try
            Dim rec = mbv.FreeEmail("example@example.com")

            If rec.ErrorCode = "" Then
                results += "email_address: " & rec.EmailAddress & vbCrLf
                results += "is_free: " & rec.IsFree & vbCrLf
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

Errors
======

| error_code | error_message |
| ---------- | ------------- |
| 100 | Missing parameter. |
| 101 | API key not found. |
| 102 | API key disabled. |
| 103 | API key expired. |
| 104 | Insufficient credits. |
| 105 | Unknown error. |

Copyright
=========

Copyright (C) 2018-2020 by MailboxValidator.com, support@mailboxvalidator.com
