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

        'データグリッドビュー初期設定
        initDgvB5Input()

        '初期フォーカス
        YmdBox.Focus()
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
        dt.Rows(5).Item("Item2") = "　　　　　矯正"
        dt.Rows(6).Item("Item2") = "　　　左　裸眼"
        dt.Rows(7).Item("Item2") = "　　　　　矯正"
        dt.Rows(8).Item("Item2") = "聴力障害　　　1:なし　2:あり"
        dt.Rows(9).Item("Item2") = "　　　　　　　1:右　　2:左"
        dt.Rows(10).Item("Item2") = "手足の運動障害"
        dt.Rows(11).Item("Item2") = "自覚症状"
        dt.Rows(12).Item("Item2") = "その他の特記事項"
        dt.Rows(13).Item("Item2") = "既往歴　　　　1:なし　2:あり"
        dt.Rows(14).Item("Item2") = "　　　　　　　　特記"
        dt.Rows(15).Item("Item2") = "ﾂﾍﾞﾙｸﾘﾝ反応　 1:陰性　2:陽性"
        dt.Rows(16).Item("Item2") = "　　　　　　　　特記"
        dt.Rows(17).Item("Item2") = "HBs 抗原"
        dt.Rows(18).Item("Item2") = "HBs 抗体"
        dt.Rows(19).Item("Item2") = "HCV 抗体"
        dt.Rows(20).Item("Item2") = "蛋白　1:-　2:±　3:1+　4:2+　5:3+"
        dt.Rows(21).Item("Item2") = "糖　　1:-　2:±　3:1+　4:2+　5:3+"
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
        dt.Rows(36).Item("Item2") = ""
        dt.Rows(37).Item("Item2") = ""
        dt.Rows(38).Item("Item2") = ""
        dt.Rows(39).Item("Item2") = ""
        dt.Rows(40).Item("Item2") = ""
        dt.Rows(41).Item("Item2") = ""
        dt.Rows(42).Item("Item2") = ""
        dt.Rows(43).Item("Item2") = ""
        dt.Rows(44).Item("Item2") = ""
        dt.Rows(45).Item("Item2") = ""
        dt.Rows(46).Item("Item2") = ""
        dt.Rows(47).Item("Item2") = ""
        dt.Rows(48).Item("Item2") = ""
        dt.Rows(49).Item("Item2") = ""
        dt.Rows(50).Item("Item2") = ""
        dt.Rows(51).Item("Item2") = ""
        dt.Rows(52).Item("Item2") = ""
        dt.Rows(53).Item("Item2") = ""
        dt.Rows(54).Item("Item2") = ""
        dt.Rows(55).Item("Item2") = ""
        dt.Rows(56).Item("Item2") = ""
        dt.Rows(57).Item("Item2") = ""
        dt.Rows(58).Item("Item2") = ""
        dt.Rows(59).Item("Item2") = ""
        dt.Rows(60).Item("Item2") = ""
        dt.Rows(61).Item("Item2") = ""
        dt.Rows(62).Item("Item2") = ""
        dt.Rows(63).Item("Item2") = ""
        dt.Rows(64).Item("Item2") = ""



        '表示
        dgvB5Input.DataSource = dt

        '幅設定等
        With dgvB5Input
            With .Columns("Item1")
                .HeaderText = ""
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
            End With
            With .Columns("Item2")
                .HeaderText = ""
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 220
            End With
            With .Columns("Result")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 220
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
        Dim age As Integer = Util.calcAge(birth, YmdBox.getADStr())
        ageBox.Text = age & " 歳"
    End Sub
End Class