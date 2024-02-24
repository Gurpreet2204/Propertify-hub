<%@ Page Title="" Language="C#" MasterPageFile="~/agent/MasterPage.master" AutoEventWireup="true" CodeFile="frmdspapp.aspx.cs" Inherits="agent_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <br />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:GridView ID="GridView1" runat="server" Width="921px" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Appointments">
                <ItemTemplate>
                    <table class="w-100">
                        <tr>
                            <td style="width: 159px">Appointment Date</td>
                            <td><%#Eval("appdat","{0:d}") %></td>
                        </tr>
                        <tr>
                            <td style="width: 159px">Email</td>
                            <td><%#Eval("usreml") %></td>
                        </tr>
                        <tr>
                            <td style="width: 159px">Phone No</td>
                            <td><%#Eval("appphn") %></td>
                        </tr>
                        <tr>
                            <td colspan="2"><%#Eval("appdsc") %></td>
                        </tr>
                   
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
 
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="dspapp" TypeName="nszillow.clsapp">
        <SelectParameters>
            <asp:QueryStringParameter Name="prpcod" QueryStringField="pcod" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
&nbsp;
</asp:Content>

