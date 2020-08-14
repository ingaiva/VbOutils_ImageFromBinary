<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadFromText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReadFromText))
        Me.rtxtImgData = New System.Windows.Forms.RichTextBox
        Me.pic = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tsmiFileOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiSql = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiImageToText = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.tsmiConvert = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmClear = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tsmiPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip
        Me.tsmiSaveImage = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtxtImgData
        '
        Me.rtxtImgData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtImgData.Location = New System.Drawing.Point(0, 23)
        Me.rtxtImgData.Name = "rtxtImgData"
        Me.rtxtImgData.Size = New System.Drawing.Size(571, 339)
        Me.rtxtImgData.TabIndex = 1
        Me.rtxtImgData.Text = ""
        '
        'pic
        '
        Me.pic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pic.Location = New System.Drawing.Point(0, 23)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(207, 339)
        Me.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic.TabIndex = 5
        Me.pic.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtxtImgData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pic)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MenuStrip3)
        Me.SplitContainer1.Size = New System.Drawing.Size(782, 394)
        Me.SplitContainer1.SplitterDistance = 571
        Me.SplitContainer1.TabIndex = 6
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Ivory
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiPaste, Me.tsmiFileOpen, Me.tsmiSql, Me.tsmiImageToText})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 32)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmiFileOpen
        '
        Me.tsmiFileOpen.Image = CType(resources.GetObject("tsmiFileOpen.Image"), System.Drawing.Image)
        Me.tsmiFileOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiFileOpen.Name = "tsmiFileOpen"
        Me.tsmiFileOpen.Size = New System.Drawing.Size(232, 28)
        Me.tsmiFileOpen.Text = "Ouvrir le fichier de l'image sérialisée"
        '
        'tsmiSql
        '
        Me.tsmiSql.Image = CType(resources.GetObject("tsmiSql.Image"), System.Drawing.Image)
        Me.tsmiSql.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiSql.Name = "tsmiSql"
        Me.tsmiSql.Size = New System.Drawing.Size(114, 28)
        Me.tsmiSql.Text = "Extraction Sql"
        '
        'tsmiImageToText
        '
        Me.tsmiImageToText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsmiImageToText.Image = CType(resources.GetObject("tsmiImageToText.Image"), System.Drawing.Image)
        Me.tsmiImageToText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiImageToText.Name = "tsmiImageToText"
        Me.tsmiImageToText.Size = New System.Drawing.Size(145, 28)
        Me.tsmiImageToText.Text = "Tool Image To Text"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Ivory
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiConvert, Me.tsmClear})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 362)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(571, 32)
        Me.MenuStrip2.TabIndex = 8
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'tsmiConvert
        '
        Me.tsmiConvert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsmiConvert.Image = CType(resources.GetObject("tsmiConvert.Image"), System.Drawing.Image)
        Me.tsmiConvert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiConvert.Name = "tsmiConvert"
        Me.tsmiConvert.Size = New System.Drawing.Size(187, 28)
        Me.tsmiConvert.Text = "Convertir ce texte en image"
        '
        'tsmClear
        '
        Me.tsmClear.Image = CType(resources.GetObject("tsmClear.Image"), System.Drawing.Image)
        Me.tsmClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmClear.Name = "tsmClear"
        Me.tsmClear.Size = New System.Drawing.Size(79, 28)
        Me.tsmClear.Text = "Effacer"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(571, 23)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Données binaires : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(207, 23)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Image : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tsmiPaste
        '
        Me.tsmiPaste.Image = CType(resources.GetObject("tsmiPaste.Image"), System.Drawing.Image)
        Me.tsmiPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiPaste.Name = "tsmiPaste"
        Me.tsmiPaste.Size = New System.Drawing.Size(74, 28)
        Me.tsmiPaste.Text = "Coller"
        '
        'MenuStrip3
        '
        Me.MenuStrip3.BackColor = System.Drawing.Color.Ivory
        Me.MenuStrip3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSaveImage})
        Me.MenuStrip3.Location = New System.Drawing.Point(0, 362)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(207, 32)
        Me.MenuStrip3.TabIndex = 11
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'tsmiSaveImage
        '
        Me.tsmiSaveImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsmiSaveImage.Image = CType(resources.GetObject("tsmiSaveImage.Image"), System.Drawing.Image)
        Me.tsmiSaveImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmiSaveImage.Name = "tsmiSaveImage"
        Me.tsmiSaveImage.Size = New System.Drawing.Size(135, 28)
        Me.tsmiSaveImage.Text = "Enregistrer image"
        '
        'FormReadFromText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(782, 426)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormReadFromText"
        Me.Text = "Collez le texte de l'image sérialisée dans la zone de texte ou ouvrez le fichier " & _
            "de l'image sérialisée"
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents rtxtImgData As System.Windows.Forms.RichTextBox
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSql As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiImageToText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiConvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tsmiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip3 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiSaveImage As System.Windows.Forms.ToolStripMenuItem
End Class
