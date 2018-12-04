Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Public Class MainForm
    Public rcube As CCube


    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        rcube = New CCube



        'If rootProd Is Nothing Then
        '    If CATIA.Documents.Count = 0 Then
        '        rcube.PrepareProducts()
        '    End If
        '    If Not CATIA.ActiveDocument.Product.PartNumber = "Rubik's Cube" Then
        '        rcube.PrepareProducts()
        '    End If
        '    rootProd = CATIA.ActiveDocument.Product
        'End If
        'If MovingProd Is Nothing Then
        '    MovingProd = rcube.FindProdByPtn(rootProd, "MovingProduct")
        'End If
        'rcube.PrepareProducts()
        'rcube.AssembleParts(100)
        'rcube.SetViewer()
        Me.ToolStripStatusLabel1.Text = "Ready"
    End Sub

#Region "move forwards"
    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        rcube.Move_U()
    End Sub


    Private Sub btn_Move_R_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Move_R.Click
        rcube.Move_R()
    End Sub

    Private Sub btn_MoveF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MoveF.Click
        rcube.Move_F()
    End Sub

    Private Sub btn_Move_L_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Move_L.Click
        rcube.Move_L()
    End Sub

    Private Sub btn_move_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_D.Click
        rcube.Move_D()
    End Sub

    Private Sub btn_move_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_B.Click
        rcube.Move_B()
    End Sub
#End Region


#Region "move backwards"

    Private Sub btn_move_U1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_U1.Click
        rcube.Move_U1()
    End Sub
    Private Sub btn_move_R1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_R1.Click
        rcube.Move_R1()
    End Sub

    Private Sub btn_move_F1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_F1.Click
        rcube.Move_F1()
    End Sub

    Private Sub btn_move_D1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_D1.Click
        rcube.Move_D1()
    End Sub

    Private Sub btn_move_L1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_L1.Click
        rcube.Move_L1()
    End Sub

    Private Sub btn_move_B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_B1.Click
        rcube.Move_B1()
    End Sub
#End Region


#Region "move entirely"

    Private Sub btn_move_X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_X.Click
        rcube.Move_X()
    End Sub


    Private Sub btn_move_Y_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_Y.Click
        rcube.Move_Y()
    End Sub

    Private Sub btn_move_Z_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_Z.Click
        rcube.Move_Z()
    End Sub

    Private Sub btn_move_X1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_X1.Click
        rcube.Move_X1()
    End Sub

    Private Sub btn_move_Y1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_Y1.Click
        rcube.Move_Y1()
    End Sub

    Private Sub btn_move_Z1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_move_Z1.Click
        rcube.Move_Z1()
    End Sub

#End Region


    '' execute movement
    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim StrEquation As String = Me.tb_Equation.Text
        If StrEquation = "" Then
            MsgBox("input is empty", MsgBoxStyle.Critical, "Input check")
            Exit Sub
        End If

        StrEquation = Trim(StrEquation)  'trim space
        Dim moves As List(Of String) = New List(Of String)

        Do While StrEquation.Length > 0
            moves.Add(StrEquation.Chars(0))
            StrEquation = StrEquation.Substring(1)
            If StrEquation.Length > 0 Then
                If StrEquation.First = "'" Then
                    moves(moves.Count - 1) = moves.Last & "'"
                    StrEquation = StrEquation.Substring(1)
                End If
            End If
            If StrEquation.Length > 0 Then
                If StrEquation.First = "2" Then
                    moves(moves.Count - 1) = moves.Last & "2"
                    StrEquation = StrEquation.Substring(1)
                End If
            End If
        Loop


        'Date is ready, about to move   ULR'U'L'2RUF'LF
        Dim i As Integer
        For i = 0 To moves.Count - 1
            If moves(i) = "U" Then
                rcube.Move_U()
            ElseIf moves(i) = "F" Then
                rcube.Move_F()
            ElseIf moves(i) = "L" Then
                rcube.Move_L()
            ElseIf moves(i) = "R" Then
                rcube.Move_R()
            ElseIf moves(i) = "B" Then
                rcube.Move_B()
            ElseIf moves(i) = "D" Then
                rcube.Move_D()
            ElseIf moves(i) = "F'" Then
                rcube.Move_F1()
            ElseIf moves(i) = "U'" Then
                rcube.Move_U1()
            ElseIf moves(i) = "R'" Then
                rcube.Move_R1()
            ElseIf moves(i) = "L'" Then
                rcube.Move_L1()
            ElseIf moves(i) = "B'" Then
                rcube.Move_B1()
            ElseIf moves(i) = "D'" Then
                rcube.Move_D1()
            ElseIf moves(i) = "X" Then
                rcube.Move_X()
            ElseIf moves(i) = "X'" Then
                rcube.Move_X1()
            ElseIf moves(i) = "Y" Then
                rcube.Move_Y()
            ElseIf moves(i) = "Y'" Then
                rcube.Move_Y1()
            ElseIf moves(i) = "Z" Then
                rcube.Move_Z()
            ElseIf moves(i) = "Z'" Then
                rcube.Move_Z1()
            End If
        Next




    End Sub

    Private Sub 创建魔方ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 创建魔方ToolStripMenuItem.Click
        rcube.CreatePart(100, 5)
    End Sub

    Private Sub 装配魔方ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 装配魔方ToolStripMenuItem.Click
        rcube.PrepareProducts()
        rcube.AssembleParts(CurDir, 100)
        rcube.SetViewer()
    End Sub


    Private Sub 启动ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InitCATIA()
    End Sub


    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        End

    End Sub

    Private Sub ResetViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetViewer.Click
        rcube.SetViewer()
    End Sub

    Private Sub 恢复视图ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rcube.SetViewer()
    End Sub

    Private Sub 保存ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存ToolStripMenuItem.Click
        Me.ToolStripStatusLabel1.Text = "saving files..."
        Dim SaveFileDlg As New SaveFileDialog()
        SaveFileDlg.InitialDirectory = CurDir()
        SaveFileDlg.OverwritePrompt = True
        SaveFileDlg.Filter = "CATIAProduct|*.CATProduct"

        Dim fileName As String
        If SaveFileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            fileName = SaveFileDlg.FileName
            CATIA.ActiveDocument.SaveAs(fileName)


            Dim i, j, k As Integer
            Dim Dir As String = Path.GetDirectoryName(fileName)
            For i = 1 To 3
                For j = 1 To 3
                    For k = 1 To 3
                        Dim PartName As String = "Unit_" & i & "-" & j & "-" & k & ".CATPart"
                        If Not FileSystem.FileExists(Dir & "\" & PartName) Then
                            Dim PartDoc = CATIA.Documents.Item(PartName)
                            PartDoc.SaveAs(Dir & "\" & PartName)
                        End If
                    Next
                Next
            Next
        End If

        Me.ToolStripStatusLabel1.Text = "Ready"

    End Sub

    Private Sub 打开ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 打开ToolStripMenuItem.Click
        Dim openFileDlg As New OpenFileDialog()
        openFileDlg.Filter = "CATIA Product|*.CATProduct"
        openFileDlg.InitialDirectory = CurDir()
        If openFileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = openFileDlg.FileName
            CATIA.Documents.Open(fileName)
        End If


    End Sub

    Private Sub 关于ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 关于ToolStripMenuItem2.Click
        FrmAbout.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rcube.HideSpecTree()
    End Sub

 
    Private Sub 帮助ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 帮助ToolStripMenuItem1.Click
        MsgBox("More infomation about notation of Rubik's Cube movements, Please visit reference website：http://www.rubik.com.cn/notation.htm" & vbCrLf &
               "In this programe, if you input URFR', the Cube will execute continious movement U、R、F、R'")
    End Sub

    Private Sub MainForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
