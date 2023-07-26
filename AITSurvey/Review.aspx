<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="AITResearch.Review" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-check-input-custom {
            border: 0;
        }

            .form-check-input-custom input[type=radio] {
                margin-right: 8px;
                vertical-align: middle;
                width: 16px;
                height: 16px;
            }
    </style>
    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="card shadow-2-strong" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <h3 class="pb-4">
                            <asp:Label ID="lblTitle" runat="server" Text="Review your answers"></asp:Label></h3>
                        <div class="row">
                            <asp:Label ID="lblMessage" runat="server" CssClass="invalid-feedback"></asp:Label>
                            <asp:Panel ID="pnlQuestionAnswer" runat="server"></asp:Panel>
                        </div>

                        <div class="row">
                            <div class="mt-1 col-sm">
                                <asp:CheckBox ID="chkRegister" runat="server" Text="Would you like to register?" /><br />
                                <br />
                                <br />
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-lg btnBack" OnClientClick="JavaScript:window.history.back(1); return false;" />
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
