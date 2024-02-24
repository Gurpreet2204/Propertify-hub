<%@ Page Title="" Language="C#" MasterPageFile="~/agent/MasterPage.master" AutoEventWireup="true" CodeFile="frmrev.aspx.cs" Inherits="agent_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <br />
    <br />
     <br />
    <br />
    <br />
    
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="ObjectDataSource2" Width="950px" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Customer Reviews">
                <ItemTemplate>
                    <table class="w-100">
                        <tr>
                            <td>&nbsp;</td>
                            <td>Posted Date :<%#Eval("agtrevdat","{0:d}") %></td>
                        </tr>
                        <tr>
                            <td colspan="2"><h4><%#Eval("agtrevtit") %></h4></td>
                        </tr>
                        <tr>
                            <td>
  <asp:Rating ID="Rating1" class="www" runat="server"
     CurrentRating='<%#Eval("agtrevscr") %>' 
    MaxRating="5"
    StarCssClass="ratingStar"
    WaitingStarCssClass="savedRatingStar"
    FilledStarCssClass="filledRatingStar"
    EmptyStarCssClass="emptyRatingStar" 
                                            
                                            
                                            ></asp:Rating>   
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2"><%#Eval("agtrevdsc") %></td>
                        </tr>
                        <tr>
                            <td>Posted By :<%#Eval("usreml") %></td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="dspagtrev" TypeName="nszillow.clsagt">
        <SelectParameters>
            <asp:SessionParameter Name="agtcod" SessionField="cod" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
