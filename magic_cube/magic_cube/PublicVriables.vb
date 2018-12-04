Imports INFITF
Imports ProductStructureTypeLib
Imports System.Math


Module PublicVriables
    Public CATIA As INFITF.Application
    Public rootProd As Product    '根装配节点
    Public MovingProd As Product  '需要移动的装配体
    Public UnitProds(2, 2)        '魔方单元数组
    Public UnitProd As Product    '魔方单元


    Public Sub InitCATIA()
        If CATIA Is Nothing Then

            CATIA = CreateObject("CATIA.Application")
            If CATIA Is Nothing Then
                Throw New Exception("您没有安装CATIA或没有注册COM组件" & vbCrLf & _
                                   "注册COM组件的方法是：" & vbCrLf & _
                                   "在命令行中运行 %InstallDir%\CNEXT.exe regserver" & _
                                   "其中%installDir%为CATIA的bin目录")
            End If
            CATIA.Visible = True
         
        End If
    End Sub


    ''' <summary>
    ''' 求绕Y轴旋转矩阵，适用于R，R1，L，L1等
    ''' </summary>
    ''' <param name="deg">旋转角度</param>
    ''' <param name="sign">旋转方向，1表示正向，-1表示逆向（右手定则）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RotateX(ByVal deg As Double, ByVal sign As Integer) As Object()
        Dim TransArray(11)
        TransArray(0) = 1.0
        TransArray(1) = 0.0
        TransArray(2) = 0.0
        TransArray(3) = 0.0
        TransArray(4) = Cos(deg * PI / 180)
        TransArray(5) = Sin(deg * PI / 180) * sign
        TransArray(6) = 0.0
        TransArray(7) = -Sin(deg * PI / 180) * sign
        TransArray(8) = Cos(deg * PI / 180)
        TransArray(9) = 0.0
        TransArray(10) = 0.0
        TransArray(11) = 0.0
        Return TransArray
    End Function


    ''' <summary>
    ''' 求绕Y轴旋转矩阵，适用于F，F1，B，B1等
    ''' </summary>
    ''' <param name="deg">旋转角度</param>
    ''' <param name="sign">旋转方向，1表示正向，-1表示逆向（右手定则）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RotateY(ByVal deg As Double, ByVal sign As Integer) As Object()
        Dim TransArray(11)
        TransArray(0) = Cos(deg * PI / 180)
        TransArray(1) = 0.0
        TransArray(2) = -Sin(deg * PI / 180) * sign
        TransArray(3) = 0.0
        TransArray(4) = 1.0
        TransArray(5) = 0.0
        TransArray(6) = Sin(deg * PI / 180) * sign
        TransArray(7) = 0.0
        TransArray(8) = Cos(deg * PI / 180)
        TransArray(9) = 0.0
        TransArray(10) = 0.0
        TransArray(11) = 0.0
        Return TransArray
    End Function

    ''' <summary>
    ''' 求绕Z轴旋转矩阵，适用于U，U1，D，D1等
    ''' </summary>
    ''' <param name="deg">旋转角度</param>
    ''' <param name="sign">旋转方向，1表示正向，-1表示逆向（右手定则）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RotateZ(ByVal deg As Double, ByVal sign As Integer) As Object()
        Dim TransArray(11)
        TransArray(0) = Cos(deg * PI / 180)          '0.866025
        TransArray(1) = Sin(deg * PI / 180) * sign
        TransArray(2) = 0.0
        TransArray(3) = -Sin(deg * PI / 180) * sign
        TransArray(4) = Cos(deg * PI / 180)
        TransArray(5) = 0.0
        TransArray(6) = 0.0
        TransArray(7) = 0.0
        TransArray(8) = 1.0
        TransArray(9) = 0.0
        TransArray(10) = 0.0
        TransArray(11) = 0.0
        Return TransArray
    End Function
End Module
