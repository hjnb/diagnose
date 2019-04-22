Imports System.Data.OleDb

Public Class 受診者マスタ
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
    Private Sub 受診者マスタ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        '印刷ラジオボタン初期値設定
        initPrintState()

        '事業所名ボックス初期設定
        initIndBox()

        'データグリッドビュー初期設定
        initDgvMaster()
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
    Private Sub initDgvMaster()
        Util.EnableDoubleBuffering(dgvMaster)

        With dgvMaster
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
            .RowHeadersWidth = 30
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
    ''' 対象事業所のデータ一覧表示
    ''' </summary>
    ''' <param name="ind">事業所名</param>
    ''' <remarks></remarks>
    Private Sub displayDgvMaster(ind As String)
        '内容クリア
        dgvMaster.Columns.Clear()

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select UK1.Nam, UK1.Kana, UK1.Sex, UK1.Birth, UK1.Age, UK1.MaxYmdB, KK2.MaxYmdA, UK1.D72, UK1.D73, UK1.D74, KK2.D76, KK2.D77, KK2.D78, KK2.D79, KK2.D80, UK1.Tel, UK1.Post, UK1.Jyu, UK1.Tan, UK1.Text from (select U.Nam, U.Kana, U.Sex, U.Birth, Int((Format(NOW(),'YYYYMMDD')-Format(U.Birth, 'YYYYMMDD'))/10000) as Age, U.Tel, U.Post, U.Jyu, U.Tan, U.Text, K1.MaxYmdB, KK1.D72, KK1.D73, KK1.D74 from UsrM as U left join (select K1.Kana, K1.MaxYmdB, Ken1.D72, Ken1.D73, Ken1.D74 from (select Kana, Max(Ymd) as MaxYmdB from Ken1 group by Kana) as K1 inner join Ken1 On K1.Kana = Ken1.Kana and K1.MaxYmdB = Ken1.Ymd) as KK1 On U.Kana = KK1.Kana where U.Ind = '" & ind & "') as UK1 left join (select K2.Kana, K2.MaxYmdA, Ken2.D76, Ken2.D77, Ken2.D78, Ken2.D79, Ken2.D80 from (select Kana, Max(Ymd) as MaxYmdA from Ken2 group by Kana) as K2 inner join Ken2 On K2.Kana = Ken2.Kana and K2.MaxYmdA = Ken2.Ymd) as KK2 On UK1.Kana = KK2.Kana order by UK1.Kana"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "UsrM")
        Dim dt As DataTable = ds.Tables("UsrM")

        '列追加
        dt.Columns.Add("List", GetType(Boolean)) '名簿
        dt.Columns.Add("LastDate", GetType(String)) '実施日
        dt.Columns.Add("Decision", GetType(String)) '判定
        For Each row As DataRow In dt.Rows
            '名簿列デフォルトでチェック有
            row("List") = True
            '実施日(B5とA4の実施日で比較し最新のを表示)
            Dim maxB As String = Util.checkDBNullValue(row("MaxYmdB"))
            Dim maxA As String = Util.checkDBNullValue(row("MaxYmdA"))
            If maxB = "" AndAlso maxA = "" Then
                row("LastDate") = ""
            Else
                row("LastDate") = If(maxB >= maxA, Util.convADStrToWarekiStr(maxB) & "  B5", Util.convADStrToWarekiStr(maxA) & "  A4")
            End If
            '判定
            Dim decisionList As New List(Of String)
            If maxB >= maxA Then
                'B5のデータの"要"が含まれてる文字取得
                Dim d72 As String = Util.checkDBNullValue(row("D72")).Replace("　", " ")
                Dim d73 As String = Util.checkDBNullValue(row("D73")).Replace("　", " ")
                Dim d74 As String = Util.checkDBNullValue(row("D74")).Replace("　", " ")
                Dim d72Index As Integer = d72.IndexOf("要")
                Dim d73Index As Integer = d73.IndexOf("要")
                Dim d74Index As Integer = d74.IndexOf("要")
                If d72Index >= 0 Then
                    Dim d72you As String = d72.Substring(d72Index, d72.Length - d72Index)
                    decisionList.Add(d72you.Split(" ")(0))
                End If
                If d73Index >= 0 Then
                    Dim d73you As String = d73.Substring(d73Index, d73.Length - d73Index)
                    decisionList.Add(d73you.Split(" ")(0))
                End If
                If d74Index >= 0 Then
                    Dim d74you As String = d74.Substring(d74Index, d74.Length - d74Index)
                    decisionList.Add(d74you.Split(" ")(0))
                End If
            Else
                'A4のデータの"要"が含まれてる文字取得
                Dim d76 As String = Util.checkDBNullValue(row("D76")).Replace("　", " ")
                Dim d77 As String = Util.checkDBNullValue(row("D77")).Replace("　", " ")
                Dim d78 As String = Util.checkDBNullValue(row("D78")).Replace("　", " ")
                Dim d79 As String = Util.checkDBNullValue(row("D79")).Replace("　", " ")
                Dim d80 As String = Util.checkDBNullValue(row("D80")).Replace("　", " ")
                Dim d76Index As Integer = d76.IndexOf("要")
                Dim d77Index As Integer = d77.IndexOf("要")
                Dim d78Index As Integer = d78.IndexOf("要")
                Dim d79Index As Integer = d79.IndexOf("要")
                Dim d80Index As Integer = d80.IndexOf("要")
                If d76Index >= 0 Then
                    Dim d76you As String = d76.Substring(d76Index, d76.Length - d76Index)
                    decisionList.Add(d76you.Split(" ")(0))
                End If
                If d77Index >= 0 Then
                    Dim d77you As String = d77.Substring(d77Index, d77.Length - d77Index)
                    decisionList.Add(d77you.Split(" ")(0))
                End If
                If d78Index >= 0 Then
                    Dim d78you As String = d78.Substring(d78Index, d78.Length - d78Index)
                    decisionList.Add(d78you.Split(" ")(0))
                End If
                If d79Index >= 0 Then
                    Dim d79you As String = d79.Substring(d79Index, d79.Length - d79Index)
                    decisionList.Add(d79you.Split(" ")(0))
                End If
                If d80Index >= 0 Then
                    Dim d80you As String = d80.Substring(d80Index, d80.Length - d80Index)
                    decisionList.Add(d80you.Split(" ")(0))
                End If
            End If
            Dim decision As String = ""
            For i As Integer = 0 To decisionList.Count - 1
                If i = 0 Then
                    decision = decisionList(i)
                Else
                    decision = decision & " " & decisionList(i)
                End If
            Next
            row("Decision") = decision
        Next

        dgvMaster.DataSource = dt
        cnn.Close()

        '幅設定等
        With dgvMaster
            .Columns("MaxYmdB").Visible = False
            .Columns("MaxYmdA").Visible = False

            .Columns("D72").Visible = False
            .Columns("D73").Visible = False
            .Columns("D74").Visible = False
            .Columns("D76").Visible = False
            .Columns("D77").Visible = False
            .Columns("D78").Visible = False
            .Columns("D79").Visible = False
            .Columns("D80").Visible = False

            With .Columns("List")
                .DisplayIndex = 0
                .HeaderText = "名簿"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 35
                .HeaderCell.Style.Font = New Font("ＭＳ Ｐゴシック", 9)
            End With
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
                .Frozen = True
                .ReadOnly = True
            End With
            With .Columns("Kana")
                .HeaderText = "カナ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 130
                .ReadOnly = True
            End With
            With .Columns("Sex")
                .HeaderText = "性別"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
                .HeaderCell.Style.Font = New Font("ＭＳ Ｐゴシック", 9)
                .ReadOnly = True
            End With
            With .Columns("Birth")
                .HeaderText = "生年月日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
                .ReadOnly = True
            End With
            With .Columns("Age")
                .HeaderText = "年齢"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
                .HeaderCell.Style.Font = New Font("ＭＳ Ｐゴシック", 9)
                .ReadOnly = True
            End With
            With .Columns("LastDate")
                .DisplayIndex = 6
                .HeaderText = "実施日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
                .ReadOnly = True
            End With
            With .Columns("Decision")
                .DisplayIndex = 7
                .HeaderText = "判定"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                If dgvMaster.Rows.Count > 20 Then
                    .Width = 123
                Else
                    .Width = 140
                End If
                .ReadOnly = True
            End With
            With .Columns("Tel")
                .HeaderText = "TEL"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
                .ReadOnly = True
            End With
            With .Columns("Post")
                .HeaderText = "〒"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("Jyu")
                .HeaderText = "住所"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 300
                .ReadOnly = True
            End With
            With .Columns("Tan")
                .HeaderText = "単価"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 50
                .DefaultCellStyle.Format = "#,0"
                .ReadOnly = True
            End With
            With .Columns("Text")
                .HeaderText = "コメント"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 300
                .ReadOnly = True
            End With
        End With
    End Sub

    ''' <summary>
    ''' 事業所名ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub indBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles indBox.SelectedValueChanged
        Dim ind As String = indBox.Text
        If ind <> "" Then
            displayDgvMaster(ind)
        End If
    End Sub

    ''' <summary>
    ''' cellFormatingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvMaster.CellFormatting
        If e.RowIndex >= 0 AndAlso dgvMaster.Columns(e.ColumnIndex).Name = "Birth" Then
            e.Value = Util.convADStrToWarekiStr(e.Value)
            e.FormattingApplied = True
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
            '値取得
            Dim nam As String = Util.checkDBNullValue(dgvMaster("Nam", e.RowIndex).Value)
            Dim kana As String = Util.checkDBNullValue(dgvMaster("Kana", e.RowIndex).Value)
            Dim sex As String = Util.checkDBNullValue(dgvMaster("Sex", e.RowIndex).Value)
            Dim birth As String = Util.checkDBNullValue(dgvMaster("Birth", e.RowIndex).Value)
            Dim tel As String = Util.checkDBNullValue(dgvMaster("Tel", e.RowIndex).Value)
            Dim post As String = Util.checkDBNullValue(dgvMaster("Post", e.RowIndex).Value)
            Dim jyu As String = Util.checkDBNullValue(dgvMaster("Jyu", e.RowIndex).Value)
            Dim tan As String = dgvMaster("Tan", e.RowIndex).Value
            Dim comment As String = Util.checkDBNullValue(dgvMaster("Text", e.RowIndex).Value)

            '各ボックスへセット
            namBox.Text = nam
            kanaBox.Text = kana
            sexBox.Text = sex
            birthBox.setADStr(birth)
            telBox.Text = tel
            postBox.Text = post
            jyuBox.Text = jyu
            TanBox.Text = tan
            commentBox.Text = comment
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
    ''' 列ヘッダーダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMaster_ColumnHeaderMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMaster.ColumnHeaderMouseDoubleClick
        Dim targetColumn As DataGridViewColumn = dgvMaster.Columns(e.ColumnIndex) '選択列
        dgvMaster.Sort(targetColumn, System.ComponentModel.ListSortDirection.Ascending) '昇順でソート
    End Sub
End Class