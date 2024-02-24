<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="frmfet.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="map-bgs">
     <header class="section-header">
          <h3>Property Type</h3>
                  </header>
    <div class="col-md-12 frm-new-tab     form-line">
                        <div class="form-group">

                            <label for="exampleInputUsername">Feature</label>
                            <asp:TextBox ID="txtfet" runat="server" CssClass="form-control"></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="FeatureRequired" ControlToValidate="txtfet"></asp:RequiredFieldValidator>        
                        </div>
                    
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-default submit" OnClick="Button1_Click" />
                               
                            </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="fetcod" DataSourceID="ObjectDataSource1" OnRowDeleting="GridView1_RowDeleting" Width="100%" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="fetdsc" HeaderText="Description" SortExpression="fetdsc" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsfet"></asp:ObjectDataSource>

        </div>
                        
       
        </div>
</asp:Content>
    
