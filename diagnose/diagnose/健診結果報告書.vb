Public Class 健診結果報告書

    '表示用データテーブル
    Private dtResult As DataTable = New DataTable()

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
    Private Sub 健診結果報告書_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        '事業所名ボックス初期設定
        initIndBox()

        '日付ボックスに現在日付を設定
        Dim nowStr As String = DateTime.Now.ToString("yyyy/MM/dd")
        fromYmdBox.setADStr(nowStr)
        toYmdBox.setADStr(nowStr)

        'データグリッドビュー初期設定
        initDgvResult()
    End Sub

    ''' <summary>
    ''' keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 健診結果報告書_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 事業所名ボックス初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initIndBox()
        indBox.ImeMode = Windows.Forms.ImeMode.Hiragana
        indBox.Items.Clear()
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "SELECT Ind FROM IndM ORDER BY Kana"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim txt As String = Util.checkDBNullValue(rs.Fields("Ind").Value)
            indBox.Items.Add(txt)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvResult()
        Util.EnableDoubleBuffering(dgvResult)

        With dgvResult
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 20
            .RowHeadersWidth = 30
            .RowTemplate.Height = 20
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 10)
            .ReadOnly = True
        End With

        '列追加、空の行追加
        Dim itemArray() As String = {"聴力　1000Hz", "　　　　4000Hz", "胸部Ｘ線", "血圧", "貧血", "肝機能", "血中脂質", "血糖", "尿　糖", "尿　蛋白", "心電図"}
        dtResult.Columns.Add("Item", GetType(String))
        dtResult.Columns.Add("JNum", GetType(String))
        dtResult.Columns.Add("SNum", GetType(String))
        For i = 0 To 10
            Dim row As DataRow = dtResult.NewRow()
            row(0) = itemArray(i)
            row(1) = ""
            row(2) = ""
            dtResult.Rows.Add(row)
        Next

        '表示
        dgvResult.DataSource = dtResult

        '幅設定等
        With dgvResult
            With .Columns("Item")
                .HeaderText = "検査項目"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 115
            End With
            With .Columns("JNum")
                .HeaderText = "実施者数"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 95
            End With
            With .Columns("SNum")
                .HeaderText = "所見者数"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 95
            End With
        End With

    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvResult.CellPainting
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
    ''' 結果人数表示
    ''' </summary>
    ''' <param name="ind">事業所名</param>
    ''' <param name="fromYmd">from日付</param>
    ''' <param name="toYmd">to日付</param>
    ''' <remarks></remarks>
    Private Sub displayDgvResult(ind As String, fromYmd As String, toYmd As String)
        '内容クリア
        For Each row As DataRow In dtResult.Rows
            '実施者
            row("JNum") = ""
            '所見者数
            row("SNum") = ""
        Next

        'データ取得

    End Sub

    ''' <summary>
    ''' 実行ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        '事業所名
        Dim ind As String = indBox.Text
        If ind = "" Then
            MsgBox("事業所名を選択して下さい。", MsgBoxStyle.Exclamation)
            indBox.DroppedDown = True
            Return
        End If

        'from日付
        Dim fromYmd As String = fromYmdBox.getADStr()
        'to日付
        Dim toYmd As String = toYmdBox.getADStr()

        'データ表示
        displayDgvResult(ind, fromYmd, toYmd)
    End Sub
End Class