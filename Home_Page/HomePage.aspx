<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmployeePolls.Home_Page.Home_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="height: 340px">
            <asp:Button class="btn btn-danger" ID="Switch_Question" runat="server" 
                Text="Unanswered Questions" AutoEventWireup="true" OnClick="OnShowQuestions"
                style="display: flex; margin: 15px auto;" Width="230px"
                />
            <div style="height: 273px; width: 1242px">
                <div style="width: 375px; height: 146px">
                    <table style="width: 100%; height: 139px;">
                        <tr>
                            <td class="modal-sm" style="width: 500px">d</td>
                        </tr>
                        <tr>
                            <td style="width: 255px">d</td>
                            <td>&nbsp;</td>
                            <td style="width: 255px">d</td>
                        </tr>
                        <tr>
                            <td class="modal-sm" style="width: 500px">ddd</td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
            <br />

        </div>
</asp:Content>
