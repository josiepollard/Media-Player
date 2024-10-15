Imports AxWMPLib
Imports WMPLib
Imports ADODB

Public Class Form1

    Dim item As Integer
    Dim connection As ADODB.Connection = Nothing
    Dim ListFilepaths As New List(Of String) 'holds filepaths

    '******************* LOAD IN CHOSEN SONGS TO PLAYER *******************
    'Media selected using a file explorer which is then populated in the list box where it can be played
    Private Sub LoadSongsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSongsToolStripMenuItem.Click

        Dim OFD As New OpenFileDialog 'File explorer window
        Dim Songs As New List(Of SongClass)

        OFD.Multiselect = True 'Multiple files can be selected at once in file explorer
        OFD.ShowDialog() 'File explorer window opens when load songs button is clicked

        If (OFD.FileNames.Count > 0) Then 'If at least 1 file has been selected

            For I As Integer = 0 To (OFD.FileNames.Count - 1) 'Minus 1 as listbox numbering starts at 0 but file dialog counting starts at 1
                GetData(OFD.FileNames(I), Songs) 'File metadata
                ListFilepaths.Add(OFD.FileNames(I)) 'Gets filepath for each song
            Next

            addToDB(Songs) 'Adds song info to database
            ListBoxAdd(Songs) 'Populates listbox

            ListBox1.SelectedIndex = 0 'Sets the selected song as the first in the list

        Else
            MsgBox("No files have been selected", MsgBoxStyle.Critical, "Error") 'Error message if no files selected in OFD
        End If
    End Sub

    '******************* ADD TO LISTBOX *******************
    'Adds the songs to the listbox
    Private Sub ListBoxAdd(tSongs As List(Of SongClass))

        For Each Item As SongClass In tSongs
            ListBox1.Items.Add(Item) 'Adds each song to listbox, uses ToString function in Song.vb to show the title and artist for each file
        Next
    End Sub

    '******************* GETS FILE METADATA *******************
    'Retrieves information about the file
    Private Sub GetData(filename As String, ByRef Songs As List(Of SongClass))

        Dim trackFile As TagLib.File = TagLib.File.Create(filename) 'TagLib is a library for reading and editing the meta-data of several popular audio formats

        Songs.Add(New SongClass(filename, trackFile.Tag.Title, trackFile.Tag.FirstPerformer, trackFile.Tag.Album, trackFile.Tag.Year, trackFile.Tag.FirstGenre)) 'Uses the song class properties, Taglib used to pull out certain information
    End Sub

    '******************* PLAYS SELECTED SONG BY CLICK *******************
    'When song is clicked in the list box it will start playing
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim CurrentSong As SongClass = ListBox1.SelectedItem

        If CurrentSong IsNot Nothing Then 'CurrentSong needs to have a value
            AxWindowsMediaPlayer1.URL = CurrentSong.filename 'Path of the song is set as the current item
            timer_progressUpdate.Interval = 100 'Interval is the time that elapses between ticks, it is set to 100 milliseconds (1 second per tick)
            timer_progressUpdate.Start() 'Timer starts to tick
        End If
    End Sub

    '******************* PAUSE BUTTON *******************
    'Song is paused using the pause button
    Private Sub PauseBtn_Click(sender As Object, e As EventArgs) Handles PauseBtn.Click

        If (ListBox1.Items.Count = 0 = True) Then 'Checks if listbox has any files loaded into it
            MsgBox("Nothing available to pause, please load in your chosen files", MsgBoxStyle.Critical, "Error") 'Error message if no songs in listbox

        Else
            AxWindowsMediaPlayer1.Ctlcontrols.pause() 'Uses windows media player pause functionality
        End If
    End Sub

    '******************* STOP BUTTON *******************
    'Song is stopped using the stop button
    Private Sub StopBtn_Click(sender As Object, e As EventArgs) Handles StopBtn.Click

        If (ListBox1.Items.Count = 0 = True) Then 'Checks if listbox has any files loaded into it
            MsgBox("Nothing available to stop, please load in your chosen files", MsgBoxStyle.Critical, "Error") 'Error message if no songs in listbox

        Else
            AxWindowsMediaPlayer1.Ctlcontrols.stop() 'Uses windows media player stop functionality
            Label1.Text = "00:00" 'Sets the trackbar value to zero
        End If
    End Sub

    '******************* PLAY BUTTON *******************
    'Song is played using the play button
    Private Sub PlayBtn_Click(sender As Object, e As EventArgs) Handles PlayBtn.Click

        If (ListBox1.Items.Count = 0 = True) Then 'Checks if listbox has any files loaded into it
            MsgBox("Nothing available to play, please load in your chosen files", MsgBoxStyle.Critical, "Error") 'Error message if no songs in listbox

        Else
            AxWindowsMediaPlayer1.Ctlcontrols.play() 'Uses windows media player play functionality
            timer_progressUpdate.Interval = 100
            timer_progressUpdate.Start()
        End If
    End Sub

    '******************* PREVIOUS SONG BUTTON *******************
    'Plays the previous song in the list using the previous button
    Private Sub PrevSongBtn_Click(sender As Object, e As EventArgs) Handles PrevSongBtn.Click

        Dim CurrentSong As SongClass = ListBox1.SelectedItem

        If (ShuffleCheck.Checked = True) Then
            MsgBox("Cannot play the previous song when shuffling", MsgBoxStyle.Critical, "Error") 'error message if shuffle button is checked

        ElseIf (ListBox1.SelectedIndex > 0) Then 'If it is not the first song in the list
            Me.ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1 'Replaces the selected index to be the current one minus 1 (aka previous item)
            AxWindowsMediaPlayer1.URL = CurrentSong.filename 'Sets the URL to be the new item
            AxWindowsMediaPlayer1.Ctlcontrols.previous() 'Uses the windows media player previous function

        Else
            MsgBox("There are no previous entires in the playlist", MsgBoxStyle.Critical, "Error") 'Error message if no songs in listbox
        End If
    End Sub

    '******************* NEXT SONG BUTTON *******************
    'Plays the next song in the list using the next button
    Private Sub NextSongBtn_Click(sender As Object, e As EventArgs) Handles NextSongBtn.Click

        item = ListBox1.SelectedIndex

        If (ListBox1.Items.Count >= 1) Then
            SongChange() 'Uses songChange funtion to select next item
            AxWindowsMediaPlayer1.Ctlcontrols.next() 'Uses the windows media player next function

        Else
            MsgBox("There are no songs available to play.", MsgBoxStyle.Critical, "Error") 'Error message if there are no items in the list
        End If
    End Sub

    '******************* MEDIA ENDED PLAY STATE *******************
    'When media has ended this is called   
    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange

        If (AxWindowsMediaPlayer1.playState = WMPPlayState.wmppsMediaEnded) Then
            SongChange() ' calls the songChange method
        End If
    End Sub

    '******************* SONG CHANGE *******************
    'When the next song is due to play:
    Private Sub SongChange()

        item = ListBox1.SelectedIndex
        Dim CurrentSong As SongClass = ListBox1.SelectedItem

        '******************* SHUFFLES SONGS *******************
        'Randomises the order in which the songs will play when the shuffled checkbox is checked
        If (ShuffleCheck.Checked = True) Then 'If the shuffle checkbox is checked
            Dim rnd = New Random() 'produces a random number
            Dim randomIndex As Integer = rnd.Next(0, ListBox1.Items.Count - 1) 'Selects a index within the list count
            Me.ListBox1.SelectedIndex = randomIndex  'Play a song with the random index
            CurrentSong = ListBox1.SelectedItem

            '******************* PLAYS THE NEXT SONG AUTOMATICALLY *******************
        ElseIf (item < ListBox1.Items.Count - 1) Then 'If not the last song in the list
            item += +1 'Adds 1 to the item index
            Me.ListBox1.SelectedIndex = item  'Play the next song in the list
            CurrentSong = ListBox1.SelectedItem

            '******************* GOES BACK TO FIRST SONG AND PLAYS AUTOMATICALLY *******************
            'If at the last song in the list, it will go back to the first song in the list if left to play automatically in order
        Else
            item = 0 'Sets the index to the first song
            Me.ListBox1.SelectedIndex = item
            CurrentSong = ListBox1.SelectedItem
        End If

        AxWindowsMediaPlayer1.URL = CurrentSong.filename
    End Sub

    '******************* DELETES SELECTED SONG FROM PLAYLIST *******************
    'Deletes the item that has been individually selected for deletion
    Private Sub DeleteSelectedSongToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedSongToolStripMenuItem.Click

        If (ListBox1.Items.Count = 0) Then 'If there are no items in the list box
            MsgBox("There are no songs available for deletion", MsgBoxStyle.Critical, "Error") 'Error message

        Else
            Dim Result As DialogResult = MessageBox.Show("Would you like to delete the song from the playlist?", "MediaPlayer", MessageBoxButtons.YesNo) 'YES / NO confirmation dialog box

            If (Result = DialogResult.Yes) Then 'if user seletcts yes
                For Each song As SongClass In ListBox1.SelectedItems
                    AxWindowsMediaPlayer1.Ctlcontrols.stop() 'Stops the song from continuing to play
                    DataBaseClass.DeleteDB(connection, False, song.filename) 'Class1 delete function used, since (isWholeTable = False) the WHERE clause is called to remove selected song
                Next

                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex) 'Removes selected index item from the listbox

                If (ListBox1.Items.Count > 0) Then 'If there are still songs left in the list, set the selected song as the first one
                    ListBox1.SelectedIndex = 0
                End If

            Else 'If user selects no
                MsgBox("Nothing has been deleted") 'Message box telling the user that nothing has been deleted
            End If
        End If
    End Sub

    '******************* DELETES ALL FROM PLAYLIST *******************
    'Deletes every item from the listbox
    Private Sub DeleteAllSongsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllSongsToolStripMenuItem.Click

        If (ListBox1.Items.Count = 0) Then 'If there are no items in the list box
            MsgBox("There are no songs available for deletion", MsgBoxStyle.Critical, "Error") ' Error message

        Else
            Dim Result As DialogResult = MessageBox.Show("Would you like to delete all of the songs from the playlist?", "MediaPlayer", MessageBoxButtons.YesNo) 'YES / NO confirmation dialog box

            If (Result = DialogResult.Yes) Then 'If user seletcts yes
                AxWindowsMediaPlayer1.Ctlcontrols.stop() 'Stops the song from continuing to play
                DataBaseClass.DeleteDB(connection, True) 'Class1 delete function used, since (isWholeTable = True), everything in the table is removed
                ListBox1.Items.Clear() 'Removes everything from the list box

            Else
                MsgBox("Nothing has been deleted") 'Message box telling the user that nothing has been deleted
            End If
        End If
    End Sub

    '******************* PROGRESS TRACKBAR *******************
    'Shows the progress of the song that is currently playing, as well as its full duration.
    'TRACKBAR SCROLL
    Private Sub TrackBarprogress_Scroll(sender As Object, e As EventArgs) Handles TrackBarprogress.Scroll

        TrackBarprogress.Maximum = AxWindowsMediaPlayer1.Ctlcontrols.currentItem.duration 'Max value is the whole duration of the song
        TrackBarprogress.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
        Label1.Text = AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString 'Text box showing current time stamp
        Label2.Text = AxWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString 'Text box showing full song duration
    End Sub
    'TRACKBAR MOUSE DOWN EVENT
    Private Sub TrackBarprogress_MouseDown(sender As Object, e As MouseEventArgs) Handles TrackBarprogress.MouseDown

        Timer1.Stop() 'Pauses the timer
        timer_progressUpdate.Stop()
    End Sub
    'TRACKBAR MOUSE UP EVENT
    Private Sub TrackBarprogress_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBarprogress.MouseUp
        AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = TrackBarprogress.Value 'The track bar position alters the position in the song
        Timer1.Start() 'Starts time
    End Sub

    '******************* TIMERS *******************
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AxWindowsMediaPlayer1.Ctlcontrols.play()
        Timer1.Enabled = False
    End Sub

    Private WithEvents timer_progressUpdate As New Timer()

    Private Sub timer_progressUpdate_Tick(sender As Object, e As EventArgs) Handles timer_progressUpdate.Tick

        TrackBarprogress_Scroll(Nothing, Nothing)
    End Sub

    Private Sub Timer_loop_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_loop.Tick

        AxWindowsMediaPlayer1.Ctlcontrols.play()
        Timer2.Enabled = False
    End Sub

    '******************* CREATE DATABASE *******************
    'Creates a database when the form is loaded
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        If System.IO.File.Exists(DataBaseClass.filename) = False Then 'If database does not already exist 
            DataBaseClass.CreateAccessDB(DataBaseClass.filename) 'Creates database in MS Access
        End If

        connection = DataBaseClass.connectDB(DataBaseClass.filename) 'creates connection to database
        Dim tSongs As List(Of SongClass) = DataBaseClass.readfromdb(connection)

        If (tSongs.Count > 0) Then
            ListBoxAdd(tSongs) 'loads in any exisiting songs in database
        End If
    End Sub

    '******************* ADD TO DATABASE *******************
    'Adds new songs to the database
    Public Function addToDB(Songs As List(Of SongClass))

        Dim rs As ADODB.Recordset

        Try
            rs = New ADODB.Recordset

            With rs
                .Open(DataBaseClass.Tablename, connection, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockPessimistic, CommandTypeEnum.adCmdTable)

                For Each item As SongClass In Songs 'For each song file

                    .AddNew() 'Adds a new row

                    'Populates each field with song properties
                    .Fields()!Path.Value = item.filename
                    .Fields()!SongTitle.Value = item.songTitle
                    .Fields()!Artist.Value = item.songArtist
                    .Fields()!Album.Value = item.songAlbum
                    .Fields()!Year.Value = item.songYear
                    .Fields()!Genre.Value = item.songGenre
                    .Update()
                Next

                .Close()
            End With

        Catch ex As Exception
        End Try
        rs = Nothing
    End Function

    '*******************SEARCH FUNCTION******************* 
    'Searches through the listbox (works but have To input whole song into textbox)
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        For x As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(x).ToString = TextBox1.Text$ Then
                ListBox1.SelectedIndex = x
                Return
            End If
        Next
    End Sub
End Class
