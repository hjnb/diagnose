Public Class DB整理

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MinimizeBox = False
        Me.MaximizeBox = False
    End Sub

    ''' <summary>
    ''' 実行ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        '現在年月
        Dim nowYmStr As String = Today.ToString("yyyy/MM")
        '4年前年月
        Dim targetYmStr As String = Today.AddYears(-4).ToString("yyyy/MM/dd")

        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)

        '健診1(B5)データ削除
        Dim cmd As New ADODB.Command()
        cmd.ActiveConnection = cnn
        cmd.CommandText = "delete from Ken1 where Ymd <= '" & targetYmStr & "'"
        cmd.Execute()

        '健診2(A4)データ削除
        cmd.CommandText = "delete from Ken2 where Ymd <= '" & targetYmStr & "'"
        cmd.Execute()
        cnn.Close()

        MsgBox("データを削除しました。" & Environment.NewLine & "DBCompact.exeを実行して下さい。", MsgBoxStyle.Information)
    End Sub
    
End Class