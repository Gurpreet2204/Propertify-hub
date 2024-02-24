<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="frmloc.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="map-bgs">
    <script type="text/javascript"
  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCsYXS5KEfQfuLJQnftXa-qiaSdrFxVTJY&sensor=false">
    </script>
<script lang="javascript">
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
        document.getElementById('ContentPlaceHolder1_lblcrd').innerHTML= e.latLng;
        document.getElementById('ContentPlaceHolder1_Hidden1').value = e.latLng;
    }

</script>
    <input id="Hidden1" type="hidden"  runat="server"/>
<header class="section-header">
          <h3>Locations</h3>
                  </header>
    <div id="map"  style="height:200px;">

    </div>
    <div class="col-md-6 frm-location     form-line">
        <br />
                        <div class="form-group">
                            <label for="exampleInputUsername">Select City</label>
 <asp:DropDownList ID="drpcty" runat="server" DataSourceID="ObjectDataSource1" DataTextField="ctynam" DataValueField="ctycod" CssClass="form-check-label" AutoPostBack="True"></asp:DropDownList>            
                        </div>
        <div class="form-group">
                            <label for="exampleInputUsername">Location</label>
 <asp:TextBox ID="txtloc" runat="server" CssClass="form-control"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtloc" runat="server" ErrorMessage="LocationRequired"></asp:RequiredFieldValidator>
                        </div>
        <div class="form-group">
                            <label for="exampleInputUsername">Coordinates</label>
  <asp:Label ID="lblcrd" runat="server" CssClass="form-control"></asp:Label>           
                        </div>
                    
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-default submit" OnClick="Button1_Click" />
                          </div>     
                            <br />
                               
                            </div>
        <div>

         

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" class="rrr" DataKeyNames="loccod" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="locnam" HeaderText="Location Name" SortExpression="locnam" />
                    <asp:BoundField DataField="loccrd" HeaderText="Coordinates" SortExpression="loccrd" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsloc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drpcty" Name="ctycod" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clscty"></asp:ObjectDataSource>

         

        </div>
                  
</asp:Content>

