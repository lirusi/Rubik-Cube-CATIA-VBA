

'import CATIA Library
Imports MECMOD
Imports PARTITF
Imports INFITF
Imports HybridShapeTypeLib
Imports ProductStructureTypeLib


'Color Class
Public Class rgb
    Public r As Integer
    Public g As Integer
    Public b As Integer

    'Constructor
    Sub New(ByVal r1 As Integer, ByVal g1 As Integer, ByVal b1 As Integer)
        r = r1
        g = g1
        b = b1
    End Sub
End Class


'Cube operation class
Public Class CCube

    Public Const SLEEPTIME As Integer = 200  'time gap between Cube movement, this is to use for stimulating the movement animation of cube units

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()

        'Initiating CAITIA
        InitCATIA()

    End Sub

    'Create Assembly Cube
    Public Sub PrepareProducts()

        'Close Cube Product which is already exist in CATIA session
        For i = 1 To CATIA.Documents.Count
            If CATIA.Documents.Item(i).Name.Contains("CATProduct") Then
                If CATIA.Documents.Item(i).Product.PartNumber = "Rubik's Cube" Then
                    CATIA.Documents.Item(i).Close()
                    Exit For
                End If
            End If
        Next

        'New Product
        Dim rootProdDoc As ProductDocument = CATIA.Documents.Add("Product")
        rootProd = rootProdDoc.Product
        rootProd.PartNumber = "Rubik's Cube"
    End Sub

    ''' <summary>
    ''' A rubik's cube is consist of 27 units, this function is to create one cube unit
    ''' </summary>
    ''' <param name="length">length of cube unit, in mm</param>
    ''' <param name="radius">fillet radiu of cube unit</param>
    ''' <remarks></remarks>
    Public Sub CreatePart(ByVal length As Double, ByVal radius As Double)

        CATIA.DisplayFileAlerts = False          'no file save alerts, overwrite cube unit parts directly
        Dim oPartDoc As PartDocument = CATIA.Documents.Add("Part")
        Dim oPart As Part = oPartDoc.Part
        Dim oPlaneXY As Object = oPart.OriginElements.PlaneXY
        Dim oPlaneYZ As Object = oPart.OriginElements.PlaneYZ
        Dim oPlaneZX As Object = oPart.OriginElements.PlaneZX
        Dim ohsf As HybridShapeFactory = oPart.HybridShapeFactory

        Dim oProcessBody = oPart.HybridBodies.Add()
        oProcessBody.Name = "Process"
        Dim oResultBody = oPart.HybridBodies.Add()
        oResultBody.Name = "Result"

        Dim oPoint As Point = ohsf.AddNewPointCoord(-length / 2, -length / 2, -length / 2) 'assume that the origin point is the center of the cube unit
        oProcessBody.AppendHybridShape(oPoint)                                             'Create the left down point first
        Dim xDir As HybridShapeDirection = ohsf.AddNewDirectionByCoord(1, 0, 0)
        Dim yDir As HybridShapeDirection = ohsf.AddNewDirectionByCoord(0, 1, 0)
        Dim zdir As HybridShapeDirection = ohsf.AddNewDirectionByCoord(0, 0, 1)
        Dim oXLine As Line = ohsf.AddNewLinePtDir(oPoint, xDir, radius, length - radius, False)
        Dim oYline As Line = ohsf.AddNewLinePtDir(oPoint, yDir, radius, length - radius, False)
        Dim oZline As Line = ohsf.AddNewLinePtDir(oPoint, zdir, radius, length - radius, False)

        oProcessBody.AppendHybridShape(oXLine)
        oProcessBody.AppendHybridShape(oYline)
        oProcessBody.AppendHybridShape(oZline)

        Dim xLineZ As Object = ohsf.AddNewTranslate(oXLine, zdir, radius)
        Dim xLineY As Object = ohsf.AddNewTranslate(oXLine, yDir, radius)
        Dim ylineX As Object = ohsf.AddNewTranslate(oYline, xDir, radius)
        Dim ylineZ As Object = ohsf.AddNewTranslate(oYline, zdir, radius)
        Dim zLineX As Object = ohsf.AddNewTranslate(oZline, xDir, radius)
        Dim zLineY As Object = ohsf.AddNewTranslate(oZline, yDir, radius)
        oProcessBody.AppendHybridShape(xLineZ)
        oProcessBody.AppendHybridShape(xLineY)
        oProcessBody.AppendHybridShape(ylineX)
        oProcessBody.AppendHybridShape(ylineZ)
        oProcessBody.AppendHybridShape(zLineX)
        oProcessBody.AppendHybridShape(zLineY)


        Dim oFrontSurf As HybridShapeExtrude = ohsf.AddNewExtrude(xLineZ, length - 2 * radius, 0, zdir)
        oFrontSurf.Name = "Front"
        oResultBody.AppendHybridShape(oFrontSurf)

        Dim oLeftSurf As HybridShapeExtrude = ohsf.AddNewExtrude(ylineZ, length - 2 * radius, 0, zdir)
        oLeftSurf.Name = "Left"
        oResultBody.AppendHybridShape(oLeftSurf)

        Dim oDownSurf As HybridShapeExtrude = ohsf.AddNewExtrude(xLineY, length - 2 * radius, 0, yDir)
        oDownSurf.Name = "Down"
        oResultBody.AppendHybridShape(oDownSurf)

        Dim oBackSurf As HybridShapeTranslate = ohsf.AddNewTranslate(oFrontSurf, yDir, length)
        oBackSurf.Name = "Back"
        oResultBody.AppendHybridShape(oBackSurf)

        Dim oRightSurf As HybridShapeTranslate = ohsf.AddNewTranslate(oLeftSurf, xDir, length)
        oRightSurf.Name = "Right"
        oResultBody.AppendHybridShape(oRightSurf)

        Dim oUpSurf As HybridShapeTranslate = ohsf.AddNewTranslate(oDownSurf, zdir, length)
        oUpSurf.Name = "Up"
        oResultBody.AppendHybridShape(oUpSurf)

        oPart.Update()

        ''Create fillets
        '----------------------------------------
        Dim CornerXY As Object = ohsf.AddNewCorner(ylineZ, xLineZ, Nothing, radius, 1, -1, False)
        oProcessBody.AppendHybridShape(CornerXY)
        Dim FilletXY As Object = ohsf.AddNewExtrude(CornerXY, length - 2 * radius, 0, zdir)
        oProcessBody.AppendHybridShape(FilletXY)

        Dim CornerYZ As Object = ohsf.AddNewCorner(ylineX, zLineX, Nothing, radius, 1, -1, False)
        oProcessBody.AppendHybridShape(CornerYZ)
        Dim FilletYZ As Object = ohsf.AddNewExtrude(CornerYZ, length - 2 * radius, 0, xDir)
        oProcessBody.AppendHybridShape(FilletYZ)

        Dim CornerZX As Object = ohsf.AddNewCorner(xLineY, zLineY, Nothing, radius, 1, -1, False)
        oProcessBody.AppendHybridShape(CornerZX)
        Dim FilletZX As Object = ohsf.AddNewExtrude(CornerZX, length - 2 * radius, 0, yDir)
        oProcessBody.AppendHybridShape(FilletZX)

        Dim oFill As HybridShapeFill = ohsf.AddNewFill()
        oFill.AddBound(CornerXY)
        oFill.AddBound(CornerYZ)
        oFill.AddBound(CornerZX)
        oProcessBody.AppendHybridShape(oFill)
        oPart.Update()

        Dim oSymmetryFill As HybridShapeSymmetry = ohsf.AddNewSymmetry(oFill, oPlaneXY)
        oProcessBody.AppendHybridShape(oSymmetryFill)

        Dim oJoin As HybridShapeAssemble = ohsf.AddNewJoin(oFill, FilletXY)
        oJoin.AddElement(oSymmetryFill)
        oPart.Update()
        'translating
        On Error Resume Next
        Dim oShapeFactory As ShapeFactory = oPart.ShapeFactory
        oPoint = ohsf.AddNewPointCoord(0, 0, 0)
        Dim oZAixs As Object = ohsf.AddNewLinePtDir(oPoint, zdir, 0, 100, True)
        oProcessBody.AppendHybridShape(oZAixs)
        oPart.Update()
        Dim oCirclePattern1 As CircPattern = oShapeFactory.AddNewSurfacicCircPattern(oJoin, 1, 4, 20, 90, 1, 1, Nothing, oZAixs, True, 360, True, True)
        oCirclePattern1.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing
        oCirclePattern1.SetRotationAxis(oZAixs)
        oProcessBody.AppendHybridShape(oCirclePattern1)
        oPart.Update()

        Dim oXAixs As Object = ohsf.AddNewLinePtDir(oPoint, xDir, 0, 100, True)
        oProcessBody.AppendHybridShape(oZAixs)
        oPart.Update()
        Dim oCirclePattern2 As CircPattern = oShapeFactory.AddNewSurfacicCircPattern(FilletYZ, 1, 4, 20, 90, 1, 1, Nothing, oXAixs, True, 360, True, True)
        oCirclePattern1.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing
        oProcessBody.AppendHybridShape(oCirclePattern2)
        oPart.Update()

        Dim oYAixs As Object = ohsf.AddNewLinePtDir(oPoint, yDir, 0, 100, True)
        oProcessBody.AppendHybridShape(oYAixs)
        oPart.Update()
        Dim oCirclePattern3 As CircPattern = oShapeFactory.AddNewSurfacicCircPattern(FilletZX, 1, 4, 20, 90, 1, 1, Nothing, oYAixs, True, 360, True, True)
        oCirclePattern1.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing
        oProcessBody.AppendHybridShape(oCirclePattern3)
        oPart.Update()
        On Error GoTo 0

        Dim ref1 As Reference = oPart.CreateReferenceFromObject(oCirclePattern1)
        Dim ref2 As Reference = oPart.CreateReferenceFromObject(oCirclePattern2)
        Dim ref3 As Reference = oPart.CreateReferenceFromObject(oCirclePattern3)


        Dim oFilletJoin As HybridShapeAssemble = ohsf.AddNewJoin(oJoin, ref1)
        oFilletJoin.AddElement(FilletYZ)
        oFilletJoin.AddElement(FilletZX)
        oFilletJoin.AddElement(ref2)
        oFilletJoin.AddElement(ref3)
        oResultBody.AppendHybridShape(oFilletJoin)
        oPart.Update()



        Dim oSelection As Selection = oPartDoc.Selection
        Dim visProp As VisPropertySet = oSelection.VisProperties
        oSelection.Clear()

        'Hide the geometry of middle operations, only show the final results
        oSelection.Add(oPart.OriginElements.PlaneXY)
        oSelection.Add(oPart.OriginElements.PlaneYZ)
        oSelection.Add(oPart.OriginElements.PlaneZX)
        oSelection.Add(oProcessBody)
        visProp.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr)
        oSelection.Clear()
        oPart.Update()
        'save catia part
        On Error Resume Next

        oPartDoc.SaveAs(CurDir() & "\Unit.CATPart")
        oPartDoc.Close()

        '根据本函数以上代码创建的基本魔方单元，另存为27个魔方单元
        'Based on this cube unit, save as 27 units, coloring the face of the units according its initial location in the cube
        '根据单元在魔方中的初始位置，为它们的外表面涂色
        SaveParts()




    End Sub

    ''' <summary>
    ''' Create one unit with surface color
    ''' </summary>
    ''' <param name="Sides"></param>
    ''' <param name="colors"></param>
    ''' <param name="PartNumber"></param>
    ''' <remarks></remarks>
    Public Sub SavePart(ByVal Sides() As String, ByVal colors() As rgb, ByVal PartNumber As String)

        CATIA.DisplayFileAlerts = False
        'Open the the basic unit catpart
        Dim oPartDoc As PartDocument = CATIA.Documents.Open(CurDir() & "\Unit.CATPart")
        Dim oPart As Part = oPartDoc.Part
        'retrive the six surface of this unit
        Dim FrontSurf As Object = oPart.HybridBodies.Item("Result").HybridShapes.Item("Front")
        Dim BackSurf As Object = oPart.HybridBodies.Item("Result").HybridShapes.Item("Back")
        Dim LeftSurf As Object = oPart.HybridBodies.Item("Result").HybridShapes.Item("Left")
        Dim RightSurf As Object = oPart.HybridBodies.Item("Result").HybridShapes.Item("Right")
        Dim UpSurf As Object = oPart.HybridBodies.Item("Result").HybridShapes.Item("Up")
        Dim DownSurf As Object = oPart.HybridBodies.Item("Result").HybridShapes.Item("Down")

        Dim oSelection As Selection = oPart.Parent.Selection
        Dim oVisprop As VisPropertySet = oSelection.VisProperties
        oSelection.Clear()

        Dim SideCount As Integer = Sides.Length
        Dim i As Integer
        'coloring surface
        For i = 0 To SideCount - 1
            If Sides(i) = "Front" Then
                oSelection.Add(FrontSurf)
            ElseIf Sides(i) = "Back" Then
                oSelection.Add(BackSurf)
            ElseIf Sides(i) = "Left" Then
                oSelection.Add(LeftSurf)
            ElseIf Sides(i) = "Right" Then
                oSelection.Add(RightSurf)
            ElseIf Sides(i) = "Up" Then
                oSelection.Add(UpSurf)
            ElseIf Sides(i) = "Down" Then
                oSelection.Add(DownSurf)
            ElseIf Sides(i) Is Nothing Then
                Continue For
            End If
            oVisprop.SetRealColor(colors(i).r, colors(i).g, colors(i).b, 1)
            oSelection.Clear()
        Next
        'information was save in the partnumber of the unit
        oPartDoc.Product.PartNumber = PartNumber
        'save this unit(with color)
        On Error Resume Next
        oPartDoc.SaveAs(CurDir() & "\" & PartNumber & ".CATPart")
        oPartDoc.Close()
    End Sub

    Public Sub SaveParts()

        '--------------------save parts
        '1，1，1 calculation, taking the leftup conor as origion 
        Dim sides(2) As String
        Dim colors(2) As rgb
        Dim red As rgb = New rgb(255, 0, 0)
        Dim green As rgb = New rgb(0, 255, 0)
        Dim blue As rgb = New rgb(0, 0, 255)
        Dim yellow As rgb = New rgb(255, 255, 0)
        Dim pink As rgb = New rgb(0, 255, 255)
        Dim purple As rgb = New rgb(255, 0, 255)
        Dim PartNumber As String = ""


        Dim layer, column, row As Integer
        For layer = 1 To 3
            For column = 1 To 3
                For row = 1 To 3
                    If layer = 1 Then sides(0) = "Up" : colors(0) = red
                    If layer = 2 Then sides(0) = Nothing
                    If layer = 3 Then sides(0) = "Down" : colors(0) = purple

                    If column = 1 Then sides(1) = "Left" : colors(1) = green
                    If column = 2 Then sides(1) = Nothing
                    If column = 3 Then sides(1) = "Right" : colors(1) = yellow

                    If row = 1 Then sides(2) = "Front" : colors(2) = blue
                    If row = 2 Then sides(2) = Nothing
                    If row = 3 Then sides(2) = "Back" : colors(2) = pink
                    PartNumber = "Unit_" & layer & "-" & column & "-" & row
                    SavePart(sides, colors, PartNumber)
                Next
            Next
        Next
    End Sub
    ''' <summary>
    ''' Assembly 27 units to a Rubik's cube
    ''' </summary>
    ''' <param name="length"></param>
    ''' <remarks></remarks>
    Public Sub AssembleParts(ByVal path As String, ByVal length As Double)

        Dim fileArray(0)

        Dim layer, column, row As Integer  'layer is counting up to down，there are 3 layers；column counting form left to  right
        'rows counting from front to back
        'in this program, layer\column\row are the coordination of the cube unit in the cube

        'cube location matrix
        Dim arrayOfVariantOfDouble1(11)
        arrayOfVariantOfDouble1(0) = 1.0
        arrayOfVariantOfDouble1(1) = 0.0
        arrayOfVariantOfDouble1(2) = 0.0
        arrayOfVariantOfDouble1(3) = 0.0
        arrayOfVariantOfDouble1(4) = 1.0
        arrayOfVariantOfDouble1(5) = 0.0
        arrayOfVariantOfDouble1(6) = 0.0
        arrayOfVariantOfDouble1(7) = 0.0
        arrayOfVariantOfDouble1(8) = 1.0
        arrayOfVariantOfDouble1(9) = 0
        arrayOfVariantOfDouble1(10) = 0
        arrayOfVariantOfDouble1(11) = 0

        Dim oUnitProd As Product = Nothing

        For layer = 1 To 3
            For column = 1 To 3
                For row = 1 To 3
                    fileArray(0) = path & "\Unit_" & layer & "-" & column & "-" & row & ".CATPart"
                    rootProd.Products.AddComponentsFromFiles(fileArray, "All")

                    oUnitProd = rootProd.Products.Item(rootProd.Products.Count)  'get the last assembled part
                    'move it to the correct location
                    SetPartPosition(oUnitProd, layer, column, row, arrayOfVariantOfDouble1, length)
                Next
            Next
        Next

        ''Create a MovingProduct，put Units that need to move
        MovingProd = rootProd.Products.AddNewProduct("MovingProduct")
        Dim v3d As Viewer3D = CATIA.ActiveWindow.ActiveViewer
        v3d.RenderingMode = CatRenderingMode.catRenderShading


    End Sub

    ''' <summary>
    ''' Upside rotate 90 degrees clockwise
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_U()
        Dim i, j As Integer

        '1.Get the units need to move
        For i = 1 To 3
            For j = 1 To 3
                'take the description reference as the location info
                UnitProd = FindPrdByDescription(rootProd, "1-" & i & "-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next
        '2.Praperation for rotation，put parts need to move in MovingProduct
        copyModel(UnitProds)

        '3.rotating the units，30 degrees each movement，to simulation the movement
        Dim Rotate30_U = RotateZ(30, -1)   'calculate moveing matrix
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(Rotate30_U)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        '4.rotating the hiden units
        Dim Rotate90_U = RotateZ(90, -1)

        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(Rotate90_U)
                UnitProd.DescriptionRef = "1-" & j & "-" & 4 - i '& "_TEMP"
            Next
        Next

        '5.show the hiden units
        RecoverModel()

    End Sub

    ''' <summary>
    ''' Rotate top surface of the cube back clockwise
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_U1()
        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = FindPrdByDescription(rootProd, "1-" & i & "-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next
        copyModel(UnitProds)

        Dim RotateU1_30 = RotateZ(30, 1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateU1_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateU1_90 = RotateZ(90, 1)

        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateU1_90)
                UnitProd.DescriptionRef = "1-" & 4 - j & "-" & i
            Next
        Next
        RecoverModel()

    End Sub

    ''' <summary>
    ''' 右面Rigth Side顺时针旋转90度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_R()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过Description reference（实际位置信息）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-3" & "-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateR_30 = RotateX(30, -1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateR_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateR_90 = RotateX(90, -1)

        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateR_90)
                UnitProd.DescriptionRef = j & "-3-" & 4 - i '& "_TEMP"
            Next
        Next

        RecoverModel()

    End Sub

    ''' <summary>
    ''' 右面反向移动
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_R1()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-3" & "-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateR_30 = RotateX(30, 1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateR_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateR_90 = RotateX(90, 1)

        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateR_90)
                UnitProd.DescriptionRef = 4 - j & "-3-" & i
            Next
        Next

        RecoverModel()

    End Sub


    ''' <summary>
    ''' 前面FrontSide顺时针旋转90度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_F()
        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-" & j & "-1")
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateF_30 = RotateY(30, 1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateF_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next


        Dim RotateF_90 = RotateY(90, 1)

        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateF_90)
                UnitProd.DescriptionRef = j & "-" & 4 - i & "-1"
            Next
        Next

        ''还原显示
        RecoverModel()

    End Sub

    Public Sub Move_F1()
        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-" & j & "-1")
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateF_30 = RotateY(30, -1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateF_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next


        Dim RotateF_90 = RotateY(90, -1)

        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateF_90)
                UnitProd.DescriptionRef = 4 - j & "-" & i & "-1"
            Next
        Next

        ''还原显示
        RecoverModel()

    End Sub

    ''' <summary>
    ''' 左面FrontSide顺时针旋转90度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_L()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-1-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateL_30 = RotateX(30, 1)  '求旋转矩阵
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateL_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next


        Dim RotateL_90deg = RotateX(90, 1)
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateL_90deg)
                UnitProd.DescriptionRef = 4 - j & "-1-" & i
            Next
        Next

        ''还原显示
        RecoverModel()
    End Sub

    Public Sub Move_L1()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-1-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateL_30 = RotateX(30, -1)  '求旋转矩阵
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateL_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next


        Dim RotateL_90deg = RotateX(90, -1)
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateL_90deg)
                UnitProd.DescriptionRef = j & "-1-" & 4 - i
            Next
        Next

        ''还原显示
        RecoverModel()
    End Sub

    Public Sub Move_D()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, "3-" & i & "-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        copyModel(UnitProds)

        Dim RotateD_30 = RotateZ(30, 1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateD_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next


        Dim RotateD_90deg = RotateZ(90, 1)
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateD_90deg)
                UnitProd.DescriptionRef = "3-" & 4 - j & "-" & i
            Next
        Next

        ''还原显示
        RecoverModel()

    End Sub

    Public Sub Move_D1()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, "3-" & i & "-" & j)
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next

        '重新加载
        copyModel(UnitProds)

        Dim RotateD_30 = RotateZ(30, -1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateD_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next


        Dim RotateD_90deg = RotateZ(90, -1)
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateD_90deg)
                UnitProd.DescriptionRef = "3-" & j & "-" & 4 - i
            Next
        Next

        ''还原显示
        RecoverModel()

    End Sub


    Public Sub Move_B()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-" & j & "-3")
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next
        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateB_30 = RotateY(30, -1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateB_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateB_90 = RotateY(90, -1)
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateB_90)
                UnitProd.DescriptionRef = 4 - j & "-" & i & "-3"
            Next
        Next

        ''还原显示
        RecoverModel()

    End Sub

    Public Sub Move_B1()

        Dim i, j As Integer
        For i = 1 To 3
            For j = 1 To 3
                '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                UnitProd = FindPrdByDescription(rootProd, i & "-" & j & "-3")
                UnitProds(i - 1, j - 1) = UnitProd
            Next
        Next
        '重新加载
        '隐藏并旋转
        copyModel(UnitProds)

        Dim RotateB_30 = RotateY(30, 1)
        Dim move1 = MovingProd.Move
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateB_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateB_90 = RotateY(90, 1)
        For i = 1 To 3
            For j = 1 To 3
                UnitProd = UnitProds(i - 1, j - 1)
                move1 = UnitProd.Move
                move1 = move1.MovableObject
                move1.Apply(RotateB_90)
                UnitProd.DescriptionRef = j & "-" & 4 - i & "-3"
            Next
        Next

        ''还原显示
        RecoverModel()

    End Sub

    ''' <summary>
    ''' 魔方整体做一个R向的转动
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move_X()

        Dim i, j, k As Integer
        Dim unitProds1(2, 2, 2)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                    UnitProd = FindPrdByDescription(rootProd, i & "-" & k & "-" & j)
                    unitProds1(k - 1, i - 1, j - 1) = UnitProd
                Next
            Next
        Next

        copyModelAll(unitProds1)

        Dim RotateR_30 = RotateX(30, -1)
        Dim move1 = MovingProd.Move()
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateR_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateR_90 = RotateX(90, -1)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    UnitProd = unitProds1(k - 1, i - 1, j - 1)
                    move1 = UnitProd.Move
                    move1 = move1.MovableObject
                    move1.Apply(RotateR_90)
                    UnitProd.DescriptionRef = j & "-" & k & "-" & 4 - i
                Next
            Next
        Next

        RecoverModelAll(unitProds1)
    End Sub

    Public Sub Move_X1()

        Dim i, j, k As Integer
        Dim unitProds1(2, 2, 2)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                    UnitProd = FindPrdByDescription(rootProd, i & "-" & k & "-" & j)
                    unitProds1(k - 1, i - 1, j - 1) = UnitProd
                Next
            Next
        Next
        copyModelAll(unitProds1)

        Dim RotateR_30 = RotateX(30, 1)
        Dim move1 = MovingProd.Move()
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateR_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateR_90 = RotateX(90, 1)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    UnitProd = unitProds1(k - 1, i - 1, j - 1)
                    move1 = UnitProd.Move
                    move1 = move1.MovableObject
                    move1.Apply(RotateR_90)
                    UnitProd.DescriptionRef = 4 - j & "-" & k & "-" & i
                Next
            Next
        Next
        RecoverModelAll(unitProds1)


    End Sub

    Public Sub Move_Y()

        Dim i, j, k As Integer
        Dim unitProds1(2, 2, 2)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                    UnitProd = FindPrdByDescription(rootProd, i & "-" & j & "-" & k)
                    unitProds1(i - 1, j - 1, k - 1) = UnitProd
                Next
            Next
        Next

        copyModelAll(unitProds1)

        Dim RotateF_30 = RotateY(30, 1)
        Dim move1 = MovingProd.Move()
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateF_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateF_90 = RotateY(90, 1)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    UnitProd = unitProds1(i - 1, j - 1, k - 1)
                    move1 = UnitProd.Move
                    move1 = move1.MovableObject
                    move1.Apply(RotateF_90)
                    UnitProd.DescriptionRef = j & "-" & 4 - i & "-" & k
                Next
            Next
        Next
        RecoverModelAll(unitProds1)

    End Sub

    Public Sub Move_Y1()

        Dim i, j, k As Integer
        Dim unitProds1(2, 2, 2)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                    UnitProd = FindPrdByDescription(rootProd, i & "-" & j & "-" & k)
                    unitProds1(i - 1, j - 1, k - 1) = UnitProd
                Next
            Next
        Next

        copyModelAll(unitProds1)

        Dim RotateF_30 = RotateY(30, -1)
        Dim move1 = MovingProd.Move()
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateF_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateF_90 = RotateY(90, -1)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    UnitProd = unitProds1(i - 1, j - 1, k - 1)
                    move1 = UnitProd.Move
                    move1 = move1.MovableObject
                    move1.Apply(RotateF_90)
                    UnitProd.DescriptionRef = 4 - j & "-" & i & "-" & k

                Next
            Next
        Next

        RecoverModelAll(unitProds1)
    End Sub

    Public Sub Move_Z()

        Dim i, j, k As Integer
        Dim unitProds1(2, 2, 2)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    '装配移动体的时候，先通过DR（实际位置）找到需要移动的单元
                    UnitProd = FindPrdByDescription(rootProd, k & "-" & i & "-" & j)
                    unitProds1(k - 1, i - 1, j - 1) = UnitProd
                Next
            Next
        Next

        copyModelAll(unitProds1)
        Dim RotateU_30 = RotateZ(30, -1)
        Dim move1 = MovingProd.Move()
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateU_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateU_90 = RotateZ(90, -1)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    UnitProd = unitProds1(k - 1, i - 1, j - 1)
                    move1 = UnitProd.Move
                    move1 = move1.MovableObject
                    move1.Apply(RotateU_90)
                    UnitProd.DescriptionRef = k & "-" & j & "-" & 4 - i
                Next
            Next
        Next
        RecoverModelAll(unitProds1)

    End Sub

    Public Sub Move_Z1()

        Dim i, j, k As Integer
        Dim unitProds1(2, 2, 2)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    'When units are going to move, firstly find the unit to move by its Description Reference
                    UnitProd = FindPrdByDescription(rootProd, k & "-" & i & "-" & j)
                    unitProds1(k - 1, i - 1, j - 1) = UnitProd
                Next
            Next
        Next

        copyModelAll(unitProds1)
        Dim RotateU_30 = RotateZ(30, 1)
        Dim move1 = MovingProd.Move()
        move1 = move1.MovableObject
        For i = 1 To 3
            move1.Apply(RotateU_30)
            System.Threading.Thread.Sleep(SLEEPTIME)
        Next

        Dim RotateU_90 = RotateZ(90, 1)
        For k = 1 To 3
            For i = 1 To 3
                For j = 1 To 3
                    UnitProd = unitProds1(k - 1, i - 1, j - 1)
                    move1 = UnitProd.Move
                    move1 = move1.MovableObject
                    move1.Apply(RotateU_90)
                    UnitProd.DescriptionRef = k & "-" & i & "-" & 4 - j
                Next
            Next
        Next

        RecoverModelAll(unitProds1)
    End Sub

    Public Sub copyModel(ByVal unitProds As Object)
        '1.Copy units to the moving product, rotate the moving product
        Dim oSel As Selection = CATIA.ActiveDocument.Selection
        oSel.Clear()
        For i = 1 To 3
            For j = 1 To 3
                oSel.Add(unitProds(i - 1, j - 1))
            Next
        Next
        oSel.Copy()
        oSel.Clear()
        oSel.Add(MovingProd)
        oSel.PasteSpecial("CATProdCont")
        oSel.Clear()

        '2.hide the units that not rotating
        'After the copy, there will be two copy of the units going to rotate. we hide units in main product, so when moving part rotates, it seems like 
        'real rotation
        For i = 1 To 3
            For j = 1 To 3
                oSel.Add(unitProds(i - 1, j - 1))
            Next
        Next
        oSel.VisProperties.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr)
        oSel.Clear()


    End Sub

    Public Sub copyModelAll(ByVal unitProds1 As Object)
        '1.Copy units to the moving product, rotate the moving product
        Dim oSel As Selection = CATIA.ActiveDocument.Selection
        oSel.Clear()
        For i = 1 To 3
            For j = 1 To 3
                For k = 1 To 3
                    oSel.Add(unitProds1(i - 1, j - 1, k - 1))
                Next
            Next
        Next
        oSel.Copy()
        oSel.Clear()
        oSel.Add(MovingProd)
        oSel.PasteSpecial("CATProdCont")
        oSel.Clear()

        '2.hide the units that not rotating
        'After the copy, there will be two copy of the units going to rotate. we hide units in main product, so when moving part rotates, it seems like 
        'real rotation
        For i = 1 To 3
            For j = 1 To 3
                For k = 1 To 3
                    oSel.Add(unitProds1(i - 1, j - 1, k - 1))
                Next
            Next
        Next
        oSel.VisProperties.SetShow(CatVisPropertyShow.catVisPropertyNoShowAttr)
        oSel.Clear()


    End Sub


    Public Sub RecoverModel()

        ''还原显示
        Dim oSel As Selection = CATIA.ActiveDocument.Selection
        oSel.Clear()
        For i = 1 To 3
            For j = 1 To 3
                oSel.Add(UnitProds(i - 1, j - 1))
            Next
        Next
        oSel.VisProperties.SetShow(CatVisPropertyShow.catVisPropertyShowAttr)
        oSel.Clear()

        '移除所有MovingPrd下的零件
        If MovingProd.Products.Count > 0 Then
            For i = 1 To 9
                MovingProd.Products.Remove(1)
            Next
        End If

    End Sub

    Public Sub RecoverModelAll(ByVal unitProds1)

        ''Show hiden units
        Dim oSel As Selection = CATIA.ActiveDocument.Selection
        oSel.Clear()
        For i = 1 To 3
            For j = 1 To 3
                For k = 1 To 3
                    oSel.Add(unitProds1(i - 1, j - 1, k - 1))
                Next
            Next
        Next
        oSel.VisProperties.SetShow(CatVisPropertyShow.catVisPropertyShowAttr)
        oSel.Clear()

        'After the rotation, Remove all parts under moving part. 
        'take the moving part as a container, when some unit needs to move, put them in . After the movement, empty it, preparation for next movement
        On Error Resume Next
        For i = 1 To 27
            MovingProd.Products.Remove(1)
        Next


    End Sub

    ''' <summary>
    ''' Get product object by its partnumber
    ''' </summary>
    ''' <param name="fatherPrd"></param>
    ''' <param name="Ptn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindProdByPtn(ByVal fatherPrd As Product, ByVal Ptn As String) As Product
        Dim prod As Product
        For Each prod In fatherPrd.Products
            If prod.PartNumber = Ptn Then
                Return prod
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Get product object by its description reference
    ''' </summary>
    ''' <param name="fatherPrd"></param>
    ''' <param name="Description"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindPrdByDescription(ByVal fatherPrd As Product, ByVal Description As String) As Product
        Dim prod As Product
        For Each prod In fatherPrd.Products
            If prod.DescriptionRef = Description Then
                Return prod
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' FindProductBy DescriptionInst
    ''' </summary>
    ''' <param name="fatherPrd"></param>
    ''' <param name="DI"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindPrdByDI(ByVal fatherPrd As Product, ByVal DI As String) As Product
        Dim prod As Product
        For Each prod In fatherPrd.Products
            If prod.DescriptionInst = DI Then
                Return prod
            End If
        Next
        Return Nothing
    End Function

    '
    Public Sub SetPartPosition(ByVal oProduct As Product, ByVal Layer As Integer, ByVal Column As Integer, _
                               ByVal Row As Integer, ByVal Array As Object, ByVal length As Double)

        'Description Reference saved the temporaty location of a unit, which is changing during the movement
        'Partnumber saves the initial location of the unit, which won't change by it's lifecycle
        '
        oProduct.DescriptionRef = Layer & "-" & Column & "-" & Row

        'When initializing the cube , only need to translation of the units
        Dim move1 = oProduct.Move.MovableObject
        Array(11) = (2 - Layer) * length     'Z坐标, 从上到下
        Array(10) = (Row - 2) * length       'y坐标，从后向前
        Array(9) = (Column - 2) * length     'x坐标，从左到右
        move1.Apply(Array)
    End Sub

    ''' <summary>
    ''' change the viewer, help to obeserve the cube
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetViewer()
        Dim viewer3d1 As Viewer3D = CATIA.ActiveWindow.ActiveViewer

        Dim array1(2)
        array1(0) = -0.2
        array1(1) = 0.91
        array1(2) = -0.35

        Dim array2(2)
        array2(0) = -0.13
        array2(1) = 0.33
        array2(2) = 0.93


        viewer3d1.Viewpoint3D.PutUpDirection(array2)
        viewer3d1.Viewpoint3D.PutSightDirection(array1)
        viewer3d1.Reframe()
    End Sub

    'hide the specification tree
    Public Sub HideSpecTree()

        If CATIA.ActiveWindow.Layout = CatSpecsAndGeomWindowLayout.catWindowGeomOnly Then
            CATIA.ActiveWindow.Layout = CatSpecsAndGeomWindowLayout.catWindowSpecsAndGeom

        Else : CATIA.ActiveWindow.Layout = CatSpecsAndGeomWindowLayout.catWindowSpecsAndGeom
            CATIA.ActiveWindow.Layout = CatSpecsAndGeomWindowLayout.catWindowGeomOnly
        End If

    End Sub

End Class
