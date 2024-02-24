<%@ Page Title="" Language="C#" MasterPageFile="~/agent/MasterPage.master" AutoEventWireup="true" CodeFile="frmprf.aspx.cs" Inherits="agent_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="map-bgs">
<header class="section-header">
          <h3>Manage Profile</h3>
                  </header>
    <div class="col-md-12     form-line design-table">
                        <div class="form-group">
                            <label for="exampleInputUsername">Services Offered</label>
                            <asp:checkboxlist runat="server" cssclass="form-control" id="ck1" Height="65px" RepeatColumns="3" RepeatDirection="Horizontal">
                                <asp:ListItem>Buying</asp:ListItem>
                                <asp:ListItem>Selling</asp:ListItem>
                                <asp:ListItem>Rental</asp:ListItem>
                                <asp:ListItem>Furnishing</asp:ListItem>
                                <asp:ListItem>Mortgaging</asp:ListItem>
                                <asp:ListItem>Estimation</asp:ListItem>
                                <asp:ListItem>Purchase</asp:ListItem>
                            </asp:checkboxlist>                              
                        </div>
                    <div class="form-group">
                            <label for="exampleInputUsername">Profile</label>
                        <asp:textbox runat="server" id="txtdsc" cssclass="form-control" textmode="Multiline" Height="265px"></asp:textbox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Description Required" ControlToValidate="txtdsc"></asp:RequiredFieldValidator>       
                        </div>
      <div class="form-group">
                            <label for="exampleInputUsername">Browse Picture</label>
          <asp:fileupload runat="server" id="filupl" cssclass="form-control"></asp:fileupload>          
                        </div>
        <br />
        <div class="form-group">
          <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-default submit" OnClick="Button1_Click" />
        </div>
    </div>
        </div>
</asp:Content>

