<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="frmprptyp.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header class="section-header">
          <h3>Property Type</h3>
                  </header>
    <div class="col-md-12 prt-btn-area     form-line">
                        <div class="form-group">
                            <label for="exampleInputUsername">Property Type</label>
                            <asp:TextBox ID="txtprptyp" runat="server" CssClass="form-control"></asp:TextBox>           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Propety Type" ControlToValidate="txtprptyp"></asp:RequiredFieldValidator>
                        </div>
                    
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-default submit" OnClick="Button1_Click" />
                               
                            </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="prptypcod" DataSourceID="ObjectDataSource1" OnRowDeleting="GridView1_RowDeleting" Width="927px" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="prptypnam" HeaderText="Property Name" SortExpression="prptypnam" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clsprptyp"></asp:ObjectDataSource>

        </div>
                        
       

</asp:Content>

