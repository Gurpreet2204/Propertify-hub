<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmfav.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <br />
    <br />
    <br />
    <br />
    </br>
     <div class="map-bgs">
                            <table class="w-100 design-table">
                                <tr>
                                    <td >
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4" DataKeyNames="prpcod,agtcod" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Favourites">
                                                    <ItemTemplate>
                                                        <table class="w-100">
                                                            <tr>
                                                                <td rowspan="4" align="center" style="width: 238px">
     <img src="prpfils/<%#getpath(Convert.ToString(Eval("pic"))) %>"
         height="150px" width="150px" class="b22" border="2" />
                                                                </td>
                                                               
                                                                <td>
     <h3><a href="frmprpdet.aspx?pcod=<%#Eval("prpcod") %>"><%#Eval("prptit") %></a></h3>
                                        
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                <b>Listed on :</b><%#Eval("prplstdat","{0:d}") %></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                <b>Price :$</b><%#Eval("prpprc") %></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                <%#Eval("prpdsc") %>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 238px" align="center">
                                                          <a href="frmprf.aspx?acod=<%#Eval("agtcod") %>"><%#Eval("agtnam") %></a><br />
      <asp:Rating ID="Rating1" class="www" runat="server"
                                           CurrentRating=<%# Convert.ToInt32(Eval("rev")) %>
    MaxRating="5"
    StarCssClass="ratingStar"
    WaitingStarCssClass="savedRatingStar"
    FilledStarCssClass="filledRatingStar"
    EmptyStarCssClass="emptyRatingStar" 
                                            
                                            
                                            ></asp:Rating> 
                                                                </td>
                                                                <td align="right">
                <asp:Button ID="b1" runat="server" CommandName="Edit" Text="View Details" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="dspfav" TypeName="nszillow.clsprp">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="usrcod" SessionField="cod" Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <br />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                        </table>
         </div>
</asp:Content>

