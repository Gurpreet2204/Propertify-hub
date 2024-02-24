<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmrev.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <br />
     <br />
     <br />
     <br />
     <br   /><br />
     <br />
     <br />

    <h3>Write Review</h3>
    <table class="w-100">
        <tr>
            <td>Select Appointment</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="det" DataValueField="appcod"></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td>Review Title</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="550px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Title Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Rating</td>
            <td> <asp:Rating ID="Rating1" class="www" runat="server"
                                          CurrentRating=<%# Convert.ToInt32(Eval("agtrevscr")) %>
    MaxRating="5"
    StarCssClass="ratingStar"
    WaitingStarCssClass="savedRatingStar"
    FilledStarCssClass="filledRatingStar"
    EmptyStarCssClass="emptyRatingStar" 
                                            
                                            
                                            ></asp:Rating> </td>
        </tr>
        <tr>
            <td>Description</td>
            <td style="margin-left: 120px">
                <asp:TextBox ID="TextBox2" runat="server" Height="182px" TextMode="MultiLine" Width="550px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Description Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="margin-left: 120px">
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Cancel" />
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="dspusrapp" TypeName="nszillow.clsapp">
                    <SelectParameters>
                        <asp:SessionParameter Name="usrcod" SessionField="cod" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

