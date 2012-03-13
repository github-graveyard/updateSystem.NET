Localization
=====

In this Folder you'll find the Localizationfiles used by the updateSystem.NET.<br />
Do not edit these Files manually. Use instead the "Location Editor" from here: http://locedit.devs-on.net/


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


**"Needs development"** means, that the Localizationlogic isn't implemented yet. 

##Structure
All Localizationfiles should use the same Structure for their Strings:

Projectname.loc <br />
 -> Dialogs <br />
 --> Global <br />
 ---> btnOk <br />
 ----> Text: "OK" <br/>
 --> aboutDialog <br />
 ---> lnkHomepage <br />
 ----> Text: "Link to my awesome Homepage" <br />
 -> Messages <br />
 --> Global <br />
 ---> msgHello: "Hello there!"<br />
 --> aboutDialog <br />
 ----> msgNoHomepage: "Sorry, no Homepage available"<br />