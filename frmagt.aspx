<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmagt.aspx.cs" Inherits="admin_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
     <br />
     <br />
     <br />
     <br />
    <div class="map-bgs">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
    <header class="section-header">
          <h3>Search Agents</h3>
                  </header>
    <div class="col-md-6 agent-add-frm form-line">
                        <div class="form-group">
                            <label for="exampleInputUsername">Select City</label>
                            <asp:dropdownlist runat="server" id="drpcty" cssclass="form-control" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="ctynam" DataValueField="ctycod" ></asp:dropdownlist>           
                        </div>
                    <div class="form-group">
                            <label for="exampleInputUsername">Select Location</label>
                            <asp:dropdownlist runat="server" id="drploc" cssclass="form-control" DataSourceID="ObjectDataSource2" DataTextField="locnam" DataValueField="loccod" AutoPostBack="True"></asp:dropdownlist>           
                        
                        </div>
        <div class="form-group">


            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="agtcod" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Search Results">
                        <ItemTemplate>
                            <table class="w-100">
                                <tr>
                                    <td rowspan="6" style="width: 243px">
     <img src="agtpics/<%#getpath(Convert.ToInt32(Eval("agtcod")),Convert.ToString(Eval("agtpic"))) %>"
         height="150px" width="150px" class="b22" border="2" />
                                    </td>
                                    <td>
       <h3><a href="frmprf.aspx?acod=<%#Eval("agtcod") %>" ><%#Eval("agtnam") %></a></h3>
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
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
       

        </div>
                      <br />
                            <br />
                            <br />
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clscty"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsloc">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="drpcty" Name="ctycod" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
    
                 
                        <br />
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="dspagtbyloc" TypeName="nszillow.clsagt">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="drploc" Name="loccod" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>

    
                 </div>
</asp:Content>

