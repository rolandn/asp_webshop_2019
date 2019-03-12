<%@ Page Title="" Language="C#" MasterPageFile="~/webforms/AspectBoutique.Master" AutoEventWireup="true" CodeBehind="PageCommande.aspx.cs" Inherits="webshop_2019.webforms.PageCommande" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHContenu" runat="server">
      <h1>Mon panier</h1>
      <form id="fGVCommande" runat="server">
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"
                PageSize="10" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="true">        
        </asp:GridView>
      </form>

</asp:Content>
