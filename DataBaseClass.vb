Option Explicit On
Imports ADOX
Public Class DataBaseClass

    Private Const Provider = "Microsoft.Jet.OLEDB.4.0"
    Public Const Tablename As String = "SongTable"
    Public Const createString As String = "Provider=" & Provider & ";Data Source=" & filename & ";"
    Public Const filename As String = "Musicplayer.mdb"

    '******************* CREATE DATABASE *******************
    'creates database in access
    Public Shared Function CreateAccessDB(ByVal DbPath As String)

        Dim Bool As Boolean = True
        Dim Cat As New ADOX.Catalog()
        Dim TableDB As ADOX.Table

        Try
            Cat.Create(createString) 'Creates access database with the name Musicplayer.mdb
            TableDB = New ADOX.Table
            TableDB.Name = Tablename
            Cat.Tables.Append(TableDB)

            'Columns that are to be shown in the database table
            TableDB.Columns.Append("Path", DataTypeEnum.adVarWChar, 250)
            TableDB.Columns.Append("SongTitle", DataTypeEnum.adVarWChar, 250)
            TableDB.Columns.Append("Artist", DataTypeEnum.adVarWChar, 250)
            TableDB.Columns.Append("Album", DataTypeEnum.adVarWChar, 250)
            TableDB.Columns.Append("Year", DataTypeEnum.adVarWChar, 250)
            TableDB.Columns.Append("Genre", DataTypeEnum.adVarWChar, 250)

            TableDB = Nothing

        Catch Excep As Exception
            Bool = False
        Finally
            Cat = Nothing
        End Try
        Return Bool
    End Function

    '******************* CONNECT TO DATABASE *******************
    Public Shared Function connectDB(filename As String) As ADODB.Connection

        Dim con As New ADODB.Connection

        Try
            con.Open(createString) 'opens database

        Catch ex As Exception
            con = Nothing

        End Try
        Return con
    End Function

    '******************* DELETE DATA FROM DATABASE *******************
    'Used to both delete all songs or delete one song
    Public Shared Function DeleteDB(ByRef connection As ADODB.Connection, isWholeTable As Boolean, Optional Path As String = Nothing)

        Dim Cmd As ADODB.Command
        Dim SqlQuery As String = "DELETE FROM " & Tablename 'the SQL Query used for both delete all and delete selected
        Dim rs As New ADODB.Recordset

        Cmd = New ADODB.Command

        If (isWholeTable = False) And (Path IsNot Nothing) Then 'If not deleting all songs AND it has at least one song in list
            SqlQuery += " WHERE Path = " & Chr(34) & Path & Chr(34) 'Deletes the selected file, chr(34) represents a double quote
        End If

        connection.BeginTrans() 'Begins a new transaction
        Cmd.ActiveConnection = connection
        Cmd.CommandType = ADODB.CommandTypeEnum.adCmdText
        Cmd.CommandText = SqlQuery
        Cmd.Execute()
        connection.CommitTrans() 'saves changes and ends transaction. Refreshes database.
    End Function

    '******************* READ DATA FROM DATABASE *******************
    'When application is opened again the exising data in the database will populate the player.
    Public Shared Function readfromdb(connection As ADODB.Connection) As List(Of SongClass)
        Dim SqlQuery As String = "SELECT * FROM " & Tablename 'Selects all items in the database
        Dim rs As New ADODB.Recordset
        Dim Songs As New List(Of SongClass)

        With rs
            .Open(SqlQuery, connection, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

            Do Until .EOF 'Do until no more data can be read
                Dim Song As New SongClass()

                Song.filename = .Fields()!path.Value
                Song.songTitle = .Fields()!SongTitle.Value
                Song.songArtist = .Fields()!Artist.Value
                Song.songAlbum = .Fields()!Album.Value
                Song.songYear = .Fields()!Year.Value
                Song.songGenre = .Fields()!Genre.Value

                Songs.Add(Song)

                .MoveNext() 'goes to the next record
            Loop
        End With

        Return Songs
    End Function

    ''FILTER DATABASE BY SEARCH 
    'Public Shared Function FilterList(connection As ADODB.Connection, SongTitle As String) As List(Of SongClass)
    '    Dim SqlQuery As String = "SELECT * FROM " & Tablename & "WHERE SongTitle = " & SongTitle 'Selects all items in the database
    '    Dim rs As New ADODB.Recordset
    '    Dim Songs As New List(Of SongClass)
    '    Dim Cmd As ADODB.Command
    '    Cmd = New ADODB.Command
    '    With rs
    '        .Open(SqlQuery, connection, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

    '        Do Until .EOF 'Do until no more data can be read
    '            Dim Song As New SongClass()

    '            Song.filename = .Fields()!path.Value
    '            Song.songTitle = .Fields()!SongTitle.Value
    '            Song.songArtist = .Fields()!Artist.Value
    '            Song.songAlbum = .Fields()!Album.Value
    '            Song.songYear = .Fields()!Year.Value
    '            Song.songGenre = .Fields()!Genre.Value

    '            Songs.Add(Song)

    '            .MoveNext() 'goes to the next record
    '        Loop
    '    End With
    '    Return Songs
    'End Function
End Class
