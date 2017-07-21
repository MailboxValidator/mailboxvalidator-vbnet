Public Class MBVResult
    Private _email_address As String
    Private _domain As String
    Private _is_free As String
    Private _is_syntax As String
    Private _is_domain As String
    Private _is_smtp As String
    Private _is_verified As String
    Private _is_server_down As String
    Private _is_greylisted As String
    Private _is_disposable As String
    Private _is_suppressed As String
    Private _is_role As String
    Private _is_high_risk As String
    Private _is_catchall As String
    Private _mailboxvalidator_score As Single
    Private _time_taken As Single
    Private _status As String
    Private _credits_available As UInt32
    Private _error_code As String
    Private _error_message As String

    Public Sub New(ByVal email As String)
        _email_address = email
    End Sub

    Public ReadOnly Property EmailAddress() As String
        Get
            Return _email_address
        End Get
    End Property

    Public Property Domain() As String
        Get
            Return _domain
        End Get
        Set(value As String)
            _domain = value
        End Set
    End Property

    Public Property IsFree() As String
        Get
            Return _is_free
        End Get
        Set(value As String)
            _is_free = value
        End Set
    End Property

    Public Property IsSyntax() As String
        Get
            Return _is_syntax
        End Get
        Set(value As String)
            _is_syntax = value
        End Set
    End Property

    Public Property IsDomain() As String
        Get
            Return _is_domain
        End Get
        Set(value As String)
            _is_domain = value
        End Set
    End Property

    Public Property IsSMTP() As String
        Get
            Return _is_smtp
        End Get
        Set(value As String)
            _is_smtp = value
        End Set
    End Property

    Public Property IsVerified() As String
        Get
            Return _is_verified
        End Get
        Set(value As String)
            _is_verified = value
        End Set
    End Property

    Public Property IsServerDown() As String
        Get
            Return _is_server_down
        End Get
        Set(value As String)
            _is_server_down = value
        End Set
    End Property

    Public Property IsGreylisted() As String
        Get
            Return _is_greylisted
        End Get
        Set(value As String)
            _is_greylisted = value
        End Set
    End Property

    Public Property IsDisposable() As String
        Get
            Return _is_disposable
        End Get
        Set(value As String)
            _is_disposable = value
        End Set
    End Property

    Public Property IsSuppressed() As String
        Get
            Return _is_suppressed
        End Get
        Set(value As String)
            _is_suppressed = value
        End Set
    End Property

    Public Property IsRole() As String
        Get
            Return _is_role
        End Get
        Set(value As String)
            _is_role = value
        End Set
    End Property

    Public Property IsHighRisk() As String
        Get
            Return _is_high_risk
        End Get
        Set(value As String)
            _is_high_risk = value
        End Set
    End Property

    Public Property IsCatchall() As String
        Get
            Return _is_catchall
        End Get
        Set(value As String)
            _is_catchall = value
        End Set
    End Property

    Public Property MailboxValidatorScore() As Single
        Get
            Return _mailboxvalidator_score
        End Get
        Set(value As Single)
            _mailboxvalidator_score = value
        End Set
    End Property

    Public Property TimeTaken() As Single
        Get
            Return _time_taken
        End Get
        Set(value As Single)
            _time_taken = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Property CreditsAvailable() As UInt32
        Get
            Return _credits_available
        End Get
        Set(value As UInt32)
            _credits_available = value
        End Set
    End Property

    Public Property ErrorCode() As String
        Get
            Return _error_code
        End Get
        Set(value As String)
            _error_code = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return _error_message
        End Get
        Set(value As String)
            _error_message = value
        End Set
    End Property

    Public ReadOnly Property Version() As String
        Get
            Dim Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version()
            Return Ver.Major & "." & Ver.Minor & "." & Ver.Build
        End Get
    End Property
End Class
