<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RespondentSearch.aspx.cs" Inherits="AITSurvey.RespondentSearch" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="gradient-custom">
            <div class="row justify-content-center align-items-center h-100">
                <div class="card shadow-2-strong card-signin" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <h3 class="pb-4">Respondent Search</h3>
                        <asp:Label ID="lblMessage" runat="server" CssClass="form-label invalid-feedback"></asp:Label>

                        <div class="row">
                            <div class="row">
                                <div class="col-3">
                                    <div class="form-outline">
                                        First Name
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control form-control-lg" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-outline">
                                        Last Name
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control form-control-lg" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-outline">
                                        Email
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-outline">
                                        Gender
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>

                                    </div>
                                </div>

                               
                            </div>
                            <div class="row">
                                 <div class="col-3">
                                    Age Group
                                    <asp:DropDownList ID="ddlAgeGroup" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                                <div class="col-3">
                                    State
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                                <div class="col-3">
                                    Postcode
                                    <asp:TextBox ID="txtPostcode" runat="server" CssClass="form-control form-control-lg" placeholder="Postcode"></asp:TextBox>
                                </div>
                                <div class="col-3">
                                    Suburb
                                    <asp:TextBox ID="txtSuburb" runat="server" CssClass="form-control form-control-lg" placeholder="Suburb"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-3">
                                    Services
                                    <asp:DropDownList ID="ddlServices" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                                <div class="col-3">
                                    Room Type
                                    <asp:DropDownList ID="ddlRoomType" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                                <div class="col-3">
                                    In-Room Service
                                    <asp:DropDownList ID="ddlRoomService" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                                <div class="col-3">
                                    Private Health Insurance 
                                    <asp:DropDownList ID="ddlHealthInsurance" runat="server" CssClass="form-select form-select-lg mb-3"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col float-end">
                                    <asp:Button ID="btnSearch" CssClass="btn btn-primary btn-lg" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <asp:GridView ID="gvRespondent" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Respondent.Id" Visible="false" />
                                    <asp:BoundField DataField="Respondent.SurveyId" Visible="false" />
                                    <asp:BoundField DataField="Respondent.Email" HeaderText="EmailAddress" />
                                    <asp:BoundField DataField="Profile.FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="Profile.LastName" HeaderText="LastName" />
                                    <asp:BoundField DataField="Profile.AgeGroup.AgeGroupName" HeaderText="AgeGroup" />
                                    <asp:BoundField DataField="Profile.Gender.GenderName" HeaderText="State" />
                                    <asp:BoundField DataField="Address.State.StateName" HeaderText="State" />
                                    <asp:BoundField DataField="Address.Suburb" HeaderText="Suburb" />
                                    <asp:BoundField DataField="Address.Postcode" HeaderText="Postcode" />
                                    <asp:BoundField DataField="Respondent.IpAddress" HeaderText="IpAddress" />
                                    <asp:BoundField DataField="Respondent.DateCreated" HeaderText="DateCareated" />
                                    <asp:TemplateField HeaderText="View Survey">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server"
                                                NavigateUrl='<%# $"SurveyDetails?respondentId={Eval("Respondent.Id")}&amp;surveyId={Eval("Respondent.SurveyId")}" %>'
                                                Text="View Survey" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
