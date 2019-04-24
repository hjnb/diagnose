<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class beforePrintForm
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
        Me.rbtnPrint = New System.Windows.Forms.RadioButton()
        Me.rbtnInput = New System.Windows.Forms.RadioButton()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rbtnPrint
        '
        Me.rbtnPrint.AutoSize = True
        Me.rbtnPrint.Checked = True
        Me.rbtnPrint.Location = New System.Drawing.Point(29, 38)
        Me.rbtnPrint.Name = "rbtnPrint"
        Me.rbtnPrint.Size = New System.Drawing.Size(95, 16)
        Me.rbtnPrint.TabIndex = 0
        Me.rbtnPrint.TabStop = True
        Me.rbtnPrint.Text = "基本項目印刷"
        Me.rbtnPrint.UseVisualStyleBackColor = True
        '
        'rbtnInput
        '
        Me.rbtnInput.AutoSize = True
        Me.rbtnInput.Location = New System.Drawing.Point(29, 69)
        Me.rbtnInput.Name = "rbtnInput"
        Me.rbtnInput.Size = New System.Drawing.Size(95, 16)
        Me.rbtnInput.TabIndex = 1
        Me.rbtnInput.Text = "健診結果入力"
        Me.rbtnInput.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(155, 109)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(66, 29)
        Me.btnExecute.TabIndex = 2
        Me.btnExecute.Text = "実行"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(220, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 29)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "ｷｬﾝｾﾙ"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'beforePrintForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 159)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.rbtnInput)
        Me.Controls.Add(Me.rbtnPrint)
        Me.Name = "beforePrintForm"
        Me.Text = "診断書"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtnPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnInput As System.Windows.Forms.RadioButton
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
