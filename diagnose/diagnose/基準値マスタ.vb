Imports System.Data.OleDb

Public Class 基準値マスタ

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
    Private Sub 基準値マスタ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        initDgvStdM()
        displayDgvStdM()
    End Sub

    ''' <summary>
    ''' keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 基準値マスタ_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvStdM()
        Util.EnableDoubleBuffering(dgvStdM)

        With dgvStdM
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
            .RowHeadersWidth = 32
            .RowTemplate.Height = 19
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
        namBox.Text = ""
        low1Box.Text = ""
        upp1Box.Text = ""
        low2Box.Text = ""
        upp2Box.Text = ""
    End Sub

    ''' <summary>
    ''' データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvStdM()
        '内容クリア
        dgvStdM.Columns.Clear()
        namBox.Text = ""
        low1Box.Text = ""
        upp1Box.Text = ""
        low2Box.Text = ""
        upp2Box.Text = ""

        'データ取得
        Dim cnn As New ADODB.Connection
        cnn.Open(topForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Nam, Low1, Upp1, Low2, Upp2 from StdM order by Nam"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "UsrM")
        Dim dt As DataTable = ds.Tables("UsrM")

        '表示
        dgvStdM.DataSource = dt
        If Not IsNothing(dgvStdM.CurrentRow) Then
            dgvStdM.CurrentRow.Selected = False
        End If

        '幅設定等
        With dgvStdM
            With .Columns("Nam")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "検査項目名"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 140
            End With
            With .Columns("Low1")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "共通（男）下限"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
            End With
            With .Columns("Upp1")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "共通（男）上限"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
            End With
            With .Columns("Low2")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "（女）下限"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
            End With
            With .Columns("Upp2")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "（女）上限"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
            End With
        End With

    End Sub

    ''' <summary>
    ''' セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStdM_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStdM.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim nam As String = Util.checkDBNullValue(dgvStdM("Nam", e.RowIndex).Value)
            Dim low1 As String = Util.checkDBNullValue(dgvStdM("Low1", e.RowIndex).Value)
            Dim upp1 As String = Util.checkDBNullValue(dgvStdM("Upp1", e.RowIndex).Value)
            Dim low2 As String = Util.checkDBNullValue(dgvStdM("Low2", e.RowIndex).Value)
            Dim upp2 As String = Util.checkDBNullValue(dgvStdM("Upp2", e.RowIndex).Value)

            '各ボックスへ
            namBox.Text = nam
            low1Box.Text = low1
            upp1Box.Text = upp1
            low2Box.Text = low2
            upp2Box.Text = upp2
        End If
    End Sub

    ''' <summary>
    ''' CellPaintingイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStdM_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvStdM.CellPainting
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
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '検査項目名
        Dim nam As String = namBox.Text
        If nam = "" Then
            MsgBox("検査項目名を入力して下さい。", MsgBoxStyle.Exclamation)
            namBox.Focus()
            Return
        End If
        '共通（男）下限
        Dim low1 As String = low1Box.Text
        If Not System.Text.RegularExpressions.Regex.IsMatch(low1, "^\d+(\.\d+)?$") Then
            MsgBox("数値を入力して下さい。", MsgBoxStyle.Exclamation)
            low1Box.Focus()
            Return
        End If
        '共通（男）上限
        Dim upp1 As String = upp1Box.Text
        If Not System.Text.RegularExpressions.Regex.IsMatch(upp1, "^\d+(\.\d+)?$") Then
            MsgBox("数値を入力して下さい。", MsgBoxStyle.Exclamation)
            upp1Box.Focus()
            Return
        End If
        '共通（女）下限
        Dim low2 As String = low2Box.Text
        If Not System.Text.RegularExpressions.Regex.IsMatch(low2, "^\d+(\.\d+)?$") Then
            MsgBox("数値を入力して下さい。", MsgBoxStyle.Exclamation)
            low2Box.Focus()
            Return
        End If
        '共通（女）上限
        Dim upp2 As String = upp2Box.Text
        If Not System.Text.RegularExpressions.Regex.IsMatch(upp2, "^\d+(\.\d+)?$") Then
            MsgBox("数値を入力して下さい。", MsgBoxStyle.Exclamation)
            upp2Box.Focus()
            Return
        End If

        '登録
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from StdM where Nam = '" & nam & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            rs.AddNew()
            rs.Fields("Nam").Value = nam
        End If
        rs.Fields("Low1").Value = low1
        rs.Fields("Upp1").Value = upp1
        rs.Fields("Low2").Value = low2
        rs.Fields("Upp2").Value = upp2
        rs.Update()
        rs.Close()
        cn.Close()

        '再表示
        displayDgvStdM()
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '検査項目名
        Dim nam As String = namBox.Text
        If nam = "" Then
            MsgBox("検査項目名を入力して下さい。", MsgBoxStyle.Exclamation)
            namBox.Focus()
            Return
        End If

        '存在チェック
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from StdM where Nam = '" & nam & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("データが存在しません。", MsgBoxStyle.Exclamation)
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
                displayDgvStdM()
            Else
                rs.Close()
                cn.Close()
            End If
        End If
    End Sub
End Class