<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 健診結果報告書
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
        Me.indBox = New System.Windows.Forms.ComboBox()
        Me.fromYmdBox = New ymdBox.ymdBox()
        Me.toYmdBox = New ymdBox.ymdBox()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.totalLabel = New System.Windows.Forms.Label()
        Me.syokenLabel = New System.Windows.Forms.Label()
        Me.sijiLabel = New System.Windows.Forms.Label()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "事業所名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "受診日"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 488)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "所見者数"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 451)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "受診者数"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 525)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "医師指示数"
        '
        'indBox
        '
        Me.indBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.indBox.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.indBox.FormattingEnabled = True
        Me.indBox.Location = New System.Drawing.Point(158, 24)
        Me.indBox.Name = "indBox"
        Me.indBox.Size = New System.Drawing.Size(317, 24)
        Me.indBox.TabIndex = 5
        '
        'fromYmdBox
        '
        Me.fromYmdBox.boxType = 3
        Me.fromYmdBox.DateText = ""
        Me.fromYmdBox.EraLabelText = "R01"
        Me.fromYmdBox.EraText = ""
        Me.fromYmdBox.Location = New System.Drawing.Point(157, 55)
        Me.fromYmdBox.MonthLabelText = "07"
        Me.fromYmdBox.MonthText = ""
        Me.fromYmdBox.Name = "fromYmdBox"
        Me.fromYmdBox.Size = New System.Drawing.Size(145, 46)
        Me.fromYmdBox.TabIndex = 6
        Me.fromYmdBox.textReadOnly = False
        '
        'toYmdBox
        '
        Me.toYmdBox.boxType = 3
        Me.toYmdBox.DateText = ""
        Me.toYmdBox.EraLabelText = "R01"
        Me.toYmdBox.EraText = ""
        Me.toYmdBox.Location = New System.Drawing.Point(334, 55)
        Me.toYmdBox.MonthLabelText = "07"
        Me.toYmdBox.MonthText = ""
        Me.toYmdBox.Name = "toYmdBox"
        Me.toYmdBox.Size = New System.Drawing.Size(145, 46)
        Me.toYmdBox.TabIndex = 7
        Me.toYmdBox.textReadOnly = False
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(328, 131)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(69, 31)
        Me.btnExecute.TabIndex = 8
        Me.btnExecute.Text = "実行"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(396, 131)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(69, 31)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(306, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "～"
        '
        'totalLabel
        '
        Me.totalLabel.AutoSize = True
        Me.totalLabel.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.totalLabel.Location = New System.Drawing.Point(159, 448)
        Me.totalLabel.Name = "totalLabel"
        Me.totalLabel.Size = New System.Drawing.Size(0, 16)
        Me.totalLabel.TabIndex = 11
        '
        'syokenLabel
        '
        Me.syokenLabel.AutoSize = True
        Me.syokenLabel.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.syokenLabel.Location = New System.Drawing.Point(159, 485)
        Me.syokenLabel.Name = "syokenLabel"
        Me.syokenLabel.Size = New System.Drawing.Size(0, 16)
        Me.syokenLabel.TabIndex = 12
        '
        'sijiLabel
        '
        Me.sijiLabel.AutoSize = True
        Me.sijiLabel.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sijiLabel.Location = New System.Drawing.Point(159, 522)
        Me.sijiLabel.Name = "sijiLabel"
        Me.sijiLabel.Size = New System.Drawing.Size(0, 16)
        Me.sijiLabel.TabIndex = 13
        '
        'dgvResult
        '
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(59, 188)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.RowTemplate.Height = 21
        Me.dgvResult.Size = New System.Drawing.Size(337, 242)
        Me.dgvResult.TabIndex = 14
        '
        '健診結果報告書
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 615)
        Me.Controls.Add(Me.dgvResult)
        Me.Controls.Add(Me.sijiLabel)
        Me.Controls.Add(Me.syokenLabel)
        Me.Controls.Add(Me.totalLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.toYmdBox)
        Me.Controls.Add(Me.fromYmdBox)
        Me.Controls.Add(Me.indBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "健診結果報告書"
        Me.Text = "健診結果報告書"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents indBox As System.Windows.Forms.ComboBox
    Friend WithEvents fromYmdBox As ymdBox.ymdBox
    Friend WithEvents toYmdBox As ymdBox.ymdBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents totalLabel As System.Windows.Forms.Label
    Friend WithEvents syokenLabel As System.Windows.Forms.Label
    Friend WithEvents sijiLabel As System.Windows.Forms.Label
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
End Class
