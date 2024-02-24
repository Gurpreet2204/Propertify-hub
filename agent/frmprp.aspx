<%@ Page Title="" Language="C#" MasterPageFile="~/agent/MasterPage.master" AutoEventWireup="true" CodeFile="frmprp.aspx.cs" Inherits="agent_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="prpcod" OnRowEditing="GridView1_RowEditing" Width="586px" OnRowDeleting="GridView1_RowDeleting" >
                                            <Columns>
                                                
                                                <asp:TemplateField HeaderText="My Properties">
                                                    <ItemTemplate >
                                                        <table class="w-100">
                                                            <tr>
                                                                <td rowspan="4" style="width: 238px">
     <img src="../prpfils/<%#getpath(Convert.ToString(Eval("pic"))) %>"
         height="150px" width="150px" class="b22" border="2" />
                                                                </td>
                                                                <td>
     <h3><a href="frmnewprp.aspx?pcod=<%#Eval("prpcod") %>"><%#Eval("prptit") %></a></h3>
                                        
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
                                           
                                                                </td>
                                                                <td align="right">
         <asp:LinkButton ID="b1" runat="server" CommandName="Edit" Text="View Appointments" />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:LinkButton ID="b2" runat="server" CommandName="Delete" Text="Close Property" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   
                                            </Columns>
                                        </asp:GridView>
   
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="dspagtprp" TypeName="nszillow.clsprp">
        <SelectParameters>
            <asp:SessionParameter Name="agtcod" SessionField="cod" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

