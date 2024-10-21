<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="EmployeePolls.Leaderboard.Leaderboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: fit-content; margin: 0 auto" class="leaderboard-container">
        <br />
        <br />
        <div class="filter-bar">
            <asp:DropDownList ID="sortControl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="onChangeValueSort">
                <asp:ListItem Text="Sort by ..." Value=""></asp:ListItem>
                <asp:ListItem Text="Author" Value="Author"></asp:ListItem>
                <asp:ListItem Text="Answered Questions" Value="AnsweredQuestions"></asp:ListItem>
                <asp:ListItem Text="Created Questions" Value="CreatedQuestions"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Avatar">
                    <ItemTemplate>
                        <asp:Image ID="imgAvatar" runat="server" ImageUrl='<%# Eval("AvatarURL") %>' AlternateText="Avatar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="AnsweredQuestions" HeaderText="Answered Questions" />
                <asp:BoundField DataField="CreatedQuestions" HeaderText="Created Questions" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>