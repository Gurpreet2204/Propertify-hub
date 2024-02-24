<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="frmcty.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<header class="section-header">
          <h3>Cities</h3>
                  </header>
    <div class="col-md-6  cty-frm    form-line">
                        <div class="form-group">
                            <label for="exampleInputUsername">City Name</label>
                            <asp:TextBox ID="txtcty" runat="server" CssClass="form-control"></asp:TextBox>         
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="CityRequired" ControlToValidate="txtcty"></asp:RequiredFieldValidator>  
                        </div>
                    
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-default submit" OnClick="Button1_Click" />
                               
                            </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ctycod" DataSourceID="ObjectDataSource1" OnRowDeleting="GridView1_RowDeleting" Width="927px" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="ctynam" HeaderText="City" SortExpression="ctynam" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="disp_rec" TypeName="nszillow.clscty"></asp:ObjectDataSource>

        </div>
                        
       

</asp:Content>

