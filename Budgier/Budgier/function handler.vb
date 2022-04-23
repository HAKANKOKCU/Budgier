Imports System.Windows.Threading

Public Class function_handler
    Property funcstring As String
    Property iskeypress As Boolean = False
    Property istextchanged As Boolean = False
    Property istimer As Boolean = False
    Property timerms As Integer = 1000
    Property thekey As String = ""
    Public WithEvents kyprslisten As UIElement
    Public WithEvents txeventslisten As TextBox
    Public WithEvents timer As DispatcherTimer
    Sub inited()
        If istimer Then
            timer = New DispatcherTimer
            timer.Interval = TimeSpan.FromMilliseconds(timerms)
            timer.Start()
        End If
    End Sub
    Sub runfunc()
        run(funcstring, True)
    End Sub
    Private Sub kyprslistened(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles kyprslisten.KeyDown
        If iskeypress Then
            If thekey = "" Then run(funcstring.Replace("[PressedKey]", e.Key.ToString), True)
            If thekey = e.Key.ToString Then
                run(funcstring.Replace("[PressedKey]", e.Key.ToString), True)
            End If
        End If
    End Sub

    Private Sub timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer.Tick
        runfunc()
    End Sub

    Private Sub txeventslisten_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles txeventslisten.TextChanged
        If istextchanged Then

        End If
    End Sub
End Class
