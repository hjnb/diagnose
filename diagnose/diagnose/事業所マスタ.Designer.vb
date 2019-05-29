<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 事業所マスタ
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.indBox = New System.Windows.Forms.TextBox()
        Me.kanaBox = New System.Windows.Forms.TextBox()
        Me.telBox = New System.Windows.Forms.TextBox()
        Me.faxBox = New System.Windows.Forms.TextBox()
        Me.tantoBox = New System.Windows.Forms.TextBox()
        Me.postBox = New System.Windows.Forms.TextBox()
        Me.jyuBox = New System.Windows.Forms.TextBox()
        Me.codBox = New System.Windows.Forms.TextBox()
        Me.sYmdBox = New ymdBox.ymdBox()
        Me.tan1Box = New System.Windows.Forms.TextBox()
        Me.tan2Box = New System.Windows.Forms.TextBox()
        Me.commentBox = New System.Windows.Forms.TextBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnEnvelope = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rbtnPreview = New System.Windows.Forms.RadioButton()
        Me.rbtnPrint = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvMaster = New System.Windows.Forms.DataGridView()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.dgvMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(60, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "事業所名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(60, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "カナ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(60, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "TEL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(60, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "〒"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(60, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "請求ｺｰﾄﾞ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(60, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "単価１"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(60, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "コメント"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(279, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "単価２"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(279, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "最終日付"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(279, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "住所"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(279, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 16)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "FAX"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(493, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "担当者"
        '
        'indBox
        '
        Me.indBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.indBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.indBox.Location = New System.Drawing.Point(142, 36)
        Me.indBox.Name = "indBox"
        Me.indBox.Size = New System.Drawing.Size(262, 23)
        Me.indBox.TabIndex = 12
        '
        'kanaBox
        '
        Me.kanaBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kanaBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.kanaBox.Location = New System.Drawing.Point(142, 66)
        Me.kanaBox.Name = "kanaBox"
        Me.kanaBox.Size = New System.Drawing.Size(116, 23)
        Me.kanaBox.TabIndex = 13
        '
        'telBox
        '
        Me.telBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.telBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.telBox.Location = New System.Drawing.Point(142, 96)
        Me.telBox.Name = "telBox"
        Me.telBox.Size = New System.Drawing.Size(116, 23)
        Me.telBox.TabIndex = 14
        '
        'faxBox
        '
        Me.faxBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.faxBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.faxBox.Location = New System.Drawing.Point(356, 96)
        Me.faxBox.Name = "faxBox"
        Me.faxBox.Size = New System.Drawing.Size(116, 23)
        Me.faxBox.TabIndex = 15
        '
        'tantoBox
        '
        Me.tantoBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tantoBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.tantoBox.Location = New System.Drawing.Point(564, 96)
        Me.tantoBox.Name = "tantoBox"
        Me.tantoBox.Size = New System.Drawing.Size(116, 23)
        Me.tantoBox.TabIndex = 16
        '
        'postBox
        '
        Me.postBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.postBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.postBox.Location = New System.Drawing.Point(142, 127)
        Me.postBox.Name = "postBox"
        Me.postBox.Size = New System.Drawing.Size(116, 23)
        Me.postBox.TabIndex = 17
        '
        'jyuBox
        '
        Me.jyuBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.jyuBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.jyuBox.Location = New System.Drawing.Point(356, 127)
        Me.jyuBox.Name = "jyuBox"
        Me.jyuBox.Size = New System.Drawing.Size(418, 23)
        Me.jyuBox.TabIndex = 18
        '
        'codBox
        '
        Me.codBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.codBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.codBox.Location = New System.Drawing.Point(142, 159)
        Me.codBox.Name = "codBox"
        Me.codBox.Size = New System.Drawing.Size(116, 23)
        Me.codBox.TabIndex = 19
        '
        'sYmdBox
        '
        Me.sYmdBox.boxType = 1
        Me.sYmdBox.DateText = ""
        Me.sYmdBox.EraLabelText = "R01"
        Me.sYmdBox.EraText = ""
        Me.sYmdBox.Location = New System.Drawing.Point(355, 157)
        Me.sYmdBox.MonthLabelText = "05"
        Me.sYmdBox.MonthText = ""
        Me.sYmdBox.Name = "sYmdBox"
        Me.sYmdBox.Size = New System.Drawing.Size(112, 30)
        Me.sYmdBox.TabIndex = 20
        '
        'tan1Box
        '
        Me.tan1Box.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tan1Box.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tan1Box.Location = New System.Drawing.Point(142, 191)
        Me.tan1Box.Name = "tan1Box"
        Me.tan1Box.Size = New System.Drawing.Size(116, 23)
        Me.tan1Box.TabIndex = 21
        '
        'tan2Box
        '
        Me.tan2Box.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tan2Box.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tan2Box.Location = New System.Drawing.Point(356, 191)
        Me.tan2Box.Name = "tan2Box"
        Me.tan2Box.Size = New System.Drawing.Size(116, 23)
        Me.tan2Box.TabIndex = 22
        '
        'commentBox
        '
        Me.commentBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.commentBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.commentBox.Location = New System.Drawing.Point(142, 235)
        Me.commentBox.Name = "commentBox"
        Me.commentBox.Size = New System.Drawing.Size(417, 23)
        Me.commentBox.TabIndex = 23
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(589, 225)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(70, 33)
        Me.btnRegist.TabIndex = 24
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(658, 225)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(70, 33)
        Me.btnDelete.TabIndex = 25
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(727, 225)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(70, 33)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnEnvelope
        '
        Me.btnEnvelope.Location = New System.Drawing.Point(824, 223)
        Me.btnEnvelope.Name = "btnEnvelope"
        Me.btnEnvelope.Size = New System.Drawing.Size(70, 33)
        Me.btnEnvelope.TabIndex = 27
        Me.btnEnvelope.Text = "封筒"
        Me.btnEnvelope.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(822, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 12)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "角形２号（手差し）"
        '
        'rbtnPreview
        '
        Me.rbtnPreview.AutoSize = True
        Me.rbtnPreview.Location = New System.Drawing.Point(673, 274)
        Me.rbtnPreview.Name = "rbtnPreview"
        Me.rbtnPreview.Size = New System.Drawing.Size(63, 16)
        Me.rbtnPreview.TabIndex = 29
        Me.rbtnPreview.TabStop = True
        Me.rbtnPreview.Text = "ﾌﾟﾚﾋﾞｭｰ"
        Me.rbtnPreview.UseVisualStyleBackColor = True
        '
        'rbtnPrint
        '
        Me.rbtnPrint.AutoSize = True
        Me.rbtnPrint.Location = New System.Drawing.Point(750, 274)
        Me.rbtnPrint.Name = "rbtnPrint"
        Me.rbtnPrint.Size = New System.Drawing.Size(47, 16)
        Me.rbtnPrint.TabIndex = 30
        Me.rbtnPrint.TabStop = True
        Me.rbtnPrint.Text = "印刷"
        Me.rbtnPrint.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(336, 301)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(200, 14)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "ﾀﾞﾌﾞﾙｸﾘｯｸした項目名で並べます。"
        '
        'dgvMaster
        '
        Me.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaster.Location = New System.Drawing.Point(63, 329)
        Me.dgvMaster.Name = "dgvMaster"
        Me.dgvMaster.RowTemplate.Height = 21
        Me.dgvMaster.Size = New System.Drawing.Size(829, 348)
        Me.dgvMaster.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(822, 210)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(150, 11)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "プロパティで手差し設定して下さい"
        '
        '事業所マスタ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 692)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dgvMaster)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.rbtnPrint)
        Me.Controls.Add(Me.rbtnPreview)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnEnvelope)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.commentBox)
        Me.Controls.Add(Me.tan2Box)
        Me.Controls.Add(Me.tan1Box)
        Me.Controls.Add(Me.sYmdBox)
        Me.Controls.Add(Me.codBox)
        Me.Controls.Add(Me.jyuBox)
        Me.Controls.Add(Me.postBox)
        Me.Controls.Add(Me.tantoBox)
        Me.Controls.Add(Me.faxBox)
        Me.Controls.Add(Me.telBox)
        Me.Controls.Add(Me.kanaBox)
        Me.Controls.Add(Me.indBox)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "事業所マスタ"
        Me.Text = "事業所マスタ"
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents indBox As System.Windows.Forms.TextBox
    Friend WithEvents kanaBox As System.Windows.Forms.TextBox
    Friend WithEvents telBox As System.Windows.Forms.TextBox
    Friend WithEvents faxBox As System.Windows.Forms.TextBox
    Friend WithEvents tantoBox As System.Windows.Forms.TextBox
    Friend WithEvents postBox As System.Windows.Forms.TextBox
    Friend WithEvents jyuBox As System.Windows.Forms.TextBox
    Friend WithEvents codBox As System.Windows.Forms.TextBox
    Friend WithEvents sYmdBox As ymdBox.ymdBox
    Friend WithEvents tan1Box As System.Windows.Forms.TextBox
    Friend WithEvents tan2Box As System.Windows.Forms.TextBox
    Friend WithEvents commentBox As System.Windows.Forms.TextBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnEnvelope As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rbtnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPrint As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvMaster As System.Windows.Forms.DataGridView
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
