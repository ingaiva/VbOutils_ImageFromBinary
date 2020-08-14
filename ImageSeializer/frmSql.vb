Imports System.Data.Sql

Public Class frmSql
    Public Shared Conn As System.Data.SqlClient.SqlConnection = Nothing
    Public Shared lastSqlRequette As String = "SELECT  [resData]   FROM [Resource] where idRes =''"

    Public Function GetConnection() As Boolean
        Try
            If Conn Is Nothing Then
                Conn = New System.Data.SqlClient.SqlConnection
            Else
                If Conn.State = System.Data.ConnectionState.Open Then
                    Conn.Close()
                End If
            End If

            Conn.ConnectionString = getConnectionString()

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connection")
        End Try
        Return False
    End Function

    Private Function getConnectionString() As String
        Dim strDataSource As String = "data source=" & Trim(Me.jcboServer.Text)


        Dim strLogin As String = ";User Id=" & Trim(Me.jtxtUser.Text) & ";Password=" & Trim(Me.jtxtPassWord.Text)
        Dim strSSPI As String = ";Integrated Security=SSPI"
        Dim strPacketSize As String = ";packet size=4096"
        Dim ret As String
        If rdbtnAuthentificationWindows.Checked Then

            ret = strDataSource & strSSPI & strPacketSize
        Else

            ret = strDataSource & strLogin & strPacketSize

        End If
        Dim bld As New SqlClient.SqlConnectionStringBuilder(ret)
        If String.IsNullOrEmpty(cboBases.Text) = False Then
            bld.InitialCatalog = cboBases.Text
        End If
        bld.ConnectTimeout = 600
        ret = bld.ToString
        bld = Nothing
        lastPassWrd = Trim(Me.jtxtPassWord.Text)
        Return ret
    End Function

    Public Shared Function GetServers() As List(Of String)
        Try
            Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
            Dim table As System.Data.DataTable = instance.GetDataSources()
            Dim lst As List(Of String) = FormatServerData(table)
            Return lst

        Catch ex As Exception
            MsgBox("Une erreur s'est produite." & vbCrLf & "Description de l'erreur : " & ex.Message, MsgBoxStyle.Information)
        End Try
        Return Nothing
    End Function

    Private Shared _listeServers As List(Of String) = Nothing
    Public Shared ReadOnly Property listeServers() As List(Of String)
        Get
            If _listeServers Is Nothing Then
                _listeServers = GetServers()
            End If
            Return _listeServers
        End Get
    End Property

    Private Shared Function FormatServerData(ByVal table As DataTable) As List(Of String)
        Dim lst As New List(Of String)
        Dim line As String
        For Each row As DataRow In table.Rows
            line = String.Empty
            For i As Integer = 0 To 1
                If i = 1 AndAlso (row(i) Is DBNull.Value OrElse String.IsNullOrEmpty(row(i).ToString)) Then
                    'Instance par défaut
                Else
                    If row(i) IsNot DBNull.Value Then
                        If String.IsNullOrEmpty(line) Then
                            line = row(i)
                        Else
                            line &= "\" & row(i).ToString
                        End If
                    End If
                End If
            Next
            If String.IsNullOrEmpty(line) = False Then
                lst.Add(line)
            End If
        Next
        Return lst
    End Function

    Private Function GetBases() As List(Of String)
        Try
            If Not Me.GetConnection() Then
                Return Nothing
            End If
            If Conn Is Nothing Then
                Return Nothing
            Else
                Dim listBases As New List(Of String)
                If Conn.State <> ConnectionState.Open Then Conn.Open()
                Dim cmd As IDbCommand = Nothing, reader As IDataReader = Nothing
                cmd = Conn.CreateCommand
                cmd.CommandText = String.Format("SELECT [name] from  [sys].[databases]") 'where [name] in ({0}), Filter
                reader = cmd.ExecuteReader

                While reader.Read
                    If reader.IsDBNull(0) = False Then
                        listBases.Add(reader.GetString(0))
                    End If
                End While
                reader.Close()
                Conn.Close()
                Return listBases
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connection to Server")
        End Try

        Return Nothing

    End Function

    Private Sub btnGetBasesFromServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBasesFromServer.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            Dim listBases As List(Of String) = Me.GetBases

            cboBases.DataSource = Nothing

            If listBases IsNot Nothing Then
                cboBases.DataSource = listBases
            End If

            If cboBases.Items.Count > 0 Then
                If listBases.Contains("ADN_BIN") Then
                    cboBases.SelectedItem = "ADN_BIN"
                Else
                    cboBases.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connection to Server")
        End Try
        Windows.Forms.Application.DoEvents()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Sub jbtnTryConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jbtnTryConnection.Click
        If Not Me.GetConnection() Then
            Return
        End If
        If Conn Is Nothing Then
            MsgBox("Connection non établie")
            Return
        Else
            If Conn.State <> ConnectionState.Open Then Conn.Open()
            Dim cmd As IDbCommand = Nothing, reader As IDataReader = Nothing
            cmd = Conn.CreateCommand
            Dim bddName As String = cboBases.Text
            If String.IsNullOrEmpty(bddName) Then bddName = "master"
            cmd.CommandText = String.Format("SELECT TOP 1 [TABLE_NAME] FROM [{0}].[INFORMATION_SCHEMA].[TABLES]", bddName)
            reader = cmd.ExecuteReader
            If reader.Read Then
                MsgBox("Connection établie")
            Else
                MsgBox("Connection non établie")
            End If
            reader.Close()
            Conn.Close()
        End If
    End Sub

    Private Sub btnSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSav.Click
        Dim s As String = GetByteFromDB()

        If String.IsNullOrEmpty(s) = False Then
            Using sfd As New SaveFileDialog
                sfd.DefaultExt = ".txt"
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Using sw As New IO.StreamWriter(sfd.FileName, False)
                        sw.Write(s)
                        sw.Flush()
                        sw.Close()
                    End Using
                End If
            End Using
        End If
    End Sub

    Private Function GetByteFromDB() As String
        If String.IsNullOrEmpty(txtReq.Text) Then
            MsgBox("Entrez la requette sql à exécuter")
            Return String.Empty
        End If
        Dim cmd As IDbCommand = Nothing
        Try
            If Not Me.GetConnection() Then
                Return String.Empty
            End If
            If Conn Is Nothing Then
                MsgBox("Connection non établie")
                Return String.Empty
            Else
                If Conn.State <> ConnectionState.Open Then Conn.Open()
                Dim reader As IDataReader = Nothing
                cmd = Conn.CreateCommand
                cmd.CommandText = txtReq.Text

                Dim o As Object = cmd.ExecuteScalar()
                If (o Is Nothing) Then
                    MsgBox("Aucune valeur retourné pour cette requête")
                    Return String.Empty
                End If
                If Not (TypeOf o Is Byte()) Then
                    MsgBox("La première colonne n'est pas de type varbynary")
                    Return String.Empty
                End If

                Dim tab() As Byte = o
                Dim sb As New System.Text.StringBuilder()
                sb.Append("0x")
                If (tab.Length > 0) Then
                    For Each b As Byte In tab
                        sb.Append(ByteToString(b))
                    Next
                End If

                Return sb.ToString()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If (Conn IsNot Nothing) Then
                Conn.Close()
            End If
            If (cmd IsNot Nothing) Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return String.Empty
    End Function

    Private Sub btnConvertToImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertToImage.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Public ReadOnly Property result() As String
        Get
            Return GetByteFromDB()
        End Get
    End Property
    

    Private Sub jcboServer_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles jcboServer.DropDown
        Me.Cursor = Cursors.WaitCursor
        jcboServer.DataSource = listeServers
        Me.Cursor = Cursors.Default
    End Sub

    Private Shared lastPassWrd As String

    Private Sub frmSql_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If String.IsNullOrEmpty(txtReq.Text) = False Then lastSqlRequette = txtReq.Text
    End Sub

    Private Sub frmSql_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Conn IsNot Nothing Then
                Dim bld As New SqlClient.SqlConnectionStringBuilder(Conn.ConnectionString)
                jcboServer.Text = bld.DataSource
                Me.jtxtUser.Text = bld.UserID
                jtxtPassWord.Text = lastPassWrd 'bld.Password
                cboBases.Text = bld.InitialCatalog
                If bld.IntegratedSecurity Then
                    rdbtnAuthentificationWindows.Checked = True
                Else
                    rdbtnAuthentificationSql.Checked = True
                End If
                bld = Nothing
                txtReq.Text = lastSqlRequette
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function ByteToString(ByVal b As Byte) As String
        Dim a As Integer = b And 15
        Dim res As String = ""
        If (a > 9) Then
            Select Case a
                Case 10
                    res = "A"
                Case 11
                    res = "B"
                Case 12
                    res = "C"
                Case 13
                    res = "D"
                Case 14
                    res = "E"
                Case 15
                    res = "F"
            End Select
        Else
            res = a.ToString
        End If
        a = b And 240
        a = a >> 4
        If (a > 9) Then
            Select Case a
                Case 10
                    res = "A" & res
                Case 11
                    res = "B" & res
                Case 12
                    res = "C" & res
                Case 13
                    res = "D" & res
                Case 14
                    res = "E" & res
                Case 15
                    res = "F" & res
            End Select
        Else
            res = a.ToString & res
        End If
        Return res
    End Function
End Class