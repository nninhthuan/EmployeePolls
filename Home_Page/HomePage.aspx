<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmployeePolls.Home_Page.Home_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home-polls-container">
        <div class="d-flex justify-content-center align-items-center toggle-question-polls">
            <asp:Button class="btn btn-danger" ID="Switch_Question" runat="server" 
                Text="Unanswered Questions" AutoEventWireup="true" OnClick="OnShowQuestions"
                />
        </div>
        <div class="questions-container">
            <asp:GridView ID="QuestionGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="QuestionId" HeaderText="QuestionId"/>
                    <asp:BoundField DataField="VotedOptionOne" HeaderText="VotedOptionOne"/>
                    <asp:BoundField DataField="TextOptionOne" HeaderText="TextOptionOne"/>
                    <asp:BoundField DataField="VotedOptionTwo" HeaderText="VotedOptionTwo"/>
                    <asp:BoundField DataField="TextOptionTwo" HeaderText="TextOptionTwo"/>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
