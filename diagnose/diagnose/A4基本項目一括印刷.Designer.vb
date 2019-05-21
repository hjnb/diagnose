<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A4基本項目一括印刷
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
        Me.bloodTypeBox = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.circleTypeBox = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.dgvNamList = New System.Windows.Forms.DataGridView()
        CType(Me.dgvNamList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bloodTypeBox
        '
        Me.bloodTypeBox.FormattingEnabled = True
        Me.bloodTypeBox.Location = New System.Drawing.Point(277, 108)
        Me.bloodTypeBox.Name = "bloodTypeBox"
        Me.bloodTypeBox.Size = New System.Drawing.Size(121, 20)
        Me.bloodTypeBox.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(275, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "採血種類"
        '
        'circleTypeBox
        '
        Me.circleTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.circleTypeBox.FormattingEnabled = True
        Me.circleTypeBox.Location = New System.Drawing.Point(277, 53)
        Me.circleTypeBox.Name = "circleTypeBox"
        Me.circleTypeBox.Size = New System.Drawing.Size(121, 20)
        Me.circleTypeBox.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(275, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 12)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "健診項目の○印"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(71, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(285, 14)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "チェック有の人の基本項目印刷を一括で行います。"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(277, 359)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(121, 49)
        Me.btnPrint.TabIndex = 36
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(12, 9)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(56, 23)
        Me.btnCheckAll.TabIndex = 35
        Me.btnCheckAll.Text = "全チェック"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(275, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "その他の検査項目3"
        '
        'cb3
        '
        Me.cb3.FormattingEnabled = True
        Me.cb3.Location = New System.Drawing.Point(277, 239)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(121, 20)
        Me.cb3.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "その他の検査項目2"
        '
        'cb2
        '
        Me.cb2.FormattingEnabled = True
        Me.cb2.Location = New System.Drawing.Point(277, 201)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(121, 20)
        Me.cb2.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "その他の検査項目1"
        '
        'cb1
        '
        Me.cb1.FormattingEnabled = True
        Me.cb1.Location = New System.Drawing.Point(277, 163)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(121, 20)
        Me.cb1.TabIndex = 23
        '
        'dgvNamList
        '
        Me.dgvNamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNamList.Location = New System.Drawing.Point(12, 38)
        Me.dgvNamList.Name = "dgvNamList"
        Me.dgvNamList.RowTemplate.Height = 21
        Me.dgvNamList.Size = New System.Drawing.Size(237, 654)
        Me.dgvNamList.TabIndex = 21
        '
        'A4基本項目一括印刷
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
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.dgvNamList)
        Me.Name = "A4基本項目一括印刷"
        Me.Text = "A4基本項目一括印刷"
        CType(Me.dgvNamList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bloodTypeBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents circleTypeBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCheckAll As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb1 As System.Windows.Forms.ComboBox
    Friend WithEvents dgvNamList As System.Windows.Forms.DataGridView
End Class
