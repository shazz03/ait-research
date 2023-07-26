<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AITSurvey._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome to AIT Research</h1>

            <div class="mt-4">
                <h5 class="pb-4">
                    <asp:Label ID="lblTitle" runat="server" Text="Title: AITR Market Research"></asp:Label></h5>
                <h6 class="pb-4">
                    <asp:Label ID="lblDescription" runat="server" Text="Description: iHospital Sydney patient survey"></asp:Label></h6>
                <h6 class="pb-4">
                    <asp:Label ID="lblSurveyId" runat="server" Text="Id: 2"></asp:Label></h6>
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" Text="Start Survey" OnClick="btnSubmit_Click" />
            </div>
        </section>
    </main>

</asp:Content>
