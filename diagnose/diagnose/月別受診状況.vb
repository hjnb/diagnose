Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting

Public Class 月別_受診状況

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
    Private Sub 月別_受診状況_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'データグリッドビュー初期設定
        initDgvResult()
        initDgvCount()

        '受診月を当月、当月受診データ表示、当月までの受診者数表示
        ymBox.setADStr(Today.ToString("yyyy/MM") & "/01")
        displayDgvResult(Today.ToString("yyyy/MM"))
        displayDgvCount(Today.ToString("yyyy/MM"))

    End Sub

    ''' <summary>
    ''' データグリッドビュー（上）初期設定
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
            .ColumnHeadersHeight = 18
            .RowHeadersWidth = 35
            .RowTemplate.Height = 18
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 10)
            .ReadOnly = False
        End With
    End Sub

    ''' <summary>
    ''' データグリッドビュー（下）初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvCount()
        Util.EnableDoubleBuffering(dgvCount)

        With dgvCount
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
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 10)
            .ReadOnly = True
        End With

        '列追加
        Dim dt As New DataTable()
        For i As Integer = 1 To 12
            dt.Columns.Add("M" & i, GetType(String))
        Next
        dt.Columns.Add("Total", GetType(String))

        '行追加
        For i As Integer = 0 To 3
            Dim row As DataRow = dt.NewRow()
            For j As Integer = 1 To 12
                row("M" & j) = ""
            Next
            row("Total") = If(i Mod 2 = 0, "計", "")
            dt.Rows.Add(row)
        Next

        '表示
        dgvCount.DataSource = dt

        '幅設定等
        With dgvCount
            For i As Integer = 1 To 12
                With .Columns("M" & i)
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Width = 70
                End With
            Next
            With .Columns("Total")
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
            End With
        End With
    End Sub

    ''' <summary>
    ''' 指定年月受診データ表示
    ''' </summary>
    ''' <param name="ym">年月(yyyy/MM)</param>
    ''' <remarks></remarks>
    Private Sub displayDgvResult(ym As String)
        '内容クリア
        dgvResult.Columns.Clear()

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rsB5 As New ADODB.Recordset
        Dim rsA4 As New ADODB.Recordset
        Dim sql As String = ""
        'B5(Ken1)データ
        sql = "select U.Ind, U.Nam, U.Kana, K1.Ymd, K1.D25, K1.D28, K1.D18 from Ken1 as K1 inner join UsrM as U on (K1.Kana = U.Kana and K1.Ind = U.Ind) where K1.Ymd Like '" & ym & "%' order by K1.Ymd, K1.Ind, K1.Kana"
        rsB5.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        'A4(Ken2)データ
        sql = "select U.Ind, U.Nam, U.Kana, K2.Ymd, K2.D63, K2.D75, K2.D72 from Ken2 as K2 inner join UsrM as U on (K2.Kana = U.Kana and K2.Ind = U.Ind) where K2.Ymd Like '" & ym & "%' order by K2.Ymd, K2.Ind, K2.Kana"
        rsA4.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

        'データテーブル作成
        Dim dt As New DataTable()
        dt.Columns.Add("Ind", GetType(String))
        dt.Columns.Add("Nam", GetType(String))
        dt.Columns.Add("Kana", GetType(String))
        dt.Columns.Add("Ymd", GetType(String))
        dt.Columns.Add("Paper", GetType(String))
        dt.Columns.Add("Xray", GetType(String))
        dt.Columns.Add("Ecg", GetType(String))
        dt.Columns.Add("Hep", GetType(String))
        While Not rsB5.EOF
            Dim row As DataRow = dt.NewRow()
            row("Ind") = Util.checkDBNullValue(rsB5.Fields("Ind").Value)
            row("Nam") = Util.checkDBNullValue(rsB5.Fields("Nam").Value)
            row("Kana") = Util.checkDBNullValue(rsB5.Fields("Kana").Value)
            row("Ymd") = Util.checkDBNullValue(rsB5.Fields("Ymd").Value)
            row("Paper") = "B5"
            row("Xray") = Util.checkDBNullValue(rsB5.Fields("D25").Value)
            row("Ecg") = Util.checkDBNullValue(rsB5.Fields("D28").Value)
            row("Hep") = Util.checkDBNullValue(rsB5.Fields("D18").Value)
            dt.Rows.Add(row)
            rsB5.MoveNext()
        End While
        While Not rsA4.EOF
            Dim row As DataRow = dt.NewRow()
            row("Ind") = Util.checkDBNullValue(rsA4.Fields("Ind").Value)
            row("Nam") = Util.checkDBNullValue(rsA4.Fields("Nam").Value)
            row("Kana") = Util.checkDBNullValue(rsA4.Fields("Kana").Value)
            row("Ymd") = Util.checkDBNullValue(rsA4.Fields("Ymd").Value)
            row("Paper") = "A4"
            row("Xray") = Util.checkDBNullValue(rsA4.Fields("D63").Value)
            row("Ecg") = Util.checkDBNullValue(rsA4.Fields("D75").Value)
            row("Hep") = Util.checkDBNullValue(rsA4.Fields("D72").Value)
            dt.Rows.Add(row)
            rsA4.MoveNext()
        End While

        '表示
        dgvResult.DataSource = dt
        cnn.Close()

        Dim targetColumn As DataGridViewColumn = dgvResult.Columns("Ymd") '選択列
        dgvResult.Sort(targetColumn, System.ComponentModel.ListSortDirection.Ascending) '昇順でソート

        '幅設定等
        With dgvResult
            With .Columns("Ind")
                .HeaderText = "事業所名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 130
                .ReadOnly = True
            End With
            With .Columns("Kana")
                .HeaderText = "カナ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 130
                .ReadOnly = True
            End With
            With .Columns("Ymd")
                .HeaderText = "受診日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 85
                .ReadOnly = True
            End With
            With .Columns("Paper")
                .HeaderText = "診断書"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("Xray")
                .HeaderText = "胸部Ｘ線"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("Ecg")
                .HeaderText = "心電図"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("Hep")
                .HeaderText = "肝炎"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .ReadOnly = True
            End With
            If .Rows.Count >= 16 Then
                .Size = New Size(869, 290)
            Else
                .Size = New Size(852, 290)
            End If

        End With

        'フォーカス
        ymBox.Focus()

    End Sub

    ''' <summary>
    ''' 指定年月より過去２年間の受診者数表示
    ''' </summary>
    ''' <param name="ym">年月(yyyy/MM)</param>
    ''' <remarks></remarks>
    Private Sub displayDgvCount(ym As String)
        '内容クリア
        For i As Integer = 0 To 3
            For j As Integer = 1 To 12
                dgvCount("M" & j, i).Value = ""
            Next
            If i Mod 2 = 1 Then
                dgvCount("Total", i).Value = ""
            End If
        Next

        '年月文字設定
        Dim currentYm As DateTime = New DateTime(CInt(ym.Split("/")(0)), CInt(ym.Split("/")(1)), 1) '現在年月
        For i As Integer = 0 To 1
            For j As Integer = 0 To 11
                dgvCount("M" & (12 - j), 0).Value = currentYm.AddMonths(-j).ToString("yyyy/MM")
                dgvCount("M" & (12 - j), 2).Value = currentYm.AddMonths(-(12 + j)).ToString("yyyy/MM")
            Next
        Next

        '受診者数取得、表示
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset
        'B5データ集計
        Dim sql As String = "select Ymd from Ken1 where '" & currentYm.AddMonths(-23).ToString("yyyy/MM") & "/01" & "' <= Ymd and Ymd <= '" & currentYm.ToString("yyyy/MM") & "/31" & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        For i As Integer = 0 To 23
            rs.Filter = "Ymd Like '" & currentYm.AddMonths(-i).ToString("yyyy/MM") & "%'"
            If i < 12 Then
                dgvCount("M" & (12 - i), 1).Value = rs.RecordCount
            Else
                dgvCount("M" & (24 - i), 3).Value = rs.RecordCount
            End If
        Next
        rs.Close()
        'A4データ集計
        sql = "select Ymd from Ken2 where '" & currentYm.AddMonths(-23).ToString("yyyy/MM") & "/01" & "' <= Ymd and Ymd <= '" & currentYm.ToString("yyyy/MM") & "/31" & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        For i As Integer = 0 To 23
            rs.Filter = "Ymd Like '" & currentYm.AddMonths(-i).ToString("yyyy/MM") & "%'"
            If i < 12 Then
                dgvCount("M" & (12 - i), 1).Value += rs.RecordCount
            Else
                dgvCount("M" & (24 - i), 3).Value += rs.RecordCount
            End If
        Next
        rs.Close()

        '合計表示
        Dim total1, total2 As Integer
        For i As Integer = 1 To 12
            total1 += dgvCount("M" & i, 1).Value
            total2 += dgvCount("M" & i, 3).Value
        Next
        dgvCount("Total", 1).Value = total1
        dgvCount("Total", 3).Value = total2

        'グラフ表示
        '初期化
        With countChart
            .Titles.Clear()
            .Series.Clear()
            .ChartAreas.Clear()
            .BackColor = Color.FromKnownColor(KnownColor.Control)
        End With

        '元データ作成
        Dim ymArray(11) As String '年月(yyyy/MM)データ
        For i As Integer = 0 To 11
            ymArray(i) = currentYm.AddMonths(-(11 - i)).ToString("yyyy/MM")
        Next
        Dim prev1CountArray(11) As String '1年前～現在年月まで受診者数データ
        For i As Integer = 1 To 12
            prev1CountArray(i - 1) = dgvCount("M" & i, 1).Value
        Next
        Dim prev2CountArray(11) As String '2年前～1年前まで受診者数データ
        For i As Integer = 1 To 12
            prev2CountArray(i - 1) = dgvCount("M" & i, 3).Value
        Next

        'データをセット
        '1年前～現在年月までデータ
        Dim prev1series As Series = New Series()
        prev1series.ChartType = SeriesChartType.Column '棒グラフ
        For i As Integer = 0 To 11
            prev1series.Points.Add(New DataPoint(i, prev1CountArray(i)))
            prev1series.Points(i).AxisLabel = ymArray(i)
            prev1series.Points(i).Color = Color.FromArgb(0, 255, 0)
        Next
        '2年前～1年前までデータ
        Dim prev2series As Series = New Series()
        prev2series.ChartType = SeriesChartType.Column '棒グラフ
        For i As Integer = 0 To 11
            prev2series.Points.Add(New DataPoint(i, prev2CountArray(i)))
            prev2series.Points(i).AxisLabel = ymArray(i)
            prev2series.Points(i).Color = Color.FromArgb(255, 0, 0)
        Next

        'エリア設定
        Dim area As New ChartArea()
        area.BackColor = Color.FromKnownColor(KnownColor.Control)
        With area.AxisY 'Y軸設定
            '目盛り
            .Maximum = 120 '最大値
            .Minimum = 0 '最小値
            .Interval = 20 '間隔
        End With
        With area.AxisX
            .IsLabelAutoFit = True
            .LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont Or LabelAutoFitStyles.IncreaseFont
            .LabelAutoFitMaxFontSize = 8
            .LabelAutoFitMinFontSize = 8
        End With

        countChart.ChartAreas.Add(area)
        countChart.Series.Add(prev2series)
        countChart.Series.Add(prev1series)

    End Sub

    ''' <summary>
    ''' CellFormattingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvResult_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvResult.CellFormatting
        If e.RowIndex >= 0 Then
            '列名
            Dim columnName As String = dgvResult.Columns(e.ColumnIndex).Name

            '受診日を和暦に
            If columnName = "Ymd" Then
                e.Value = Util.convADStrToWarekiStr(Util.checkDBNullValue(e.Value))
                e.FormattingApplied = True
            End If

            '胸部Ｘ線、心電図、肝炎：検査実施ならば○
            If columnName = "Xray" OrElse columnName = "Ecg" OrElse columnName = "Hep" Then
                e.Value = If(Util.checkDBNullValue(e.Value) = "", "", "○")
                e.FormattingApplied = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvResult_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvResult.CellPainting
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
        '選択したセルに枠を付ける
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 表示ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDisplay_Click(sender As System.Object, e As System.EventArgs) Handles btnDisplay.Click
        '受診年月データ表示
        displayDgvResult(ymBox.getADymStr())
        displayDgvCount(ymBox.getADymStr())
    End Sub

    ''' <summary>
    ''' 年月ボックスエンターキー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymBox_keyDownEnter(sender As Object, e As System.EventArgs) Handles ymBox.keyDownEnter
        btnDisplay.Focus()
    End Sub
End Class