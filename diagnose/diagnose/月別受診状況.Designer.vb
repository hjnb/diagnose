<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 月別_受診状況
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
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.dgvCount = New System.Windows.Forms.DataGridView()
        Me.countChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ymBox = New ADBox.adBox()
        Me.btnDisplay = New System.Windows.Forms.Button()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.countChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvResult
        '
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(50, 56)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.RowTemplate.Height = 21
        Me.dgvResult.Size = New System.Drawing.Size(869, 290)
        Me.dgvResult.TabIndex = 6
        '
        'dgvCount
        '
        Me.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCount.Location = New System.Drawing.Point(51, 366)
        Me.dgvCount.Name = "dgvCount"
        Me.dgvCount.RowTemplate.Height = 21
        Me.dgvCount.Size = New System.Drawing.Size(913, 75)
        Me.dgvCount.TabIndex = 7
        '
        'countChart
        '
        Me.countChart.Location = New System.Drawing.Point(53, 458)
        Me.countChart.Name = "countChart"
        Series2.Name = "Series1"
        Me.countChart.Series.Add(Series2)
        Me.countChart.Size = New System.Drawing.Size(845, 231)
        Me.countChart.TabIndex = 8
        Me.countChart.Text = "Chart1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "受診年月"
        '
        'ymBox
        '
        Me.ymBox.dateText = "17"
        Me.ymBox.Location = New System.Drawing.Point(125, 12)
        Me.ymBox.Mode = 1
        Me.ymBox.monthText = "07"
        Me.ymBox.Name = "ymBox"
        Me.ymBox.Size = New System.Drawing.Size(105, 35)
        Me.ymBox.TabIndex = 10
        Me.ymBox.yearText = "2019"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(249, 14)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(68, 33)
        Me.btnDisplay.TabIndex = 11
        Me.btnDisplay.Text = "表示"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        '月別_受診状況
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 701)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.ymBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.countChart)
        Me.Controls.Add(Me.dgvCount)
        Me.Controls.Add(Me.dgvResult)
        Me.Name = "月別_受診状況"
        Me.Text = "月別_受診状況"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.countChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCount As System.Windows.Forms.DataGridView
    Friend WithEvents countChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ymBox As ADBox.adBox
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
End Class
