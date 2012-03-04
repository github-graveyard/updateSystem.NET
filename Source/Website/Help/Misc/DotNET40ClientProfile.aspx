<%@ Page Title="{appname} - Probleme mit dem .NET Framework 4.0 Client Profile" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="DotNET40ClientProfile.aspx.cs" Inherits="Help_Misc_DotNET40ClientProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
    <h2>Probleme mit dem .NET Framework 4.0 Client Profile</h2>
    <p>
        Wenn Sie den updateController in Ihr Projekt einbebunden haben, und beim kompilieren die folgende Fehlermeldung erhalten, dann haben Sie das falsche Zielframework eingestellt. Das updateSystem.NET unterstützt in der aktuellen Version alle .NET Framework Versionen bis auf das <strong>.NET Framework 4.0 Client Profile</strong>.
    </p>
    <div class="errormessage">
    <p>
       "Die Assembly "updateSystemDotNet.Controller", auf die verwiesen wird, konnte nicht aufgelöst werden, da sie eine Abhängigkeit von "System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" aufweist (nicht im aktuellen Zielframework ".NETFramework,Version=v4.0,Profile=Client" enthalten). Entfernen Sie Verweise auf im Zielframework nicht enthaltene Assemblys, oder weisen Sie das Projekt neu zu.
    </p>
    </div>
    <h3>Lösung</h3>
    <p>
        Gehen Sie in die Einstellungen in Ihrem Projekt und ändern Sie dort das Zielframework auf entweder das vollwertige .NET Framework 4.0 oder eine niedrigere Version.
    </p>
    <p>
        Die Einstellung dafür ist im Visual Studio 2010 jeweils für C# und VB.NET an verschiedenen Stellen zu finden:
    </p>
    <p class="content_center">
        <img src="/Images/Help/Misc/vs_2010_csharp.png" alt="Visual Studio 2010 C#" /><br />
        Einstellungen für ein C#-Projekt
    </p>
    <p class="content_center">
        <img src="/Images/Help/Misc/vs_2010_vb.png" alt="Visual Studio 2010 VB.NET" /><br />
        Einstellungen für ein VB.NET-Projekt
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>

