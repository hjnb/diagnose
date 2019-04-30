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
    ''' 入力内容
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()

    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click

    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub

    ''' <summary>
    ''' クリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click

    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub
End Class