<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thankyou.aspx.cs" Inherits="AITResearch.Thankyou" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="card shadow-2-strong" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <h3 class="pb-4">
                            <asp:Label ID="lblTitle" runat="server" Text="Thank you for completing Survey."></asp:Label></h3>

                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
