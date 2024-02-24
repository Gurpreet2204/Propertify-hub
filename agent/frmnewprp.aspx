<%@ Page Title="" Language="C#" MasterPageFile="~/agent/MasterPage.master" AutoEventWireup="true" CodeFile="frmnewprp.aspx.cs" Inherits="agent_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <header class="section-header ">
          <h3>Property Information</h3>
                  </header>
    <div class="container design-tab">
    <div class="col-md-6     form-line">
           <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1092px" style="margin-bottom: 164px">
        <asp:TabPanel runat="server" HeaderText="Property Details" ID="TabPanel1">
            <ContentTemplate><script type="text/javascript"
  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCsYXS5KEfQfuLJQnftXa-qiaSdrFxVTJY&sensor=false">
    </script><script lang="javascript">
    function intialize()
    {
        var mapOptions = {
            center: { lat: 30.7900, lng: 76.7800 },
            zoom: 8
        };
        var map = new google.maps.Map(document.getElementById('map'),mapOptions);
        google.maps.event.addListener(map, 'click', getLangLong);
    }
    function getLangLong(e)
    {
        document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_lblcrd').innerHTML = e.latLng;
        document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_Hidden1').value = e.latLng;
    }

</script><div id="map" style="height:235px;"></div><div class="form-group"><label for="exampleInputUsername"></label><asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="form-control" RepeatDirection="Horizontal" Height="24px" ><asp:ListItem Value="R">For Rent</asp:ListItem>
                <asp:ListItem Value="P">Purchase</asp:ListItem>
                </asp:RadioButtonList></div><div class="form-group"><label for="exampleInputUsername">Select Property Type</label> <asp:DropDownList ID="drpprptyp" runat="server" CssClass="form-control" DataSourceID="ObjectDataSource1" DataTextField="prptypnam" DataValueField="prptypcod"></asp:DropDownList></div><div class="form-group"><label for="exampleInputUsername">Property Title</label> <asp:TextBox ID="txtprptit" runat="server" CssClass="form-control"></asp:TextBox></div><div class="form-group"><label for="exampleInputUsername">Property Cost</label> <asp:TextBox ID="txtcst" runat="server" CssClass="form-control"></asp:TextBox></div><div class="form-group"><label for="exampleInputUsername">Coordinates</label> <asp:Label ID="lblcrd" runat="server" CssClass="form-control"></asp:Label><input id="Hidden1" type="hidden" runat="server" />
                </input>
                

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </input>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </input>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </input>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </input>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </input>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </input>
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div><div class="form-group"><label for="exampleInputUsername">Address</label> <asp:TextBox ID="txtadd" runat="server" CssClass="form-control" TextMode="MultiLine" Height="110px"></asp:TextBox></div><div class="form-group"><label for="exampleInputUsername">Description</label> <asp:TextBox ID="txtdsc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="260px" OnTextChanged="txtdsc_TextChanged"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Description Required" ControlToValidate="txtdsc"></asp:RequiredFieldValidator></div><div class="form-group">&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Submit" CausesValidation="false" CssClass="btn btn-default submit" OnClick="Button1_Click" /></div></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Features">
        <ContentTemplate><div class="form-group"><label for="exampleInputUsername">Select Feature<br /> </label> &nbsp;<asp:DropDownList ID="drpfet" runat="server" CssClass="form-control" DataSourceID="ObjectDataSource2" DataTextField="fetdsc" DataValueField="fetcod"></asp:DropDownList> </div><div class="form-group"><label for="exampleInputUsername">Description</label> <asp:TextBox ID="txtfetdsc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="158px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Description Required" ControlToValidate="txtfetdsc"></asp:RequiredFieldValidator></div><div class="form-group"><asp:Button ID="Button2" runat="server" Text="Submit" CausesValidation="false" CssClass="btn btn-default submit" OnClick="Button2_Click" /><br /><asp:GridView ID="GridView1" runat="server" Width="894px" AutoGenerateColumns="False" DataKeyNames="prpfetcod" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"><Columns><asp:BoundField DataField="fetdsc" HeaderText="Feature" /><asp:BoundField DataField="prpfetdsc" HeaderText="Description"><ItemStyle Width="500px" /></asp:BoundField><asp:CommandField ShowEditButton="True" /><asp:CommandField ShowDeleteButton="True" /></Columns></asp:GridView><br /><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsfet"></asp:ObjectDataSource></div></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Pictures">
        <ContentTemplate><table class="w-100"><tr><td style="width: 119px">&nbsp;</td><td><asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="16px" RepeatDirection="Horizontal" Width="373px"><asp:ListItem Value="P">Picture</asp:ListItem><asp:ListItem Value="V">Video</asp:ListItem></asp:RadioButtonList>
            </td></tr><tr><td style="width: 119px">Browse File</td><td><asp:FileUpload ID="FileUpload1" runat="server" />
                </td></tr><tr><td style="width: 119px">Description</td><td><asp:TextBox ID="TextBox1" runat="server" Height="139px" TextMode="MultiLine" Width="688px"></asp:TextBox>
                </td></tr><tr><td style="width: 119px">&nbsp;</td><td><asp:Button ID="Button3" CausesValidation="false" runat="server" OnClick="Button3_Click" Text="Submit" /></td></tr><tr><td colspan="2"><asp:DataList ID="DataList1" runat="server" DataKeyField="prppiccod" Height="266px" OnItemDataBound="DataList1_ItemDataBound" RepeatColumns="3" RepeatDirection="Horizontal" Width="920px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged"><ItemTemplate><asp:Literal ID="Literal1" runat="server"></asp:Literal><p><%#Eval("prppicdsc") %></p><asp:LinkButton ID="lk1" runat="server" CommandName="Edit"
                                    Text="Edit" />&#160;&#160;&#160;&#160;&#160; <asp:LinkButton ID="lk2" runat="server" CommandName="Delete"
                                    Text="Delete" /><br /><asp:LinkButton ID="lk3" runat="server" CausesValidation="false" CommandName="Select"
                                    Text="Set As Main Picture" /></ItemTemplate></asp:DataList></td></tr></table></ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
                           
           <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsprptyp"></asp:ObjectDataSource>
                           
        </div>
        </div>
</asp:Content>

