Public Class frmReadFromText

    Private Sub FormReadFromText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearPictureBox()
        tsmiConvert.Enabled = (rtxtImgData.TextLength > 0)
    End Sub

    Private Sub convertImageFromText()
        convertImageFromText(Trim(Me.rtxtImgData.Text))
    End Sub

    Private Shared hexArr As String() = New String() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, "A", "B", "C", "D", "E", "F"}
    Private Function isHexString(ByVal txt As String) As Boolean
        If txt.StartsWith("0x") Then txt = txt.Substring(2)
        For i As Integer = 0 To txt.Length - 1
            Dim ch As Char = txt.Chars(i)
            If Char.IsWhiteSpace(ch) = False Then
                If hexArr.Contains(ch.ToString.ToUpperInvariant) = False Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub convertImageFromText(ByVal txt As String)
        clearPictureBox()
        Try
            If String.IsNullOrEmpty(txt) = False Then
                Dim img As Image = Nothing
                If isHexString(txt) Then
                    img = convertFromHexByteString(txt)
                Else
                    img = convertFromBase64String(txt)
                End If
                If img IsNot Nothing Then
                    pic.Image = img
                    If Me.pic.Image IsNot Nothing AndAlso (Me.pic.Image.Width > Me.pic.Width Or Me.pic.Image.Height > Me.pic.Height) Then
                        Me.pic.SizeMode = PictureBoxSizeMode.Zoom
                    End If
                End If
                tsmiSaveImage.Enabled = (pic.Image IsNot Nothing)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function convertFromHexByteString(ByVal txt As String) As Image
        Try

            If String.IsNullOrEmpty(txt) = False Then
                If txt.StartsWith("0x") Then txt = txt.Substring(2)
                txt = txt.Replace(" "c, "")
                Return convertFromHexString(txt)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Private Function convertFromHexString(ByVal txt As String) As Image
        'conversion à partir de données - tableau de bytes sous forme de string hexa
        ' Cette presentation se retrouve notamment en base de données dans les colonnes de type varbinary(MAX)
        Dim i As Integer = 0
        Try
            If (txt.Length Mod 2 = 1) Then
                'si la chaine contient un nombre impaire de caractère, ce n'est pas normal  'on rajoute un 0 pour retomber sur un nombre pair ...
                txt &= "0"
            End If
            'on a une chaine d'hex qu'on converti en tab de byte
            Dim data((txt.Length / 2) - 1) As Byte
            For i = 0 To data.Length - 1
                If (txt.Length > (2 * i) + 1) Then 'on fait rentrer 2 cases du premier tableau de type string dans une case du second de type byte --> logic 1 octet = 2 caracteres Hexa
                    data(i) = Convert.ToByte(txt(2 * i) & txt((2 * i) + 1), 16)
                End If
            Next
            Dim ext As String = findImageExtention(data)
            If String.IsNullOrEmpty(ext) AndAlso MsgBox("Format image inconnu. Continuer?", MsgBoxStyle.YesNo, "") <> MsgBoxResult.Yes Then
                Return Nothing
            End If

            Dim img As Image = createImageFromByteArray(data)
            img.Tag = ext

            Return img
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Private Function convertFromBase64String(ByVal txt As String) As Image
        ' Cette presentation se retrouve notamment dans les fichiers XML images serialisées 
        Try
            Dim imageBytes As Byte() = Convert.FromBase64String(txt)
            Dim ext As String = findImageExtention(imageBytes)
            If String.IsNullOrEmpty(ext) AndAlso MsgBox("Format image inconnu. Continuer?", MsgBoxStyle.YesNo, "") <> MsgBoxResult.Yes Then
                Return Nothing
            End If
            Dim img As Image = createImageFromByteArray(imageBytes)
            img.Tag = ext
            Return img
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Private Function createImageFromByteArray(ByVal imageBytes As Byte()) As Image
        Dim btmpConverter As System.Drawing.ImageConverter
        btmpConverter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(Image))
        Dim img As Image = CType(btmpConverter.ConvertFrom(imageBytes), Image)
        Return img
    End Function

#Region "Les indicateurs de format "
    Public Shared trameJpeg As Byte() = New Byte() {&HFF, &HD8, &HFF}
    Public Shared trameBmp As Byte() = New Byte() {&H42, &H4D}
    Public Shared tramePng As Byte() = New Byte() {&H89, &H50, &H4E, &H47, &HD, &HA, &H1A, &HA}
    Public Shared trameGif1 As Byte() = New Byte() {&H47, &H49, &H46, &H38, &H37, &H61}
    Public Shared trameGif2 As Byte() = New Byte() {&H47, &H49, &H46, &H38, &H39, &H61}
    Public Shared trameIco As Byte() = New Byte() {&H0, &H0, &H1, &H0} '00 00 01 00

    Public Shared trameGzip As Byte() = New Byte() {&H1F, &H8B, &H8}
    Public Shared trameExcel As Byte() = New Byte() {&H9, &H8, &H10, &H0, &H0, &H6, &H5, &H0}

    Public Shared trameWavStart As Byte() = New Byte() {&H52, &H49, &H46, &H46} '52 49 46 46 
    Public Shared trameWavEmpty As Byte() = New Byte() {&H0, &H0, &H0, &H0}
    Public Shared trameWavEnd As Byte() = New Byte() {&H57, &H41, &H56, &H45, &H66, &H6D, &H74, &H20}

    Public Shared trameWord As Byte() = New Byte() {&HD0, &HCF, &H11, &HE0, &HA1, &HB1, &H1A, &HE1}
    Public Shared tramePdf As Byte() = New Byte() {&H25, &H50, &H44, &H46}
    Public Shared Function findImageExtention(ByRef imageStreamBuffer As Byte()) As String
        Dim imgFrmt As Drawing.Imaging.ImageFormat = findImageFormat(imageStreamBuffer)

        If imgFrmt Is Drawing.Imaging.ImageFormat.Bmp Then
            Return "." & imgFrmt.ToString
        ElseIf imgFrmt Is Drawing.Imaging.ImageFormat.Gif Then
            Return "." & imgFrmt.ToString
        ElseIf imgFrmt Is Drawing.Imaging.ImageFormat.Png Then
            Return "." & imgFrmt.ToString
        ElseIf imgFrmt Is Drawing.Imaging.ImageFormat.Jpeg Then
            Return "." & imgFrmt.ToString
        End If
        Return String.Empty
    End Function

    Public Shared Function findImageFormat(ByRef imageStreamBuffer As Byte()) As Drawing.Imaging.ImageFormat
        If imageStreamBuffer IsNot Nothing AndAlso imageStreamBuffer.Length > 0 Then
            If FindSignature(trameJpeg, imageStreamBuffer) Then
                Return Imaging.ImageFormat.Jpeg
            End If
            If FindSignature(tramePng, imageStreamBuffer) Then
                Return Imaging.ImageFormat.Png
            End If
            If FindSignature(trameGif1, imageStreamBuffer) Then
                Return Imaging.ImageFormat.Gif
            End If
            If FindSignature(trameGif2, imageStreamBuffer) Then
                Return Imaging.ImageFormat.Gif
            End If
            If FindSignature(trameBmp, imageStreamBuffer) Then
                Return Imaging.ImageFormat.Bmp
            End If
            If FindSignature(trameIco, imageStreamBuffer) Then
                Return Imaging.ImageFormat.Icon
            End If
        End If
        Return Nothing
    End Function

    Private Shared Function FindSignature(ByVal signatureBuffer As Byte(), ByRef resBuffer As Byte()) As Boolean
        Dim ret As Boolean = False
        If resBuffer.Length >= signatureBuffer.Length Then
            Dim buf As Byte() = Array.CreateInstance(GetType(Byte), signatureBuffer.Length)
            Array.Copy(resBuffer, buf, buf.Length)
            If CompareArrayValues(buf, signatureBuffer) Then
                ret = True
            End If
        End If

        Return ret
    End Function

    Private Shared Function CompareArrayValues(ByVal Arr1 As Byte(), ByVal Arr2 As Byte()) As Boolean

        If Arr1.Length <> Arr2.Length Then
            Return False
        End If

        For i As Integer = 0 To Arr1.GetUpperBound(0)
            If Arr1(i) <> Arr2(i) Then
                Return False
            End If
        Next


        Return True
    End Function
#End Region

    Private Sub rtxtImgData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtxtImgData.TextChanged
        tsmiConvert.Enabled = (rtxtImgData.TextLength > 0)
    End Sub

    Private Sub clearPictureBox()
        If pic.Image IsNot Nothing Then pic.Image.Dispose()
        pic.Image = Nothing
        pic.Tag = Nothing
        Me.pic.SizeMode = PictureBoxSizeMode.CenterImage
        tsmiSaveImage.Enabled = (pic.Image IsNot Nothing)
        Me.Refresh()
    End Sub

    Private Sub tsmiFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiFileOpen.Click
        Try
            Using ofd As New OpenFileDialog
                If ofd.ShowDialog = Windows.Forms.DialogResult.OK AndAlso String.IsNullOrEmpty(ofd.FileName) = False Then
                    Dim txt As String
                    Using reader As New IO.StreamReader(ofd.FileName)
                        txt = reader.ReadToEnd()
                        reader.Close()
                    End Using
                    convertImageFromText(txt)
                    rtxtImgData.Text = txt
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsmiConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiConvert.Click
        convertImageFromText()
    End Sub


    Private Sub tsmiSaveImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiSaveImage.Click
        If pic.Image IsNot Nothing Then
            Using sfd As New SaveFileDialog
                If pic.Image.Tag IsNot Nothing Then
                    sfd.DefaultExt = pic.Image.Tag.ToString
                    sfd.Filter = String.Format("Fichier image|*{0}|Tout les fichiers|*.*", pic.Tag)
                End If
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    pic.Image.Save(sfd.FileName)
                End If
            End Using
        End If
    End Sub

    Private Sub SqlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiSql.Click
        Using frm As New frmSql
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim txt As String = frm.result
                If String.IsNullOrEmpty(txt) = False Then
                    convertImageFromText(txt)
                    rtxtImgData.Text = txt
                End If
            End If
        End Using
    End Sub

    Private Sub ImageToTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiImageToText.Click
        Using frm As New frmImageToText
            If frm.openImageFile() Then
                frm.ShowDialog()
            End If
        End Using
    End Sub

    Private Sub tsmClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmClear.Click
        clearPictureBox()
        rtxtImgData.Clear()
    End Sub

    Private Sub tsmiPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiPaste.Click
        If Clipboard.ContainsText Then
            Dim txt As String = Clipboard.GetText
            If String.IsNullOrEmpty(txt) = False Then
                convertImageFromText(txt)
                rtxtImgData.Text = txt
            End If
        End If
    End Sub


End Class