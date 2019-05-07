Imports System.Text

Public Class A4InputDataGridView
    Inherits DataGridView

    '文字数制限用
    Private Const LIMIT_LENGTH_BYTE As Integer = 60

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Protected Overrides Function ProcessDataGridViewKey(e As System.Windows.Forms.KeyEventArgs) As Boolean
        Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
        If Not IsNothing(tb) AndAlso ((e.KeyCode = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (e.KeyCode = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
            Return False
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function

    Private Sub A4InputDataGridView_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEndEdit
        Dim currentCellRowIndex As Integer = Me.CurrentCell.RowIndex

        '身長 or 体重を入力後、bmi算出
        If (currentCellRowIndex = 0 OrElse currentCellRowIndex = 1) Then
            Dim heightStr As String = Util.checkDBNullValue(Me("Result", 0).Value)
            Dim weightStr As String = Util.checkDBNullValue(Me("Result", 1).Value)
            If (heightStr <> "0" AndAlso weightStr <> "0") AndAlso System.Text.RegularExpressions.Regex.IsMatch(heightStr, "^\d+(\.\d+)?$") AndAlso System.Text.RegularExpressions.Regex.IsMatch(weightStr, "^\d+(\.\d+)?$") Then
                Dim height As Double = heightStr
                Dim weight As Double = weightStr
                Dim bmi As Double = Math.Round(weight / ((height / 100) * (height / 100)), 1, MidpointRounding.AwayFromZero)
                Me("Result", 3).Value = bmi.ToString("#.0")
            Else
                Me("Result", 3).Value = ""
            End If
        End If
    End Sub

    Private Sub A4InputDataGridView_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            Dim pParts As DataGridViewPaintParts
            If e.ColumnIndex = 0 OrElse e.ColumnIndex = 1 Then
                pParts = e.PaintParts And Not DataGridViewPaintParts.Border
            Else
                pParts = e.PaintParts
            End If

            '縦線
            If e.ColumnIndex = 0 Then
                With e.CellBounds
                    .Offset(-1, 0)
                    e.Graphics.DrawLine(New Pen(Color.FromKnownColor(KnownColor.ControlDark)), .Right, .Top, .Right, .Bottom)
                End With
            End If
            '横線
            If e.RowIndex = 15 OrElse e.RowIndex = 18 OrElse e.RowIndex = 22 OrElse e.RowIndex = 31 OrElse e.RowIndex = 36 OrElse e.RowIndex = 43 OrElse e.RowIndex = 54 OrElse e.RowIndex = 59 OrElse e.RowIndex = 62 OrElse e.RowIndex = 64 OrElse e.RowIndex = 67 OrElse e.RowIndex = 68 OrElse e.RowIndex = 71 OrElse e.RowIndex = 74 OrElse e.RowIndex = 75 Then
                With e.CellBounds
                    .Offset(0, -1)
                    e.Graphics.DrawLine(New Pen(Color.FromKnownColor(KnownColor.ControlDark)), .Left, .Top, .Right, .Top)
                End With
            End If

            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    Private Sub A4InputDataGridView_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Me.EditingControlShowing
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            '選択行index
            Dim selectedRowIndex As Integer = dgv.CurrentCell.RowIndex

            '編集のために表示されているテキストボックス取得、設定
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            tb.ImeMode = Windows.Forms.ImeMode.Alpha
            If selectedRowIndex = 4 OrElse selectedRowIndex = 5 OrElse selectedRowIndex = 6 OrElse selectedRowIndex = 57 OrElse selectedRowIndex = 58 OrElse selectedRowIndex = 62 OrElse selectedRowIndex = 63 OrElse selectedRowIndex = 64 OrElse selectedRowIndex = 65 OrElse selectedRowIndex = 66 OrElse selectedRowIndex = 67 OrElse selectedRowIndex = 70 OrElse selectedRowIndex >= 74 Then
                tb.ImeMode = Windows.Forms.ImeMode.Hiragana
            End If

            'イベントハンドラを削除
            RemoveHandler tb.KeyPress, AddressOf dgvTextBox_KeyPress

            If selectedRowIndex >= 75 Then
                '総合判定入力テキストボックス用
                AddHandler tb.KeyPress, AddressOf dgvTextBox_KeyPress
            End If
        End If
    End Sub

    ''' <summary>
    ''' 総合判定入力テキストボックス用KeyPressイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim text As String = CType(sender, DataGridViewTextBoxEditingControl).Text
        Dim lengthByte As Integer = Encoding.GetEncoding("Shift_JIS").GetByteCount(text)

        If lengthByte >= LIMIT_LENGTH_BYTE Then '設定されているバイト数以上の時
            If e.KeyChar = ChrW(Keys.Back) Then
                'Backspaceは入力可能
                e.Handled = False
            Else
                '入力できなくする
                e.Handled = True
            End If
        End If
    End Sub
End Class
