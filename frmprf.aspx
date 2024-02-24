<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmprf.aspx.cs" Inherits="_Default" %>
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
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
             <ItemTemplate>
                            <table class="w-100">
                                <tr>
                                    <td rowspan="6" style="width: 243px">
     <img src="agtpics/<%#getpath(Convert.ToInt32(Eval("agtcod")),Convert.ToString(Eval("agtpic"))) %>"
         height="150px" width="150px" class="b22" border="2" />
                                    </td>
                                    <td>
                                        <h3><%#Eval("agtnam") %></h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td><i><%#Eval("agtser") %></i></td>
                                </tr>
                                <tr>
                                    <td><p><%#Eval("agtprf") %></p></td>
                                </tr>
                                <tr>
                                    <td><b><%#Eval("nop") %></b> properties posted since <%#Eval("usrregdat","{0:d}") %></td>
                                </tr>
                                <tr>
                                    <td>
                            <asp:Rating ID="Rating1" class="www" runat="server"
                                           CurrentRating=<%# Convert.ToInt32(Eval("revscr")) %>
    MaxRating="5"
    StarCssClass="ratingStar"
    WaitingStarCssClass="savedRatingStar"
    FilledStarCssClass="filledRatingStar"
    EmptyStarCssClass="emptyRatingStar" 
                                            
                                            
                                            ></asp:Rating>   
                                            by <%#Eval("revcnt") %> customers</td>
                                </tr>
                             
                            </table>
                        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="dspagtprf" TypeName="nszillow.clsagt">
        <SelectParameters>
            <asp:QueryStringParameter Name="agtcod" QueryStringField="acod" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
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
     CurrentRating=<%# Convert.ToInt32(Eval("agtrevscr")) %>
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
            <asp:QueryStringParameter Name="agtcod" QueryStringField="acod" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

