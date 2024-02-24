<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmapp.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <br />
    <br />
     <h3>Book Appointment</h3>
     <table class="w-100">
        <tr>
            <td style="width: 194px">Suitable Date</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox1">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Date Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 194px">Phone No</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Phone No. Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td style="width: 194px">Description</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="217px" Width="713px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Description Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
             <td></td>
             <td>
                 <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
             &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button2" runat="server" Text="Cancel" />
             </td>
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>
                 <asp:Label ID="Label2" runat="server"></asp:Label>
             </td>
         </tr>
    </table>
</asp:Content>

