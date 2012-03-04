<%@ Page Title="{appname} - F.A.Q.s" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Oft gestellte Fragen bezüglich des updateSystem.NET</h2>
	<p>
		Bevor Sie eine Frage im Forum stellen oder mir eine eMail schreiben, schauen Sie bitte in den FAQ ob Ihre Frage nicht schon beantwortet wurde.
	</p>
	<div id="faq">
		<h3>Inhalt</h3>
		<ul>
			<li><a href="#voraussetzungen">Voraussetzungen</a></li>
			<li><a href="#lizenz">Lizenz</a></li>
			<li><a href="#verwendung">Verwendung</a></li>
		</ul>
		<a id="voraussetzungen"></a><h3>1) Voraussetzungen</h3>
		<ul class="faqs">
			<li>
				<p>
					<span class="q">Was sind die (Software-)Voraussetzungen an das updateSystem.NET?</span><br />
					Das updateSystem.NET (die Administration und der updateController) benötigen das Microsoft .NET Framework 2.0 (oder höher) um Ausgeführt werden zu können. Unterstützt werden die Betriebssysteme Windows XP, Server 2003(+R2), Vista, Server 2008(+R2) und 7 jeweils in der 32- sowie in der 64-Bit Edition.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Läuft das updateSystem.NET auch auf Linux (via Mono)?</span><br />
					Nein. Und dies ist auch in Zukunft nicht geplant.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Welche Visual Studio Versionen unterstützt der updateController?</span><br />
					Der updateController funktioniert im Visual Studio 2005, 2008 und 2010 sowie den korrespondierenden Express Editionen.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Unterstützt der updateController das .NET Framework 4.0 Client Profile?</span><br />
					Nein. Das .NET 4.0 Client Profile wird derzeit nicht unterstützt, es wird das volle .NET Framework 4.0 benötigt.
				</p>
				<p>
				    Siehe dazu auch: <a href="/Help/Misc/DotNET40ClientProfile.aspx">"Die Assembly "updateSystemDotNet.Controller", auf die verwiesen wird, konnte nicht aufgelöst werden..."</a>
				</p>
			</li>
			<li>
				<p>
					<span class="q">Unterstützt der updateController WPF?</span><br />
					Eingeschränkt. Sie können die updateController Komponente auch in WPF Anwendungen verwenden, allerdings wird das Hinzufügen in die ToolBox bei WPF Elementen nicht gelingen.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Was muss mein Server/Webspace unterstützen um Updates verteilen zu können?</span><br />
					Sie benötigen auf Ihrem Webspace Zugang via FTP(S) sowie über HTTP(S) zum Up- und Download der Updates.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Kann ich Updates auch via SFTP hochladen?</span><br />
					Nein.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Welche Voraussetungen hat der Statistikdienst?</span><br />
					Für den Statistikdienst benötigen Sie einen Webspace welcher ASP.NET (min. Version 3.5) sowie den Microsoft SQL Server (min. Version 2005) unterstützt.
				</p>
				<p>
				    <strong>Hinweis: Die Unterstützung für den auf PHP-Basierenden Statistikdienst wurde mit der Version 1.6 eingestellt!</strong>
				</p>
			</li>
		</ul>
		<a id="lizenz"></a><h3>2) Lizenz</h3>
		<ul class="faqs">
			<li>
				<p>
					<span class="q">Wie viel kostet das updateSystem.NET?</span><br />
					Das updateSystem.NET ist und bleibt komplett kostenlos.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Darf ich das updateSystem.NET auch für kommerzielle Anwendungen benutzen?</span><br />
					Ja, und dies uneingeschränkt.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Wie sieht's mit dem Quellcode aus?</span><br />
					Das updateSystem.NET ist proprietäre Software. Sie dürfen es kostenlos verwenden aber der Quellcode wird in keinem Fall veröffentlicht.
				</p>
			</li>
			<li>
				<p><a id="donate"></a>
					<span class="q">Ich finde das updateSystem.NET toll und möchte den Entwickler unterstützen, wie kann ich dies tun?</span><br />
					Sie können den Entwickler über eine Spende via PayPal unterstützen.
				</p>
				<p>
					<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Y67TPZVJUG968" target="_blank"><img src="https://www.paypal.com/de_DE/DE/i/btn/btn_donateCC_LG.gif" alt="PayPal Donate" /></a>
				</p>
			</li>
			<li>
				<p>
					<span class="q">Darf ich das updateController Assembly z.B. als Resource in die Zielanwendung einbetten?</span><br />
					Ja, allerdings unter einer Voraussetzung: Das Assembly darf unter <span style="text-decoration:underline;">keinen Umständen</span> dauerhaft verändert werden. Tools wie z.B. ILMerge von Microsoft sind daher in Verbindung mit dem updateController nicht gestattet.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Muss ich irgendwo in der Anwendung erwähnen, dass ich das updateSystem.NET benutze?</span><br />
					Nein, dies ist nicht zwingend Notwendig aber natürlich gerne gesehen.
				</p>
			</li>
		</ul>
		<a id="verwendung"></a><h3>3) Verwendung</h3>
		<ul class="faqs">
			<li>
				<p>
					<span class="q">Wo finde ich das updateController Assembly zum Referenzieren in meiner Anwendung?</span><br />
					Den updateController finden Sie im Installationsverzeichnis des updateSystem.NET (üblicher Weise <em>"C:\Programme\updateSystem.NET\"</em> in dem Unterverzeichnis <em>"Deploy"</em> unter dem Dateinamen <em>"updateSystemDotNet.Controller.dll"</em>.
				</p>
			</li>
			<li>
				<p>
					<span class="q">Welche Dateien muss ich mit meiner Anwendung ausliefern?</span><br />
					Prinzipiell müssen Sie nur die <em>updateSystemDotNet.Controller.dll</em> beilegen. Um bei Fehlern in der updateController Assembly einen vollständigen Stacktrace erhalten zu können, ist es zudem ratsam die Symboldatei <em>updateSystemDotNet.Controller.pdb</em> hinzu zu nehmen. Die <em>updateSystemDotNet.Controller.xml</em> müssen Sie nicht weiterverteilen.
				</p>
			</li>
			<li>
			    <p>
			        <span class="q">Wo finde ich die Installations-ID meiner Anwendung?</span><br />
			        Die Installations-ID ist meist eine GUID im Format {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX} welche von dem jeweiligen Installationsprogramm vergeben wird. Sie finden sie i.d.R. in den Einstellungen/Eigenschaften des entsprechenden Setupprojektes.
			    </p>
			</li>
		</ul>
	</div>
</asp:Content>