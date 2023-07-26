<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="AITSurvey.Questions" %>

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
                            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h3>
                        <div class="row">
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Panel ID="pnlOptions" runat="server">
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblMessage" runat="server" CssClass="invalid-feedback"></asp:Label>
                        <div class="row">
                            <div class="mt-4 col-sm">
                                <asp:Button ID="btnSkip" CausesValidation="false" CssClass="btn btn-primary btn-lg" runat="server" Text="Skip" OnClick="btnSkip_Click" />
                            </div>
                           <div class="mt-4 col-sm">
                               <asp:button id="btnBack" runat="server" text="Back" CssClass="btn btn-primary btn-lg" OnClientClick="JavaScript:window.history.back(1); return false;" /> 
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" Text="Next" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
