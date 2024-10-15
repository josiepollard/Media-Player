<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LoadSongsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSongsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSelectedSongToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllSongsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PrevSongBtn = New System.Windows.Forms.Button()
        Me.PlayBtn = New System.Windows.Forms.Button()
        Me.PauseBtn = New System.Windows.Forms.Button()
        Me.StopBtn = New System.Windows.Forms.Button()
        Me.NextSongBtn = New System.Windows.Forms.Button()
        Me.ShuffleCheck = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TrackBarprogress = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer_loop = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarprogress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Highlight
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadSongsToolStripMenuItem, Me.DeleteSongsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(775, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LoadSongsToolStripMenuItem
        '
        Me.LoadSongsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LoadSongsToolStripMenuItem.Name = "LoadSongsToolStripMenuItem"
        Me.LoadSongsToolStripMenuItem.Size = New System.Drawing.Size(100, 24)
        Me.LoadSongsToolStripMenuItem.Text = "Load Songs"
        '
        'DeleteSongsToolStripMenuItem
        '
        Me.DeleteSongsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteSelectedSongToolStripMenuItem, Me.DeleteAllSongsToolStripMenuItem})
        Me.DeleteSongsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.DeleteSongsToolStripMenuItem.Name = "DeleteSongsToolStripMenuItem"
        Me.DeleteSongsToolStripMenuItem.Size = New System.Drawing.Size(111, 24)
        Me.DeleteSongsToolStripMenuItem.Text = "Delete Songs"
        '
        'DeleteSelectedSongToolStripMenuItem
        '
        Me.DeleteSelectedSongToolStripMenuItem.Name = "DeleteSelectedSongToolStripMenuItem"
        Me.DeleteSelectedSongToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.DeleteSelectedSongToolStripMenuItem.Text = "Delete Selected Song"
        '
        'DeleteAllSongsToolStripMenuItem
        '
        Me.DeleteAllSongsToolStripMenuItem.Name = "DeleteAllSongsToolStripMenuItem"
        Me.DeleteAllSongsToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.DeleteAllSongsToolStripMenuItem.Text = "Delete All Songs"
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(12, 45)
        Me.AxWindowsMediaPlayer1.MaximumSize = New System.Drawing.Size(315, 228)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(315, 228)
        Me.AxWindowsMediaPlayer1.TabIndex = 2
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(336, 45)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(424, 228)
        Me.ListBox1.TabIndex = 3
        '
        'PrevSongBtn
        '
        Me.PrevSongBtn.BackgroundImage = CType(resources.GetObject("PrevSongBtn.BackgroundImage"), System.Drawing.Image)
        Me.PrevSongBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PrevSongBtn.Location = New System.Drawing.Point(12, 296)
        Me.PrevSongBtn.Name = "PrevSongBtn"
        Me.PrevSongBtn.Size = New System.Drawing.Size(128, 48)
        Me.PrevSongBtn.TabIndex = 4
        Me.PrevSongBtn.UseVisualStyleBackColor = True
        '
        'PlayBtn
        '
        Me.PlayBtn.BackgroundImage = CType(resources.GetObject("PlayBtn.BackgroundImage"), System.Drawing.Image)
        Me.PlayBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PlayBtn.Location = New System.Drawing.Point(146, 296)
        Me.PlayBtn.Name = "PlayBtn"
        Me.PlayBtn.Size = New System.Drawing.Size(128, 48)
        Me.PlayBtn.TabIndex = 5
        Me.PlayBtn.UseVisualStyleBackColor = True
        '
        'PauseBtn
        '
        Me.PauseBtn.BackgroundImage = CType(resources.GetObject("PauseBtn.BackgroundImage"), System.Drawing.Image)
        Me.PauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PauseBtn.Location = New System.Drawing.Point(280, 296)
        Me.PauseBtn.Name = "PauseBtn"
        Me.PauseBtn.Size = New System.Drawing.Size(128, 48)
        Me.PauseBtn.TabIndex = 6
        Me.PauseBtn.UseVisualStyleBackColor = True
        '
        'StopBtn
        '
        Me.StopBtn.BackgroundImage = CType(resources.GetObject("StopBtn.BackgroundImage"), System.Drawing.Image)
        Me.StopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.StopBtn.Location = New System.Drawing.Point(414, 296)
        Me.StopBtn.Name = "StopBtn"
        Me.StopBtn.Size = New System.Drawing.Size(128, 48)
        Me.StopBtn.TabIndex = 7
        Me.StopBtn.UseVisualStyleBackColor = True
        '
        'NextSongBtn
        '
        Me.NextSongBtn.BackgroundImage = CType(resources.GetObject("NextSongBtn.BackgroundImage"), System.Drawing.Image)
        Me.NextSongBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NextSongBtn.Location = New System.Drawing.Point(548, 296)
        Me.NextSongBtn.Name = "NextSongBtn"
        Me.NextSongBtn.Size = New System.Drawing.Size(128, 48)
        Me.NextSongBtn.TabIndex = 8
        Me.NextSongBtn.UseVisualStyleBackColor = True
        '
        'ShuffleCheck
        '
        Me.ShuffleCheck.AutoSize = True
        Me.ShuffleCheck.Location = New System.Drawing.Point(682, 296)
        Me.ShuffleCheck.Name = "ShuffleCheck"
        Me.ShuffleCheck.Size = New System.Drawing.Size(78, 21)
        Me.ShuffleCheck.TabIndex = 9
        Me.ShuffleCheck.Text = "Shuffle "
        Me.ShuffleCheck.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'TrackBarprogress
        '
        Me.TrackBarprogress.Location = New System.Drawing.Point(146, 350)
        Me.TrackBarprogress.Maximum = 100
        Me.TrackBarprogress.Name = "TrackBarprogress"
        Me.TrackBarprogress.Size = New System.Drawing.Size(530, 56)
        Me.TrackBarprogress.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(89, 361)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "00:00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(679, 361)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "00:00"
        '
        'Timer_loop
        '
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Highlight
        Me.TextBox1.Location = New System.Drawing.Point(663, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(604, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Search"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 406)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrackBarprogress)
        Me.Controls.Add(Me.ShuffleCheck)
        Me.Controls.Add(Me.NextSongBtn)
        Me.Controls.Add(Me.StopBtn)
        Me.Controls.Add(Me.PauseBtn)
        Me.Controls.Add(Me.PlayBtn)
        Me.Controls.Add(Me.PrevSongBtn)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Media Player"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarprogress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LoadSongsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteSongsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents PrevSongBtn As Button
    Friend WithEvents PlayBtn As Button
    Friend WithEvents PauseBtn As Button
    Friend WithEvents StopBtn As Button
    Friend WithEvents NextSongBtn As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents ShuffleCheck As CheckBox
    Friend WithEvents DeleteSelectedSongToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteAllSongsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents TrackBarprogress As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer_loop As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
End Class
