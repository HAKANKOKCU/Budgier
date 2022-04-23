Class MainWindow 

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Me.Hide()
        Try
            If Not Command() = "" Then
                Environment.CurrentDirectory = Command().Replace("""", "").Replace(Command.Replace("""", "").Split("\").Last, "")
                run(Command().Replace("""", ""))
            Else
                Console.Write("Path to run (cmd to command line): ")
                Dim pth As String = Console.ReadLine.Replace("""", "")
                If Not pth = "cmd" Then
                    'MsgBox("""" + pth.Replace(pth.Split("\").Last, "") + """")
                    Environment.CurrentDirectory = pth.Replace(pth.Split("\").Last, "")
                    Console.Clear()
                    run(pth)
                Else
                    While True
                        Try
                            Console.WriteLine("")
                            Console.ForegroundColor = ConsoleColor.Yellow
                            Console.Write("Budgier > ")
                            Console.ForegroundColor = ConsoleColor.White
                            Dim line = Console.ReadLine
                            Console.ForegroundColor = ConsoleColor.Gray
                            run(line, True)
                        Catch ex As Exception
                            Console.WriteLine(ex.Message)
                        End Try
                    End While
                End If
                End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Me.Close()
        End Try
    End Sub
End Class
