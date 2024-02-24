<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="frmreg.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="map-bgs">
    <header class="section-header">
          <h3>Register New Agent</h3>
                  </header>
    <div class="col-md-6 reg-frm     form-line">
                        <div class="form-group">
                            <label for="exampleInputUsername">Select City</label>
                            <asp:dropdownlist runat="server" id="drpcty" cssclass="form-control" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="ctynam" DataValueField="ctycod" ></asp:dropdownlist>           
                        </div>
                    <div class="form-group">
                            <label for="exampleInputUsername">Select Location</label>
                            <asp:dropdownlist runat="server" id="drploc" cssclass="form-control" DataSourceID="ObjectDataSource2" DataTextField="locnam" DataValueField="loccod"></asp:dropdownlist>           
                        
                        </div>
          <div class="form-group">
                            <label for="exampleInputUsername">Agent Name</label>
              <asp:textbox runat="server" ID="txtnam" cssclass="form-control" ></asp:textbox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Agent Name Required" ControlToValidate="txtnam"></asp:RequiredFieldValidator>
                        
                        </div>
          <div class="form-group">
                            <label for="exampleInputUsername">Agent Email</label>
              <asp:textbox runat="server" id="txteml" cssclass="form-control"></asp:textbox> 
                            <asp:RegularExpressionValidator ControlToValidate="txteml" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                        </div>
        <div class="form-group">
            <asp:button runat="server" text="Submit" id="btnsub" class="submit" OnClick="btnsub_Click" />

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
    
                 </div>
</asp:Content>

