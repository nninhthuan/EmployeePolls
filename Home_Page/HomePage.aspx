<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmployeePolls.Home_Page.Home_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:CheckBox ID="Switch_Question" runat="server" OnClick="OnShowQuestions" />
        </div>
</asp:Content>
