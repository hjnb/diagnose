Public Class topForm
    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\Diagnose.mdb"
    Public DB_Diagnose As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\Diagnose.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\Diagnose.ini"

    '画像パス
    Public imageFilePath As String = My.Application.Info.DirectoryPath & "\Diagnose.wmf"

    'Health3のデータベースパス
    Public dbHealth3FilePath As String = Util.getIniString("System", "HealthDir", iniFilePath) & "\Health3.mdb"
    Public DB_Health3 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbHealth3FilePath

    'SealBoxフォルダパス
    Public sealBoxDirPath As String = Util.getIniString("System", "SealBoxDir", iniFilePath)

    '各フォーム
    Dim examineeMasterForm As 受診者マスタ
    Dim officeMasterForm As 事業所マスタ
    Dim examinationStatusForm As 月別_受診状況
    Dim criteriaValueMasterForm As 基準値マスタ
    Dim examineeListForm As 受診者一覧
    Dim implementationHistoryForm As 事業所別_実施履歴
    Dim resultReportForm As 健診結果報告書
    Dim maintenanceForm As 保守
    Dim dbArrangementForm As DB整理
    Dim enqueteForm As アンケートシステム

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub topForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(imageFilePath) Then
            MsgBox("画像ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        '画面サイズ等
        Me.WindowState = FormWindowState.Maximized
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        '画像の配置処理
        topPicture.ImageLocation = imageFilePath
    End Sub

    ''' <summary>
    ''' トップ画像クリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub topPicture_Click(sender As System.Object, e As System.EventArgs) Handles topPicture.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 受診者マスタボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExamineeMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnExamineeMaster.Click
        If IsNothing(examineeMasterForm) OrElse examineeMasterForm.IsDisposed Then
            examineeMasterForm = New 受診者マスタ()
            examineeMasterForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 事業所マスタボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOfficeMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnOfficeMaster.Click
        If IsNothing(officeMasterForm) OrElse officeMasterForm.IsDisposed Then
            officeMasterForm = New 事業所マスタ()
            officeMasterForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 月別受診状況ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExaminationStatus_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminationStatus.Click
        If IsNothing(examinationStatusForm) OrElse examinationStatusForm.IsDisposed Then
            examinationStatusForm = New 月別_受診状況()
            examinationStatusForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 基準値マスタボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCriteriaValueMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnCriteriaValueMaster.Click
        If IsNothing(criteriaValueMasterForm) OrElse criteriaValueMasterForm.IsDisposed Then
            criteriaValueMasterForm = New 基準値マスタ()
            criteriaValueMasterForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 受診者一覧ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExamineeList_Click(sender As System.Object, e As System.EventArgs) Handles btnExamineeList.Click
        If IsNothing(examineeListForm) OrElse examineeListForm.IsDisposed Then
            examineeListForm = New 受診者一覧()
            examineeListForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 事業所別実施履歴ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImplementationHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnImplementationHistory.Click
        If IsNothing(implementationHistoryForm) OrElse implementationHistoryForm.IsDisposed Then
            implementationHistoryForm = New 事業所別_実施履歴()
            implementationHistoryForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 健診結果報告書ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnResultReport_Click(sender As System.Object, e As System.EventArgs) Handles btnResultReport.Click
        If IsNothing(resultReportForm) OrElse resultReportForm.IsDisposed Then
            resultReportForm = New 健診結果報告書()
            resultReportForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' 保守ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMaintenance_Click(sender As System.Object, e As System.EventArgs) Handles btnMaintenance.Click
        If IsNothing(maintenanceForm) OrElse maintenanceForm.IsDisposed Then
            maintenanceForm = New 保守()
            maintenanceForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' DB整理ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDBArrangement_Click(sender As System.Object, e As System.EventArgs) Handles btnDBArrangement.Click
        If IsNothing(dbArrangementForm) OrElse dbArrangementForm.IsDisposed Then
            dbArrangementForm = New DB整理()
            dbArrangementForm.Show()
        End If
    End Sub

    ''' <summary>
    ''' アンケートシステムボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEnquete_Click(sender As System.Object, e As System.EventArgs) Handles btnEnquete.Click
        If IsNothing(enqueteForm) OrElse enqueteForm.IsDisposed Then
            enqueteForm = New アンケートシステム()
            enqueteForm.Show()
        End If
    End Sub
End Class
