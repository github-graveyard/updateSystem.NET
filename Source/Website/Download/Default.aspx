<%@ Page Title="{appname} - Download" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Download_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Das updateSystem.NET herunterladen</h2>

	<div class="download">

		<h3>Aktuelle Version</h3>
		<table>
			<tbody>
				<tr>
					<td class="Image">
						<img src="/Images/Download/Box.png" alt="Download" />
					</td>
					<td class="Text">
						<p>
							<strong>Dateiname:</strong> <asp:Label runat="server" ID="lblFilename" Text="n/a"></asp:Label> (<asp:Label runat="server" ID="lblDownloadCount" Text="0"></asp:Label> Downloads)
						</p>
						<p>
							<strong>Größe:</strong> <asp:Label runat="server" ID="lblFileSize" Text="n/a"></asp:Label>
						</p>
						<p>
							<strong>Version:</strong> <asp:Label runat="server" ID="lblVersion" Text="n/a"></asp:Label> (<a href="https://bugs.devs-on.net/Projects/ChangeLog.aspx?pid=1" target="_blank">Release Notes</a>)
						</p>
						<p>
							<strong>Lizenz:</strong> Freeware (<a href="/FAQ.aspx#lizenz">F.A.Q.s zur Lizenz</a>)
						</p>
						<p>
							<asp:Button runat="server" ID="btnDownload" Enabled="true" Text="Herunterladen" Width="150" 
								Height="25" onclick="btnDownload_Click" />
						</p>
					</td>
				</tr>
			</tbody>
		</table>
	</div>
	<h3 style="margin-top:20px;">Weitere Links</h3>
		<ul>
			<li><a href="https://bugs.devs-on.net/Projects/Roadmap.aspx?pid=1">Die offizielle updateSystem.NET Roadmap</a></li>
			<li><a href="http://www.microsoft.com/downloads/details.aspx?familyid=5b2c0358-915b-4eb5-9b1d-10e506da9d0f&displaylang=de#filelist" target="_blank">.NET Framework 2.0 Download</a> (Nur relevant für Benutzer mit Windows XP)</li>
			<li><a href="https://maximiliankrauss.net/category/updateSystemNET.aspx">Aktuelle Entwicklungsnachrichten in meinem Blog</a></li>
			<li><a href="/FAQ.aspx#donate"><strong>Die Entwicklung durch eine Spende unterstützen.</strong></a></li>
		</ul>
</asp:Content>

