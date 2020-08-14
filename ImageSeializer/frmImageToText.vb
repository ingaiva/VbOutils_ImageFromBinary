Imports System.IO

Public Class frmImageToText

#Region "Commandes"
    Private Sub btnOpenImageFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenImageFile.Click
        openImageFile()
    End Sub

    Private Sub btnSerialiseToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialiseToFile.Click
        Try
            If (Not String.IsNullOrEmpty(Me.TextBox1.Text)) Then
                If (IO.File.Exists(Me.TextBox1.Text)) Then

                    Dim newFile As String = String.Empty
                    Using sfd As New SaveFileDialog
                        sfd.DefaultExt = ".txt"
                        sfd.Filter = "Fichier texte|*.txt|Tout les fichiers|*.*"
                        sfd.OverwritePrompt = False
                        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                            newFile = sfd.FileName
                        End If
                    End Using
                    Application.DoEvents()
                    Me.Enabled = False
                    If scriptDocument(Me.TextBox1.Text, newFile, "", "") Then
                        showMsg("Terminé")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub btnSerialiseToClipBoardBase64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialiseToClipBoardBase64.Click
        Try
            If (Not String.IsNullOrEmpty(Me.TextBox1.Text)) Then
                If (IO.File.Exists(Me.TextBox1.Text)) Then
                    Me.Enabled = False
                    Dim txt As String = scriptDocumentAsBase64(Me.TextBox1.Text)
                    Me.Enabled = True
                    If String.IsNullOrEmpty(txt) = False Then
                        Clipboard.SetText(txt)
                        showMsg("Terminé")
                    Else
                        MsgBox("Erreur")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSerialiseToClipBoardByteArray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialiseToClipBoardByteArray.Click
        If (IO.File.Exists(Me.TextBox1.Text)) Then
            Dim filePath As String = Me.TextBox1.Text
            Me.Enabled = False
            Dim txt As String = scriptDocumentAsByteStr(filePath)
            Me.Enabled = True
            If String.IsNullOrEmpty(txt) = False Then
                Clipboard.SetText(txt)
                showMsg("Terminé")
            Else
                MsgBox("Erreur")
            End If
        End If
    End Sub
#End Region

    Public Function openImageFile() As Boolean
        Using frm As New OpenFileDialog()
            frm.CheckFileExists = True
            frm.CheckPathExists = True
            frm.DereferenceLinks = True
            frm.Multiselect = False
            frm.FileName = ""
            frm.Filter = "Images (*.bmp, *.jpg, *.png)|*.bmp;*.jpg; *.png|Files (*.*)|*.*"
            frm.ShowDialog()
            If (Not String.IsNullOrEmpty(frm.FileName)) Then
                Me.TextBox1.Text = frm.FileName
                Me.PictureBox1.ImageLocation = frm.FileName
                Return True
            End If
        End Using
        Return False
    End Function

    Public Shared Function getMemoryStream(ByVal filePath As String) As MemoryStream
        If File.Exists(filePath) Then
            Dim fStream As FileStream = Nothing
            Dim mStream As MemoryStream = Nothing
            Try
                fStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
                mStream = getMemoryStream(fStream)
            Catch ex As Exception
                If mStream IsNot Nothing Then
                    mStream.Close()
                    mStream.Dispose()
                End If
                mStream = Nothing
                Throw ex
            Finally
                If fStream IsNot Nothing Then
                    fStream.Close()
                    fStream.Dispose()
                End If
                fStream = Nothing
            End Try

            Return mStream
        End If
        Return Nothing
    End Function

    Public Shared Function getMemoryStream(ByVal fStream As FileStream) As MemoryStream
        If fStream IsNot Nothing Then
            Dim mStream As New MemoryStream

            mStream.SetLength(fStream.Length) 'Permet de supprimer les octets non utilisés en utilisant .GetBuffer() du MemoryStream
            mStream.Position = 0
            fStream.Position = 0

            While fStream.Position < fStream.Length
                mStream.WriteByte(fStream.ReadByte())
            End While

            mStream.Position = 0

            Return mStream
        End If
        Return Nothing
    End Function

    Public Shared Function scriptDocument(ByVal filePath As String, ByVal scriptFile As String, ByVal debutQuery As String, ByVal endQuery As String) As Boolean


        If String.IsNullOrEmpty(scriptFile) Then Return False
        Dim txt As String = scriptDocumentAsByteStr(filePath)
        If String.IsNullOrEmpty(txt) Then Return False

        Dim sw As IO.StreamWriter = Nothing
        Try

            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(scriptFile))

            sw = New IO.StreamWriter(scriptFile, False)
            If String.IsNullOrEmpty(debutQuery) = False Then sw.Write(debutQuery)
            sw.Write(txt)
            If String.IsNullOrEmpty(endQuery) = False Then sw.Write(endQuery)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sw IsNot Nothing Then
                sw.Flush()
                sw.Close()
                sw.Dispose()
            End If
            sw = Nothing
        End Try
        Return False

    End Function

    Public Shared Function scriptDocumentAsBase64(ByVal filePath As String) As String

        Dim mOriginalStream As IO.MemoryStream = Nothing
        Try

            mOriginalStream = getMemoryStream(filePath)

            If (mOriginalStream IsNot Nothing AndAlso mOriginalStream.Length > 0) Then
                Dim buf As Byte() = mOriginalStream.ToArray
                Return Convert.ToBase64String(buf)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Génération du script ")
        Finally
            If mOriginalStream IsNot Nothing Then
                mOriginalStream.Close()
                mOriginalStream.Dispose()
            End If
            mOriginalStream = Nothing
        End Try
        Return String.Empty
    End Function

    Public Shared Function scriptDocumentAsByteStr(ByVal filePath As String) As String
        Dim mOriginalStream As IO.MemoryStream = Nothing

        Dim ret As String
        Try

            mOriginalStream = getMemoryStream(filePath)

            If (mOriginalStream IsNot Nothing AndAlso mOriginalStream.Length > 0) Then

                Dim cpt As Integer = 0
                Dim n As Integer = 0
                Do
                    Dim buffer As Byte() = Array.CreateInstance(GetType(Byte), 128)
                    cpt = mOriginalStream.Read(buffer, 0, buffer.Length)
                    If cpt > 0 Then
                        If cpt < 128 Then ReDim Preserve buffer(cpt - 1)
                        n += 1
                        Dim bufferStr As String = BitConverter.ToString(buffer).Replace("-", "")
                        If n = 1 Then
                            ret &= String.Format("0x{0}", bufferStr)
                        Else
                            ret &= bufferStr
                        End If
                    End If
                Loop Until cpt = 0

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Génération du script")
        Finally
            If mOriginalStream IsNot Nothing Then
                mOriginalStream.Close()
                mOriginalStream.Dispose()
            End If
            mOriginalStream = Nothing
        End Try
        Return ret
    End Function

    Public Shared Sub showMsg(ByVal texteToShow As String, Optional ByVal timeOutSec As Integer = 1)
        Using frm As New frmMsg(texteToShow, timeOutSec)
            frm.ShowDialog()
        End Using
    End Sub
End Class