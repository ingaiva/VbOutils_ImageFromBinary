<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageToText
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOpenImageFile = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSerialiseToFile = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnSerialiseToClipBoardBase64 = New System.Windows.Forms.Button
        Me.btnSerialiseToClipBoardByteArray = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOpenImageFile
        '
        Me.btnOpenImageFile.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOpenImageFile.Location = New System.Drawing.Point(414, 24)
        Me.btnOpenImageFile.Name = "btnOpenImageFile"
        Me.btnOpenImageFile.Size = New System.Drawing.Size(37, 20)
        Me.btnOpenImageFile.TabIndex = 7
        Me.btnOpenImageFile.Text = "..."
        Me.btnOpenImageFile.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(396, 20)
        Me.TextBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sélectionnez l'image à sérialiser :"
        '
        'btnSerialiseToFile
        '
        Me.btnSerialiseToFile.Location = New System.Drawing.Point(305, 54)
        Me.btnSerialiseToFile.Name = "btnSerialiseToFile"
        Me.btnSerialiseToFile.Size = New System.Drawing.Size(146, 34)
        Me.btnSerialiseToFile.TabIndex = 4
        Me.btnSerialiseToFile.Text = "Sérialiser bytes dans un fichier"
        Me.btnSerialiseToFile.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(125, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(92, 117)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'btnSerialiseToClipBoardBase64
        '
        Me.btnSerialiseToClipBoardBase64.Location = New System.Drawing.Point(305, 137)
        Me.btnSerialiseToClipBoardBase64.Name = "btnSerialiseToClipBoardBase64"
        Me.btnSerialiseToClipBoardBase64.Size = New System.Drawing.Size(146, 34)
        Me.btnSerialiseToClipBoardBase64.TabIndex = 9
        Me.btnSerialiseToClipBoardBase64.Text = "Copier Base64String dans presse papiers"
        Me.btnSerialiseToClipBoardBase64.UseVisualStyleBackColor = True
        '
        'btnSerialiseToClipBoardByteArray
        '
        Me.btnSerialiseToClipBoardByteArray.Location = New System.Drawing.Point(305, 94)
        Me.btnSerialiseToClipBoardByteArray.Name = "btnSerialiseToClipBoardByteArray"
        Me.btnSerialiseToClipBoardByteArray.Size = New System.Drawing.Size(146, 34)
        Me.btnSerialiseToClipBoardByteArray.TabIndex = 10
        Me.btnSerialiseToClipBoardByteArray.Text = "Copier bytes dans presse papiers"
        Me.btnSerialiseToClipBoardByteArray.UseVisualStyleBackColor = True
        '
        'frmImageToText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 179)
        Me.Controls.Add(Me.btnSerialiseToClipBoardByteArray)
        Me.Controls.Add(Me.btnSerialiseToClipBoardBase64)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnOpenImageFile)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSerialiseToFile)
        Me.Name = "frmImageToText"
        Me.Text = "Sérialiser image sous forme de texte"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpenImageFile As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSerialiseToFile As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSerialiseToClipBoardBase64 As System.Windows.Forms.Button
    Friend WithEvents btnSerialiseToClipBoardByteArray As System.Windows.Forms.Button
End Class
