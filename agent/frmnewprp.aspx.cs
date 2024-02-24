using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agent_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Page.IsPostBack==false)
        {
            if (Request.QueryString["pcod"] != null)
            {
                ViewState["cod"] = Request.QueryString["pcod"];
                grdbind();
                listbind();
                nszillow.clsprp obj = new nszillow.clsprp();
                List<nszillow.clsprpprp> k = obj.find_rec(Convert.ToInt32(ViewState["cod"]));
                txtadd.Text = k[0].prpadd;
                txtcst.Text = k[0].prpprc.ToString();
                txtdsc.Text = k[0].prpdsc;
                txtprptit.Text = k[0].prptit;
                lblcrd.Text = k[0].prpcrd;
                Hidden1.Value = k[0].prpcrd;
                drpprptyp.DataBind();
                drpprptyp.SelectedIndex = -1;
                drpprptyp.Items.FindByValue(k[0].prpprptypcod.ToString()).Selected = true;
                if (k[0].prpsalsts.ToString() == "S")
                    RadioButtonList1.SelectedIndex = 0;
                else
                    RadioButtonList1.SelectedIndex = 1;
                Button1.Text = "Update";
            }
            else
            {
                TabContainer1.Tabs[1].Enabled = false;
                TabContainer1.Tabs[2].Enabled = false;
            }
            TabContainer1.ActiveTabIndex = 0;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        nszillow.clsprp obj = new nszillow.clsprp();
        nszillow.clsprpprp objprp = new nszillow.clsprpprp();
        objprp.prpagtcod = Convert.ToInt32(Session["cod"]);
        objprp.prpadd = txtadd.Text;
        objprp.prpcrd = lblcrd.Text;
        objprp.prpdsc = txtdsc.Text;
        objprp.prplstdat = DateTime.Now;
        objprp.prpmanpiccod = -1;
        objprp.prpprc = Convert.ToSingle(txtcst.Text);
        objprp.prpprptypcod = Convert.ToInt32(drpprptyp.SelectedValue);
      objprp.prpsalsts = Convert.ToChar(RadioButtonList1.SelectedValue);
        objprp.prptit = txtprptit.Text;
        objprp.prpsts = 'A';
        if (Button1.Text == "Submit")
        {
            Int32 a = obj.save_rec(objprp);
            ViewState["cod"] = a;
            TabContainer1.Tabs[0].Enabled = false;
            TabContainer1.Tabs[1].Enabled = true;
            TabContainer1.Tabs[2].Enabled = true;
        }
        else
        {
            objprp.prpcod = Convert.ToInt32(ViewState["cod"]);
            obj.updprp_rec(objprp);
        }
        TabContainer1.ActiveTabIndex = 1;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        nszillow.clsprpfet obj = new nszillow.clsprpfet();
        nszillow.clsprpfetprp objprp = new nszillow.clsprpfetprp();
        objprp.prpfetprpcod = Convert.ToInt32(ViewState["cod"]);
        objprp.prpfetfetcod = Convert.ToInt32(drpfet.SelectedValue);
        objprp.prpfetdsc = txtfetdsc.Text;
        obj.Save_Rec(objprp);
        grdbind();
        txtfetdsc.Text = String.Empty;
        TabContainer1.Tabs[0].Enabled = false;
        TabContainer1.Tabs[1].Enabled = false;
        TabContainer1.Tabs[2].Enabled = true;
        TabContainer1.ActiveTabIndex = 2;
    }

    private void grdbind()
    {
        nszillow.clsprpfet obj = new nszillow.clsprpfet();
        GridView1.DataSource = obj.dispprpfet(
            Convert.ToInt32(ViewState["cod"]));
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        nszillow.clsprpfet obj = new nszillow.clsprpfet();
        List<nszillow.clsprpfetprp> k = obj.Find_Rec(Convert.ToInt32(GridView1
            .DataKeys[e.NewEditIndex][0]));
        txtfetdsc.Text = k[0].prpfetdsc;
        ViewState["cod"] = k[0].prpfetcod;
        Button1.Text = "Update";
        e.Cancel = true;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        nszillow.clsprpfet obj = new nszillow.clsprpfet();
        nszillow.clsprpfetprp objprp = new nszillow.clsprpfetprp();
        objprp.prpfetcod = Convert.ToInt32(GridView1.DataKeys[e.RowIndex][0]);
        obj.Del_Rec(objprp);
        GridView1.DataBind();
        e.Cancel = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        nszillow.clsprppic obj = new nszillow.clsprppic();
        nszillow.clsprppicprp objprp = new nszillow.clsprppicprp();
        objprp.prppicprpcod = Convert.ToInt32(ViewState["cod"]);
        objprp.prppicsts = Convert.ToChar(RadioButtonList2.
                                      SelectedValue);
        objprp.prppicdsc = TextBox1.Text;
        String fil = FileUpload1.PostedFile.FileName;
        if (fil != "")
            fil = fil.Substring(fil.LastIndexOf('.'));
        objprp.prppicfil = fil;
        Int32 a=obj.Save_Rec(objprp);
        if (fil != "")
 FileUpload1.PostedFile.SaveAs(Server.MapPath("../prpfils")
                + "//" + a.ToString() + fil);
        TextBox1.Text = String.Empty;
        listbind();
    }
    private void listbind()
    {
        nszillow.clsprppic obj = new nszillow.clsprppic();
        DataList1.DataSource = obj.Disp_Rec(Convert.ToInt32(
            ViewState["cod"]));
        DataList1.DataBind();
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if(e.Item.ItemType==ListItemType.Item||
            e.Item.ItemType==ListItemType.AlternatingItem)
        {
            Int32 ppcod = Convert.ToInt32(DataList1.DataKeys
                [e.Item.ItemIndex]);
            nszillow.clsprppic obj = new nszillow.clsprppic();
            List<nszillow.clsprppicprp> k= obj.Find_Rec(ppcod);
         Literal lit = (Literal)(e.Item.FindControl("Literal1"));
            if (k[0].prppicsts == 'P')
                lit.Text = "<img src=../prpfils/" + k[0].prppiccod + k[0].prppicfil + " height=180px width=180px />";
            else
            {

              
               
             lit.Text = "<video width=320 height=240 controls=controls ><source src=../prpfils/"+ k[0].prppiccod + k[0].prppicfil + "/></video>";
           
                LinkButton lk3 = (LinkButton)(e.Item.FindControl("lk3"));
                lk3.Visible = false;
            }
            }
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        nszillow.clsprp obj = new nszillow.clsprp();
        nszillow.clsprpprp objprp = new nszillow.clsprpprp();
        objprp.prpcod = Convert.ToInt32(ViewState["cod"]);
        objprp.prpmanpiccod = Convert.ToInt32(DataList1.DataKeys[DataList1.SelectedIndex]);
        obj.upd_rec(objprp);
        listbind();
    }

    protected void txtdsc_TextChanged(object sender, EventArgs e)
    {

    }
}