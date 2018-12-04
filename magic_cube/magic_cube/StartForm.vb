Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class StartForm

    Private Sub StartForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitCATIA()

        If CATIA Is Nothing Then
            If MsgBox("CATIA is not running, Are you want to Start Catia？", MsgBoxStyle.OkCancel, "magic cube") = MsgBoxResult.Ok Then
                Me.ToolStripStatusLabel1.Text = "Starting CATIA, Please Wait"
                If FileCheck(CurDir()) Then
                    If MsgBox("There are Cube units in your folder, Would you like to Assembly them to get the Cube？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim rCube As New CCube
                        rCube.PrepareProducts()
                        rCube.AssembleParts(CurDir(), 100)
                        rCube.SetViewer()

                        MainForm.ShowDialog()
                        Me.Visible = False

                    Else

                    End If
                End If
            End If
        End If

        Me.ToolStripStatusLabel1.Text = "Ready"
    End Sub

    ''' <summary>
    ''' Check if the execute folder has cube unit parts
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FileCheck(ByVal path As String) As Boolean
        Dim i, j, k As Integer
        For i = 1 To 3
            For j = 1 To 3
                For k = 1 To 3
                    If FileExists(path & "\Unit_" & i & "-" & j & "-" & k & ".CATPart") Then
                        Continue For
                    Else
                        Return False
                    End If
                Next
            Next
        Next
        Return True
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If FileCheck(CurDir()) Then
            Dim rCube As New CCube
            rCube.PrepareProducts()
            rCube.AssembleParts(CurDir(), 100)
            rCube.SetViewer()

            MainForm.ShowDialog()
            Me.Visible = False

        Else
            MsgBox("The units' part is not sufficent, Please Create cube units first！", MsgBoxStyle.OkOnly)
        End If
       
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim openDirDlg As New FolderBrowserDialog
        openDirDlg.ShowNewFolderButton = False
        openDirDlg.Description = "Select a folder which cube units in"
        Dim newFolder As String = String.Empty
        If openDirDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            newFolder = openDirDlg.SelectedPath
            If FileCheck(newFolder) Then
                Dim rCube As New CCube
                rCube.PrepareProducts()
                rCube.AssembleParts(newFolder, 100)
                rCube.SetViewer()
                MainForm.ShowDialog()
                Me.Visible = False
            End If
        End If

   
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rcube As New CCube
        Me.ToolStripStatusLabel1.Text = "CATIA is creating cube units，Please wait..."
        CATIA.Visible = False
        rcube.CreatePart(100, 10)
        CATIA.Visible = True
        rcube.PrepareProducts()
        rcube.AssembleParts(CurDir, 100)
        rcube.SetViewer()
        MainForm.ShowDialog()
        Me.Visible = False
    End Sub

 
End Class