Public Class frmMsg
    Public Overloads Function ShowDialog(ByVal textToShow As String, Optional ByVal timeOutSec As Integer = 3) As Windows.Forms.DialogResult

        Me.Label1.Text = textToShow
        Me.Timer1.Interval = timeOutSec * 1000

        Return MyBase.ShowDialog

    End Function

    Private Sub frmMsg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Timer1.Enabled = False
    End Sub

    Private Sub frmMsg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Public Sub New(ByVal textToShow As String, Optional ByVal timeOutSec As Integer = 3)
        InitializeComponent()
        Me.Label1.Text = textToShow
        Me.Timer1.Interval = timeOutSec * 1000
    End Sub
End Class