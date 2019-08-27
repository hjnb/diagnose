Imports System.Text

Public Class B5InputDataGridView
    Inherits DataGridView

    '文字数制限用
    Private Const LIMIT_LENGTH_BYTE As Integer = 90

    Protected Overrides Function ProcessDialogKey(keyData As System.Windows.Forms.Keys) As Boolean
        Dim inputStr As String = Util.checkDBNullValue(Me.CurrentCell.Value)
        If keyData = Keys.Enter AndAlso inputStr = "" Then
            If 10 <= Me.CurrentCell.RowIndex AndAlso Me.CurrentCell.RowIndex <= 12 Then
                Me.CurrentCell.Value = "なし"
            End If
        ElseIf keyData = Keys.Tab AndAlso (53 <= Me.CurrentCell.RowIndex AndAlso Me.CurrentCell.RowIndex <= 61) Then
            Dim columnIndex As Integer = Me.CurrentCell.ColumnIndex
            If columnIndex = 1 Then
                Me.CurrentCell = Me(2, Me.CurrentCell.RowIndex)
            ElseIf columnIndex = 2 Then
                Me.CurrentCell = Me(1, Me.CurrentCell.RowIndex)
            End If
            Return True
        End If
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

    Private Sub B5InputDataGridView_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            Dim pParts As DataGridViewPaintParts
            If e.ColumnIndex = 0 OrElse (e.ColumnIndex = 1 AndAlso ((0 <= e.RowIndex AndAlso e.RowIndex <= 52) OrElse e.RowIndex >= 62)) Then
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
            If (e.ColumnIndex = 0 OrElse e.ColumnIndex = 1) AndAlso (e.RowIndex = 17 OrElse e.RowIndex = 20 OrElse e.RowIndex = 23 OrElse e.RowIndex = 24 OrElse e.RowIndex = 27 OrElse e.RowIndex = 29 OrElse e.RowIndex = 53 OrElse e.RowIndex = 62) Then
                With e.CellBounds
                    .Offset(0, -1)
                    e.Graphics.DrawLine(New Pen(Color.FromKnownColor(KnownColor.ControlDark)), .Left, .Top, .Right, .Top)
                End With
            End If

            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    Private Sub B5InputDataGridView_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Me.EditingControlShowing
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            '選択行index
            Dim selectedRowIndex As Integer = dgv.CurrentCell.RowIndex
            '選択列index
            Dim selectedColumnIndex As Integer = dgv.CurrentCell.ColumnIndex

            '編集のために表示されているテキストボックス取得、設定
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            tb.ImeMode = Windows.Forms.ImeMode.Alpha
            If selectedColumnIndex = 1 OrElse selectedRowIndex = 10 OrElse selectedRowIndex = 11 OrElse selectedRowIndex = 12 OrElse selectedRowIndex = 14 OrElse selectedRowIndex = 16 OrElse selectedRowIndex = 23 OrElse selectedRowIndex = 24 OrElse selectedRowIndex = 25 OrElse selectedRowIndex = 26 OrElse selectedRowIndex = 27 OrElse selectedRowIndex = 28 OrElse selectedRowIndex = 62 OrElse selectedRowIndex = 63 OrElse selectedRowIndex = 64 Then
                tb.ImeMode = Windows.Forms.ImeMode.Hiragana
            End If

            'イベントハンドラを削除
            RemoveHandler tb.KeyPress, AddressOf dgvTextBox_KeyPress

            If selectedRowIndex >= 62 Then
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
