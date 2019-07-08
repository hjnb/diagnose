Imports System.Data.OleDb

Public Class 健診結果報告書

    '表示用データテーブル
    Private dtResult As DataTable = New DataTable()

    '基準値データテーブル
    Private dtBaseVal As DataTable

    '男女で基準値が異なる項目名
    Private stdValName() As String = {"Ｆｅ", "ＨＤＬ－ｺﾚｽﾃﾛｰﾙ", "γ－ＧＴＰ", "ｸﾚｱﾁﾆﾝ", "血清ｸﾚｱﾁﾆﾝ", "赤沈", "赤血球数", "血色素量", "ﾍﾏﾄｸﾘｯﾄ", "ﾍﾓｸﾞﾛﾋﾞﾝ"}

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

        '基準値データ設定
        initDtBaseVal()
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
    ''' 基準値データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDtBaseVal()
        Dim cn As New ADODB.Connection
        cn.Open(topForm.DB_Diagnose)
        Dim rsBase As New ADODB.Recordset
        Dim sql As String = "select Nam, Low1, Upp1, Low2, Upp2 from StdM"
        rsBase.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rsBase, "StdM")
        dtBaseVal = ds.Tables("StdM")
        cn.Close()
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
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rsKenD1 As New ADODB.Recordset
        Dim rsKenD2 As New ADODB.Recordset
        Dim sql1 As String = "select U.Sex, K.* from (select * from Ken1 where Ind = '" & ind & "' and ('" & fromYmd & "' <= Ymd and Ymd <= '" & toYmd & "')) as K inner join UsrM as U on K.Ind = U.Ind and K.Kana = U.Kana"
        Dim sql2 As String = "select U.Sex, K.* from (select * from Ken2 where Ind = '" & ind & "' and ('" & fromYmd & "' <= Ymd and Ymd <= '" & toYmd & "')) as K inner join UsrM as U on K.Ind = U.Ind and K.Kana = U.Kana"
        rsKenD1.Open(sql1, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
        rsKenD2.Open(sql2, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)

        '所見なしの言葉
        Const NP_WORD As String = "異常なし"

        '各項目count
        Dim earJNum As Integer = 0 '聴力実施者数
        Dim ear1000Hz As Integer = 0 '聴力1000Hz
        Dim ear4000Hz As Integer = 0 '聴力4000Hz
        Dim xpJNum As Integer = 0 '胸部Ｘ線実施者数
        Dim xp As Integer = 0 '胸部Ｘ線
        Dim bpJNum As Integer = 0 '血圧実施者数
        Dim bp As Integer = 0 '血圧
        Dim hinJNum As Integer = 0 '貧血実施者数
        Dim hin As Integer = 0 '貧血
        Dim kanki As Integer = 0 '肝機能
        Dim sisitu As Integer = 0 '血中脂質
        Dim keto As Integer = 0 '血糖
        Dim nyoto As Integer = 0 '尿糖
        Dim nyotan As Integer = 0 '尿蛋白
        Dim ecg As Integer = 0 '心電図
        Dim jNum As Integer = 0 '受診者数
        Dim sNum As Integer = 0 '所見者数
        Dim drInstruct As Integer = 0 '医師指示

        'B5データの集計処理
        While Not rsKenD1.EOF
            '性別
            Dim sex As String = Util.checkDBNullValue(rsKenD1.Fields("Sex").Value)

            '聴力
            Dim d9 As String = Util.checkDBNullValue(rsKenD1.Fields("D9").Value)
            If d9 <> "" Then
                earJNum += 1
            End If
            If d9 = "2" Then
                ear1000Hz += 1
                ear4000Hz += 1
            End If
            '胸部Ｘ線
            Dim d25 As String = Util.checkDBNullValue(rsKenD1.Fields("D25").Value)
            Dim d26 As String = Util.checkDBNullValue(rsKenD1.Fields("D26").Value)
            Dim d27 As String = Util.checkDBNullValue(rsKenD1.Fields("D27").Value)
            If d25 <> "" Then
                xpJNum += 1
            End If
            If d25 <> "" AndAlso d25 <> NP_WORD Then
                xp += 1
            End If
            '血圧
            Dim d3 As String = Util.checkDBNullValue(rsKenD1.Fields("D3").Value)
            Dim d4 As String = Util.checkDBNullValue(rsKenD1.Fields("D4").Value)
            Dim d3Result As Boolean = checkBaseValue(d3, "最高血圧", sex)
            Dim d4Result As Boolean = checkBaseValue(d4, "最低血圧", sex)
            If d3 <> "" Then
                bpJNum += 1
            End If
            If Not d3Result OrElse Not d4Result Then
                bp += 1
            End If
            '貧血
            Dim d32 As String = Util.checkDBNullValue(rsKenD1.Fields("D32").Value)
            Dim d32Result As Boolean = checkBaseValue(d32, "ﾍﾓｸﾞﾛﾋﾞﾝ", sex)
            If d32 <> "" Then
                hinJNum += 1
            End If
            If Not d32Result Then
                hin += 1
            End If
            '肝機能




            rsKenD1.MoveNext()
        End While

        'A4データの集計処理
        While Not rsKenD2.EOF
            '性別
            Dim sex As String = Util.checkDBNullValue(rsKenD2.Fields("Sex").Value)

            '聴力
            Dim d12 As String = Util.checkDBNullValue(rsKenD2.Fields("D12").Value)
            Dim d13 As String = Util.checkDBNullValue(rsKenD2.Fields("D13").Value)
            Dim d14 As String = Util.checkDBNullValue(rsKenD2.Fields("D14").Value)
            Dim d15 As String = Util.checkDBNullValue(rsKenD2.Fields("D15").Value)
            If d12 <> "" Then
                earJNum += 1
            End If
            If d12 = "2" OrElse d14 = "2" Then
                ear1000Hz += 1
            End If
            If d13 = "2" OrElse d15 = "2" Then
                ear4000Hz += 1
            End If
            '胸部Ｘ線
            Dim d63 As String = Util.checkDBNullValue(rsKenD2.Fields("D63").Value)
            Dim d64 As String = Util.checkDBNullValue(rsKenD2.Fields("D64").Value)
            If d63 <> "" Then
                xpJNum += 1
            End If
            If d63 <> "" AndAlso d63 <> NP_WORD Then
                xp += 1
            End If
            '血圧
            Dim d16 As String = Util.checkDBNullValue(rsKenD2.Fields("D16").Value)
            Dim d17 As String = Util.checkDBNullValue(rsKenD2.Fields("D17").Value)
            Dim d16Result As Boolean = checkBaseValue(d16, "最高血圧", sex)
            Dim d17Result As Boolean = checkBaseValue(d17, "最低血圧", sex)
            If d16 <> "" Then
                bpJNum += 1
            End If
            If Not d16Result OrElse Not d17Result Then
                bp += 1
            End If
            '貧血
            Dim d46 As String = Util.checkDBNullValue(rsKenD2.Fields("D46").Value)
            Dim d46Result As Boolean = checkBaseValue(d46, "ﾍﾓｸﾞﾛﾋﾞﾝ", sex)
            If d46 <> "" Then
                hinJNum += 1
            End If
            If Not d46Result Then
                hin += 1
            End If



            rsKenD2.MoveNext()
        End While

        '集計値セット
        '聴力1000Hz　実施者数、所見者数
        dtResult.Rows(0).Item("JNum") = earJNum
        dtResult.Rows(0).Item("SNum") = ear1000Hz
        '聴力4000Hz　実施者数、所見者数
        dtResult.Rows(1).Item("JNum") = earJNum
        dtResult.Rows(1).Item("SNum") = ear4000Hz
        '胸部Ｘ線　実施者数、所見者数
        dtResult.Rows(2).Item("JNum") = xpJNum
        dtResult.Rows(2).Item("SNum") = xp
        '血圧　実施者数、所見者数
        dtResult.Rows(3).Item("JNum") = bpJNum
        dtResult.Rows(3).Item("SNum") = bp
        '貧血
        dtResult.Rows(4).Item("JNum") = hinJNum
        dtResult.Rows(4).Item("SNum") = hin


    End Sub

    ''' <summary>
    ''' 検査値が基準値範囲外かチェック
    ''' </summary>
    ''' <param name="resultValue">検査結果値</param>
    ''' <param name="itemName">検査項目名</param>
    ''' <returns>範囲内:true、範囲外:false</returns>
    ''' <remarks></remarks>
    Private Function checkBaseValue(resultValue As String, itemName As String, sex As String) As Boolean
        If Not System.Text.RegularExpressions.Regex.IsMatch(resultValue, "^\d+(\.\d+)?$") Then
            Return True
        Else
            '基準値の取得
            Dim low As Decimal
            Dim upp As Decimal
            If sex = "2" AndAlso Array.IndexOf(stdValName, itemName) >= 0 Then
                '女性用の基準値
                low = dtBaseVal.Select("Nam = '" & itemName & "'")(0).Item("Low2")
                upp = dtBaseVal.Select("Nam = '" & itemName & "'")(0).Item("Upp2")
            Else
                low = dtBaseVal.Select("Nam = '" & itemName & "'")(0).Item("Low1")
                upp = dtBaseVal.Select("Nam = '" & itemName & "'")(0).Item("Upp1")
            End If

            '基準値範囲外はfalse、範囲内はtrueを返す
            If Not (low <= resultValue AndAlso resultValue <= upp) Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

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