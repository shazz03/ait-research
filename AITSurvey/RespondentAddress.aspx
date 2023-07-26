<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RespondentAddress.aspx.cs" Inherits="AITSurvey.RespondentAddress" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="card shadow-2-strong card-signin" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <h3 class="pb-4">Location</h3>
                        <asp:Label ID="lblMessage" runat="server" CssClass="form-label invalid-feedback"></asp:Label>

                        <div class="row">
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblAddressType" AssociatedControlID="ddlState" runat="server" Text="Address Type *" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlAddressType" runat="server" CssClass="form-select form-select-lg mb-3">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblState" AssociatedControlID="ddlState" runat="server" Text="State *" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblSuburb" AssociatedControlID="txtSuburb" runat="server" Text="Suburb *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtSuburb" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validateSuburb" ControlToValidate="txtSuburb" runat="server" ErrorMessage="Suburb required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSuburb" runat="server" ValidationExpression="^[a-zA-Z ]*$" ErrorMessage="Invalid Suburb Input" CssClass="invalid-feedback"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblPostcode" AssociatedControlID="txtPostcode" runat="server" Text="Postcode *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtPostcode" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPostcode" runat="server" ErrorMessage="Postcode required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtPostcode" runat="server" ErrorMessage="Invalid Postcode Input" ValidationExpression="^[0-9]*$" CssClass="invalid-feedback"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        <div class="mt-4 col-sm">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" Text="Submit Survey" OnClick="btnSubmit_Click" />
                        </div>
                            </div>

                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
