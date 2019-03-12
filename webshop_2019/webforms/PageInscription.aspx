 <%@ Page Title="" Language="C#" MasterPageFile="~/webforms/AspectBoutique.Master" AutoEventWireup="true" 
     CodeBehind="PageInscription.aspx.cs" Inherits="webshop_2019.webforms.PageInscription" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">
    <h1>Inscription</h1>
        <form id="fAjouterClient" runat="server">
        <div class="elementecran" style="text-align: center;">
            <br />
            Nom:
            <asp:TextBox ID="TBNom" MaxLength="20" runat="server"
                CssClass="saisie-texte" Style="width: 175px;" required="required">
            </asp:TextBox>
            <br />
            <br />
            Prénom:
            <asp:TextBox ID="TBPrenom" MaxLength="20" runat="server"
                CssClass="saisie-texte" Style="width: 175px;" required="required">
            </asp:TextBox>
            <br />
            <br />
            Adresse complète:
            <asp:TextBox ID="TBAdresse" MaxLength="50" runat="server"
                CssClass="saisie-texte" Style="width: 175px;" required="required">
            </asp:TextBox>
            <br />
            <br />
            Email:
            <asp:TextBox ID="TBEmail" MaxLength="50" runat="server" TextMode="Email"
                CssClass="saisie-texte" Style="width: 175px;" required="required">
            </asp:TextBox>
            <br />
            <br />
            Password:
            <asp:TextBox ID="TBPassword" MaxLength="20" runat="server" TextMode="Password"
                CssClass="saisie-texte" Style="width: 175px;" required="required">
            </asp:TextBox>
            <br />
            <br />
        
            <asp:Button ID="BContinuer" runat="server" Text="Continuer"
            OnClick="BContinuer_Click" CssClass="bouton" />
            <button type="button" class="bouton" onclick="location.reload();" >
            Réinitialiser</button>
        
            <br />
            <br />
        </div>
        </form>
</asp:Content>
