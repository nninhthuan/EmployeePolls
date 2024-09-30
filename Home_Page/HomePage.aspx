<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmployeePolls.Home_Page.Home_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="d-flex justify-content-center align-items-center">
            <asp:Button class="btn btn-danger" ID="Switch_Question" runat="server" 
                Text="Unanswered Questions" AutoEventWireup="true" OnClick="OnShowQuestions"
                style="display: flex; margin: 15px auto;"
                />
        </div>
</asp:Content>
