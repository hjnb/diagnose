<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class topForm
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
        Me.topPicture = New System.Windows.Forms.PictureBox()
        Me.btnExaminationStatus = New System.Windows.Forms.Button()
        Me.btnCriteriaValueMaster = New System.Windows.Forms.Button()
        Me.btnImplementationHistory = New System.Windows.Forms.Button()
        Me.btnMaintenance = New System.Windows.Forms.Button()
        Me.btnResultReport = New System.Windows.Forms.Button()
        Me.btnEnquete = New System.Windows.Forms.Button()
        Me.btnDBArrangement = New System.Windows.Forms.Button()
        Me.btnExamineeList = New System.Windows.Forms.Button()
        Me.btnOfficeMaster = New System.Windows.Forms.Button()
        Me.btnExamineeMaster = New System.Windows.Forms.Button()
        CType(Me.topPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'topPicture
        '
        Me.topPicture.Location = New System.Drawing.Point(586, 79)
        Me.topPicture.Name = "topPicture"
        Me.topPicture.Size = New System.Drawing.Size(119, 117)
        Me.topPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.topPicture.TabIndex = 22
        Me.topPicture.TabStop = False
        '
        'btnExaminationStatus
        '
        Me.btnExaminationStatus.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExaminationStatus.Location = New System.Drawing.Point(49, 190)
        Me.btnExaminationStatus.Name = "btnExaminationStatus"
        Me.btnExaminationStatus.Size = New System.Drawing.Size(238, 65)
        Me.btnExaminationStatus.TabIndex = 21
        Me.btnExaminationStatus.Text = "月別　受診状況"
        Me.btnExaminationStatus.UseVisualStyleBackColor = True
        '
        'btnCriteriaValueMaster
        '
        Me.btnCriteriaValueMaster.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCriteriaValueMaster.Location = New System.Drawing.Point(49, 254)
        Me.btnCriteriaValueMaster.Name = "btnCriteriaValueMaster"
        Me.btnCriteriaValueMaster.Size = New System.Drawing.Size(238, 65)
        Me.btnCriteriaValueMaster.TabIndex = 20
        Me.btnCriteriaValueMaster.Text = "基準値マスタ"
        Me.btnCriteriaValueMaster.UseVisualStyleBackColor = True
        '
        'btnImplementationHistory
        '
        Me.btnImplementationHistory.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnImplementationHistory.Location = New System.Drawing.Point(286, 190)
        Me.btnImplementationHistory.Name = "btnImplementationHistory"
        Me.btnImplementationHistory.Size = New System.Drawing.Size(238, 65)
        Me.btnImplementationHistory.TabIndex = 19
        Me.btnImplementationHistory.Text = "事業所別　実施履歴"
        Me.btnImplementationHistory.UseVisualStyleBackColor = True
        '
        'btnMaintenance
        '
        Me.btnMaintenance.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMaintenance.Location = New System.Drawing.Point(286, 318)
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.Size = New System.Drawing.Size(238, 65)
        Me.btnMaintenance.TabIndex = 18
        Me.btnMaintenance.Text = "保守"
        Me.btnMaintenance.UseVisualStyleBackColor = True
        '
        'btnResultReport
        '
        Me.btnResultReport.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnResultReport.Location = New System.Drawing.Point(286, 254)
        Me.btnResultReport.Name = "btnResultReport"
        Me.btnResultReport.Size = New System.Drawing.Size(238, 65)
        Me.btnResultReport.TabIndex = 17
        Me.btnResultReport.Text = "健診結果報告書"
        Me.btnResultReport.UseVisualStyleBackColor = True
        '
        'btnEnquete
        '
        Me.btnEnquete.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEnquete.Location = New System.Drawing.Point(523, 382)
        Me.btnEnquete.Name = "btnEnquete"
        Me.btnEnquete.Size = New System.Drawing.Size(238, 65)
        Me.btnEnquete.TabIndex = 16
        Me.btnEnquete.Text = "アンケートシステム"
        Me.btnEnquete.UseVisualStyleBackColor = True
        '
        'btnDBArrangement
        '
        Me.btnDBArrangement.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDBArrangement.Location = New System.Drawing.Point(286, 382)
        Me.btnDBArrangement.Name = "btnDBArrangement"
        Me.btnDBArrangement.Size = New System.Drawing.Size(238, 65)
        Me.btnDBArrangement.TabIndex = 15
        Me.btnDBArrangement.Text = "DB整理"
        Me.btnDBArrangement.UseVisualStyleBackColor = True
        '
        'btnExamineeList
        '
        Me.btnExamineeList.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExamineeList.Location = New System.Drawing.Point(286, 126)
        Me.btnExamineeList.Name = "btnExamineeList"
        Me.btnExamineeList.Size = New System.Drawing.Size(238, 65)
        Me.btnExamineeList.TabIndex = 14
        Me.btnExamineeList.Text = "受診者一覧"
        Me.btnExamineeList.UseVisualStyleBackColor = True
        '
        'btnOfficeMaster
        '
        Me.btnOfficeMaster.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnOfficeMaster.Location = New System.Drawing.Point(49, 126)
        Me.btnOfficeMaster.Name = "btnOfficeMaster"
        Me.btnOfficeMaster.Size = New System.Drawing.Size(238, 65)
        Me.btnOfficeMaster.TabIndex = 13
        Me.btnOfficeMaster.Text = "事業所マスタ"
        Me.btnOfficeMaster.UseVisualStyleBackColor = True
        '
        'btnExamineeMaster
        '
        Me.btnExamineeMaster.Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExamineeMaster.Location = New System.Drawing.Point(49, 62)
        Me.btnExamineeMaster.Name = "btnExamineeMaster"
        Me.btnExamineeMaster.Size = New System.Drawing.Size(238, 65)
        Me.btnExamineeMaster.TabIndex = 12
        Me.btnExamineeMaster.Text = "受診者マスタ"
        Me.btnExamineeMaster.UseVisualStyleBackColor = True
        '
        'topForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 561)
        Me.Controls.Add(Me.topPicture)
        Me.Controls.Add(Me.btnExaminationStatus)
        Me.Controls.Add(Me.btnCriteriaValueMaster)
        Me.Controls.Add(Me.btnImplementationHistory)
        Me.Controls.Add(Me.btnMaintenance)
        Me.Controls.Add(Me.btnResultReport)
        Me.Controls.Add(Me.btnEnquete)
        Me.Controls.Add(Me.btnDBArrangement)
        Me.Controls.Add(Me.btnExamineeList)
        Me.Controls.Add(Me.btnOfficeMaster)
        Me.Controls.Add(Me.btnExamineeMaster)
        Me.Name = "topForm"
        Me.Text = "Diagnose　健診"
        CType(Me.topPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents topPicture As System.Windows.Forms.PictureBox
    Friend WithEvents btnExaminationStatus As System.Windows.Forms.Button
    Friend WithEvents btnCriteriaValueMaster As System.Windows.Forms.Button
    Friend WithEvents btnImplementationHistory As System.Windows.Forms.Button
    Friend WithEvents btnMaintenance As System.Windows.Forms.Button
    Friend WithEvents btnResultReport As System.Windows.Forms.Button
    Friend WithEvents btnEnquete As System.Windows.Forms.Button
    Friend WithEvents btnDBArrangement As System.Windows.Forms.Button
    Friend WithEvents btnExamineeList As System.Windows.Forms.Button
    Friend WithEvents btnOfficeMaster As System.Windows.Forms.Button
    Friend WithEvents btnExamineeMaster As System.Windows.Forms.Button

End Class
