<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btn_Move_R = New System.Windows.Forms.Button()
        Me.btn_MoveF = New System.Windows.Forms.Button()
        Me.btn_Move_L = New System.Windows.Forms.Button()
        Me.btn_move_D = New System.Windows.Forms.Button()
        Me.btn_move_B = New System.Windows.Forms.Button()
        Me.btn_move_U1 = New System.Windows.Forms.Button()
        Me.btn_move_R1 = New System.Windows.Forms.Button()
        Me.btn_move_F1 = New System.Windows.Forms.Button()
        Me.btn_move_D1 = New System.Windows.Forms.Button()
        Me.btn_move_L1 = New System.Windows.Forms.Button()
        Me.btn_move_B1 = New System.Windows.Forms.Button()
        Me.tb_Equation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建魔方ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.装配魔方ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.帮助ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_move_Z = New System.Windows.Forms.Button()
        Me.btn_move_Y = New System.Windows.Forms.Button()
        Me.btn_move_X = New System.Windows.Forms.Button()
        Me.btn_move_Z1 = New System.Windows.Forms.Button()
        Me.btn_move_Y1 = New System.Windows.Forms.Button()
        Me.btn_move_X1 = New System.Windows.Forms.Button()
        Me.btnResetViewer = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMove
        '
        Me.btnMove.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnMove.Location = New System.Drawing.Point(5, 123)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(44, 40)
        Me.btnMove.TabIndex = 2
        Me.btnMove.Text = "U"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btn_Move_R
        '
        Me.btn_Move_R.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_Move_R.Location = New System.Drawing.Point(5, 169)
        Me.btn_Move_R.Name = "btn_Move_R"
        Me.btn_Move_R.Size = New System.Drawing.Size(44, 36)
        Me.btn_Move_R.TabIndex = 3
        Me.btn_Move_R.Text = "R"
        Me.btn_Move_R.UseVisualStyleBackColor = True
        '
        'btn_MoveF
        '
        Me.btn_MoveF.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_MoveF.Location = New System.Drawing.Point(5, 211)
        Me.btn_MoveF.Name = "btn_MoveF"
        Me.btn_MoveF.Size = New System.Drawing.Size(44, 38)
        Me.btn_MoveF.TabIndex = 4
        Me.btn_MoveF.Text = "F"
        Me.btn_MoveF.UseVisualStyleBackColor = True
        '
        'btn_Move_L
        '
        Me.btn_Move_L.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_Move_L.Location = New System.Drawing.Point(78, 169)
        Me.btn_Move_L.Name = "btn_Move_L"
        Me.btn_Move_L.Size = New System.Drawing.Size(43, 36)
        Me.btn_Move_L.TabIndex = 5
        Me.btn_Move_L.Text = "L"
        Me.btn_Move_L.UseVisualStyleBackColor = True
        '
        'btn_move_D
        '
        Me.btn_move_D.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_D.Location = New System.Drawing.Point(78, 123)
        Me.btn_move_D.Name = "btn_move_D"
        Me.btn_move_D.Size = New System.Drawing.Size(43, 40)
        Me.btn_move_D.TabIndex = 6
        Me.btn_move_D.Text = "D"
        Me.btn_move_D.UseVisualStyleBackColor = True
        '
        'btn_move_B
        '
        Me.btn_move_B.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_B.Location = New System.Drawing.Point(78, 211)
        Me.btn_move_B.Name = "btn_move_B"
        Me.btn_move_B.Size = New System.Drawing.Size(43, 38)
        Me.btn_move_B.TabIndex = 7
        Me.btn_move_B.Text = "B"
        Me.btn_move_B.UseVisualStyleBackColor = True
        '
        'btn_move_U1
        '
        Me.btn_move_U1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_U1.Location = New System.Drawing.Point(162, 123)
        Me.btn_move_U1.Name = "btn_move_U1"
        Me.btn_move_U1.Size = New System.Drawing.Size(42, 40)
        Me.btn_move_U1.TabIndex = 8
        Me.btn_move_U1.Text = "U'"
        Me.btn_move_U1.UseVisualStyleBackColor = True
        '
        'btn_move_R1
        '
        Me.btn_move_R1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_R1.Location = New System.Drawing.Point(162, 169)
        Me.btn_move_R1.Name = "btn_move_R1"
        Me.btn_move_R1.Size = New System.Drawing.Size(42, 36)
        Me.btn_move_R1.TabIndex = 9
        Me.btn_move_R1.Text = "R'"
        Me.btn_move_R1.UseVisualStyleBackColor = True
        '
        'btn_move_F1
        '
        Me.btn_move_F1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_F1.Location = New System.Drawing.Point(162, 211)
        Me.btn_move_F1.Name = "btn_move_F1"
        Me.btn_move_F1.Size = New System.Drawing.Size(42, 38)
        Me.btn_move_F1.TabIndex = 10
        Me.btn_move_F1.Text = "F'"
        Me.btn_move_F1.UseVisualStyleBackColor = True
        '
        'btn_move_D1
        '
        Me.btn_move_D1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_D1.Location = New System.Drawing.Point(231, 123)
        Me.btn_move_D1.Name = "btn_move_D1"
        Me.btn_move_D1.Size = New System.Drawing.Size(42, 40)
        Me.btn_move_D1.TabIndex = 11
        Me.btn_move_D1.Text = "D'"
        Me.btn_move_D1.UseVisualStyleBackColor = True
        '
        'btn_move_L1
        '
        Me.btn_move_L1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_L1.Location = New System.Drawing.Point(231, 169)
        Me.btn_move_L1.Name = "btn_move_L1"
        Me.btn_move_L1.Size = New System.Drawing.Size(42, 36)
        Me.btn_move_L1.TabIndex = 12
        Me.btn_move_L1.Text = "L'"
        Me.btn_move_L1.UseVisualStyleBackColor = True
        '
        'btn_move_B1
        '
        Me.btn_move_B1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_B1.Location = New System.Drawing.Point(231, 211)
        Me.btn_move_B1.Name = "btn_move_B1"
        Me.btn_move_B1.Size = New System.Drawing.Size(42, 38)
        Me.btn_move_B1.TabIndex = 13
        Me.btn_move_B1.Text = "B'"
        Me.btn_move_B1.UseVisualStyleBackColor = True
        '
        'tb_Equation
        '
        Me.tb_Equation.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tb_Equation.Location = New System.Drawing.Point(5, 68)
        Me.tb_Equation.Name = "tb_Equation"
        Me.tb_Equation.Size = New System.Drawing.Size(310, 26)
        Me.tb_Equation.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightGray
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 21)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Cube Movements："
        '
        'btn_OK
        '
        Me.btn_OK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OK.Location = New System.Drawing.Point(321, 64)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(80, 30)
        Me.btn_OK.TabIndex = 16
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.DimGray
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 319)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(544, 25)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.DarkKhaki
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(155, 20)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.创建魔方ToolStripMenuItem, Me.装配魔方ToolStripMenuItem, Me.保存ToolStripMenuItem, Me.打开ToolStripMenuItem, Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.文件ToolStripMenuItem.Text = "File"
        '
        '创建魔方ToolStripMenuItem
        '
        Me.创建魔方ToolStripMenuItem.Name = "创建魔方ToolStripMenuItem"
        Me.创建魔方ToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.创建魔方ToolStripMenuItem.Text = "Create Cube Units"
        '
        '装配魔方ToolStripMenuItem
        '
        Me.装配魔方ToolStripMenuItem.Name = "装配魔方ToolStripMenuItem"
        Me.装配魔方ToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.装配魔方ToolStripMenuItem.Text = "Assemble Cube"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.保存ToolStripMenuItem.Text = "Save..."
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.打开ToolStripMenuItem.Text = "Open..."
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.退出ToolStripMenuItem.Text = "Quit"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Linen
        Me.MenuStrip1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.帮助ToolStripMenuItem1, Me.关于ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(544, 28)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '帮助ToolStripMenuItem1
        '
        Me.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1"
        Me.帮助ToolStripMenuItem1.Size = New System.Drawing.Size(53, 24)
        Me.帮助ToolStripMenuItem1.Text = "Help"
        '
        '关于ToolStripMenuItem2
        '
        Me.关于ToolStripMenuItem2.Name = "关于ToolStripMenuItem2"
        Me.关于ToolStripMenuItem2.Size = New System.Drawing.Size(63, 24)
        Me.关于ToolStripMenuItem2.Text = "About"
        '
        'btn_move_Z
        '
        Me.btn_move_Z.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_Z.Location = New System.Drawing.Point(300, 211)
        Me.btn_move_Z.Name = "btn_move_Z"
        Me.btn_move_Z.Size = New System.Drawing.Size(42, 38)
        Me.btn_move_Z.TabIndex = 21
        Me.btn_move_Z.Text = "Z"
        Me.btn_move_Z.UseVisualStyleBackColor = True
        '
        'btn_move_Y
        '
        Me.btn_move_Y.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_Y.Location = New System.Drawing.Point(300, 169)
        Me.btn_move_Y.Name = "btn_move_Y"
        Me.btn_move_Y.Size = New System.Drawing.Size(42, 36)
        Me.btn_move_Y.TabIndex = 20
        Me.btn_move_Y.Text = "Y"
        Me.btn_move_Y.UseVisualStyleBackColor = True
        '
        'btn_move_X
        '
        Me.btn_move_X.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_X.Location = New System.Drawing.Point(300, 123)
        Me.btn_move_X.Name = "btn_move_X"
        Me.btn_move_X.Size = New System.Drawing.Size(42, 40)
        Me.btn_move_X.TabIndex = 19
        Me.btn_move_X.Text = "X"
        Me.btn_move_X.UseVisualStyleBackColor = True
        '
        'btn_move_Z1
        '
        Me.btn_move_Z1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_Z1.Location = New System.Drawing.Point(359, 211)
        Me.btn_move_Z1.Name = "btn_move_Z1"
        Me.btn_move_Z1.Size = New System.Drawing.Size(42, 38)
        Me.btn_move_Z1.TabIndex = 24
        Me.btn_move_Z1.Text = "Z'"
        Me.btn_move_Z1.UseVisualStyleBackColor = True
        '
        'btn_move_Y1
        '
        Me.btn_move_Y1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_Y1.Location = New System.Drawing.Point(359, 169)
        Me.btn_move_Y1.Name = "btn_move_Y1"
        Me.btn_move_Y1.Size = New System.Drawing.Size(42, 36)
        Me.btn_move_Y1.TabIndex = 23
        Me.btn_move_Y1.Text = "Y'"
        Me.btn_move_Y1.UseVisualStyleBackColor = True
        '
        'btn_move_X1
        '
        Me.btn_move_X1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_move_X1.Location = New System.Drawing.Point(359, 123)
        Me.btn_move_X1.Name = "btn_move_X1"
        Me.btn_move_X1.Size = New System.Drawing.Size(42, 40)
        Me.btn_move_X1.TabIndex = 22
        Me.btn_move_X1.Text = "X'"
        Me.btn_move_X1.UseVisualStyleBackColor = True
        '
        'btnResetViewer
        '
        Me.btnResetViewer.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnResetViewer.Location = New System.Drawing.Point(5, 269)
        Me.btnResetViewer.Name = "btnResetViewer"
        Me.btnResetViewer.Size = New System.Drawing.Size(128, 30)
        Me.btnResetViewer.TabIndex = 25
        Me.btnResetViewer.Text = "Resume Viewer"
        Me.btnResetViewer.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(153, 269)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 30)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Hide/Show Spec Tree（F3）"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(544, 344)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnResetViewer)
        Me.Controls.Add(Me.btn_move_Z1)
        Me.Controls.Add(Me.btn_move_Y1)
        Me.Controls.Add(Me.btn_move_X1)
        Me.Controls.Add(Me.btn_move_Z)
        Me.Controls.Add(Me.btn_move_Y)
        Me.Controls.Add(Me.btn_move_X)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_Equation)
        Me.Controls.Add(Me.btn_move_B1)
        Me.Controls.Add(Me.btn_move_L1)
        Me.Controls.Add(Me.btn_move_D1)
        Me.Controls.Add(Me.btn_move_F1)
        Me.Controls.Add(Me.btn_move_R1)
        Me.Controls.Add(Me.btn_move_U1)
        Me.Controls.Add(Me.btn_move_B)
        Me.Controls.Add(Me.btn_move_D)
        Me.Controls.Add(Me.btn_Move_L)
        Me.Controls.Add(Me.btn_MoveF)
        Me.Controls.Add(Me.btn_Move_R)
        Me.Controls.Add(Me.btnMove)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "Rubik's Cube"
        Me.TransparencyKey = System.Drawing.Color.Olive
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents btn_Move_R As System.Windows.Forms.Button
    Friend WithEvents btn_MoveF As System.Windows.Forms.Button
    Friend WithEvents btn_Move_L As System.Windows.Forms.Button
    Friend WithEvents btn_move_D As System.Windows.Forms.Button
    Friend WithEvents btn_move_B As System.Windows.Forms.Button
    Friend WithEvents btn_move_U1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_R1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_F1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_D1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_L1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_B1 As System.Windows.Forms.Button
    Friend WithEvents tb_Equation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 创建魔方ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 装配魔方ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 帮助ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_move_Z As System.Windows.Forms.Button
    Friend WithEvents btn_move_Y As System.Windows.Forms.Button
    Friend WithEvents btn_move_X As System.Windows.Forms.Button
    Friend WithEvents btn_move_Z1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_Y1 As System.Windows.Forms.Button
    Friend WithEvents btn_move_X1 As System.Windows.Forms.Button
    Friend WithEvents btnResetViewer As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel

End Class
