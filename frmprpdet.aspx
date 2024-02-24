<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmprpdet.aspx.cs" Inherits="_Default" %>
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

    <header class="section-header ">
          <h3>Property Details</h3>
                  </header>
    <div class="container design-tab">
    <div class="col-md-6     form-line">
            <input id="Hidden1" type="hidden"  runat="server"/>
                <input id="Hidden2" type="hidden"  runat="server"/>
           <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1092px" style="margin-bottom: 164px" >
       
                <asp:TabPanel runat="server" HeaderText="Property Details" ID="TabPanel1">
            <ContentTemplate> <script type="text/javascript"
  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCsYXS5KEfQfuLJQnftXa-qiaSdrFxVTJY&sensor=false">
    </script>
    <script lang="javascript">
                 var map;
                 function intialize() {
                     var mapOptions = {
                         center: { lat: 30.7900, lng: 76.7800 },
                         zoom: 8
                     };
                     map = new google.maps.Map(document.getElementById('map'), mapOptions);
                 
                     
                     //var args = locationList[0].split(',');
                     //var location = new google.maps.LatLng(args[0], args[1])
                     //var a = 1;

                     var marker = new google.maps.Marker({
                         position: new google.maps.LatLng(30.7900, 76.7800),
                         map: map,
                     });
        //             var marker = new google.maps.Marker(
        //{
        //    position: location,
        //    map: map,
        //    icon: 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=' + a + '|FF0000|000000'
        //});

                     //marker.setTitle(message[0]);
                     //attachSecretMessage(marker, 0);
                     

                 }
                 //function attachSecretMessage(marker, number) {
                 //    var infowindow = new google.maps.InfoWindow(
                 //    {
                 //        content: message[number],
                 //        size: new google.maps.Size(50, 50)
                 //    });
                 //    google.maps.event.addListener(marker, "click", function () {
                 //        infowindow.open(map, marker);
                 //    });
                 //}

</script><div id="map" style="height:235px;"></div>
            
                 <asp:DataList ID="DataList2" runat="server" OnSelectedIndexChanged="DataList2_SelectedIndexChanged" Width="988px" OnEditCommand="DataList2_EditCommand" OnDeleteCommand="DataList2_DeleteCommand" OnItemDataBound="DataList2_ItemDataBound">
                    <ItemTemplate>
                        <table class="w-100 design-table"   >
                            <tr>
                                <td rowspan="5" style="width: 328px">
  <img src="prpfils/<%#getpath(Convert.ToString(Eval("pic"))) %>"
         height="300px" width="300px" class="b22" border="2" />

                                </td>
                                <td><h3><%#Eval("prptit") %></h3></td>
                            </tr>
                            <tr>
                                <td><b>Address: </b><%#Eval("prpadd") %></td>
                            </tr>
                            <tr>
                                <td><b>Price :</b><%#Eval("prpprc") %></td>
                            </tr>
                            <tr>
                                <td><p>
                                    <%#Eval("prpdsc") %>

                                    </p></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lk1" runat="server" CausesValidation="false" CommandName="Edit"
                                        Text="Add To Favourites" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lk2" runat="server" CausesValidation="false" CommandName="Delete"
                                        Text="Book Appointment" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <br />
               </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Features" >
        <ContentTemplate>
          
       
          
                <asp:GridView ID="GridView1" runat="server" Width="894px"  AutoGenerateColumns="False" DataKeyNames="prpfetcod" ><Columns><asp:BoundField DataField="fetdsc" HeaderText="Feature" /><asp:BoundField DataField="prpfetdsc" HeaderText="Description"><ItemStyle Width="500px" /></asp:BoundField></Columns></asp:GridView><br /><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsfet"></asp:ObjectDataSource></div></ContentTemplate>
        </asp:TabPanel>
       <div>
                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Pictures">
        <ContentTemplate>
           
                <asp:DataList ID="DataList1" runat="server" DataKeyField="prppiccod" Height="266px" OnItemDataBound="DataList1_ItemDataBound" RepeatColumns="3" RepeatDirection="Horizontal" Width="920px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged"><ItemTemplate><asp:Literal ID="Literal1" runat="server"></asp:Literal><p><%#Eval("prppicdsc") %></p>
                   </ItemTemplate></asp:DataList></ContentTemplate>
        </asp:TabPanel>

            </asp:TabContainer>
                       
           <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsprptyp"></asp:ObjectDataSource>
                           
       </div>     
        </div>
</asp:Content>