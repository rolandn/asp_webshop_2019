<%@ Page Title="" Language="C#" MasterPageFile="~/webforms/AspectBoutique.Master" AutoEventWireup="true" CodeBehind="PageMessage.aspx.cs" Inherits="WebApplication1.PresentationLayer.PageMessage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">
    <h1>Information</h1>
    <p>
    <b><asp:Label ID="LMsg" runat="server" Text="Label" CssClass="msg"></asp:Label></b>
    </p>
    <p class ="msg">Cliquez sur le bouton back pour recommencer ou faites une sélection dans
    la barre des menus...
    </p>
</asp:Content>
