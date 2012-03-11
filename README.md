updateSystem.NET
=======

Hi there! Most of this Stuff (including the Website) is still in German. I'll translate everything as soon as possible. If you speak German you can join my Developmentsquad. It consists of my and ... me :trollface:.

Homepage: http://updatesystem.net

##Copyright
Copyright 2008 - 2012 Maximilian Krauss - All rights reserved.

##Licensing
This Project is licensed under the Terms and Conditions of the Code Project Open License. See the LICENSE.md File for more Information.

##Contribute
Feel free to Fork this Project and make a Pull Request for these Features you'll see in the Master-Branch.
If you're new to git and/or don't want to be an Commandline-Guerilla use SmartGit. It's free for non-commercial use and very easy to handle.

##Build the Solution
For security reasons I've excluded any Strongname Keys from this Repository. In order to build this Solution you have to generate your own Key. You can do this by typing the following command in a Visual Studio Command Prompt:

    sn.exe -k 4096 <myRepoPath>\UpdateSystem.snk