Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.Data.OleDb

Public Class A4InputForm
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
    '尿蛋白、糖、潜血用
    Private numberDic1 As New Dictionary(Of String, String) From {{"1", "(－)"}, {"2", "(±)"}, {"3", "(＋)"}, {"4", "(2＋)"}, {"5", "(3＋)"}}
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
    Private Sub A4InputForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
        initDgvA4Input()

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
        Dim sql As String = "select Ymd from Ken2 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' order by Ymd Desc"
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
    Private Sub initDgvA4Input()
        Util.EnableDoubleBuffering(dgvA4Input)

        With dgvA4Input
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
        For i As Integer = 0 To 79
            Dim row As DataRow = dt.NewRow()
            row(0) = ""
            row(1) = ""
            row(2) = ""
            dt.Rows.Add(row)
        Next

        '初期値設定
        '1列目
        dt.Rows(0).Item("Item1") = "診察等"
        dt.Rows(15).Item("Item1") = "血圧"
        dt.Rows(18).Item("Item1") = "脂質"
        dt.Rows(22).Item("Item1") = "肝機能等"
        dt.Rows(31).Item("Item1") = "血糖"
        dt.Rows(36).Item("Item1") = "尿一般・腎"
        dt.Rows(43).Item("Item1") = "血液一般"
        dt.Rows(54).Item("Item1") = "眼底"
        dt.Rows(59).Item("Item1") = "肺機能"
        dt.Rows(62).Item("Item1") = "胸部Ｘ線"
        dt.Rows(64).Item("Item1") = "胃部"
        dt.Rows(67).Item("Item1") = "腹部"
        dt.Rows(68).Item("Item1") = "大腸"
        dt.Rows(71).Item("Item1") = "肝炎"
        dt.Rows(74).Item("Item1") = "心電図"
        dt.Rows(75).Item("Item1") = "総合判定"

        '2列目
        dt.Rows(0).Item("Item2") = "身長"
        dt.Rows(1).Item("Item2") = "体重"
        dt.Rows(2).Item("Item2") = "腹囲"
        dt.Rows(3).Item("Item2") = "ＢＭＩ"
        dt.Rows(4).Item("Item2") = "既往歴・自覚症状"
        dt.Rows(5).Item("Item2") = ""
        dt.Rows(6).Item("Item2") = "腹部・胸部　所見"
        dt.Rows(7).Item("Item2") = "視力　右　裸眼"
        dt.Rows(8).Item("Item2") = "             矯正"
        dt.Rows(9).Item("Item2") = "　　　  左　裸眼"
        dt.Rows(10).Item("Item2") = "　　　　　   矯正"
        dt.Rows(11).Item("Item2") = "聴力　右　1000Hz　所見　1：無　2：有"
        dt.Rows(12).Item("Item2") = "　　　　　　 4000Hz　所見　1：無　2：有"
        dt.Rows(13).Item("Item2") = "　　　　左　1000Hz　所見　1：無　2：有"
        dt.Rows(14).Item("Item2") = "　　　　　　 4000Hz　所見　1：無　2：有"
        dt.Rows(15).Item("Item2") = "最高血圧"
        dt.Rows(16).Item("Item2") = "最低血圧"
        dt.Rows(17).Item("Item2") = "採血時間(食後)　1：10時間未満　2：以上"
        dt.Rows(18).Item("Item2") = "総ｺﾚｽﾃﾛｰﾙ"
        dt.Rows(19).Item("Item2") = "中性脂肪"
        dt.Rows(20).Item("Item2") = "ＨＤＬ－ｺﾚｽﾃﾛｰﾙ"
        dt.Rows(21).Item("Item2") = "ＬＤＬ－ｺﾚｽﾃﾛｰﾙ"
        dt.Rows(22).Item("Item2") = "ＧＯＴ"
        dt.Rows(23).Item("Item2") = "ＧＰＴ"
        dt.Rows(24).Item("Item2") = "γ－ＧＴＰ"
        dt.Rows(25).Item("Item2") = "ＡＬＰ"
        dt.Rows(26).Item("Item2") = "総蛋白"
        dt.Rows(27).Item("Item2") = "ｱﾙﾌﾞﾐﾝ"
        dt.Rows(28).Item("Item2") = "総ﾋﾞﾘﾙﾋﾞﾝ"
        dt.Rows(29).Item("Item2") = "ＬＤＨ"
        dt.Rows(30).Item("Item2") = "ｱﾐﾗｰｾﾞ"
        dt.Rows(31).Item("Item2") = "尿酸"
        dt.Rows(32).Item("Item2") = "血糖"
        dt.Rows(33).Item("Item2") = "ﾍﾓｸﾞﾛﾋﾞﾝＡ１ｃ"
        dt.Rows(34).Item("Item2") = "随時血糖"
        dt.Rows(35).Item("Item2") = "尿糖　　 1：－　2：±　3：1＋　4：2＋　5：3＋"
        dt.Rows(36).Item("Item2") = "尿蛋白　1：－　2：±　3：1＋　4：2＋　5：3＋"
        dt.Rows(37).Item("Item2") = "尿潜血　1：－　2：±　3：1＋　4：2＋　5：3＋"
        dt.Rows(38).Item("Item2") = "血清ｸﾚｱﾁﾆﾝ"
        dt.Rows(39).Item("Item2") = "尿沈査　 赤血球"
        dt.Rows(40).Item("Item2") = "　　　　　　白血球"
        dt.Rows(41).Item("Item2") = "　　　　　　上皮細胞"
        dt.Rows(42).Item("Item2") = "　　　　　　円柱"
        dt.Rows(43).Item("Item2") = "白血球数"
        dt.Rows(44).Item("Item2") = "赤血球数"
        dt.Rows(45).Item("Item2") = "血色素量"
        dt.Rows(46).Item("Item2") = "ﾍﾏﾄｸﾘｯﾄ"
        dt.Rows(47).Item("Item2") = "血小板数"
        dt.Rows(48).Item("Item2") = "末梢血液像　Baso"
        dt.Rows(49).Item("Item2") = "　　　　　　　　 Eosino"
        dt.Rows(50).Item("Item2") = "　　　　　　　　 Stub"
        dt.Rows(51).Item("Item2") = "　　　　　　　　 Seg"
        dt.Rows(52).Item("Item2") = "　　　　　　　　 Lympho"
        dt.Rows(53).Item("Item2") = "　　　　　　　　 Mono"
        dt.Rows(54).Item("Item2") = "眼底　Ｋ．Ｗ．"
        dt.Rows(55).Item("Item2") = "　　　Scheie　H"
        dt.Rows(56).Item("Item2") = "　　　Scheie　S"
        dt.Rows(57).Item("Item2") = "所見"
        dt.Rows(58).Item("Item2") = "実施理由"
        dt.Rows(59).Item("Item2") = "肺活量"
        dt.Rows(60).Item("Item2") = "一秒量"
        dt.Rows(61).Item("Item2") = "一秒率"
        dt.Rows(62).Item("Item2") = "総合判定"
        dt.Rows(63).Item("Item2") = "所見"
        dt.Rows(64).Item("Item2") = "Ｘ線　所見"
        dt.Rows(65).Item("Item2") = ""
        dt.Rows(66).Item("Item2") = "内視鏡　所見"
        dt.Rows(67).Item("Item2") = "腹部超音波　所見"
        dt.Rows(68).Item("Item2") = "免疫便潜血反応　１日目　1：－　2：＋"
        dt.Rows(69).Item("Item2") = "　　　　　　　　　　　 ２日目　1：－　2：＋"
        dt.Rows(70).Item("Item2") = "直腸診　所見"
        dt.Rows(71).Item("Item2") = "ＨＢｓ抗原　　　　 1：－　2：±　3：＋"
        dt.Rows(72).Item("Item2") = "ＨＣＶ抗体　　　　1：感染なし　2：あり　3：要検査"
        dt.Rows(73).Item("Item2") = "ＨＣＶ核酸増幅　1：感染なし　2：あり"
        dt.Rows(74).Item("Item2") = "所見"
        dt.Rows(75).Item("Item2") = "判定"
        dt.Rows(76).Item("Item2") = ""
        dt.Rows(77).Item("Item2") = ""
        dt.Rows(78).Item("Item2") = ""
        dt.Rows(79).Item("Item2") = ""

        '表示
        dgvA4Input.DataSource = dt

        '幅設定等
        With dgvA4Input
            With .Columns("Item1")
                .HeaderText = ""
                .DefaultCellStyle = item1CellStyle
                .Width = 85
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Item2")
                .HeaderText = "項目"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle = item2CellStyle
                .Width = 280
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Result")
                .HeaderText = "検査値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 230
                .SortMode = DataGridViewColumnSortMode.NotSortable
                dgvA4Input("Result", 3).Style = item2CellStyle
                dgvA4Input("Result", 3).ReadOnly = True
            End With
        End With
    End Sub

    ''' <summary>
    ''' 健診日ボックスエンターキーkeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub YmdBox_keyDownEnterOrDown(sender As Object, e As System.EventArgs) Handles YmdBox.keyDownEnterOrDown
        If YmdBox.getADStr() = "" Then
            Return
        End If

        '年齢算出、ラベルに表示
        Dim age As Integer = Util.calcAge(birth, YmdBox.getADStr())
        ageBox.Text = age & " 歳"

        'dgvの１行目へ
        dgvA4Input.CurrentCell = dgvA4Input("Result", 0)
        dgvA4Input.Focus()
    End Sub

    ''' <summary>
    ''' 健診データ表示
    ''' </summary>
    ''' <param name="ymd"></param>
    ''' <remarks></remarks>
    Private Sub displayKenData(ymd As String)
        'クリア
        clearInput()

        'データ取得、表示
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from Ken2 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            '年齢
            Dim age As Integer = Util.calcAge(birth, Util.checkDBNullValue(rs.Fields("Ymd").Value))
            ageBox.Text = age & " 歳"

            '健診日
            YmdBox.setADStr(Util.checkDBNullValue(rs.Fields("Ymd").Value))

            '検査値
            For i As Integer = 0 To 79
                dgvA4Input("Result", i).Value = Util.checkDBNullValue(rs.Fields("D" & (i + 1)).Value)
            Next
        End If
        rs.Close()
        cn.Close()

        'フォーカス
        YmdBox.Focus()
    End Sub

    ''' <summary>
    ''' 入力内容
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        ageBox.Text = "   歳"
        YmdBox.clearText()
        For i As Integer = 0 To 79
            dgvA4Input("Result", i).Value = ""
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
        Dim d(79) As String
        For i As Integer = 0 To 79
            d(i) = Util.checkDBNullValue(dgvA4Input("Result", i).Value)
        Next

        '登録
        Dim cn As New ADODB.Connection()
        cn.Open(topForm.DB_Diagnose)
        Dim sql As String = "select * from Ken2 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            rs.AddNew()
            rs.Fields("Ind").Value = ind
            rs.Fields("Kana").Value = kana
            rs.Fields("Birth").Value = birth
            rs.Fields("Ymd").Value = ymd
            For i As Integer = 0 To 79
                rs.Fields("D" & (i + 1)).Value = d(i)
            Next
        Else
            '更新登録
            For i As Integer = 0 To 79
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
        Dim sql As String = "select * from Ken2 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
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
        Dim sql As String = "select * from Ken2 where Ind = '" & ind & "' and Kana = '" & kana & "' and Birth = '" & birth & "' and Ymd = '" & ymd & "'"
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

        'エクセル準備
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(topForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("診断書２改")
        Dim xlShapes As Excel.Shapes = DirectCast(oSheet.Shapes, Excel.Shapes)
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        Dim image2aPath As String = topForm.diag2aPath '胸部画像
        Dim image2bPath As String = topForm.diag2bPath '胃部画像
        Dim cell As Excel.Range = DirectCast(oSheet.Cells(24, "S"), Excel.Range)
        xlShapes.AddPicture(image2aPath, False, True, cell.Left, cell.Top, 70, 60)
        cell = DirectCast(oSheet.Cells(31, "S"), Excel.Range)
        xlShapes.AddPicture(image2bPath, False, True, cell.Left, cell.Top, 60, 50)

        '所見等の部分の入力値有、無の場合のフォント名
        Const FONT_NAME_INPUT As String = "ＭＳ Ｐゴシック"
        Const FONT_NAME_NO_INPUT As String = "ＭＳ Ｐ明朝"
        '左半分
        'ｶﾅ
        oSheet.Range("H5").Value = kana
        '氏名
        oSheet.Range("H6").Value = nam
        '性別
        oSheet.Range("L8").Value = If(sex = 1, "①　男　・　2　女", "1　男　・　②　女")
        '生年月日
        Dim wareki As String = Util.convADStrToWarekiStr(birth)
        Dim age As Integer = Util.calcAge(birth, Today.ToString("yyyy/MM/dd"))
        oSheet.Range("H9").Value = wareki.Split("/")(0) & "　年　" & wareki.Split("/")(1) & "　月　" & wareki.Split("/")(2) & "　日"
        oSheet.Range("O9").Value = age & "　歳"
        '身長
        oSheet.Range("I10").Value = Util.checkDBNullValue(rs.Fields("D1").Value)
        '体重
        oSheet.Range("N10").Value = Util.checkDBNullValue(rs.Fields("D2").Value)
        '腹囲
        oSheet.Range("I11").Value = Util.checkDBNullValue(rs.Fields("D3").Value)
        'BMI
        oSheet.Range("N11").Value = Util.checkDBNullValue(rs.Fields("D4").Value)
        '胸部・腹部所見
        oSheet.Range("H13").Value = Util.checkDBNullValue(rs.Fields("D7").Value)
        '視力　右　裸眼
        oSheet.Range("I15").Value = Util.checkDBNullValue(rs.Fields("D8").Value)
        '      右　矯正
        oSheet.Range("N15").Value = Util.checkDBNullValue(rs.Fields("D9").Value)
        '視力　左　裸眼
        oSheet.Range("I16").Value = Util.checkDBNullValue(rs.Fields("D10").Value)
        '      左　矯正
        oSheet.Range("N16").Value = Util.checkDBNullValue(rs.Fields("D11").Value)
        '聴力　右　1000Hz
        Dim d12Result As String = "所見　無 ・ 有"
        Dim d12 As String = Util.checkDBNullValue(rs.Fields("D12").Value)
        If d12 = "1" Then
            d12Result = "所見　無"
        ElseIf d12 = "2" Then
            d12Result = "所見　有"
        End If
        oSheet.Range("I17").Font.Name = If(d12Result = "所見　無 ・ 有", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("I17").Value = d12Result
        '      右　4000Hz
        Dim d13Result As String = "無 ・ 有"
        Dim d13 As String = Util.checkDBNullValue(rs.Fields("D13").Value)
        If d13 = "1" Then
            d13Result = "無"
        ElseIf d13 = "2" Then
            d13Result = "有"
        End If
        oSheet.Range("O17").Font.Name = If(d13Result = "無 ・ 有", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("O17").Value = d13Result
        '      左　1000Hz
        Dim d14Result As String = "所見　無 ・ 有"
        Dim d14 As String = Util.checkDBNullValue(rs.Fields("D14").Value)
        If d14 = "1" Then
            d14Result = "所見　無"
        ElseIf d14 = "2" Then
            d14Result = "所見　有"
        End If
        oSheet.Range("I18").Font.Name = If(d14Result = "所見　無 ・ 有", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("I18").Value = d14Result
        '      左　4000Hz
        Dim d15Result As String = "無 ・ 有"
        Dim d15 As String = Util.checkDBNullValue(rs.Fields("D15").Value)
        If d15 = "1" Then
            d15Result = "無"
        ElseIf d15 = "2" Then
            d15Result = "有"
        End If
        oSheet.Range("O18").Font.Name = If(d15Result = "無 ・ 有", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("O18").Value = d15Result
        '最高血圧
        oSheet.Range("I19").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D16").Value), "最高血圧", baseValDt)
        '最低血圧
        oSheet.Range("I20").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D17").Value), "最低血圧", baseValDt)
        '総ｺﾚｽﾃﾛｰﾙ
        oSheet.Range("I21").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D19").Value), "総ｺﾚｽﾃﾛｰﾙ", baseValDt)
        '中性脂肪
        oSheet.Range("I22").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D20").Value), "中性脂肪", baseValDt)
        'ＨＤＬ
        oSheet.Range("I23").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D21").Value), "ＨＤＬ－ｺﾚｽﾃﾛｰﾙ", baseValDt)
        'ＬＤＬ
        oSheet.Range("I25").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D22").Value), "ＬＤＬ－ｺﾚｽﾃﾛｰﾙ", baseValDt)
        'ＧＯＴ
        oSheet.Range("I26").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D23").Value), "ＧＯＴ", baseValDt)
        'ＧＰＴ
        oSheet.Range("I27").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D24").Value), "ＧＰＴ", baseValDt)
        'γＧＴＰ
        oSheet.Range("I28").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D25").Value), "γ－ＧＴＰ", baseValDt)
        'ＡＬＰ
        oSheet.Range("I30").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D26").Value), "ＡＬＰ", baseValDt)
        '総蛋白
        oSheet.Range("I31").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D27").Value), "総蛋白", baseValDt)
        'ｱﾙﾌﾞﾐﾝ
        oSheet.Range("I32").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D28").Value), "ｱﾙﾌﾞﾐﾝ", baseValDt)
        '総ﾋﾞﾘﾙﾋﾞﾝ
        oSheet.Range("I33").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D29").Value), "総ﾋﾞﾘﾙﾋﾞﾝ", baseValDt)
        'ＬＤＨ
        oSheet.Range("I34").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D30").Value), "ＬＤＨ", baseValDt)
        'ｱﾐﾗｰｾﾞ
        oSheet.Range("I35").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D31").Value), "ｱﾐﾗｰｾﾞ", baseValDt)
        '尿酸
        oSheet.Range("I36").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D32").Value), "尿酸", baseValDt)
        '血糖
        oSheet.Range("I37").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D33").Value), "血糖", baseValDt)
        'ﾍﾓｸﾞﾛﾋﾞﾝＡ１ｃ
        oSheet.Range("I38").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D34").Value), "ﾍﾓｸﾞﾛﾋﾞﾝＡ１ｃ", baseValDt)
        '随時血糖
        oSheet.Range("I39").Value = Util.checkDBNullValue(rs.Fields("D35").Value)
        '尿糖
        Dim d36 As String = Util.checkDBNullValue(rs.Fields("D36").Value)
        Dim d36Result As String = "　－　　±　　１＋　　２＋　　３＋"
        If numberDic1.ContainsKey(d36) Then
            d36Result = numberDic1(d36)
            oSheet.Range("G40").Font.Name = FONT_NAME_INPUT
        End If
        oSheet.Range("G40").Value = d36Result
        '尿蛋白
        Dim d37 As String = Util.checkDBNullValue(rs.Fields("D37").Value)
        Dim d37Result As String = "　－　　±　　１＋　　２＋　　３＋"
        If numberDic1.ContainsKey(d37) Then
            d37Result = numberDic1(d37)
            oSheet.Range("G41").Font.Name = FONT_NAME_INPUT
        End If
        oSheet.Range("G41").Value = d37Result
        '尿潜血
        Dim d38 As String = Util.checkDBNullValue(rs.Fields("D38").Value)
        Dim d38Result As String = "　－　　±　　１＋　　２＋　　３＋"
        If numberDic1.ContainsKey(d38) Then
            d38Result = numberDic1(d38)
            oSheet.Range("G42").Font.Name = FONT_NAME_INPUT
        End If
        oSheet.Range("G42").Value = d38Result
        '血清ｸﾚｱﾁﾆﾝ
        oSheet.Range("I43").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D39").Value), "血清ｸﾚｱﾁﾆﾝ", baseValDt)
        '尿沈査　赤血球
        oSheet.Range("I45").Value = Util.checkDBNullValue(rs.Fields("D40").Value)
        '　　　　白血球
        oSheet.Range("N45").Value = Util.checkDBNullValue(rs.Fields("D41").Value)
        '　　　　上皮細胞
        oSheet.Range("I46").Value = Util.checkDBNullValue(rs.Fields("D42").Value)
        '　　　　円柱
        oSheet.Range("N46").Value = Util.checkDBNullValue(rs.Fields("D43").Value)
        '白血球数
        oSheet.Range("I47").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D44").Value), "白血球数", baseValDt)
        '赤血球数
        oSheet.Range("I48").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D45").Value), "赤血球数", baseValDt)
        '血色素量
        oSheet.Range("I50").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D46").Value), "血色素量", baseValDt)
        'ヘマトクリット値
        oSheet.Range("I52").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D47").Value), "ﾍﾏﾄｸﾘｯﾄ", baseValDt)
        '血小板数
        oSheet.Range("I54").Value = checkBaseValue(Util.checkDBNullValue(rs.Fields("D48").Value), "血小板数", baseValDt)
        'Baso
        oSheet.Range("I55").Value = Util.checkDBNullValue(rs.Fields("D49").Value)
        'Eosino
        oSheet.Range("N55").Value = Util.checkDBNullValue(rs.Fields("D50").Value)
        'Stub
        oSheet.Range("I56").Value = Util.checkDBNullValue(rs.Fields("D51").Value)
        'Seg
        oSheet.Range("N56").Value = Util.checkDBNullValue(rs.Fields("D52").Value)
        'Lympho
        oSheet.Range("I57").Value = Util.checkDBNullValue(rs.Fields("D53").Value)
        'Mono
        oSheet.Range("N57").Value = Util.checkDBNullValue(rs.Fields("D54").Value)

        '右半分
        Const NP_WORD As String = "異常なし"
        Const DEFAULT_WORD As String = "1 ： 無　　2 ： 有"
        Const NASHI As String = "① ： 無　　2 ： 有"
        Const ARI As String = "1 ： 無　　② ： 有"
        '受診日
        Dim yyyy As String = ymd.Split("/")(0)
        Dim MM As String = ymd.Split("/")(1)
        Dim dd As String = ymd.Split("/")(2)
        Dim youbi As String = New DateTime(yyyy, CInt(MM), CInt(dd)).ToString("ddd")
        '西暦ver
        'Dim ymdFormatted As String = "受診日：　" & yyyy & "　年　" & MM & "　月　" & dd & "　日 (　" & youbi & "　)"
        '和暦ver
        Dim warekiStr As String = YmdBox.getWarekiStr()
        Dim kanji As String = Util.getKanji(warekiStr)
        Dim ymdFormatted As String = "受診日：" & kanji & "　" & warekiStr.Substring(1, 2) & "　年　" & warekiStr.Substring(4, 2) & "　月　" & warekiStr.Substring(7, 2) & "　日 (　" & youbi & "　)"

        oSheet.Range("S3").Value = ymdFormatted
        '現在所
        oSheet.Range("W5").Value = ind
        '既往歴・自覚症状
        oSheet.Range("R10").Value = Util.checkDBNullValue(rs.Fields("D5").Value)
        oSheet.Range("R11").Value = Util.checkDBNullValue(rs.Fields("D6").Value)
        '採血時間（食後）
        Dim d18 As String = Util.checkDBNullValue(rs.Fields("D18").Value)
        Dim d18Result As String = "1 ： 10時間未満　　2 ： 以上"
        If d18 = "1" Then
            d18Result = "① ： 10時間未満　　2 ： 以上"
        ElseIf d18 = "2" Then
            d18Result = "1 ： 10時間未満　　② ： 以上"
        End If
        oSheet.Range("U13").Font.Name = If(d18Result = "1 ： 10時間未満　　2 ： 以上", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("U13").Value = d18Result
        'K.W.
        oSheet.Range("Y14").Value = Util.checkDBNullValue(rs.Fields("D55").Value)
        'Scheie
        oSheet.Range("Z15").Value = Util.checkDBNullValue(rs.Fields("D56").Value)
        oSheet.Range("AB15").Value = Util.checkDBNullValue(rs.Fields("D57").Value)
        '眼底所見
        Dim d58 As String = Util.checkDBNullValue(rs.Fields("D58").Value)
        Dim d58Result As String = DEFAULT_WORD
        If d58 = NP_WORD Then
            d58Result = NASHI
        ElseIf d58 <> "" Then
            d58Result = ARI
        End If
        oSheet.Range("T16").Font.Name = If(d58Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("T16").Value = d58Result
        oSheet.Range("T17").Value = d58
        '実施理由
        oSheet.Range("T19").Value = Util.checkDBNullValue(rs.Fields("D59").Value)
        '肺活量
        oSheet.Range("Y20").Value = Util.checkDBNullValue(rs.Fields("D60").Value)
        '一秒量
        oSheet.Range("Y21").Value = Util.checkDBNullValue(rs.Fields("D61").Value)
        '一秒率
        oSheet.Range("Y22").Value = Util.checkDBNullValue(rs.Fields("D62").Value)
        '胸部ｘ線
        Dim d63 As String = Util.checkDBNullValue(rs.Fields("D63").Value)
        Dim d64 As String = Util.checkDBNullValue(rs.Fields("D64").Value)
        Dim d63Result As String = DEFAULT_WORD
        If d63 = NP_WORD Then
            d63Result = NASHI
            oSheet.Range("X25").Value = d63
            oSheet.Range("X26").Value = d64
        ElseIf d63 <> "" Then
            d63Result = ARI
            oSheet.Range("X25").Value = d63
            oSheet.Range("X26").Value = d64
        End If
        oSheet.Range("Y23").Font.Name = If(d63Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("Y23").Value = d63Result
        '胃部ｘ線
        Dim d65 As String = Util.checkDBNullValue(rs.Fields("D65").Value)
        Dim d66 As String = Util.checkDBNullValue(rs.Fields("D66").Value)
        Dim d65Result As String = DEFAULT_WORD
        If d65 = NP_WORD Then
            d65Result = NASHI
            oSheet.Range("X32").Value = d65
            oSheet.Range("X33").Value = d66
        ElseIf d65 <> "" Then
            d65Result = ARI
            oSheet.Range("X32").Value = d65
            oSheet.Range("X33").Value = d66
        End If
        oSheet.Range("Y30").Font.Name = If(d65Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("Y30").Value = d65Result
        '内視鏡
        Dim d67 As String = Util.checkDBNullValue(rs.Fields("D67").Value)
        Dim d67Result As String = DEFAULT_WORD
        If d67 = NP_WORD Then
            d67Result = NASHI
            oSheet.Range("X36").Value = d67
        ElseIf d67 <> "" Then
            d67Result = ARI
            oSheet.Range("X36").Value = d67
        End If
        oSheet.Range("Y35").Font.Name = If(d67Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("Y35").Value = d67Result
        '腹部超音波
        Dim d68 As String = Util.checkDBNullValue(rs.Fields("D68").Value)
        Dim d68Result As String = DEFAULT_WORD
        If d68 = NP_WORD Then
            d68Result = NASHI
            oSheet.Range("X39").Value = d68
        ElseIf d68 <> "" Then
            d68Result = ARI
            oSheet.Range("X39").Value = d68
        End If
        oSheet.Range("Y38").Font.Name = If(d68Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("Y38").Value = d68Result
        '便潜血反応
        Dim d69 As String = Util.checkDBNullValue(rs.Fields("D69").Value)
        Dim d70 As String = Util.checkDBNullValue(rs.Fields("D70").Value)
        Dim d69Result As String = "1日目　－　　＋"
        Dim d70Result As String = "2日目　－　　＋"
        If d69 = "1" Then
            d69Result = "1日目　(－)"
        ElseIf d69 = "2" Then
            d69Result = "1日目　(＋)"
        End If
        If d70 = "1" Then
            d70Result = "2日目　(－)"
        ElseIf d70 = "2" Then
            d70Result = "2日目　(＋)"
        End If
        oSheet.Range("W41").Font.Name = If(d69Result = "1日目　－　　＋", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("W41").Value = d69Result
        oSheet.Range("AA41").Font.Name = If(d70Result = "2日目　－　　＋", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("AA41").Value = d70Result
        '直腸診
        Dim d71 As String = Util.checkDBNullValue(rs.Fields("D71").Value)
        Dim d71Result As String = DEFAULT_WORD
        If d71 = NP_WORD Then
            d71Result = NASHI
            oSheet.Range("X43").Value = d71
        ElseIf d71 <> "" Then
            d71Result = ARI
            oSheet.Range("X43").Value = d71
        End If
        oSheet.Range("Y42").Font.Name = If(d71Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("Y42").Value = d71Result
        'HBs抗原
        Dim d72 As String = Util.checkDBNullValue(rs.Fields("D72").Value)
        Dim d72Result As String = "　－　　±　　＋"
        If d72 = "1" Then
            d72Result = "　(－)"
        ElseIf d72 = "2" Then
            d72Result = "　(±)"
        ElseIf d72 = "3" Then
            d72Result = "　(＋)"
        End If
        oSheet.Range("W45").Font.Name = If(d72Result = "　－　　±　　＋", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("W45").Value = d72Result
        'HCV抗体
        Dim d73 As String = Util.checkDBNullValue(rs.Fields("D73").Value)
        Dim d73Result As String = "　感染なし　　あり　　要再検"
        If d73 = "1" Then
            d73Result = "　感染なし"
        ElseIf d73 = "2" Then
            d73Result = "　感染あり"
        ElseIf d73 = "3" Then
            d73Result = "　要検査"
        End If
        oSheet.Range("W46").Font.Name = If(d73Result = "　感染なし　　あり　　要再検", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("W46").Value = d73Result
        'HCV核酸増幅
        Dim d74 As String = Util.checkDBNullValue(rs.Fields("D74").Value)
        Dim d74Result As String = "　感染なし　　あり"
        If d74 = "1" Then
            d74Result = "　感染なし"
        ElseIf d74 = "2" Then
            d74Result = "　感染あり"
        End If
        oSheet.Range("W47").Font.Name = If(d74Result = "　感染なし　　あり", FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("W47").Value = d74Result
        '心電図
        Dim d75 As String = Util.checkDBNullValue(rs.Fields("D75").Value)
        Dim d75Result As String = DEFAULT_WORD
        If d75 = NP_WORD Then
            d75Result = NASHI
            oSheet.Range("X49").Value = d75
        ElseIf d75 <> "" Then
            d75Result = ARI
            oSheet.Range("X49").Value = d75
        End If
        oSheet.Range("Y48").Font.Name = If(d75Result = DEFAULT_WORD, FONT_NAME_NO_INPUT, FONT_NAME_INPUT)
        oSheet.Range("Y48").Value = d75Result
        '判定
        oSheet.Range("S52").Value = Util.checkDBNullValue(rs.Fields("D76").Value)
        oSheet.Range("S53").Value = Util.checkDBNullValue(rs.Fields("D77").Value)
        oSheet.Range("S54").Value = Util.checkDBNullValue(rs.Fields("D78").Value)
        oSheet.Range("S55").Value = Util.checkDBNullValue(rs.Fields("D79").Value)
        oSheet.Range("S56").Value = Util.checkDBNullValue(rs.Fields("D80").Value)

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