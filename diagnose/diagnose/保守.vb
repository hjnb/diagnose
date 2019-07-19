Imports System.Data.OleDb

Public Class 保守

    '選択者生年月日、事業所名保持用
    Private selectedBirth As String
    Private selectedInd As String

    ''' <summary>
    ''' 行ヘッダーのカレントセルを表す三角マークを非表示に設定する為のクラス。
    ''' </summary>
    ''' <remarks></remarks>
    Public Class dgvRowHeaderCell

        'DataGridViewRowHeaderCell を継承
        Inherits DataGridViewRowHeaderCell

        'DataGridViewHeaderCell.Paint をオーバーライドして行ヘッダーを描画
        Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, _
           ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates, _
           ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, _
           ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
           ByVal paintParts As DataGridViewPaintParts)
            '標準セルの描画からセル内容の背景だけ除いた物を描画(-5)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, _
                     formattedValue, errorText, cellStyle, advancedBorderStyle, _
                     Not DataGridViewPaintParts.ContentBackground)
        End Sub

    End Class

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 保守_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'データグリッドビュー初期設定
        initDgvUsrM()

        '事業所リスト初期設定
        initIndList()
    End Sub

    ''' <summary>
    ''' 事業所リスト初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initIndList()
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select Ind from IndM order by Kana"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim ind As String = Util.checkDBNullValue(rs.Fields("Ind").Value)
            indList.Items.Add(ind)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvUsrM()
        Util.EnableDoubleBuffering(dgvUsrM)

        With dgvUsrM
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowHeadersWidth = 30
            .ColumnHeadersHeight = 18
            .RowTemplate.Height = 18
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' 対象事業所データ表示
    ''' </summary>
    ''' <param name="ind"></param>
    ''' <remarks></remarks>
    Private Sub displayDgvUsrM(ind As String)
        '内容クリア
        dgvUsrM.Columns.Clear()
        clearInput()

        '選択事業所名
        selectedInd = ind

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Nam, Kana, Birth from UsrM where Ind = '" & ind & "' order by Kana"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "UsrM")
        Dim dt As DataTable = ds.Tables("UsrM")

        '表示
        dgvUsrM.DataSource = dt
        If Not IsNothing(dgvUsrM.CurrentRow) Then
            dgvUsrM.CurrentRow.Selected = False
        End If

        '幅設定等
        With dgvUsrM
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 95
            End With
            With .Columns("Kana")
                .HeaderText = "ｶﾅ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 95
            End With
            With .Columns("Birth")
                .HeaderText = "生年月日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 85
            End With
            If dgvUsrM.Rows.Count > 20 Then
                .Size = New Size(324, 380)
            Else
                .Size = New Size(307, 380)
            End If
        End With

    End Sub

    ''' <summary>
    ''' 事業所リスト
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub indList_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles indList.SelectedValueChanged
        displayDgvUsrM(indList.Text)
    End Sub

    ''' <summary>
    ''' CellFormattingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvUsrM_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvUsrM.CellFormatting
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgvUsrM.Columns(e.ColumnIndex).Name
            '生年月日を和暦に
            If columnName = "Birth" Then
                e.Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(dgvUsrM("Birth", e.RowIndex).Value))
                e.FormattingApplied = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' CellMouseClickイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvUsrM_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvUsrM.CellMouseClick
        If e.RowIndex >= 0 Then
            'ｶﾅ
            Dim kana As String = Util.checkDBNullValue(dgvUsrM("Kana", e.RowIndex).Value)
            '生年月日
            selectedBirth = Util.checkDBNullValue(dgvUsrM("Birth", e.RowIndex).Value)

            '変更前ラベルと変更後ボックスへセット
            kanaLabel.Text = kana
            kanaBox.Text = kana
            kanaBox.Focus()
            kanaBox.SelectionStart = kanaBox.TextLength
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvUsrM_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvUsrM.CellPainting
        '行ヘッダーかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                (e.RowIndex + 1).ToString(), _
                e.CellStyle.Font, _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        '変更前カナラベル
        kanaLabel.Text = ""
        '変更後カナボックス
        kanaBox.Text = ""

        '選択者生年月日
        selectedBirth = ""
        '選択事業所名
        selectedInd = ""
    End Sub

    ''' <summary>
    ''' Runボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        '変更前カナ
        Dim prevKana As String = kanaLabel.Text
        If prevKana = "" Then
            MsgBox("変更対象者を選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If
        '変更後カナ
        Dim changedKana As String = kanaBox.Text
        If changedKana = "" Then
            MsgBox("変更後のｶﾅを入力して下さい。", MsgBoxStyle.Exclamation)
            kanaBox.Focus()
            Return
        End If
        If prevKana = changedKana Then
            MsgBox("ｶﾅが変更されていません。", MsgBoxStyle.Exclamation)
            kanaBox.Focus()
            Return
        End If

        '受診者マスタ(UsrM)の変更
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from UsrM where Ind = '" & selectedInd & "' and Kana = '" & prevKana & "' and Birth = '" & selectedBirth & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox(prevKana & " 様のデータが存在しません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        Else
            While Not rs.EOF
                rs.Fields("Kana").Value = changedKana
                rs.Update()
                rs.MoveNext()
            End While

            rs.Close()
        End If
        
        'B5健診データ(Ken1)の変更
        sql = "select * from Ken1 where Ind = '" & selectedInd & "' and Kana = '" & prevKana & "' and Birth = '" & selectedBirth & "'"
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            rs.Fields("Kana").Value = changedKana
            rs.Update()
            rs.MoveNext()
        End While
        rs.Close()

        'A4健診データ(Ken2)の変更
        sql = "select * from Ken2 where Ind = '" & selectedInd & "' and Kana = '" & prevKana & "' and Birth = '" & selectedBirth & "'"
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            rs.Fields("Kana").Value = changedKana
            rs.Update()
            rs.MoveNext()
        End While
        rs.Close()

        '再表示
        displayDgvUsrM(selectedInd)

    End Sub

    ''' <summary>
    ''' ｶﾅボックスkeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub kanaBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles kanaBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnExecute.Focus()
        End If
    End Sub
End Class