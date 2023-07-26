<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveyDetails.aspx.cs" Inherits="AITResearch.SurveyDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="card shadow-2-strong" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <h3 class="pb-4">
                            <asp:Label ID="lblTitle" runat="server" Text="Details"></asp:Label></h3>
                        <div class="row">
                            <asp:Label ID="lblMessage" runat="server" CssClass="invalid-feedback"></asp:Label>
                            <asp:Panel ID="pnlQuestionAnswer" runat="server"></asp:Panel>
                        </div>
                        <div class="row">
                            <div class="mt-4 col-sm">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-lg" OnClientClick="JavaScript:window.history.back(1); return false;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
