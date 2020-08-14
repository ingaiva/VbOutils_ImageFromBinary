<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSql
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
        Me.pnlRl = New System.Windows.Forms.Panel
        Me.jtxtPassWord = New System.Windows.Forms.TextBox
        Me.jtxtUser = New System.Windows.Forms.TextBox
        Me.lblVersionReseau = New System.Windows.Forms.Label
        Me.jbtnTryConnection = New System.Windows.Forms.Button
        Me.pnlServerReseau = New System.Windows.Forms.Panel
        Me.jcboServer = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblTitre = New System.Windows.Forms.Label
        Me.rdbtnAuthentificationWindows = New System.Windows.Forms.RadioButton
        Me.lblPassWord = New System.Windows.Forms.Label
        Me.rdbtnAuthentificationSql = New System.Windows.Forms.RadioButton
        Me.lblUser = New System.Windows.Forms.Label
        Me.cboBases = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnGetBasesFromServer = New System.Windows.Forms.Button
        Me.lblTable = New System.Windows.Forms.Label
        Me.txtReq = New System.Windows.Forms.TextBox
        Me.btnSav = New System.Windows.Forms.Button
        Me.btnConvertToImage = New System.Windows.Forms.Button
        Me.pnlRl.SuspendLayout()
        Me.pnlServerReseau.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRl
        '
        Me.pnlRl.AutoSize = True
        Me.pnlRl.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlRl.Controls.Add(Me.jtxtPassWord)
        Me.pnlRl.Controls.Add(Me.jtxtUser)
        Me.pnlRl.Controls.Add(Me.lblVersionReseau)
        Me.pnlRl.Controls.Add(Me.jbtnTryConnection)
        Me.pnlRl.Controls.Add(Me.pnlServerReseau)
        Me.pnlRl.Controls.Add(Me.lblTitre)
        Me.pnlRl.Controls.Add(Me.rdbtnAuthentificationWindows)
        Me.pnlRl.Controls.Add(Me.lblPassWord)
        Me.pnlRl.Controls.Add(Me.rdbtnAuthentificationSql)
        Me.pnlRl.Controls.Add(Me.lblUser)
        Me.pnlRl.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRl.Location = New System.Drawing.Point(0, 0)
        Me.pnlRl.Name = "pnlRl"
        Me.pnlRl.Size = New System.Drawing.Size(561, 133)
        Me.pnlRl.TabIndex = 29
        '
        'jtxtPassWord
        '
        Me.jtxtPassWord.Location = New System.Drawing.Point(196, 110)
        Me.jtxtPassWord.Name = "jtxtPassWord"
        Me.jtxtPassWord.Size = New System.Drawing.Size(224, 20)
        Me.jtxtPassWord.TabIndex = 24
        '
        'jtxtUser
        '
        Me.jtxtUser.Location = New System.Drawing.Point(196, 86)
        Me.jtxtUser.Name = "jtxtUser"
        Me.jtxtUser.Size = New System.Drawing.Size(224, 20)
        Me.jtxtUser.TabIndex = 23
        '
        'lblVersionReseau
        '
        Me.lblVersionReseau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVersionReseau.Location = New System.Drawing.Point(438, 3)
        Me.lblVersionReseau.Name = "lblVersionReseau"
        Me.lblVersionReseau.Size = New System.Drawing.Size(122, 24)
        Me.lblVersionReseau.TabIndex = 22
        Me.lblVersionReseau.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'jbtnTryConnection
        '
        Me.jbtnTryConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.jbtnTryConnection.Location = New System.Drawing.Point(428, 32)
        Me.jbtnTryConnection.Name = "jbtnTryConnection"
        Me.jbtnTryConnection.Size = New System.Drawing.Size(125, 23)
        Me.jbtnTryConnection.TabIndex = 17
        Me.jbtnTryConnection.Text = "Tester la connexion"
        '
        'pnlServerReseau
        '
        Me.pnlServerReseau.Controls.Add(Me.jcboServer)
        Me.pnlServerReseau.Controls.Add(Me.Label2)
        Me.pnlServerReseau.Location = New System.Drawing.Point(5, 32)
        Me.pnlServerReseau.Name = "pnlServerReseau"
        Me.pnlServerReseau.Size = New System.Drawing.Size(417, 22)
        Me.pnlServerReseau.TabIndex = 10
        '
        'jcboServer
        '
        Me.jcboServer.FormattingEnabled = True
        Me.jcboServer.Location = New System.Drawing.Point(99, 0)
        Me.jcboServer.Name = "jcboServer"
        Me.jcboServer.Size = New System.Drawing.Size(316, 21)
        Me.jcboServer.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nom du serveur :"
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.Location = New System.Drawing.Point(10, 7)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(158, 13)
        Me.lblTitre.TabIndex = 7
        Me.lblTitre.Text = "Paramètres de connexion :"
        '
        'rdbtnAuthentificationWindows
        '
        Me.rdbtnAuthentificationWindows.AutoSize = True
        Me.rdbtnAuthentificationWindows.Checked = True
        Me.rdbtnAuthentificationWindows.Location = New System.Drawing.Point(103, 64)
        Me.rdbtnAuthentificationWindows.Name = "rdbtnAuthentificationWindows"
        Me.rdbtnAuthentificationWindows.Size = New System.Drawing.Size(145, 17)
        Me.rdbtnAuthentificationWindows.TabIndex = 10
        Me.rdbtnAuthentificationWindows.TabStop = True
        Me.rdbtnAuthentificationWindows.Text = "Authentification Windows"
        Me.rdbtnAuthentificationWindows.UseVisualStyleBackColor = True
        '
        'lblPassWord
        '
        Me.lblPassWord.AutoSize = True
        Me.lblPassWord.Location = New System.Drawing.Point(100, 117)
        Me.lblPassWord.Name = "lblPassWord"
        Me.lblPassWord.Size = New System.Drawing.Size(77, 13)
        Me.lblPassWord.TabIndex = 15
        Me.lblPassWord.Text = "Mot de passe :"
        '
        'rdbtnAuthentificationSql
        '
        Me.rdbtnAuthentificationSql.AutoSize = True
        Me.rdbtnAuthentificationSql.Location = New System.Drawing.Point(265, 64)
        Me.rdbtnAuthentificationSql.Name = "rdbtnAuthentificationSql"
        Me.rdbtnAuthentificationSql.Size = New System.Drawing.Size(156, 17)
        Me.rdbtnAuthentificationSql.TabIndex = 11
        Me.rdbtnAuthentificationSql.Text = "Authentification SQL Server"
        Me.rdbtnAuthentificationSql.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(100, 91)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(90, 13)
        Me.lblUser.TabIndex = 13
        Me.lblUser.Text = "Nom d'utilisateur :"
        '
        'cboBases
        '
        Me.cboBases.FormattingEnabled = True
        Me.cboBases.Location = New System.Drawing.Point(5, 167)
        Me.cboBases.Name = "cboBases"
        Me.cboBases.Size = New System.Drawing.Size(417, 21)
        Me.cboBases.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 15)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Base de données"
        '
        'btnGetBasesFromServer
        '
        Me.btnGetBasesFromServer.BackColor = System.Drawing.Color.Silver
        Me.btnGetBasesFromServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetBasesFromServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetBasesFromServer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnGetBasesFromServer.Location = New System.Drawing.Point(196, 136)
        Me.btnGetBasesFromServer.Name = "btnGetBasesFromServer"
        Me.btnGetBasesFromServer.Size = New System.Drawing.Size(224, 24)
        Me.btnGetBasesFromServer.TabIndex = 78
        Me.btnGetBasesFromServer.Text = "Rechercher la base sur serveur"
        Me.btnGetBasesFromServer.UseVisualStyleBackColor = False
        '
        'lblTable
        '
        Me.lblTable.AutoSize = True
        Me.lblTable.Location = New System.Drawing.Point(2, 197)
        Me.lblTable.Name = "lblTable"
        Me.lblTable.Size = New System.Drawing.Size(48, 13)
        Me.lblTable.TabIndex = 80
        Me.lblTable.Text = "Requête"
        '
        'txtReq
        '
        Me.txtReq.Location = New System.Drawing.Point(5, 213)
        Me.txtReq.Multiline = True
        Me.txtReq.Name = "txtReq"
        Me.txtReq.Size = New System.Drawing.Size(548, 72)
        Me.txtReq.TabIndex = 79
        Me.txtReq.Text = "SELECT  [resData]   FROM [Resource] where idRes =''"
        '
        'btnSav
        '
        Me.btnSav.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSav.Location = New System.Drawing.Point(259, 301)
        Me.btnSav.Name = "btnSav"
        Me.btnSav.Size = New System.Drawing.Size(161, 23)
        Me.btnSav.TabIndex = 81
        Me.btnSav.Text = "Enregistrer dans un fichier txt"
        Me.btnSav.UseVisualStyleBackColor = True
        '
        'btnConvertToImage
        '
        Me.btnConvertToImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConvertToImage.Location = New System.Drawing.Point(426, 301)
        Me.btnConvertToImage.Name = "btnConvertToImage"
        Me.btnConvertToImage.Size = New System.Drawing.Size(127, 23)
        Me.btnConvertToImage.TabIndex = 82
        Me.btnConvertToImage.Text = "Afficher image"
        Me.btnConvertToImage.UseVisualStyleBackColor = True
        '
        'frmSql
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 326)
        Me.Controls.Add(Me.btnConvertToImage)
        Me.Controls.Add(Me.btnSav)
        Me.Controls.Add(Me.lblTable)
        Me.Controls.Add(Me.txtReq)
        Me.Controls.Add(Me.btnGetBasesFromServer)
        Me.Controls.Add(Me.cboBases)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlRl)
        Me.Name = "frmSql"
        Me.Text = "Extraction de données binaires de la base de données."
        Me.pnlRl.ResumeLayout(False)
        Me.pnlRl.PerformLayout()
        Me.pnlServerReseau.ResumeLayout(False)
        Me.pnlServerReseau.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlRl As System.Windows.Forms.Panel
    Friend WithEvents lblVersionReseau As System.Windows.Forms.Label
    Friend WithEvents jbtnTryConnection As System.Windows.Forms.Button
    Friend WithEvents pnlServerReseau As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents rdbtnAuthentificationWindows As System.Windows.Forms.RadioButton
    Friend WithEvents lblPassWord As System.Windows.Forms.Label
    Friend WithEvents rdbtnAuthentificationSql As System.Windows.Forms.RadioButton
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents jcboServer As System.Windows.Forms.ComboBox
    Friend WithEvents jtxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents jtxtUser As System.Windows.Forms.TextBox
    Friend WithEvents cboBases As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetBasesFromServer As System.Windows.Forms.Button
    Friend WithEvents lblTable As System.Windows.Forms.Label
    Friend WithEvents txtReq As System.Windows.Forms.TextBox
    Friend WithEvents btnSav As System.Windows.Forms.Button
    Friend WithEvents btnConvertToImage As System.Windows.Forms.Button
End Class
