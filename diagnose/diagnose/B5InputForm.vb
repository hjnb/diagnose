Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Data.OleDb

Public Class B5InputForm

    '事業所名
    Private ind As String
    '氏名
    Private nam As String
    'カナ
    Private kana As String
    '性別（男：1、女：2）
    Private sex As String
    '生年月日(yyyy/MM/dd)
    Private birth As String
    '印刷状態(印刷:true, ﾌﾟﾚﾋﾞｭｰ:false)
    Private printState As Boolean
    '1列目セルスタイル
    Private item1CellStyle As DataGridViewCellStyle
    '2列目セルスタイル
    Private item2CellStyle As DataGridViewCellStyle
    '蛋白、糖用
    Private numberDic1 As New Dictionary(Of String, String) From {{"1", "－"}, {"2", "±"}, {"3", "＋"}, {"4", "2＋"}, {"5", "3＋"}}
    'ｳﾛﾋﾞﾘﾉｰｹﾞﾝ用
    Private numberDic2 As New Dictionary(Of String, String) From {{"2", "±"}, {"3", "＋"}, {"4", "2＋"}, {"5", "3＋"}}
    '診断書印刷の基準値範囲外の記号
    Private HASHMARK As String = " #"
    '男女で基準値が異なる項目名
    Private stdValName() As String = {"Ｆｅ", "ＨＤＬ－ｺﾚｽﾃﾛｰﾙ", "γ－ＧＴＰ", "ｸﾚｱﾁﾆﾝ", "血清ｸﾚｱﾁﾆﾝ", "赤沈", "赤血球数", "血色素量", "ﾍﾏﾄｸﾘｯﾄ", "ﾍﾓｸﾞﾛﾋﾞﾝ"}

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="ind">事業所名</param>
    ''' <param name="nam">氏名</param>
    ''' <param name="kana">カナ</param>
    ''' <param name="sex">性別</param>
    ''' <param name="birth">生年月日</param>
    ''' <param name="printState">印刷状態</param>
    ''' <remarks></remarks>
    Public Sub New(ind As String, nam As String, kana As String, sex As String, birth As String, printState As Boolean)
        InitializeComponent()

        Me.ind = ind
        Me.nam = nam
        Me.kana = kana
        Me.sex = sex
        Me.birth = birth
        Me.printState = printState
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub B5InputForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        YmdBox.canEnterKeyDown = True

        '受診者情報表示
        indBox.Text = ind
        namBox.Text = nam
        sexBox.Text = If(sex = "1", "男", "女")
        birthBox.Text = Util.convADStrToWarekiStr(birth) & " 生"
        ageBox.Text = "   歳"

        '履歴リスト初期設定
        initHistoryListBox()

        'セルスタイル作成
        initCellStyle()

        'データグリッドビュー初期設定
        initDgvB5Input()

        '初期フォーカス
        YmdBox.Focus()
    End Sub

    ''' <summary>
    ''' セルスタイル作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initCellStyle()
        '1列目
        item1CellStyle = New DataGridViewCellStyle()
        item1CellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
        item1CellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
        item1CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '2列目
        item2CellStyle = New DataGridViewCellStyle()
        item2CellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
        item2CellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
        item2CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End Sub

    ''' <summary>
    ''' 履歴リスト初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initHistoryListBox()
        historyListBox.Items.Clear()
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select Ymd from Ken1 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' order by Ymd Desc"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            historyListBox.Items.Add(Util.checkDBNullValue(rs.Fields("Ymd").Value))
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvB5Input()
        Util.EnableDoubleBuffering(dgvB5Input)

        With dgvB5Input
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.None
            .MultiSelect = False
            .RowHeadersVisible = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersVisible = True
            .ColumnHeadersHeight = 18
            .RowTemplate.Height = 16
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ScrollBars = ScrollBars.Vertical
            .EditMode = DataGridViewEditMode.EditOnEnter
            .DefaultCellStyle.Font = New Font("ＭＳ Ｐゴシック", 9)
        End With

        '列追加、空の行追加
        Dim dt As New DataTable()
        dt.Columns.Add("Item1", Type.GetType("System.String"))
        dt.Columns.Add("Item2", Type.GetType("System.String"))
        dt.Columns.Add("Result", Type.GetType("System.String"))
        For i As Integer = 0 To 64
            Dim row As DataRow = dt.NewRow()
            row(0) = ""
            row(1) = ""
            row(2) = ""
            dt.Rows.Add(row)
        Next

        '初期値設定
        '1列目
        dt.Rows(0).Item("Item1") = "診察等"
        dt.Rows(17).Item("Item1") = "肝炎"
        dt.Rows(20).Item("Item1") = "尿検査"
        dt.Rows(23).Item("Item1") = "聴打診"
        dt.Rows(24).Item("Item1") = "胸部"
        dt.Rows(27).Item("Item1") = "心電図"
        dt.Rows(29).Item("Item1") = "血液検査"
        dt.Rows(53).Item("Item1") = "その他の検査"
        dt.Rows(62).Item("Item1") = "判定"

        '2列目
        dt.Rows(0).Item("Item2") = "身長"
        dt.Rows(1).Item("Item2") = "体重"
        dt.Rows(2).Item("Item2") = "最高血圧"
        dt.Rows(3).Item("Item2") = "最低血圧"
        dt.Rows(4).Item("Item2") = "視力　右　裸眼"
        dt.Rows(5).Item("Item2") = "             矯正"
        dt.Rows(6).Item("Item2") = "　　　  左　裸眼"
        dt.Rows(7).Item("Item2") = "　　　　　   矯正"
        dt.Rows(8).Item("Item2") = "聴力障害　　　1:なし　2:あり"
        dt.Rows(9).Item("Item2") = "　　　　　　　    1:右　　2:左"
        dt.Rows(10).Item("Item2") = "手足の運動障害"
        dt.Rows(11).Item("Item2") = "自覚症状"
        dt.Rows(12).Item("Item2") = "その他の特記事項"
        dt.Rows(13).Item("Item2") = "既往歴　　　　 1:なし　2:あり"
        dt.Rows(14).Item("Item2") = "　　　　　　　　  特記"
        dt.Rows(15).Item("Item2") = "ﾂﾍﾞﾙｸﾘﾝ反応 1:陰性　2:陽性"
        dt.Rows(16).Item("Item2") = "　　　　　　　　  特記"
        dt.Rows(17).Item("Item2") = "HBs 抗原"
        dt.Rows(18).Item("Item2") = "HBs 抗体"
        dt.Rows(19).Item("Item2") = "HCV 抗体"
        dt.Rows(20).Item("Item2") = "蛋白　   1:-　2:±　3:1+　4:2+　5:3+"
        dt.Rows(21).Item("Item2") = "糖　　    1:-　2:±　3:1+　4:2+　5:3+"
        dt.Rows(22).Item("Item2") = "ｳﾛﾋﾞﾘﾉｰｹﾞﾝ 2:±　3:1+　4:2+　5:3+"
        dt.Rows(23).Item("Item2") = "所見"
        dt.Rows(24).Item("Item2") = "Ｘ線"
        dt.Rows(25).Item("Item2") = ""
        dt.Rows(26).Item("Item2") = ""
        dt.Rows(27).Item("Item2") = "心電図"
        dt.Rows(28).Item("Item2") = ""
        dt.Rows(29).Item("Item2") = "白血球数"
        dt.Rows(30).Item("Item2") = "赤血球数"
        dt.Rows(31).Item("Item2") = "ﾍﾓｸﾞﾛﾋﾞﾝ"
        dt.Rows(32).Item("Item2") = "ﾍﾏﾄｸﾘｯﾄ"
        dt.Rows(33).Item("Item2") = "総ｺﾚｽﾃﾛｰﾙ"
        dt.Rows(34).Item("Item2") = "HDL-ｺﾚｽﾃﾛｰﾙ"
        dt.Rows(35).Item("Item2") = "中性脂肪"
        dt.Rows(36).Item("Item2") = "ＧＯＴ"
        dt.Rows(37).Item("Item2") = "ＧＰＴ"
        dt.Rows(38).Item("Item2") = "γ－ＧＴＰ"
        dt.Rows(39).Item("Item2") = "ＡＬＰ"
        dt.Rows(40).Item("Item2") = "赤沈"
        dt.Rows(41).Item("Item2") = "ＣＲＰ"
        dt.Rows(42).Item("Item2") = "尿酸"
        dt.Rows(43).Item("Item2") = "尿素窒素"
        dt.Rows(44).Item("Item2") = "ｸﾚｱﾁﾆﾝ"
        dt.Rows(45).Item("Item2") = "総蛋白"
        dt.Rows(46).Item("Item2") = "Ａ／Ｇ"
        dt.Rows(47).Item("Item2") = "ＺＴＴ"
        dt.Rows(48).Item("Item2") = "血糖"
        dt.Rows(49).Item("Item2") = "ﾍﾓｸﾞﾛﾋﾞﾝＡ１ｃ"
        dt.Rows(50).Item("Item2") = "Ｆｅ"
        dt.Rows(51).Item("Item2") = "ＲＰＲ"
        dt.Rows(52).Item("Item2") = "ＴＰＨＡ"
        dt.Rows(53).Item("Item2") = ""
        dt.Rows(54).Item("Item2") = ""
        dt.Rows(55).Item("Item2") = ""
        dt.Rows(56).Item("Item2") = ""
        dt.Rows(57).Item("Item2") = ""
        dt.Rows(58).Item("Item2") = ""
        dt.Rows(59).Item("Item2") = ""
        dt.Rows(60).Item("Item2") = ""
        dt.Rows(61).Item("Item2") = ""
        dt.Rows(62).Item("Item2") = "総合判定"
        dt.Rows(63).Item("Item2") = ""
        dt.Rows(64).Item("Item2") = ""

        '表示
        dgvB5Input.DataSource = dt

        '幅設定等
        With dgvB5Input
            With .Columns("Item1")
                .HeaderText = ""
                .DefaultCellStyle = item1CellStyle
                .Width = 100
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Item2")
                .HeaderText = "項目"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 220
                For i As Integer = 0 To 64
                    If (0 <= i AndAlso i <= 52) OrElse i >= 62 Then
                        dgvB5Input("Item2", i).ReadOnly = True
                        dgvB5Input("Item2", i).Style = item2CellStyle
                    End If
                Next
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Result")
                .HeaderText = "検査値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 220
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
    End Sub

    ''' <summary>
    ''' 健診日ボックスエンターキーイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub YmdBox_keyDownEnter(sender As Object, e As System.EventArgs) Handles YmdBox.keyDownEnterOrDown
        If YmdBox.getADStr() = "" Then
            Return
        End If

        '年齢算出、ラベルに表示
        Dim age As Integer = Util.calcAge(birth, YmdBox.getADStr())
        ageBox.Text = age & " 歳"

        'dgvの１行目へ
        dgvB5Input.CurrentCell = dgvB5Input("Result", 0)
        dgvB5Input.Focus()
    End Sub

    ''' <summary>
    ''' 健診データ表示
    ''' </summary>
    ''' <param name="ymd">健診実施日</param>
    ''' <remarks></remarks>
    Private Sub displayKenData(ymd As String)
        'クリア
        clearInput()

        'データ取得、表示
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from Ken1 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            '年齢
            Dim age As Integer = Util.calcAge(birth, Util.checkDBNullValue(rs.Fields("Ymd").Value))
            ageBox.Text = age & " 歳"

            '健診日
            YmdBox.setADStr(Util.checkDBNullValue(rs.Fields("Ymd").Value))

            '身長～TPHA
            For i As Integer = 0 To 52
                dgvB5Input("Result", i).Value = Util.checkDBNullValue(rs.Fields("D" & (i + 1)).Value)
            Next
            'その他の検査(項目)
            For i As Integer = 53 To 61
                Dim plusNum As Integer = i - 52
                dgvB5Input("Item2", i).Value = Util.checkDBNullValue(rs.Fields("D" & (i + plusNum)).Value)
            Next
            'その他の検査(検査値)
            For i As Integer = 53 To 61
                Dim plusNum As Integer = i - 51
                dgvB5Input("Result", i).Value = Util.checkDBNullValue(rs.Fields("D" & (i + plusNum)).Value)
            Next

            '総合判定
            dgvB5Input("Result", 62).Value = Util.checkDBNullValue(rs.Fields("D72").Value)
            dgvB5Input("Result", 63).Value = Util.checkDBNullValue(rs.Fields("D73").Value)
            dgvB5Input("Result", 64).Value = Util.checkDBNullValue(rs.Fields("D74").Value)
        End If
        rs.Close()
        cn.Close()

        'フォーカス
        YmdBox.Focus()
    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        ageBox.Text = "   歳"
        YmdBox.clearText()
        For i As Integer = 0 To 64
            dgvB5Input("Result", i).Value = ""
            If 53 <= i AndAlso i <= 61 Then
                dgvB5Input("Item2", i).Value = ""
            End If
        Next
        YmdBox.Focus()
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '健診日
        Dim ymd As String = YmdBox.getADStr()
        If ymd = "" Then
            MsgBox("健診日を入力して下さい。", MsgBoxStyle.Exclamation)
            YmdBox.Focus()
            Return
        End If

        '入力データ取得
        Dim d(73) As String
        '身長～TPHA
        For i As Integer = 0 To 52
            d(i) = Util.checkDBNullValue(dgvB5Input("Result", i).Value)
        Next
        'その他の検査(項目)
        For i As Integer = 53 To 61
            Dim plusNum As Integer = i - 53
            d(i + plusNum) = Util.checkDBNullValue(dgvB5Input("Item2", i).Value)
        Next
        'その他の検査(検査値)
        For i As Integer = 53 To 61
            Dim plusNum As Integer = i - 52
            d(i + plusNum) = Util.checkDBNullValue(dgvB5Input("Result", i).Value)
        Next
        '総合判定
        d(71) = Util.checkDBNullValue(dgvB5Input("Result", 62).Value)
        d(72) = Util.checkDBNullValue(dgvB5Input("Result", 63).Value)
        d(73) = Util.checkDBNullValue(dgvB5Input("Result", 64).Value)

        '登録
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from Ken1 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            rs.AddNew()
            rs.Fields("Ind").Value = ind
            rs.Fields("Kana").Value = kana
            rs.Fields("Birth").Value = birth
            rs.Fields("Ymd").Value = ymd
            For i As Integer = 0 To 73
                rs.Fields("D" & (i + 1)).Value = d(i)
            Next
        Else
            '更新登録
            For i As Integer = 0 To 73
                rs.Fields("D" & (i + 1)).Value = d(i)
            Next
        End If
        rs.Update()
        rs.Close()
        cn.Close()

        initHistoryListBox()
        clearInput()
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '健診日
        Dim ymd As String = YmdBox.getADStr()

        '登録されているか確認
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim rs As New ADODB.Recordset()
        Dim sql As String = "select * from Ken1 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("登録されていません。", MsgBoxStyle.Exclamation)
            cn.Close()
            Return
        End If

        '削除
        Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.Yes Then
            rs.Delete()
            rs.Update()
            cn.Close()
        Else
            cn.Close()
            Return
        End If

        initHistoryListBox()
        clearInput()
    End Sub

    ''' <summary>
    ''' クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearInput()
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim ymd As String = YmdBox.getADStr()
        If ymd = "" Then
            MsgBox("データを選択して下さい。", MsgBoxStyle.Exclamation)
            Return
        End If

        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from Ken1 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("健診データが存在しません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        End If

        '基準値データ取得
        Dim baseValDt As DataTable
        Dim rsBase As New ADODB.Recordset
        sql = "select Nam, Low1, Upp1, Low2, Upp2 from StdM"
        rsBase.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rsBase, "StdM")
        baseValDt = ds.Tables("StdM")

        '異常値のチェック有無で付与文字変更
        If CheckAbnormal.Checked = False Then
            HASHMARK = ""
        End If

        '受診日
        Dim yyyy As String = ymd.Split("/")(0)
        Dim MM As String = ymd.Split("/")(1)
        Dim dd As String = ymd.Split("/")(2)
        Dim youbi As String = New DateTime(yyyy, CInt(MM), CInt(dd)).ToString("ddd") '曜日
        '西暦ver
        'Dim ymdFormatted As String = "受診日：　" & yyyy & "　年　" & MM & "　月　" & dd & "　日 (　" & youbi & "　)"
        '和暦ver
        Dim wareki As String = YmdBox.getWarekiStr()
        Dim kanji As String = Util.getKanji(wareki)
        Dim ymdFormatted As String = "受診日：" & kanji & "　" & wareki.Substring(1, 2) & "　年　" & wareki.Substring(4, 2) & "　月　" & wareki.Substring(7, 2) & "　日 (　" & youbi & "　)"

        'データ貼り付け用配列
        Dim dataArrayLeft(42, 3) As String '左半分用
        Dim dataArrayRight(23, 0) As String '右半分用(血液検査結果部分)

        '左半分
        'カナ
        dataArrayLeft(0, 0) = " " & kana
        '氏名
        dataArrayLeft(1, 0) = " " & nam
        '性別
        Dim sexFormatted As String = If(sex = 1, "① 男 ・ 2 女　", "1 男 ・ ② 女　")
        dataArrayLeft(3, 0) = sexFormatted
        '生年月日
        Dim warekiBirth As String = Util.convADStrToWarekiStr(birth)
        Dim age As Integer = Util.calcAge(birth, ymd)
        Dim birthFormatted As String = " " & warekiBirth.Split("/")(0) & "　年　" & warekiBirth.Split("/")(1) & "　月　" & warekiBirth.Split("/")(2) & "　日　" & age & "　歳　"
        dataArrayLeft(4, 0) = birthFormatted
        '事業所名
        dataArrayLeft(5, 0) = ind
        '身長
        Dim height As Double = 0
        If System.Text.RegularExpressions.Regex.IsMatch(Util.checkDBNullValue(rs.Fields("D1").Value), "^\d+(\.\d+)?$") Then
            height = rs.Fields("D1").Value
            dataArrayLeft(9, 0) = height.ToString(".0")
            dataArrayLeft(9, 1) = "Cm"
        End If
        '体重
        Dim weight As Double = 0
        If System.Text.RegularExpressions.Regex.IsMatch(Util.checkDBNullValue(rs.Fields("D2").Value), "^\d+(\.\d+)?$") Then
            weight = rs.Fields("D2").Value
            dataArrayLeft(10, 0) = weight.ToString(".0")
            dataArrayLeft(10, 1) = "Kg"
        End If
        'BMI
        If height <> 0 AndAlso weight <> 0 Then
            Dim bmi As Double = Math.Round(weight / ((height / 100) * (height / 100)), 1, MidpointRounding.AwayFromZero)
            dataArrayLeft(10, 2) = "(BMI)"
            dataArrayLeft(10, 3) = bmi.ToString(".0")
        End If
        '視力　右
        dataArrayLeft(11, 0) = Util.checkDBNullValue(rs.Fields("D5").Value) '裸眼
        Dim kyoseiRight As String = If(Util.checkDBNullValue(rs.Fields("D6").Value) = "", "　　", Util.checkDBNullValue(rs.Fields("D6").Value))
        dataArrayLeft(11, 2) = " ( " & kyoseiRight & " )" '矯正
        '視力　左
        dataArrayLeft(12, 0) = Util.checkDBNullValue(rs.Fields("D7").Value) '裸眼
        Dim kyoseiLeft As String = If(Util.checkDBNullValue(rs.Fields("D8").Value) = "", "　　", Util.checkDBNullValue(rs.Fields("D8").Value))
        dataArrayLeft(12, 2) = " ( " & kyoseiLeft & " )" '矯正
        '聴力障害
        Dim hearingResult1 As String
        Dim hearingResult2 As String
        Dim d9 As String = Util.checkDBNullValue(rs.Fields("D9").Value)
        Dim d10 As String = Util.checkDBNullValue(rs.Fields("D10").Value)
        If d9 = "1" Then
            hearingResult1 = "なし"
            hearingResult2 = ""
        ElseIf d9 = "2" Then
            hearingResult1 = "あり"
            If d10 = "1" Then
                hearingResult2 = "(　右　)"
            ElseIf d10 = "2" Then
                hearingResult2 = "(　左　)"
            Else
                hearingResult2 = "(　右　・　左　)"
            End If
        Else
            hearingResult1 = ""
            hearingResult2 = ""
        End If
        dataArrayLeft(13, 0) = hearingResult1
        dataArrayLeft(13, 2) = hearingResult2
        '手足の運動障害
        dataArrayLeft(14, 0) = "　" & Util.checkDBNullValue(rs.Fields("D11").Value)
        '自覚症状
        dataArrayLeft(16, 0) = "　" & Util.checkDBNullValue(rs.Fields("D12").Value)
        'その他の特記事項
        dataArrayLeft(18, 0) = "　" & Util.checkDBNullValue(rs.Fields("D13").Value)
        '既往歴
        dataArrayLeft(20, 0) = "特記すべきもの"
        Dim d14 As String = Util.checkDBNullValue(rs.Fields("D14").Value)
        If d14 = "2" Then
            dataArrayLeft(21, 0) = "　" & Util.checkDBNullValue(rs.Fields("D15").Value)
        End If
        'ﾂﾍﾞﾙｸﾘﾝ反応
        Dim d16Result As String
        Dim d16 As String = Util.checkDBNullValue(rs.Fields("D16").Value)
        If d16 = "1" Then
            d16Result = "　① 陰性　・　2 陽性"
        ElseIf d16 = "2" Then
            d16Result = "　1 陰性　・　② 陽性"
        Else
            d16Result = "　1 陰性　・　2 陽性"
        End If
        dataArrayLeft(22, 0) = d16Result
        dataArrayLeft(23, 0) = "　" & Util.checkDBNullValue(rs.Fields("D17").Value)
        'その他の検査
        dataArrayLeft(24, 0) = Util.checkDBNullValue(rs.Fields("D54").Value) '項目1
        dataArrayLeft(24, 2) = Util.checkDBNullValue(rs.Fields("D55").Value) '結果値1
        dataArrayLeft(25, 0) = Util.checkDBNullValue(rs.Fields("D56").Value) '項目2
        dataArrayLeft(25, 2) = Util.checkDBNullValue(rs.Fields("D57").Value) '結果値2
        dataArrayLeft(26, 0) = Util.checkDBNullValue(rs.Fields("D58").Value) '項目3
        dataArrayLeft(26, 2) = Util.checkDBNullValue(rs.Fields("D59").Value) '結果値3
        dataArrayLeft(27, 0) = Util.checkDBNullValue(rs.Fields("D60").Value) '項目4
        dataArrayLeft(27, 2) = Util.checkDBNullValue(rs.Fields("D61").Value) '結果値4
        dataArrayLeft(28, 0) = Util.checkDBNullValue(rs.Fields("D62").Value) '項目5
        dataArrayLeft(28, 2) = Util.checkDBNullValue(rs.Fields("D63").Value) '結果値5
        dataArrayLeft(29, 0) = Util.checkDBNullValue(rs.Fields("D64").Value) '項目6
        dataArrayLeft(29, 2) = Util.checkDBNullValue(rs.Fields("D65").Value) '結果値6
        dataArrayLeft(30, 0) = Util.checkDBNullValue(rs.Fields("D66").Value) '項目7
        dataArrayLeft(30, 2) = Util.checkDBNullValue(rs.Fields("D67").Value) '結果値7
        dataArrayLeft(31, 0) = Util.checkDBNullValue(rs.Fields("D68").Value) '項目8
        dataArrayLeft(31, 2) = Util.checkDBNullValue(rs.Fields("D69").Value) '結果値8
        dataArrayLeft(32, 0) = Util.checkDBNullValue(rs.Fields("D70").Value) '項目9
        dataArrayLeft(32, 2) = Util.checkDBNullValue(rs.Fields("D71").Value) '結果値9
        '肝炎
        dataArrayLeft(36, 0) = "HBs抗原"
        dataArrayLeft(36, 2) = Util.checkDBNullValue(rs.Fields("D18").Value) 'HBs抗原
        dataArrayLeft(37, 0) = "HBs抗体"
        dataArrayLeft(37, 2) = Util.checkDBNullValue(rs.Fields("D19").Value) 'HBs抗体
        dataArrayLeft(38, 0) = "HCV抗体"
        dataArrayLeft(38, 2) = Util.checkDBNullValue(rs.Fields("D20").Value) 'HCV抗体
        '総合判定
        dataArrayLeft(40, 0) = "　" & Util.checkDBNullValue(rs.Fields("D72").Value) '1行目
        dataArrayLeft(41, 0) = "　" & Util.checkDBNullValue(rs.Fields("D73").Value) '2行目
        dataArrayLeft(42, 0) = "　" & Util.checkDBNullValue(rs.Fields("D74").Value) '3行目

        '右半分(血液検査結果部分)
        Dim itemNameArray() As String = {"白血球数", "赤血球数", "ﾍﾓｸﾞﾛﾋﾞﾝ", "ﾍﾏﾄｸﾘｯﾄ", "総ｺﾚｽﾃﾛｰﾙ", "ＨＤＬ－ｺﾚｽﾃﾛｰﾙ", "中性脂肪", "ＧＯＴ", "ＧＰＴ", "γ－ＧＴＰ", "ＡＬＰ", "赤沈", "ＣＲＰ", "尿酸", "尿素窒素", "ｸﾚｱﾁﾆﾝ", "総蛋白", "Ａ／Ｇ", "ＺＴＴ", "血糖", "ﾍﾓｸﾞﾛﾋﾞﾝＡ１ｃ", "Ｆｅ", "", ""}
        For i As Integer = 30 To 53
            dataArrayRight(i - 30, 0) = checkBaseValue(Util.checkDBNullValue(rs.Fields("D" & i).Value), itemNameArray(i - 30), baseValDt)
        Next
        '右半分（上記以外）
        '血圧
        Dim bloodPressure As String
        Dim ketuH As String = checkBaseValue(Util.checkDBNullValue(rs.Fields("D3").Value), "最高血圧", baseValDt)
        Dim ketuR As String = checkBaseValue(Util.checkDBNullValue(rs.Fields("D4").Value), "最低血圧", baseValDt)
        bloodPressure = ketuH & "　/　" & ketuR & "　mmhg"
        '尿検査
        Dim tanpaku As String = Util.checkDBNullValue(rs.Fields("D21").Value)
        If numberDic1.ContainsKey(tanpaku) Then
            tanpaku = "　(" & numberDic1(tanpaku) & ")"
        Else
            tanpaku = ""
        End If
        Dim tou As String = Util.checkDBNullValue(rs.Fields("D22").Value)
        If numberDic1.ContainsKey(tou) Then
            tou = "　(" & numberDic1(tou) & ")"
        Else
            tou = ""
        End If
        Dim urobiri As String = Util.checkDBNullValue(rs.Fields("D23").Value)
        If numberDic2.ContainsKey(urobiri) Then
            urobiri = "　(" & numberDic1(urobiri) & ")"
        Else
            urobiri = ""
        End If

        '聴打診所見
        Dim tyoda As String = " " & Util.checkDBNullValue(rs.Fields("D24").Value)
        '胸部Ｘ線
        Dim xRay1 As String = " " & Util.checkDBNullValue(rs.Fields("D25").Value)
        Dim xRay2 As String = " " & Util.checkDBNullValue(rs.Fields("D26").Value)
        Dim xRay3 As String = " " & Util.checkDBNullValue(rs.Fields("D27").Value)
        '心電図
        Dim ecg1 As String = " " & Util.checkDBNullValue(rs.Fields("D28").Value)
        Dim ecg2 As String = " " & Util.checkDBNullValue(rs.Fields("D29").Value)

        'エクセル準備
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(topForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("診断書改")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '受診日
        oSheet.Range("I3").Value = ymdFormatted

        'データ貼り付け
        oSheet.Range("D4", "G46").Value = dataArrayLeft
        oSheet.Range("K4").Value = bloodPressure
        oSheet.Range("K7", "K10").Value = {{tanpaku}, {tou}, {urobiri}, {tyoda}}
        oSheet.Range("J12", "J17").Value = {{xRay1}, {xRay2}, {xRay3}, {""}, {ecg1}, {ecg2}}
        oSheet.Range("K19", "K42").Value = dataArrayRight

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If printState = True Then
            oSheet.PrintOut()
        Else
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
    ''' 検査値が基準値範囲外かチェック
    ''' </summary>
    ''' <param name="resultValue">検査結果値</param>
    ''' <param name="itemName">検査項目名</param>
    ''' <param name="baseDt">基準値データテーブル</param>
    ''' <returns>範囲外の場合は#記号を付けて返す</returns>
    ''' <remarks></remarks>
    Private Function checkBaseValue(resultValue As String, itemName As String, baseDt As DataTable) As String
        If Not System.Text.RegularExpressions.Regex.IsMatch(resultValue, "^\d+(\.\d+)?$") Then
            Return resultValue
        Else
            '基準値の取得
            Dim low As Double
            Dim upp As Double
            If sex = "2" AndAlso Array.IndexOf(stdValName, itemName) >= 0 Then
                '女性用の基準値
                low = baseDt.Select("Nam = '" & itemName & "'")(0).Item("Low2")
                upp = baseDt.Select("Nam = '" & itemName & "'")(0).Item("Upp2")
            Else
                low = baseDt.Select("Nam = '" & itemName & "'")(0).Item("Low1")
                upp = baseDt.Select("Nam = '" & itemName & "'")(0).Item("Upp1")
            End If

            '基準値範囲外の場合は"#"記号を付ける
            If Not (low <= resultValue AndAlso resultValue <= upp) Then
                Return resultValue & HASHMARK
            Else
                Return resultValue
            End If
        End If
    End Function

    ''' <summary>
    ''' 履歴リスト値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub historyListBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles historyListBox.SelectedValueChanged
        Dim selectedYmd As String = historyListBox.Text
        If selectedYmd <> "" Then
            displayKenData(selectedYmd)
        End If
    End Sub
End Class