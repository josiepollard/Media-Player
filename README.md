# Media-Player

MUSIC PLAYER 
****************

CONTENTS
-------------------------
* Introduction
* Installation
* Supported file types


INTRODUCTION 
-------------------------
This solution is for a music interface written in Visual basic (.NET).

* Allows music playback
* Have a shuffle button
* Able to load in songs which are then added to a database
* Search option to find a certain song within the database
* Lists the songs by name
* Have user control over playback


INSTALLATION
-------------------------
* Install Visual Studio Community 2019 Version 16.11, it can be found here: https://my.visualstudio.com/Downloads?q=visual%20studio%202019&wt.mc_id=o~msft~vscom~older-downloads
* Once downloaded, Visual Studio will ask you to select the workloads to install. You will need to select '.NET desktop development'	 
* In the file explorer, double click on the file called 'mediaPlayerSP.vbproj', this will open up the project. here the code can be viewed and the project can be ran using the start button in Visual Studio. 
* It is possible you may enocunter a build error the first time the code is ran: *Couldn't process file Form1.resx due to its being in the Internet or Restricted zone or having the mark of the web on the file.* in this case your computer may need to run a security scan and/or you may need to right click on the file name in file explorer and select properties. at the bottom there will be a section called security. here you will need to check the 'unblock' checkbox and click apply.			



SUPPORTED FILE TYPES
-------------------------
* mp3
* mp4
* m4a

Within the properties of the file, the details should be populated. At minimum it needs to have a Title and Album.
Without these the file will still be able to play, but no name or details about it will be visible in the player.


![Example Image](Screenshot 2024-10-15 114704)
