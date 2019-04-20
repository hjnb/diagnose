<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 受診者マスタ
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.indBox = New System.Windows.Forms.ComboBox()
        Me.namBox = New System.Windows.Forms.TextBox()
        Me.sexBox = New System.Windows.Forms.TextBox()
        Me.telBox = New System.Windows.Forms.TextBox()
        Me.TanBox = New System.Windows.Forms.TextBox()
        Me.kanaBox = New System.Windows.Forms.TextBox()
        Me.birthBox = New ymdBox.ymdBox()
        Me.postBox = New System.Windows.Forms.TextBox()
        Me.jyuBox = New System.Windows.Forms.TextBox()
        Me.commentBox = New System.Windows.Forms.TextBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnA4Paper = New System.Windows.Forms.Button()
        Me.btnB5Paper = New System.Windows.Forms.Button()
        Me.btnNameList = New System.Windows.Forms.Button()
        Me.rbtnPreview = New System.Windows.Forms.RadioButton()
        Me.rbtnPrint = New System.Windows.Forms.RadioButton()
        Me.dgvMaster = New System.Windows.Forms.DataGridView()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        CType(Me.dgvMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(69, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "事業所名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(69, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "氏名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "性別"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(69, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "TEL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(69, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "単価"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(197, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "１：男　２：女"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(360, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "カナ"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(360, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "生年月日"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(360, 135)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "〒"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(360, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "コメント"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(184, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 12)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "ダブルクリックした項目名で並べます。"
        '
        'indBox
        '
        Me.indBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.indBox.FormattingEnabled = True
        Me.indBox.Location = New System.Drawing.Point(160, 32)
        Me.indBox.Name = "indBox"
        Me.indBox.Size = New System.Drawing.Size(296, 24)
        Me.indBox.TabIndex = 100
        '
        'namBox
        '
        Me.namBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.namBox.Location = New System.Drawing.Point(160, 66)
        Me.namBox.Name = "namBox"
        Me.namBox.Size = New System.Drawing.Size(152, 23)
        Me.namBox.TabIndex = 101
        '
        'sexBox
        '
        Me.sexBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sexBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.sexBox.Location = New System.Drawing.Point(160, 98)
        Me.sexBox.MaxLength = 1
        Me.sexBox.Name = "sexBox"
        Me.sexBox.Size = New System.Drawing.Size(29, 23)
        Me.sexBox.TabIndex = 103
        Me.sexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'telBox
        '
        Me.telBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.telBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.telBox.Location = New System.Drawing.Point(160, 133)
        Me.telBox.Name = "telBox"
        Me.telBox.Size = New System.Drawing.Size(114, 23)
        Me.telBox.TabIndex = 105
        '
        'TanBox
        '
        Me.TanBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TanBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TanBox.Location = New System.Drawing.Point(160, 166)
        Me.TanBox.Name = "TanBox"
        Me.TanBox.Size = New System.Drawing.Size(114, 23)
        Me.TanBox.TabIndex = 108
        '
        'kanaBox
        '
        Me.kanaBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kanaBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.kanaBox.Location = New System.Drawing.Point(440, 66)
        Me.kanaBox.Name = "kanaBox"
        Me.kanaBox.Size = New System.Drawing.Size(152, 23)
        Me.kanaBox.TabIndex = 102
        '
        'birthBox
        '
        Me.birthBox.boxType = 1
        Me.birthBox.DateText = ""
        Me.birthBox.EraLabelText = "H31"
        Me.birthBox.EraText = ""
        Me.birthBox.Location = New System.Drawing.Point(439, 96)
        Me.birthBox.MonthLabelText = "04"
        Me.birthBox.MonthText = ""
        Me.birthBox.Name = "birthBox"
        Me.birthBox.Size = New System.Drawing.Size(112, 30)
        Me.birthBox.TabIndex = 104
        '
        'postBox
        '
        Me.postBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.postBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.postBox.Location = New System.Drawing.Point(440, 133)
        Me.postBox.Name = "postBox"
        Me.postBox.Size = New System.Drawing.Size(92, 23)
        Me.postBox.TabIndex = 106
        '
        'jyuBox
        '
        Me.jyuBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.jyuBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.jyuBox.Location = New System.Drawing.Point(549, 133)
        Me.jyuBox.Name = "jyuBox"
        Me.jyuBox.Size = New System.Drawing.Size(304, 23)
        Me.jyuBox.TabIndex = 107
        '
        'commentBox
        '
        Me.commentBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.commentBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.commentBox.Location = New System.Drawing.Point(440, 166)
        Me.commentBox.Name = "commentBox"
        Me.commentBox.Size = New System.Drawing.Size(413, 23)
        Me.commentBox.TabIndex = 109
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(340, 209)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(75, 32)
        Me.btnRegist.TabIndex = 110
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(414, 209)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 32)
        Me.btnDelete.TabIndex = 111
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnA4Paper
        '
        Me.btnA4Paper.Location = New System.Drawing.Point(562, 209)
        Me.btnA4Paper.Name = "btnA4Paper"
        Me.btnA4Paper.Size = New System.Drawing.Size(75, 32)
        Me.btnA4Paper.TabIndex = 113
        Me.btnA4Paper.Text = "診断書A4"
        Me.btnA4Paper.UseVisualStyleBackColor = True
        '
        'btnB5Paper
        '
        Me.btnB5Paper.Location = New System.Drawing.Point(488, 209)
        Me.btnB5Paper.Name = "btnB5Paper"
        Me.btnB5Paper.Size = New System.Drawing.Size(75, 32)
        Me.btnB5Paper.TabIndex = 112
        Me.btnB5Paper.Text = "診断書B5"
        Me.btnB5Paper.UseVisualStyleBackColor = True
        '
        'btnNameList
        '
        Me.btnNameList.Location = New System.Drawing.Point(636, 209)
        Me.btnNameList.Name = "btnNameList"
        Me.btnNameList.Size = New System.Drawing.Size(75, 32)
        Me.btnNameList.TabIndex = 114
        Me.btnNameList.Text = "名簿"
        Me.btnNameList.UseVisualStyleBackColor = True
        '
        'rbtnPreview
        '
        Me.rbtnPreview.AutoSize = True
        Me.rbtnPreview.Location = New System.Drawing.Point(723, 221)
        Me.rbtnPreview.Name = "rbtnPreview"
        Me.rbtnPreview.Size = New System.Drawing.Size(63, 16)
        Me.rbtnPreview.TabIndex = 115
        Me.rbtnPreview.TabStop = True
        Me.rbtnPreview.Text = "ﾌﾟﾚﾋﾞｭｰ"
        Me.rbtnPreview.UseVisualStyleBackColor = True
        '
        'rbtnPrint
        '
        Me.rbtnPrint.AutoSize = True
        Me.rbtnPrint.Location = New System.Drawing.Point(792, 221)
        Me.rbtnPrint.Name = "rbtnPrint"
        Me.rbtnPrint.Size = New System.Drawing.Size(47, 16)
        Me.rbtnPrint.TabIndex = 116
        Me.rbtnPrint.TabStop = True
        Me.rbtnPrint.Text = "印刷"
        Me.rbtnPrint.UseVisualStyleBackColor = True
        '
        'dgvMaster
        '
        Me.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaster.Location = New System.Drawing.Point(124, 273)
        Me.dgvMaster.Name = "dgvMaster"
        Me.dgvMaster.RowTemplate.Height = 21
        Me.dgvMaster.Size = New System.Drawing.Size(747, 402)
        Me.dgvMaster.TabIndex = 117
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(792, 221)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 116
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "印刷"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        '受診者マスタ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 687)
        Me.Controls.Add(Me.dgvMaster)
        Me.Controls.Add(Me.rbtnPrint)
        Me.Controls.Add(Me.rbtnPreview)
        Me.Controls.Add(Me.btnNameList)
        Me.Controls.Add(Me.btnA4Paper)
        Me.Controls.Add(Me.btnB5Paper)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.commentBox)
        Me.Controls.Add(Me.jyuBox)
        Me.Controls.Add(Me.postBox)
        Me.Controls.Add(Me.birthBox)
        Me.Controls.Add(Me.kanaBox)
        Me.Controls.Add(Me.TanBox)
        Me.Controls.Add(Me.telBox)
        Me.Controls.Add(Me.sexBox)
        Me.Controls.Add(Me.namBox)
        Me.Controls.Add(Me.indBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "受診者マスタ"
        Me.Text = "受診者マスタ"
        CType(Me.dgvMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents indBox As System.Windows.Forms.ComboBox
    Friend WithEvents namBox As System.Windows.Forms.TextBox
    Friend WithEvents sexBox As System.Windows.Forms.TextBox
    Friend WithEvents telBox As System.Windows.Forms.TextBox
    Friend WithEvents TanBox As System.Windows.Forms.TextBox
    Friend WithEvents kanaBox As System.Windows.Forms.TextBox
    Friend WithEvents birthBox As ymdBox.ymdBox
    Friend WithEvents postBox As System.Windows.Forms.TextBox
    Friend WithEvents jyuBox As System.Windows.Forms.TextBox
    Friend WithEvents commentBox As System.Windows.Forms.TextBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnA4Paper As System.Windows.Forms.Button
    Friend WithEvents btnB5Paper As System.Windows.Forms.Button
    Friend WithEvents btnNameList As System.Windows.Forms.Button
    Friend WithEvents rbtnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPrint As System.Windows.Forms.RadioButton
    Friend WithEvents dgvMaster As System.Windows.Forms.DataGridView
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
