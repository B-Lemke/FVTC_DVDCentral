<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BJL.DVDCentral.WebForm.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin</h2>
    
    <div class="row">
    <div class="col-md-2 m-2">
        <a href="ManageDirectors.aspx" class="btn btn-info btn-lg">Directors</a>
    </div>
    <div class="col-md-2 m-2">
        <a href="ManageFormats.aspx" class="btn btn-info btn-lg">Formats</a>
    </div>
    <div class="col-md-2 m-2">
        <a href="ManageRatings.aspx" class="btn btn-info btn-lg">Ratings</a>
    </div>
    <div class="col-md-2 m-2">
        <a href="ManageGenres.aspx" class="btn btn-info btn-lg">Genres</a>
    </div>
        </div>

</asp:Content>
