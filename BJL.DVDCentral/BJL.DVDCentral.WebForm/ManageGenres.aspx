<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageGenres.aspx.cs" Inherits="BJL.DVDCentral.WebForm.ManageGenres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header rounded-top">
        <h3>Genres</h3>
    </div>

    <p></p>
    <a class="nav-link" runat="server" href="~/Admin">Back to Admin</a>

    <div class="form-row ml-1 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label1" runat="server" Text="Genres:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlGenres" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGenres_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-row ml-1 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:TextBox ID="txtGenreDescription" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row ml-5 mt-2">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-lg btn-info m-2" OnClick="btnInsert_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-lg btn-info m-2" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-lg btn-info m-2" OnClick="btnDelete_Click" />
    </div>

</asp:Content>
