﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B5InputForm
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
        Me.components = New System.ComponentModel.Container()
        Me.ageBox = New System.Windows.Forms.TextBox()
        Me.birthBox = New System.Windows.Forms.TextBox()
        Me.sexBox = New System.Windows.Forms.TextBox()
        Me.namBox = New System.Windows.Forms.TextBox()
        Me.indBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.YmdBox = New ymdBox.ymdBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.CheckAbnormal = New System.Windows.Forms.CheckBox()
        Me.historyListBox = New System.Windows.Forms.ListBox()
        Me.dgvB5Input = New diagnose.B5InputDataGridView(Me.components)
        CType(Me.dgvB5Input, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ageBox
        '
        Me.ageBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ageBox.ForeColor = System.Drawing.Color.Blue
        Me.ageBox.Location = New System.Drawing.Point(511, 19)
        Me.ageBox.Name = "ageBox"
        Me.ageBox.ReadOnly = True
        Me.ageBox.Size = New System.Drawing.Size(41, 19)
        Me.ageBox.TabIndex = 16
        Me.ageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'birthBox
        '
        Me.birthBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.birthBox.ForeColor = System.Drawing.Color.Blue
        Me.birthBox.Location = New System.Drawing.Point(419, 19)
        Me.birthBox.Name = "birthBox"
        Me.birthBox.ReadOnly = True
        Me.birthBox.Size = New System.Drawing.Size(93, 19)
        Me.birthBox.TabIndex = 15
        Me.birthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sexBox
        '
        Me.sexBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sexBox.ForeColor = System.Drawing.Color.Blue
        Me.sexBox.Location = New System.Drawing.Point(392, 19)
        Me.sexBox.Name = "sexBox"
        Me.sexBox.ReadOnly = True
        Me.sexBox.Size = New System.Drawing.Size(28, 19)
        Me.sexBox.TabIndex = 14
        Me.sexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'namBox
        '
        Me.namBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.namBox.ForeColor = System.Drawing.Color.Blue
        Me.namBox.Location = New System.Drawing.Point(298, 19)
        Me.namBox.Name = "namBox"
        Me.namBox.ReadOnly = True
        Me.namBox.Size = New System.Drawing.Size(95, 19)
        Me.namBox.TabIndex = 13
        Me.namBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'indBox
        '
        Me.indBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.indBox.ForeColor = System.Drawing.Color.Blue
        Me.indBox.Location = New System.Drawing.Point(102, 19)
        Me.indBox.Name = "indBox"
        Me.indBox.ReadOnly = True
        Me.indBox.Size = New System.Drawing.Size(198, 19)
        Me.indBox.TabIndex = 12
        Me.indBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "健診日"
        '
        'YmdBox
        '
        Me.YmdBox.boxType = 1
        Me.YmdBox.DateText = ""
        Me.YmdBox.EraLabelText = "H31"
        Me.YmdBox.EraText = ""
        Me.YmdBox.Location = New System.Drawing.Point(145, 55)
        Me.YmdBox.MonthLabelText = "04"
        Me.YmdBox.MonthText = ""
        Me.YmdBox.Name = "YmdBox"
        Me.YmdBox.Size = New System.Drawing.Size(112, 30)
        Me.YmdBox.TabIndex = 18
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(275, 56)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(70, 26)
        Me.btnRegist.TabIndex = 19
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(344, 56)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(70, 26)
        Me.btnDelete.TabIndex = 20
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(413, 56)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(70, 26)
        Me.btnClear.TabIndex = 21
        Me.btnClear.Text = "クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(482, 56)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(70, 26)
        Me.btnPrint.TabIndex = 22
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'CheckAbnormal
        '
        Me.CheckAbnormal.AutoSize = True
        Me.CheckAbnormal.Checked = True
        Me.CheckAbnormal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckAbnormal.Location = New System.Drawing.Point(493, 93)
        Me.CheckAbnormal.Name = "CheckAbnormal"
        Me.CheckAbnormal.Size = New System.Drawing.Size(60, 16)
        Me.CheckAbnormal.TabIndex = 23
        Me.CheckAbnormal.Text = "異常値"
        Me.CheckAbnormal.UseVisualStyleBackColor = True
        '
        'historyListBox
        '
        Me.historyListBox.FormattingEnabled = True
        Me.historyListBox.ItemHeight = 12
        Me.historyListBox.Location = New System.Drawing.Point(569, 19)
        Me.historyListBox.Name = "historyListBox"
        Me.historyListBox.Size = New System.Drawing.Size(91, 64)
        Me.historyListBox.TabIndex = 24
        '
        'dgvB5Input
        '
        Me.dgvB5Input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvB5Input.Location = New System.Drawing.Point(102, 115)
        Me.dgvB5Input.Name = "dgvB5Input"
        Me.dgvB5Input.RowTemplate.Height = 21
        Me.dgvB5Input.Size = New System.Drawing.Size(558, 594)
        Me.dgvB5Input.TabIndex = 25
        '
        'B5InputForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 728)
        Me.Controls.Add(Me.dgvB5Input)
        Me.Controls.Add(Me.historyListBox)
        Me.Controls.Add(Me.CheckAbnormal)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.YmdBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ageBox)
        Me.Controls.Add(Me.birthBox)
        Me.Controls.Add(Me.sexBox)
        Me.Controls.Add(Me.namBox)
        Me.Controls.Add(Me.indBox)
        Me.Name = "B5InputForm"
        Me.Text = "健康診断書B5"
        CType(Me.dgvB5Input, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ageBox As System.Windows.Forms.TextBox
    Friend WithEvents birthBox As System.Windows.Forms.TextBox
    Friend WithEvents sexBox As System.Windows.Forms.TextBox
    Friend WithEvents namBox As System.Windows.Forms.TextBox
    Friend WithEvents indBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents YmdBox As ymdBox.ymdBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents CheckAbnormal As System.Windows.Forms.CheckBox
    Friend WithEvents historyListBox As System.Windows.Forms.ListBox
    Friend WithEvents dgvB5Input As diagnose.B5InputDataGridView
End Class
