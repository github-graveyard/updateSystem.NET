Localization
=====

This folder contains localization files used by updateSystem.NET.<br />
Do not edit these files manually. Use the Localization Editor available here: http://locedit.devs-on.net/


##Translations
* Administration (in progress)
 * English (in progress)
 * German (pending)

* Setup (pending)
 * English (pending)
 * German (pending)

* updateController (pending, needs development)
 * English (pending)
 * German (pending)

* updateInstaller (pending, needs development)
 * English (pending, needs translation)
 * German (pending, needs translation)


**"Needs development"** means the localization code isn't implemented yet. 

##Structure
All localization files should use the same structure for their strings:

Projectname.loc <br />
 -> Dialogs <br />
 --> Global <br />
 ---> btnOk <br />
 ----> Text: "OK" <br/>
 --> aboutDialog <br />
 ---> lnkHomepage <br />
 ----> Text: "Link to my awesome homepage" <br />
 -> Messages <br />
 --> Global <br />
 ---> msgHello: "Hello there!"<br />
 --> aboutDialog <br />
 ----> msgNoHomepage: "Sorry, no homepage available"<br />