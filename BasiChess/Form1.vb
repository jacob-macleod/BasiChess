Public Class Form1
    Public gameGrid As String()() = {
    ({"♜", "♞", "♝", "♛", "♚", "♝", "♞", "♜"}),
    ({"♟", "♟", "♟", "♟", "♟", "♟", "♟", "♟"}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({" ", " ", " ", " ", " ", " ", " ", " ", " "}),
    ({"♙", "♙", "♙", "♙", "♙", "♙", "♙", "♙"}),
    ({"♖", "♘", "♗", "♕", "♔", "♗", "♘", "♖"})}

    Dim btncollection As New Microsoft.VisualBasic.Collection()

    '  Coordinates must be in x,y format
    Public Function CheckIfMoveIsValid(Piece As String, Coordinates As Integer())
        Dim CoordinatesToReturn As Integer()()

        ' Pawns can move one space ahead diagonly
        If Piece Is "♙" Then
            ' X, y Format - Return coordinates where the preice can be moved to
            CoordinatesToReturn = {({Coordinates(0) - 1, Coordinates(1) + 1}), ({Coordinates(0) + 1, Coordinates(1) + 1})}
            Return CoordinatesToReturn
        Else
            CoordinatesToReturn = {({0, 0}), ({0, 0})}
            Return CoordinatesToReturn
        End If
    End Function

    ' Converts a button name such as Button24 to a set of coordinates which it returns
    Public Function ConvertButtonToCoordinates(ButtonName As String)
        Dim Str_ButtonNumber As String
        Dim Int_ButtonNumber As Integer
        Dim NearestMultiple As Integer
        Dim XCoord As Integer
        Dim YCoord As Integer

        ' Get the number of the button in ButtonName which wil be in the format ("Button", Number) conjoined as a String
        Str_ButtonNumber = ButtonName.Split("n"c)(1)
        Int_ButtonNumber = CStr(Str_ButtonNumber)

        ' Find the nearest multiple of 8 to Int_ButtonNumber which is higher than Int_ButtonNumber
        For i As Integer = 0 To 7
            If ((Int_ButtonNumber + i) Mod 8) = 0 Then
                ' This line is garunteed to be reached eventually
                NearestMultiple = Int_ButtonNumber + 1
                ' This will be a whole number
                NearestMultiple = NearestMultiple / 8
            End If
        Next

        ' Find the x Coordinate
        XCoord = NearestMultiple * 8
        XCoord = XCoord - Int_ButtonNumber
        XCoord = 8 - XCoord

        ' Find the y Coordinate
        YCoord = Int_ButtonNumber - XCoord
        YCoord = YCoord / 8
        YCoord = YCoord + 1

        ' Return the coordinates as an array
        Dim CoordsToReturn = New Integer(1) {XCoord, YCoord}
        Return CoordsToReturn
    End Function

    ' Apply the values in gamegrid to all the buttons, changing their icon
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer
        x = 0
        y = 0

        For Each ctl In Me.Controls
            If TypeOf ctl Is Button Then
                If x > 7 Then
                    x = 0
                    y = y + 1
                End If
                ctl.Font = New Font("Microsoft Sans Serif", 56, FontStyle.Regular)
                ctl.Text = gameGrid(y)(x)
                x = x + 1
            End If
        Next
    End Sub

    Dim WasButtonClicked = False
    Dim valueOfButtonClicked = ""
    Dim buttonClicked As Button

    ' Moving of pieces in chess
    ' Runs whenever a button is clicked. When two buttons are clicked one takes the other
    Public Sub ButtonOnClickEvent(sender)
        Dim Coords As Integer()
        Dim CoordsReturned As Integer()()
        ' Dummy data so far - I next need to make it 
        Coords = {7, 5}

        ' Returns coordinates showing where a piece can be moved
        CoordsReturned = CheckIfMoveIsValid(sender.Text, ConvertButtonToCoordinates(sender.Name))
        For x As Integer = 0 To 1
            ' I now know where a specific piece can move
            Dim ButtonWherePieceCanBeMoved As String
            ButtonWherePieceCanBeMoved = "Button"
            ' I need to turn the coords given by CheckIfMoveIsValid() (say 6, 4) into a number corrosponding to the button name from 1 to 64 so i can select Button + number
            ' as in Button1. This is done mathematically, as in
            ButtonWherePieceCanBeMoved = ButtonWherePieceCanBeMoved + (((((CoordsReturned(x)(1) - 1) * 8) + CoordsReturned(x)(0)).ToString())).ToString()
            For Each ctl In Me.Controls
                ' When know where the piece can be moved to
                If CType(ctl.Name, String).ToString().Contains(ButtonWherePieceCanBeMoved) Then
                    ctl.BackColor = Color.Red
                End If
            Next
        Next

        If WasButtonClicked = True Then
            ' To take another piece
            If buttonClicked.Text IsNot Nothing Then
                If sender.BackColor = Color.Red Then
                    buttonClicked.Text = Nothing
                    sender.Text = valueOfButtonClicked
                    WasButtonClicked = False
                    ' Make the background color of all buttons white
                    For Each ctl In Me.Controls
                        ctl.BackColor = Color.White
                    Next
                End If
                'To move a piece from one place to another
            Else
                If sender.BackColor = Color.Red Then
                    buttonClicked.Text = sender.Text
                    sender.Text = valueOfButtonClicked
                    WasButtonClicked = False
                    ' Make the background color of all buttons white
                    For Each ctl In Me.Controls
                        ctl.BackColor = Color.White
                    Next
                End If
            End If
        Else
            valueOfButtonClicked = sender.Text
            buttonClicked = sender
            WasButtonClicked = True
            buttonClicked.BackColor = Color.Red
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click, Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click, Button57.Click, Button58.Click, Button59.Click, Button60.Click, Button61.Click, Button62.Click, Button63.Click, Button64.Click
        ButtonOnClickEvent(sender)
    End Sub
End Class
