<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RespondentSearch.aspx.cs" Inherits="AITResearch.RespondentSearch" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


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
                                        

                                    </div>
                                    <div class="row">
                                        <div class="col-3">
                                            <div class="form-outline">
                                                Survey
                                        <asp:DropDownList ID="ddlSurvey" runat="server" CssClass="form-select form-select-lg mb-3" OnSelectedIndexChanged="ddlSurvey_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="col-5" style="padding-top:32px">
                                                select survey to display search criteria below
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Panel ID="pnlSearch" runat="server" CssClass="row"></asp:Panel>
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
                                            <asp:BoundField DataField="Respondent.MacAddress" HeaderText="IpAddress" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
