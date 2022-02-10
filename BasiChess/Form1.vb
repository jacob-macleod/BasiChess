Public Class Form1
    Dim gameGrid As String()() = {
    ({"♜", "♞", "♝", "♛", "♚", "♝", "♞", "♜"}),
    ({"♟", "♟", "♟", "♟", "♟", "♟", "♟", "♟"}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({"♙", "♙", "♙", "♙", "♙", "♙", "♙", "♙"}),
    ({"♖", "♘", "♗", "♕", "♔", "♗", "♘", "♖"})}


    Public Sub ChangeText(button As Button)
        button.Text = "Hello"
    End Sub

    ' Apply the values in gamegrid to all the buttons, changing their icon
    Public Sub ChangeAllButtonText()

    End Sub

    Dim WasButtonClicked = False
    Dim valueOfButtonClicked = ""
    Dim buttonClicked As Button

    ' Moving of pieces in chess
    ' Runs whenever a button is clicked. When two buttons are clicked it swaps them around
    ' TODO: Make it so they only swap around if the rules of chess allow them to
    Public Sub ButtonOnClickEvent(sender)
        If WasButtonClicked = True Then
            buttonClicked.Text = sender.Text
            sender.Text = valueOfButtonClicked
            WasButtonClicked = False
        Else
            valueOfButtonClicked = sender.Text
            buttonClicked = sender
            WasButtonClicked = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click, Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click, Button57.Click, Button58.Click, Button59.Click, Button60.Click, Button61.Click, Button62.Click, Button63.Click, Button64.Click
        ButtonOnClickEvent(sender)
    End Sub
End Class
