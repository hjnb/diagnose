Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class 事業所マスタ

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
    Private Sub 事業所マスタ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        '印刷ラジオボタン初期値設定
        initPrintState()

        'データグリッドビュー初期設定
        initDgvMaster()

        '事業所データ表示
        displayDgvMaster()
    End Sub

    ''' <summary>
    ''' keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 受診者マスタ_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 印刷ラジオボタン初期値設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initPrintState()
        Dim state As String = Util.getIniString("System", "Printer", topForm.iniFilePath)
        If state = "Y" Then
            rbtnPrint.Checked = True
        Else
            rbtnPreview.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' ﾌﾟﾚﾋﾞｭｰラジオボタン値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnPreview_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPreview.CheckedChanged
        If rbtnPreview.Checked = True Then
            Util.putIniString("System", "Printer", "N", topForm.iniFilePath)
        End If
    End Sub

    ''' <summary>
    ''' 印刷ラジオボタン値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnPrint_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPrint.CheckedChanged
        If rbtnPrint.Checked = True Then
            Util.putIniString("System", "Printer", "Y", topForm.iniFilePath)
        End If
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvMaster()
        Util.EnableDoubleBuffering(dgvMaster)

        With dgvMaster
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowHeadersWidth = 35
            .RowTemplate.Height = 18
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 10)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        indBox.Text = ""
        kanaBox.Text = ""
        telBox.Text = ""
        faxBox.Text = ""
        tantoBox.Text = ""
        postBox.Text = ""
        jyuBox.Text = ""
        codBox.Text = ""
        sYmdBox.clearText()
        tan1Box.Text = ""
        tan2Box.Text = ""
        commentBox.Text = ""
    End Sub

    ''' <summary>
    ''' 事業所マスタデータ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvMaster()
        '内容クリア
        dgvMaster.Columns.Clear()
        clearInput()

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select IAB.Ind, IAB.Kana, C.PCount, IAB.Tel, IAB.Fax, IAB.Tanto, IAB.Post, IAB.Jyu, IAB.SYmd, IAB.Cod, IAB.MaxA4, IAB.MaxB5, IAB.Tan1, IAB.Tan2, IAB.Text from (select IA.Ind, IA.Kana, IA.Tel, IA.Fax, IA.Tanto, IA.Post, IA.Jyu, IA.SYmd, IA.Cod, IA.Tan1, IA.Tan2, IA.Text, IA.MaxA4, B.MaxB5 from (select I.Ind, I.Kana, I.Tel, I.Fax, I.Tanto, I.Post, I.Jyu, I.SYmd, I.Cod, I.Tan1, I.Tan2, I.Text, A.MaxA4 from IndM as I left outer join (select Ind, Max(Ymd) as MaxA4 from Ken2 group by Ind) as A on I.Ind = A.Ind) as IA left outer join (select Ind, Max(Ymd) as MaxB5 from Ken1 group by Ind) as B on IA.Ind = B.Ind) as IAB left outer join (select Ind, count(Ind) as PCount from UsrM group by Ind) as C on IAB.Ind = C.Ind order by IAB.Kana"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "IndM")
        Dim dt As DataTable = ds.Tables("IndM")

        '最終日付列
        For Each row As DataRow In dt.Rows
            '登録最終日付、B5の最新実施日、A4の最新実施日で比較し最新のを表示
            Dim maxA As String = Util.checkDBNullValue(row("MaxA4"))
            Dim maxB As String = Util.checkDBNullValue(row("MaxB5"))
            Dim sYmd As String = Util.checkDBNullValue(row("SYmd"))
            Dim maxYmd As String = If(maxA <= maxB, maxB, maxA)
            maxYmd = If(maxYmd <= sYmd, sYmd, maxYmd)
            row("SYmd") = If(maxYmd = "", "", Util.convADStrToWarekiStr(maxYmd))
        Next

        '表示
        dgvMaster.DataSource = dt
        cnn.Close()

        '幅設定等
        With dgvMaster

            '非表示
            .Columns("MaxA4").Visible = False
            .Columns("MaxB5").Visible = False

            With .Columns("Ind")
                .HeaderText = "事業所名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 240
                .Frozen = True
                '.Visible = False
            End With
            With .Columns("Kana")
                .HeaderText = "カナ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("PCount")
                .HeaderText = "登録数"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 65
            End With
            With .Columns("Tel")
                .HeaderText = "TEL"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 105
            End With
            With .Columns("Fax")
                .HeaderText = "FAX"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 105
            End With
            With .Columns("Tanto")
                .HeaderText = "担当者"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 105
            End With
            With .Columns("Post")
                .HeaderText = "〒"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 80
            End With
            With .Columns("Jyu")
                .HeaderText = "住所"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 375
            End With
            With .Columns("Cod")
                .HeaderText = "請求ｺｰﾄﾞ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
            End With
            With .Columns("SYmd")
                .HeaderText = "最終日付"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("Tan1")
                .HeaderText = "単価１"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .DefaultCellStyle.Format = "#,0"
            End With
            With .Columns("Tan2")
                .HeaderText = "単価２"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .DefaultCellStyle.Format = "#,0"
            End With
            With .Columns("Text")
                .HeaderText = "コメント"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 305
            End With
        End With

        'フォーカス
        indBox.Focus()
    End Sub

    ''' <summary>
    ''' CellFormatting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvMaster.CellFormatting
        '単価１と単価２の列
        If e.RowIndex >= 0 AndAlso (e.ColumnIndex = 11 OrElse e.ColumnIndex = 12) Then
            If e.Value = 0 Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMaster.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim ind As String = Util.checkDBNullValue(dgvMaster("Ind", e.RowIndex).Value)
            Dim kana As String = Util.checkDBNullValue(dgvMaster("Kana", e.RowIndex).Value)
            Dim tel As String = Util.checkDBNullValue(dgvMaster("Tel", e.RowIndex).Value)
            Dim fax As String = Util.checkDBNullValue(dgvMaster("Fax", e.RowIndex).Value)
            Dim tanto As String = Util.checkDBNullValue(dgvMaster("Tanto", e.RowIndex).Value)
            Dim post As String = Util.checkDBNullValue(dgvMaster("Post", e.RowIndex).Value)
            Dim jyu As String = Util.checkDBNullValue(dgvMaster("Jyu", e.RowIndex).Value)
            Dim cod As String = Util.checkDBNullValue(dgvMaster("Cod", e.RowIndex).Value)
            Dim sYmd As String = Util.checkDBNullValue(dgvMaster("SYmd", e.RowIndex).Value)
            Dim tan1 As String = Util.checkDBNullValue(dgvMaster("Tan1", e.RowIndex).Value)
            Dim tan2 As String = Util.checkDBNullValue(dgvMaster("Tan2", e.RowIndex).Value)
            Dim comment As String = Util.checkDBNullValue(dgvMaster("Text", e.RowIndex).Value)

            '値をセット
            indBox.Text = ind
            kanaBox.Text = kana
            telBox.Text = tel
            faxBox.Text = fax
            tantoBox.Text = tanto
            postBox.Text = post
            jyuBox.Text = jyu
            codBox.Text = cod
            If sYmd <> "" Then
                sYmdBox.setWarekiStr(sYmd)
            End If
            tan1Box.Text = tan1
            tan2Box.Text = tan2
            commentBox.Text = comment

            'フォーカス
            indBox.Focus()
            indBox.SelectionStart = indBox.TextLength
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvMaster.CellPainting
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
    ''' 列ヘッダーダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_ColumnHeaderMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMaster.ColumnHeaderMouseDoubleClick
        Dim targetColumn As DataGridViewColumn = dgvMaster.Columns(e.ColumnIndex) '選択列
        dgvMaster.Sort(targetColumn, System.ComponentModel.ListSortDirection.Ascending) '昇順でソート
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '事業所名
        Dim ind As String = indBox.Text
        If ind = "" Then
            MsgBox("事業所名を入力して下さい。", MsgBoxStyle.Exclamation)
            indBox.Focus()
            Return
        End If
        'カナ
        Dim kana As String = kanaBox.Text
        If kana = "" Then
            MsgBox("カナを入力して下さい。", MsgBoxStyle.Exclamation)
            kanaBox.Focus()
            Return
        End If
        'TEL
        Dim tel As String = telBox.Text
        'FAX
        Dim fax As String = faxBox.Text
        '担当者
        Dim tanto As String = tantoBox.Text
        '〒
        Dim post As String = postBox.Text
        '住所
        Dim jyu As String = jyuBox.Text
        '請求ｺｰﾄﾞ
        Dim cod As String = codBox.Text
        '最終日付
        Dim sYmd As String = sYmdBox.getADStr()
        '単価１
        Dim tan1 As String = If(tan1Box.Text = "", "0", tan1Box.Text)
        If Not System.Text.RegularExpressions.Regex.IsMatch(tan1, "^\d+$") Then
            MsgBox("単価は数値を入力して下さい。", MsgBoxStyle.Exclamation)
            tan1Box.Focus()
            Return
        End If
        '単価２
        Dim tan2 As String = If(tan2Box.Text = "", "0", tan2Box.Text)
        If Not System.Text.RegularExpressions.Regex.IsMatch(tan2, "^\d+$") Then
            MsgBox("単価は数値を入力して下さい。", MsgBoxStyle.Exclamation)
            tan2Box.Focus()
            Return
        End If
        'ｺﾒﾝﾄ
        Dim comment As String = commentBox.Text

        '登録
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from IndM where Ind = '" & ind & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            rs.AddNew()
            rs.Fields("Ind").Value = ind
            rs.Fields("Kana").Value = kana
            rs.Fields("Tel").Value = tel
            rs.Fields("Fax").Value = fax
            rs.Fields("Tanto").Value = tanto
            rs.Fields("Post").Value = post
            rs.Fields("Jyu").Value = jyu
            rs.Fields("Cod").Value = cod
            rs.Fields("SYmd").Value = sYmd
            rs.Fields("Tan1").Value = tan1
            rs.Fields("Tan2").Value = tan2
            rs.Fields("Text").Value = comment
            rs.Update()
            rs.Close()
            cn.Close()

            '再表示
            displayDgvMaster()
        Else
            '更新登録
            Dim result As DialogResult = MessageBox.Show("変更してよろしいですか？", "変更", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                rs.Fields("Ind").Value = ind
                rs.Fields("Kana").Value = kana
                rs.Fields("Tel").Value = tel
                rs.Fields("Fax").Value = fax
                rs.Fields("Tanto").Value = tanto
                rs.Fields("Post").Value = post
                rs.Fields("Jyu").Value = jyu
                rs.Fields("Cod").Value = cod
                rs.Fields("SYmd").Value = sYmd
                rs.Fields("Tan1").Value = tan1
                rs.Fields("Tan2").Value = tan2
                rs.Fields("Text").Value = comment
                rs.Update()
                rs.Close()
                cn.Close()

                '再表示
                displayDgvMaster()
            Else
                rs.Close()
                cn.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '事業所名
        Dim ind As String = indBox.Text
        If ind = "" Then
            MsgBox("事業所名を入力して下さい。", MsgBoxStyle.Exclamation)
            indBox.Focus()
            Return
        End If

        '削除
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from IndM where Ind = '" & ind & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("登録されていません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                rs.Delete()
                rs.Update()
                rs.Close()
                cn.Close()

                '再表示
                displayDgvMaster()
            Else
                rs.Close()
                cn.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        '件数
        Dim rowsCount As Integer = dgvMaster.Rows.Count

        '現在日付
        Dim nowYmd As String = DateTime.Now.ToString("yyyy/MM/dd")

        '貼り付けデータ作成
        Dim dataList As New List(Of String(,))
        Dim dataArray(35, 9) As String
        Dim arrayRowIndex As Integer = 0
        For i As Integer = 0 To rowsCount - 1
            If arrayRowIndex = 36 Then
                dataList.Add(dataArray.Clone())
                Array.Clear(dataArray, 0, dataArray.Length)
                arrayRowIndex = 0
            End If

            'No.
            dataArray(arrayRowIndex, 0) = i + 1
            '事業所名
            dataArray(arrayRowIndex, 1) = Util.checkDBNullValue(dgvMaster("Ind", i).Value)
            'ｶﾅ
            dataArray(arrayRowIndex, 2) = Util.checkDBNullValue(dgvMaster("Kana", i).Value)
            '登録数
            dataArray(arrayRowIndex, 3) = Util.checkDBNullValue(dgvMaster("PCount", i).Value)
            '最終日付
            dataArray(arrayRowIndex, 4) = Util.checkDBNullValue(dgvMaster("SYmd", i).Value)
            '関連
            Dim kanren As String = Util.checkDBNullValue(dgvMaster("Text", i).Value)
            dataArray(arrayRowIndex, 5) = If(kanren.IndexOf("関連") >= 0, kanren, "")
            'TEL
            dataArray(arrayRowIndex, 6) = Util.checkDBNullValue(dgvMaster("Tel", i).Value)
            '担当者
            dataArray(arrayRowIndex, 7) = Util.checkDBNullValue(dgvMaster("Tanto", i).Value)
            '〒
            dataArray(arrayRowIndex, 8) = Util.checkDBNullValue(dgvMaster("Post", i).Value)
            '住所
            dataArray(arrayRowIndex, 9) = Util.checkDBNullValue(dgvMaster("Jyu", i).Value)

            arrayRowIndex += 1
        Next
        dataList.Add(dataArray.Clone())

        'エクセル
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(topForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("事業所一覧改")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '日付
        oSheet.Range("E2").Value = nowYmd

        '必要枚数コピペ
        For i As Integer = 0 To dataList.Count - 2
            Dim xlPasteRange As Excel.Range = oSheet.Range("A" & (41 + (40 * i))) 'ペースト先
            oSheet.Rows("1:40").copy(xlPasteRange)
            oSheet.HPageBreaks.Add(oSheet.Range("A" & (41 + (40 * i)))) '改ページ
        Next

        'データ貼り付け
        For i As Integer = 0 To dataList.Count - 1
            oSheet.Range("K" & (2 + 40 * i)).Value = (i + 1) & " 頁"
            oSheet.Range("B" & (4 + 40 * i), "K" & (39 + 40 * i)).Value = dataList(i)
        Next

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If rbtnPrint.Checked = True Then
            oSheet.PrintOut()
        ElseIf rbtnPreview.Checked = True Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub

    ''' <summary>
    ''' 封筒ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEnvelope_Click(sender As System.Object, e As System.EventArgs) Handles btnEnvelope.Click
        '事業所名
        Dim ind As String = indBox.Text
        If ind = "" Then
            MsgBox("事業所名を入力して下さい。", MsgBoxStyle.Exclamation)
            indBox.Focus()
            Return
        End If
        '郵便番号
        Dim post As String = postBox.Text
        '住所
        Dim jyu As String = jyuBox.Text.Replace(" ", "　")
        Dim jyu1 As String = jyu.Split("　")(0)
        Dim jyu2 As String = If(jyu.IndexOf("　") >= 0, jyu.Split("　")(1), "")

        'エクセル
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(topForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("角形２号")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '郵便番号
        oSheet.Range("Y6").Value = If(post = "", "", "〒" & post)
        '住所１
        oSheet.Range("K19").Value = jyu1
        '住所２
        oSheet.Range("K20").Value = jyu2
        '事業所名
        oSheet.Range("K22").Value = ind & "　様"

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If rbtnPrint.Checked = True Then
            oSheet.PrintOut()
        ElseIf rbtnPreview.Checked = True Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub
End Class