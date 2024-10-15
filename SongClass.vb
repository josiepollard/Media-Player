Option Explicit On

Public Class SongClass
    Public Overrides Function ToString() As String

        Return String.Format("{0} - {1}", songTitle, songAlbum) 'Used to Add song title and song artist to listbox
    End Function

    Public Property songTitle As String
    Public Property songArtist As String
    Public Property songGenre As String
    Public Property songYear As String
    Public Property songAlbum As String
    Public Property filename As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal strFilename As String, ByVal strSongTitle As String, ByVal strSongArtist As String, ByVal strSongAlbumn As String, ByVal strSongYear As String, ByVal strSongGenre As String)

        filename = strFilename
        songTitle = strSongTitle
        songArtist = strSongArtist
        songAlbum = strSongAlbumn
        songYear = strSongYear
        songGenre = strSongGenre
    End Sub
End Class
