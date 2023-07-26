<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RespondentProfile.aspx.cs" Inherits="AITSurvey.RespondentProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="card shadow-2-strong card-signin" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <h3 class="pb-4">Create Profile</h3>
                        <asp:Label ID="lblMessage" runat="server" CssClass="form-label invalid-feedback"></asp:Label>

                        <div class="row">
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblFirstName" AssociatedControlID="txtFirstName" runat="server" Text="First Name *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validateFirstName" ControlToValidate="txtFirstName" runat="server" ErrorMessage="First Name required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblLastName" AssociatedControlID="txtLastName" runat="server" Text="Last Name *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validateLastName" ControlToValidate="txtLastName" runat="server" ErrorMessage="Last Name required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validateEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Last Name required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <div class="form-outline datepicker w-100">
                                    <asp:Label ID="lblBirthdayDate" AssociatedControlID="txtBirthdayDate" runat="server" Text="Birthday *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtBirthdayDate" runat="server" CssClass="form-control form-control-lg" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validateBirthdayDate" ControlToValidate="txtBirthdayDate" runat="server" ErrorMessage="Birthday Date required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm">
                                <div class="form-outline">
                                    <asp:Label ID="Label1" AssociatedControlID="txtContactNumber" runat="server" Text="Contact Number *" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validateContactNumber" ControlToValidate="txtContactNumber" runat="server" ErrorMessage="Contact Number required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="mt-4 col-sm">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" Text="Save & Continue to Location" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                </div>

            </div>
            </div>
        </section>
    </main>
</asp:Content>
