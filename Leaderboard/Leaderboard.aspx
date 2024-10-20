<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="EmployeePolls.Leaderboard.Leaderboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: fit-content; margin: 0 auto" class="leaderboard-container">
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Avatar">
                    <ItemTemplate>
                        <asp:Image ID="imgAvatar" runat="server" ImageUrl='<%# Eval("AvatarURL") %>' AlternateText="Avatar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserId" HeaderText="Author" />
                <asp:BoundField DataField="AnsweredQuestions" HeaderText="Answered Questions" />
                <asp:BoundField DataField="CreatedQuestions" HeaderText="Created Questions" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>