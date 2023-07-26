<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="AITSurvey.StaffLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-signin" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <h3>Staff Login</h3>
                            <asp:Label ID="lblMessage" runat="server" Text="" class="invalid-feedback"></asp:Label>
                            <div class="form-outline">
                                <asp:Label ID="lblUserName" AssociatedControlID="txtUserName" runat="server" Text="Username *" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="validateUserName" ControlToValidate="txtUserName" runat="server" ErrorMessage="Username required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>

                            </div>

                            <div class="form-outline">
                                <asp:Label ID="lblPassword" AssociatedControlID="txtPassword" runat="server" Text="Password *" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="validatePassword" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password required" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>
                            UserName: username
                            Password: password
                            <div class="mt-4">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" runat="server" Text="Signin" OnClick="btnSubmit_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
