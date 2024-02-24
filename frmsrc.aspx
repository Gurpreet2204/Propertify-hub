<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmsrc.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <br />
    <br />
    <br />
    <br />
    </br>
 <div class="map-bgs">
   
    <header class="section-header">
          <h3>Search Property</h3>
                  </header>
     <div class="container">
    <div class="col-md-12 form-line search-page">
        <div class="form-area-search">
         <div class="form-group">
                            <label for="exampleInputUsername">Property For</label>
             <asp:RadioButtonList ID="r1" runat="server" AutoPostBack="True" Height="16px" RepeatDirection="Horizontal" Width="760px">
                 <asp:ListItem Selected="True" Value="P">Purchase</asp:ListItem>
                 <asp:ListItem Value="R">Rental</asp:ListItem>
                            </asp:RadioButtonList>      
                        </div>
                        <div class="form-group">
                            <label for="exampleInputUsername">Select City</label>
                            <asp:dropdownlist runat="server" id="drpcty" cssclass="form-control" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="ctynam" DataValueField="ctycod" ></asp:dropdownlist>           
                        </div>
                    <div class="form-group">
                            <label for="exampleInputUsername">Select Location</label>
                            <asp:dropdownlist runat="server" id="drploc" cssclass="form-control" DataSourceID="ObjectDataSource2" DataTextField="locnam" DataValueField="loccod" AutoPostBack="True"></asp:dropdownlist>           
                         
                        </div>
        <div class="form-group">
            <label for="exampleInputUsername">Select Property Type</label>
            <asp:dropdownlist runat="server" id="drpprptyp" cssclass="form-control" AutoPostBack="True" DataSourceID="ObjectDataSource3" DataTextField="prptypnam" DataValueField="prptypcod"></asp:dropdownlist>           
        </div>
                  </div>
                            <table class="w-100 design-table">
                                <tr>
                                    <td >
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4" DataKeyNames="prpcod,agtcod" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Search Results">
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
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="srcprp" TypeName="nszillow.clsprp">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="drploc" Name="loccod" PropertyName="SelectedValue" Type="Int32" />
                                                <asp:ControlParameter ControlID="drpprptyp" Name="prptypcod" PropertyName="SelectedValue" Type="Int32" />
                                                <asp:ControlParameter ControlID="r1" Name="sts" PropertyName="SelectedValue" Type="Char" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <br />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                        </table>
                            <br />
                            <br />
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clscty"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsloc">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="drpcty" Name="ctycod" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
    
                 
                  

    
                        <br />
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsprptyp"></asp:ObjectDataSource>
    
                 
                  

    
                 </div>
     </div>


    </div>
</asp:Content>

