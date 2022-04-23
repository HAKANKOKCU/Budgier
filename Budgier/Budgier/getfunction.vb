Imports System.Data
Imports System.IO

Module getfunction
    Dim vars As New Dictionary(Of String, Object)
    Dim visuallerwins As New Dictionary(Of String, Window)
    Dim vswingrids As New Dictionary(Of String, Grid)
    Dim brushutils As New BrushConverter
    Dim funcs As New Dictionary(Of String, String)
    Dim visuallerlabels As New Dictionary(Of String, Label)
    Dim visuallerimages As New Dictionary(Of String, Image)
    Dim visuallerbuttons As New Dictionary(Of String, Button)
    Dim visuallertextboxes As New Dictionary(Of String, TextBox)
    Dim ififstamenttrue As Boolean = True
    Sub run(ByVal file As String, Optional ByVal readstring As Boolean = False)
        Dim a As String
        If readstring Then
            a = file
        Else
            a = My.Computer.FileSystem.ReadAllText(file)
            Console.Title = file
        End If
        a = a.Replace(vbCrLf, "")
        ' - Define - 
        Dim str As String = Nothing
        Dim funcname As String = ""
        Dim funcvars As New ArrayList
        Dim isreadingSTR As Boolean = False
        Dim isreadingFUNCNAME As Boolean = True
        Dim isreadingFUNCVARS As Boolean = False
        Dim funcvrtemp As String = ""
        Dim isreadingFUNC As Boolean = False
        Dim readfunc As String = ""
        ' - End Define - 
        If Not readstring Then
            Console.WriteLine("Def finished.")
        End If
        For i As Integer = 0 To a.Length - 1
            Dim chara As Char = a(i) 'The character reader (IMPORTANT FOR CODE READING BY PC)
            'Console.Write(chara)
            If chara = ")" And Not isreadingFUNC Then
                isreadingFUNCVARS = False
                funcvrtemp = funcvrtemp.Replace(" , ", ",").Replace(", ", ",").Replace(" ,", ",")
                funcvrtemp = funcvrtemp
                Dim splittedvr As Array = funcvrtemp.Split(",")
                For Each item As String In splittedvr
                    item = item.Replace("[Specname[user.desktop]]",
                                     My.Computer.FileSystem.SpecialDirectories.Desktop
                                     ).Replace("[Specname[user.pictures]]",
                                     My.Computer.FileSystem.SpecialDirectories.MyPictures
                                     ).Replace("[Specname[user.documents]]",
                                     My.Computer.FileSystem.SpecialDirectories.MyDocuments
                                     ).Replace("[Coma]", ",").Replace("[NewLine]", Environment.NewLine)
                    item = item.Replace("[Clock.Year]", Now.Year)
                    item = item.Replace("[Clock.Month]", Now.Month)
                    item = item.Replace("[Clock.DayOfYear]", Now.DayOfYear)
                    item = item.Replace("[Clock.DayOfMonth]", Now.Day)
                    item = item.Replace("[Clock.DayOfWeek]", Now.DayOfWeek)
                    item = item.Replace("[Clock.Hour]", Now.Hour)
                    item = item.Replace("[Clock.Minute]", Now.Minute)
                    item = item.Replace("[Clock.Second]", Now.Second)
                    Try
                        For ii As Integer = 0 To visuallerimages.Count - 1
                            item = item.Replace("[VisuallerContent[" & visuallerimages.Keys(ii) & "]]",
                                                visuallerimages(visuallerimages.Keys(ii)).Source.ToString)
                            item = item.Replace("[VisuallerWidth[" & visuallerimages.Keys(ii) & "]]",
                                                visuallerimages(visuallerimages.Keys(ii)).Width)
                            item = item.Replace("[VisuallerHeight[" & visuallerimages.Keys(ii) & "]]",
                                                visuallerimages(visuallerimages.Keys(ii)).Height)
                            item = item.Replace("[VisuallerOpacity[" & visuallerimages.Keys(ii) & "]]",
                                                visuallerimages(visuallerimages.Keys(ii)).Opacity)
                            item = item.Replace("[VisuallerPosition[" & visuallerimages.Keys(ii) & "]]",
                                                visuallerimages(visuallerimages.Keys(ii)).Margin.Left &
                                                "¨" & visuallerimages(visuallerimages.Keys(ii)).Margin.Top &
                                                "¨" & visuallerimages(visuallerimages.Keys(ii)).Margin.Right &
                                                "¨" & visuallerimages(visuallerimages.Keys(ii)).Margin.Bottom)
                        Next
                        For ii As Integer = 0 To visuallerlabels.Count - 1
                            item = item.Replace("[VisuallerContent[" & visuallerlabels.Keys(ii) & "]]",
                                                visuallerlabels(visuallerlabels.Keys(ii)).Content)
                            item = item.Replace("[VisuallerWidth[" & visuallerlabels.Keys(ii) & "]]",
                                                visuallerlabels(visuallerlabels.Keys(ii)).Width)
                            item = item.Replace("[VisuallerHeight[" & visuallerlabels.Keys(ii) & "]]",
                                                visuallerlabels(visuallerlabels.Keys(ii)).Height)
                            item = item.Replace("[VisuallerOpacity[" & visuallerlabels.Keys(ii) & "]]",
                                                visuallerlabels(visuallerlabels.Keys(ii)).Opacity)
                            item = item.Replace("[VisuallerPosition[" & visuallerlabels.Keys(ii) & "]]",
                                                visuallerlabels(visuallerlabels.Keys(ii)).Margin.Left &
                                                "¨" & visuallerlabels(visuallerlabels.Keys(ii)).Margin.Top &
                                                "¨" & visuallerlabels(visuallerlabels.Keys(ii)).Margin.Right &
                                                "¨" & visuallerlabels(visuallerlabels.Keys(ii)).Margin.Bottom)
                        Next
                        For ii As Integer = 0 To visuallerbuttons.Count - 1
                            item = item.Replace("[VisuallerContent[" & visuallerbuttons.Keys(ii) & "]]",
                                                visuallerbuttons(visuallerbuttons.Keys(ii)).Content)
                            item = item.Replace("[VisuallerWidth[" & visuallerbuttons.Keys(ii) & "]]",
                                                visuallerbuttons(visuallerbuttons.Keys(ii)).Width)
                            item = item.Replace("[VisuallerHeight[" & visuallerbuttons.Keys(ii) & "]]",
                                                visuallerbuttons(visuallerbuttons.Keys(ii)).Height)
                            item = item.Replace("[VisuallerOpacity[" & visuallerbuttons.Keys(ii) & "]]",
                                                visuallerbuttons(visuallerbuttons.Keys(ii)).Opacity)
                            item = item.Replace("[VisuallerPosition[" & visuallerbuttons.Keys(ii) & "]]",
                                                visuallerbuttons(visuallerbuttons.Keys(ii)).Margin.Left &
                                                "¨" & visuallerbuttons(visuallerbuttons.Keys(ii)).Margin.Top &
                                                "¨" & visuallerbuttons(visuallerbuttons.Keys(ii)).Margin.Right &
                                                "¨" & visuallerbuttons(visuallerbuttons.Keys(ii)).Margin.Bottom)
                        Next
                        For ii As Integer = 0 To visuallertextboxes.Count - 1
                            item = item.Replace("[VisuallerContent[" & visuallertextboxes.Keys(ii) & "]]",
                                                visuallertextboxes(visuallertextboxes.Keys(ii)).Text)
                            item = item.Replace("[VisuallerWidth[" & visuallertextboxes.Keys(ii) & "]]",
                                                visuallertextboxes(visuallertextboxes.Keys(ii)).Width)
                            item = item.Replace("[VisuallerHeight[" & visuallertextboxes.Keys(ii) & "]]",
                                                visuallertextboxes(visuallertextboxes.Keys(ii)).Height)
                            item = item.Replace("[VisuallerOpacity[" & visuallertextboxes.Keys(ii) & "]]",
                                                visuallertextboxes(visuallertextboxes.Keys(ii)).Opacity)
                            item = item.Replace("[VisuallerPosition[" & visuallertextboxes.Keys(ii) & "]]",
                                                visuallertextboxes(visuallertextboxes.Keys(ii)).Margin.Left &
                                                "¨" & visuallertextboxes(visuallertextboxes.Keys(ii)).Margin.Top &
                                                "¨" & visuallertextboxes(visuallertextboxes.Keys(ii)).Margin.Right &
                                                "¨" & visuallertextboxes(visuallertextboxes.Keys(ii)).Margin.Bottom)
                        Next
                        For ii As Integer = 0 To vars.Count - 1
                            item = item.Replace("[ReadVar[" & vars.Keys(ii) & "]]", vars(vars.Keys(ii)))
                            If vars(vars.Keys(ii)).ToString.Contains("¨") Then
                                'It is a list.
                                item = item.Replace("[List[" & vars.Keys(ii) & "]Length]",
                                                    vars(vars.Keys(ii)).ToString.Split("¨").Length)
                                For b As Integer = 0 To vars(vars.Keys(ii)).ToString.Split("¨").Length - 1
                                    item = item.Replace("[List[" & vars.Keys(ii) & "]Item[" & b & "]]",
                                                    vars(vars.Keys(ii)).ToString.Split("¨")(b))
                                Next
                            End If
                        Next
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    funcvars.Add(item)
                Next
                findfunc(funcname, funcvars)
                funcname = ""
                funcvars.Clear()
                funcvrtemp = ""
                isreadingFUNCNAME = True
            End If
            If chara = "}" Then
                isreadingFUNC = False
                funcs.Add(funcname.Trim, readfunc)
                funcname = ""
                readfunc = False
                readfunc = ""
                isreadingFUNCNAME = True
            End If
            If isreadingFUNCVARS Then
                funcvrtemp += chara
            End If
            If chara = "(" And Not isreadingFUNC Then
                isreadingFUNCNAME = False
                isreadingFUNCVARS = True
                'Console.WriteLine("ReadFuncName finished.")
            End If
            If chara = "{" Then
                isreadingFUNCNAME = False
                isreadingFUNC = True
            End If
            If isreadingFUNCNAME Then
                If Not chara = vbCr And Not chara = vbLf And Not chara = ")" And Not chara = "}" Then
                    funcname += chara
                End If
            End If
            If isreadingFUNC Then
                If Not chara = vbCr And Not chara = vbLf And Not chara = "}" And Not chara = "{" Then
                    readfunc += chara
                End If
            End If
        Next
        If Not readstring Then
            Console.WriteLine("")
            Console.WriteLine("Script Finished.")
            Console.Title += " [Script Finished]"
        End If
    End Sub

    Private Sub findfunc(ByVal fnname As String, ByVal fnvars As ArrayList)
        If ififstamenttrue Then
            If fnname = "line.print" Then
                Dim tempfunc = Console.ForegroundColor
                If fnvars.Count > 1 Then
                    Console.ForegroundColor = fnvars(1)
                End If
                Console.Write(fnvars(0))
                Console.ForegroundColor = tempfunc
            ElseIf fnname = "line.printLine" Then
                Dim tempfunc = Console.ForegroundColor
                If fnvars.Count > 1 Then
                    Console.ForegroundColor = fnvars(1)
                End If
                Console.WriteLine(fnvars(0))
                Console.ForegroundColor = tempfunc
            ElseIf fnname = "line.clearAll" Then
                Console.Clear()
            ElseIf fnname = "title.set" Then
                Console.Title = fnvars(0)
            ElseIf fnname = "line.setColor" Then
                Console.ForegroundColor = New DataTable().Compute(fnvars(0), Nothing)
            ElseIf fnname = "line.clearLines" Then
                Console.Clear()
            ElseIf fnname = "filesys.files.write" Then
                My.Computer.FileSystem.WriteAllText(fnvars(0), fnvars(1), False)
            ElseIf fnname = "filesys.files.append" Then
                My.Computer.FileSystem.WriteAllText(fnvars(0), fnvars(1), True)
            ElseIf fnname = "filesys.files.delete" Then
                My.Computer.FileSystem.DeleteFile(fnvars(0))
            ElseIf fnname = "filesys.folders.create" Then
                My.Computer.FileSystem.CreateDirectory(fnvars(0))
            ElseIf fnname = "filesys.folders.delete" Then
                My.Computer.FileSystem.DeleteDirectory(fnvars(0), FileIO.DeleteDirectoryOption.DeleteAllContents)
            ElseIf fnname = "filesys.files.read" Then
                vars.Item(fnvars(0)) = My.Computer.FileSystem.ReadAllText(fnvars(1))
            ElseIf fnname = "filesys.files.list" Then
                Dim temp As String = ""
                ' = Console.ReadLine
                If fnvars(2) = "allSub" Then
                    For Each Filee As String In My.Computer.FileSystem.GetFiles(fnvars(1), FileIO.SearchOption.SearchAllSubDirectories)
                        temp += IIf(temp = "", "", "¨") + Filee
                    Next
                ElseIf fnvars(2) = "topLevel" Then
                    For Each Filee As String In My.Computer.FileSystem.GetFiles(fnvars(1), FileIO.SearchOption.SearchTopLevelOnly)
                        temp += IIf(temp = "", "", "¨") + Filee
                    Next
                End If
                vars.Item(fnvars(0)) = temp
            ElseIf fnname = "filesys.folders.list" Then
                Dim temp As String = ""
                ' = Console.ReadLine
                If fnvars(2) = "allSub" Then
                    For Each Filee As String In My.Computer.FileSystem.GetDirectories(fnvars(1), FileIO.SearchOption.SearchAllSubDirectories)
                        temp += IIf(temp = "", "", "¨") + Filee
                    Next
                ElseIf fnvars(2) = "topLevel" Then
                    For Each Filee As String In My.Computer.FileSystem.GetDirectories(fnvars(1), FileIO.SearchOption.SearchTopLevelOnly)
                        temp += IIf(temp = "", "", "¨") + Filee
                    Next
                End If
                vars.Item(fnvars(0)) = temp
            ElseIf fnname = "budgier.waitms" Then
                System.Threading.Thread.Sleep(New DataTable().Compute(fnvars(0), Nothing))
            ElseIf fnname = "visualler.windows.create" Then
                visuallerwins.Add("Window_" & fnvars(0), New Window)
                vswingrids.Add("Window_" & fnvars(0), New Grid)
                visuallerwins("Window_" & fnvars(0)).Content = vswingrids("Window_" & fnvars(0))
            ElseIf fnname = "visualler.windows.show" Then
                visuallerwins("Window_" & fnvars(0)).Show()
            ElseIf fnname = "visualler.windows.setTitle" Then
                visuallerwins("Window_" & fnvars(0)).Title = fnvars(1)
            ElseIf fnname = "visualler.windows.setIcon" Then
                Dim bmp As New BitmapImage()
                bmp.BeginInit()
                bmp.UriSource = New Uri(fnvars(1), UriKind.Relative)
                bmp.EndInit()
                visuallerwins("Window_" & fnvars(0)).Icon = bmp
            ElseIf fnname = "visualler.windows.size.setW" Then
                visuallerwins("Window_" & fnvars(0)).Width = New DataTable().Compute(fnvars(1), Nothing)
            ElseIf fnname = "visualler.windows.size.setH" Then
                visuallerwins("Window_" & fnvars(0)).Height = New DataTable().Compute(fnvars(1), Nothing)
            ElseIf fnname = "visualler.windows.size.addW" Then
                visuallerwins("Window_" & fnvars(0)).Width += fnvars(1)
            ElseIf fnname = "visualler.windows.size.addH" Then
                visuallerwins("Window_" & fnvars(0)).Height += fnvars(1)
            ElseIf fnname = "visualler.windows.setColor" Then
                visuallerwins("Window_" & fnvars(0)).Background = brushutils.ConvertFromString(fnvars(1))
            ElseIf fnname = "visualler.windows.position.setStart" Then
                visuallerwins("Window_" & fnvars(0)).WindowStartupLocation = fnvars(1)
            ElseIf fnname = "visualler.windows.position.setHorziontalAlign" Then
                vswingrids("Window_" & fnvars(0)).HorizontalAlignment = fnvars(1)
            ElseIf fnname = "visualler.windows.position.setVerticalAlign" Then
                vswingrids("Window_" & fnvars(0)).VerticalAlignment = fnvars(1)
            ElseIf fnname = "visualler.elements.create" Then
                If fnvars(1) = "label" Then
                    Dim lbl As New Label
                    visuallerlabels.Add(fnvars(0) & "_" & fnvars(2), lbl)
                    vswingrids("Window_" & fnvars(0)).Children.Add(lbl)
                    lbl.Content = "text label"
                    lbl.Foreground = Brushes.Black
                    lbl.FontSize = 12
                    lbl.Visibility = Visibility.Visible
                End If
                If fnvars(1) = "image" Then
                    Dim lbl As New Image
                    visuallerimages.Add(fnvars(0) & "_" & fnvars(2), lbl)
                    vswingrids("Window_" & fnvars(0)).Children.Add(lbl)
                    Dim bmp As New BitmapImage()
                    bmp.BeginInit()
                    bmp.UriSource = New Uri("/Budgier;component/imageicon.png", UriKind.Relative)
                    bmp.EndInit()
                    lbl.Source = bmp
                    lbl.Visibility = Visibility.Visible
                End If
                If fnvars(1) = "button" Then
                    Dim lbl As New Button
                    visuallerbuttons.Add(fnvars(0) & "_" & fnvars(2), lbl)
                    vswingrids("Window_" & fnvars(0)).Children.Add(lbl)
                    lbl.Visibility = Visibility.Visible
                    lbl.Content = "Click Me!"
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl As New TextBox
                    visuallertextboxes.Add(fnvars(0) & "_" & fnvars(2), lbl)
                    vswingrids("Window_" & fnvars(0)).Children.Add(lbl)
                    lbl.Visibility = Visibility.Visible
                End If
            ElseIf fnname = "visualler.elements.setContent" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.Content = fnvars(3)
                End If
                If fnvars(1) = "image" Then
                    Dim lbl = visuallerimages(fnvars(0) & "_" & fnvars(2))
                    Dim bmp As New BitmapImage()
                    bmp.BeginInit()
                    bmp.UriSource = New Uri(fnvars(3), UriKind.Relative)
                    bmp.EndInit()
                    lbl.Source = bmp
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.Content = fnvars(3)
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.Text = fnvars(3)
                End If
            ElseIf fnname = "visualler.elements.setColor" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.Foreground = brushutils.ConvertFromString(fnvars(3))
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.Foreground = brushutils.ConvertFromString(fnvars(3))
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.Foreground = brushutils.ConvertFromString(fnvars(3))
                End If
            ElseIf fnname = "visualler.elements.setBackcolor" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.Background = brushutils.ConvertFromString(fnvars(3))
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.Background = brushutils.ConvertFromString(fnvars(3))
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.Background = brushutils.ConvertFromString(fnvars(3))
                End If
            ElseIf fnname = "visualler.elements.setFontsize" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.FontSize = fnvars(3)
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.FontSize = fnvars(3)
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.FontSize = brushutils.ConvertFromString(fnvars(3))
                End If
            ElseIf fnname = "visualler.elements.setPosition" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.Margin = New Thickness(New DataTable().Compute(fnvars(3), Nothing),
                                               New DataTable().Compute(fnvars(4), Nothing),
                                               New DataTable().Compute(fnvars(5), Nothing),
                                               New DataTable().Compute(fnvars(6), Nothing))
                End If
                If fnvars(1) = "image" Then
                    Dim lbl = visuallerimages(fnvars(0) & "_" & fnvars(2))
                    lbl.Margin = New Thickness(New DataTable().Compute(fnvars(3), Nothing),
                                               New DataTable().Compute(fnvars(4), Nothing),
                                               New DataTable().Compute(fnvars(5), Nothing),
                                               New DataTable().Compute(fnvars(6), Nothing))
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.Margin = New Thickness(New DataTable().Compute(fnvars(3), Nothing),
                                               New DataTable().Compute(fnvars(4), Nothing),
                                               New DataTable().Compute(fnvars(5), Nothing),
                                               New DataTable().Compute(fnvars(6), Nothing))
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.Margin = New Thickness(New DataTable().Compute(fnvars(3), Nothing),
                                               New DataTable().Compute(fnvars(4), Nothing),
                                               New DataTable().Compute(fnvars(5), Nothing),
                                               New DataTable().Compute(fnvars(6), Nothing))
                End If
            ElseIf fnname = "visualler.elements.setSize" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.Width = New DataTable().Compute(fnvars(3), Nothing)
                    lbl.Height = New DataTable().Compute(fnvars(4), Nothing)
                End If
                If fnvars(1) = "image" Then
                    Dim lbl = visuallerimages(fnvars(0) & "_" & fnvars(2))
                    lbl.Width = New DataTable().Compute(fnvars(3), Nothing)
                    lbl.Height = New DataTable().Compute(fnvars(4), Nothing)
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.Width = New DataTable().Compute(fnvars(3), Nothing)
                    lbl.Height = New DataTable().Compute(fnvars(4), Nothing)
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.Width = New DataTable().Compute(fnvars(3), Nothing)
                    lbl.Height = New DataTable().Compute(fnvars(4), Nothing)
                End If
            ElseIf fnname = "visualler.elements.setOpacity" Then
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    lbl.Opacity = New DataTable().Compute(fnvars(3), Nothing)
                End If
                If fnvars(1) = "image" Then
                    Dim lbl = visuallerimages(fnvars(0) & "_" & fnvars(2))
                    lbl.Opacity = New DataTable().Compute(fnvars(3), Nothing)
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    lbl.Opacity = New DataTable().Compute(fnvars(3), Nothing)
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    lbl.Opacity = New DataTable().Compute(fnvars(3), Nothing)
                End If
            ElseIf fnname = "visualler.elements.setFunction.click" Then
                Dim a As New function_handler
                a.funcstring = funcs(fnvars(3))
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    AddHandler lbl.MouseUp, AddressOf a.runfunc
                End If
                If fnvars(1) = "image" Then
                    Dim lbl = visuallerimages(fnvars(0) & "_" & fnvars(2))
                    AddHandler lbl.MouseUp, AddressOf a.runfunc
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    AddHandler lbl.Click, AddressOf a.runfunc
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    AddHandler lbl.MouseUp, AddressOf a.runfunc
                End If
            ElseIf fnname = "visualler.elements.setFunction.keyDown" Then
                Dim a As New function_handler
                a.funcstring = funcs(fnvars(3))
                If fnvars(1) = "label" Then
                    Dim lbl = visuallerlabels(fnvars(0) & "_" & fnvars(2))
                    a.iskeypress = True
                    a.thekey = fnvars(4)
                    a.kyprslisten = lbl
                    lbl.Focusable = True
                End If
                If fnvars(1) = "image" Then
                    Dim lbl = visuallerimages(fnvars(0) & "_" & fnvars(2))
                    a.iskeypress = True
                    a.thekey = fnvars(4)
                    a.kyprslisten = lbl
                    lbl.Focusable = True
                End If
                If fnvars(1) = "button" Then
                    Dim lbl = visuallerbuttons(fnvars(0) & "_" & fnvars(2))
                    a.iskeypress = True
                    a.thekey = fnvars(4)
                    a.kyprslisten = lbl
                    lbl.Focusable = True
                End If
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    a.iskeypress = True
                    a.thekey = fnvars(4)
                    a.kyprslisten = lbl
                    lbl.Focusable = True
                End If
            ElseIf fnname = "visualler.elements.setFunction.textChanged" Then
                Dim a As New function_handler
                a.funcstring = funcs(fnvars(3))
                If fnvars(1) = "textbox" Then
                    Dim lbl = visuallertextboxes(fnvars(0) & "_" & fnvars(2))
                    a.istextchanged = True
                    a.txeventslisten = lbl
                End If
            ElseIf fnname = "clock.addTickFunction" Then
                Dim a As New function_handler
                a.istimer = True
                a.timerms = fnvars(0)
                a.funcstring = funcs(fnvars(1))
                a.inited()
            ElseIf fnname = "list.addItem" Then
                vars.Item(fnvars(0)) = vars.Item(fnvars(0)) & "¨" & fnvars(1)
            ElseIf fnname = "list.addInt" Then
                vars.Item(fnvars(0)) = vars.Item(fnvars(0)) & "¨" & New DataTable().Compute(fnvars(1),
                                                                                                 Nothing)
            ElseIf fnname = "list.RemoveID" Then
                Dim temp As String = ""
                Dim id As Integer = 0
                For Each item In vars(vars.Keys(fnvars(0))).ToString.Split("¨")
                    If Not item = vars(vars.Keys(fnvars(0))).ToString.Split("¨")(id) Then
                        If Not temp = "" Then
                            temp += "¨" & vars(vars.Keys(fnvars(0))).ToString.Split("¨")(id)
                        Else
                            temp = vars(vars.Keys(fnvars(0))).ToString.Split("¨")(fnvars(1))
                        End If
                    End If
                    id += 1
                Next
                vars(vars.Keys(fnvars(0))) = temp
            ElseIf fnname = "list.Remove" Then
                Dim temp As String = ""
                Dim id As Integer = 0
                For Each item In vars(vars.Keys(fnvars(0))).ToString.Split("¨")
                    If Not item = fnvars(1) Then
                        If Not temp = "" Then
                            temp += "¨" & vars(vars.Keys(fnvars(0))).ToString.Split("¨")(id)
                        Else
                            temp = vars(vars.Keys(fnvars(0))).ToString.Split("¨")(id)
                        End If
                    End If
                    id += 1
                Next
                vars(vars.Keys(fnvars(0))) = temp
            ElseIf fnname = "var.create" Then
                If fnvars.Count > 1 Then
                    vars.Add(fnvars(0), fnvars(1))
                Else
                    vars.Add(fnvars(0), "")
                End If
            ElseIf fnname = "var.set" Then
                vars.Item(fnvars(0)) = New DataTable().Compute(fnvars(1), Nothing)
            ElseIf fnname = "var.setString" Then
                vars.Item(fnvars(0)) = fnvars(1)
            ElseIf fnname = "var.addString" Then
                vars.Item(fnvars(0)) = vars.Item(fnvars(0)) & fnvars(1)
            ElseIf fnname = "repeat" Then
                For ddd As Integer = 1 To fnvars(0)
                    If funcs.ContainsKey(fnvars(1)) Then
                        run(funcs(fnvars(1)), True)
                    Else
                        Throw New Exception("Unknown function name for 'repeat' func name = " + fnname)
                    End If
                Next
            ElseIf fnname = "repeatForever" Then
                While True
                    If funcs.ContainsKey(fnvars(0)) Then
                        run(funcs(fnvars(0)), True)
                    Else
                        Throw New Exception("Unknown function name for 'repeat' func name = " + fnname)
                    End If
                End While
            ElseIf fnname = "runString" Then
                run(fnvars(0), True)
            ElseIf fnname = "line.rdLine" Then
                vars.Item(fnvars(0)) = Console.ReadLine
            ElseIf fnname = "line.rdKey" Then
                    vars.Item(fnvars(0)) = Console.ReadKey
            ElseIf fnname = "IF" Then
                    ififstamenttrue = fnvars(0) = fnvars(1)
            ElseIf fnname = "IntIF" Then
                    ififstamenttrue = New DataTable().Compute(
                        fnvars(0), Nothing) = New DataTable().Compute(fnvars(1), Nothing)
            Else
                    If funcs.ContainsKey(fnname) Then 'Check for custom functions
                        run(funcs(fnname), True)
                    ElseIf fnname = "endIF" Then
                    Else
                        Throw New Exception("Unknown function name func name = " + fnname)
                    End If
            End If
        Else
            If fnname = "endIF" Then
                ififstamenttrue = True
            End If
        End If
    End Sub
End Module
