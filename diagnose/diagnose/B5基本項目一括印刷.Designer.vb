<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B5基本項目一括印刷
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvNamList = New System.Windows.Forms.DataGridView()
        Me.checkSenketu = New System.Windows.Forms.CheckBox()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb6 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb5 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb4 = New System.Windows.Forms.ComboBox()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.circleTypeBox = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bloodTypeBox = New System.Windows.Forms.ComboBox()
        CType(Me.dgvNamList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNamList
        '
        Me.dgvNamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNamList.Location = New System.Drawing.Point(12, 38)
        Me.dgvNamList.Name = "dgvNamList"
        Me.dgvNamList.RowTemplate.Height = 21
        Me.dgvNamList.Size = New System.Drawing.Size(237, 654)
        Me.dgvNamList.TabIndex = 0
        '
        'checkSenketu
        '
        Me.checkSenketu.AutoSize = True
        Me.checkSenketu.Location = New System.Drawing.Point(277, 149)
        Me.checkSenketu.Name = "checkSenketu"
        Me.checkSenketu.Size = New System.Drawing.Size(96, 16)
        Me.checkSenketu.TabIndex = 1
        Me.checkSenketu.Text = "尿潜血枠作成"
        Me.checkSenketu.UseVisualStyleBackColor = True
        '
        'cb1
        '
        Me.cb1.FormattingEnabled = True
        Me.cb1.Location = New System.Drawing.Point(277, 202)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(121, 20)
        Me.cb1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "その他の検査項目1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "その他の検査項目2"
        '
        'cb2
        '
        Me.cb2.FormattingEnabled = True
        Me.cb2.Location = New System.Drawing.Point(277, 240)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(121, 20)
        Me.cb2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(275, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "その他の検査項目3"
        '
        'cb3
        '
        Me.cb3.FormattingEnabled = True
        Me.cb3.Location = New System.Drawing.Point(277, 278)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(121, 20)
        Me.cb3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "その他の検査項目6"
        '
        'cb6
        '
        Me.cb6.FormattingEnabled = True
        Me.cb6.Location = New System.Drawing.Point(277, 392)
        Me.cb6.Name = "cb6"
        Me.cb6.Size = New System.Drawing.Size(121, 20)
        Me.cb6.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(275, 339)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "その他の検査項目5"
        '
        'cb5
        '
        Me.cb5.FormattingEnabled = True
        Me.cb5.Location = New System.Drawing.Point(277, 354)
        Me.cb5.Name = "cb5"
        Me.cb5.Size = New System.Drawing.Size(121, 20)
        Me.cb5.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(275, 301)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "その他の検査項目4"
        '
        'cb4
        '
        Me.cb4.FormattingEnabled = True
        Me.cb4.Location = New System.Drawing.Point(277, 316)
        Me.cb4.Name = "cb4"
        Me.cb4.Size = New System.Drawing.Size(121, 20)
        Me.cb4.TabIndex = 8
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(12, 9)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(56, 23)
        Me.btnCheckAll.TabIndex = 14
        Me.btnCheckAll.Text = "全チェック"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(277, 544)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(121, 49)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(71, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(285, 14)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "チェック有の人の基本項目印刷を一括で行います。"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(275, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "健診項目の○印"
        '
        'circleTypeBox
        '
        Me.circleTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.circleTypeBox.FormattingEnabled = True
        Me.circleTypeBox.Location = New System.Drawing.Point(277, 53)
        Me.circleTypeBox.Name = "circleTypeBox"
        Me.circleTypeBox.Size = New System.Drawing.Size(121, 20)
        Me.circleTypeBox.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(275, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "採血種類"
        '
        'bloodTypeBox
        '
        Me.bloodTypeBox.FormattingEnabled = True
        Me.bloodTypeBox.Location = New System.Drawing.Point(277, 108)
        Me.bloodTypeBox.Name = "bloodTypeBox"
        Me.bloodTypeBox.Size = New System.Drawing.Size(121, 20)
        Me.bloodTypeBox.TabIndex = 20
        '
        'B5基本項目一括印刷
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 704)
        Me.Controls.Add(Me.bloodTypeBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.circleTypeBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCheckAll)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cb6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cb4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.checkSenketu)
        Me.Controls.Add(Me.dgvNamList)
        Me.Name = "B5基本項目一括印刷"
        Me.Text = "B5基本項目一括印刷"
        CType(Me.dgvNamList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvNamList As System.Windows.Forms.DataGridView
    Friend WithEvents checkSenketu As System.Windows.Forms.CheckBox
    Friend WithEvents cb1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb4 As System.Windows.Forms.ComboBox
    Friend WithEvents btnCheckAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents circleTypeBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents bloodTypeBox As System.Windows.Forms.ComboBox
End Class
