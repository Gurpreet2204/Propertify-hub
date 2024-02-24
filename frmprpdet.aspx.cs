using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Page.IsPostBack == false)
        {
            grdbind();
            listbind();
            nszillow.clsprp obj = new nszillow.clsprp();
            DataSet ds = obj.dspprpdet(Convert.ToInt32(Request.QueryString["pcod"]));
            DataList2.DataSource = ds;
            DataList2.DataBind();
            String crd = ds.Tables[0].Rows[0]["prpcrd"].ToString();
            if (crd.Length > 0)
            {
                crd = crd.Substring(1);
                crd = crd.Substring(0, crd.Length - 1);
                //
                String[] r = crd.Split(',');
                List<String> oGeocodeList = new List<String>();
                    String s = "'" + r[0] + "," + r[1] + "'";
                    oGeocodeList.Add(s);
                var geocodevalues = string.Join(",", oGeocodeList.ToArray());
                List<String> oMessageList = new List<String>();
              
                    oMessageList.Add(ds.Tables[0].Rows[0]["prpadd"].ToString());
             
                String message = string.Join(",", oMessageList.ToArray());
                ClientScript.RegisterArrayDeclaration("locationList", geocodevalues);
                ClientScript.RegisterArrayDeclaration("message", message);

            }
            }
    }
    public String getpath(String pic)
    {
        if (pic == "")
            return "nopic.png";
        else
            return pic;
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void grdbind()
    {
        nszillow.clsprpfet obj = new nszillow.clsprpfet();
        GridView1.DataSource = obj.dispprpfet(
            Convert.ToInt32(Request.QueryString["pcod"]));
        GridView1.DataBind();
    }
    private void listbind()
    {
        nszillow.clsprppic obj = new nszillow.clsprppic();
        DataList1.DataSource = obj.Disp_Rec(Convert.ToInt32(
            Request.QueryString["pcod"]));
        DataList1.DataBind();
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Int32 ppcod = Convert.ToInt32(DataList1.DataKeys
                [e.Item.ItemIndex]);
            nszillow.clsprppic obj = new nszillow.clsprppic();
            List<nszillow.clsprppicprp> k = obj.Find_Rec(ppcod);
            Literal lit = (Literal)(e.Item.FindControl("Literal1"));
            if (k[0].prppicsts == 'P')
                lit.Text = "<img src=prpfils/" + k[0].prppiccod + k[0].prppicfil + " height=180px width=180px />";
            else
            {


                // lit.Text = "< video width =320 height =240 controls = controls source src = ../ prpfils / " + k[0].prppiccod + k[0].prppicfil + "/>";
                // lit.Text = "<video width=320 height=240 controls=controls><source src=../prpfils/"+ k[0].prppiccod + k[0].prppicfil + "/></video>";

                lit.Text = "<embed src=prpfils/" + k[0].prppiccod + k[0].prppicfil + " height=600px width=400px autoplay=false />";      
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DataList2_EditCommand(object source, DataListCommandEventArgs e)
    {
        if (Session["cod"] == null)
            Response.Redirect("index.aspx");
        else
        {
            nszillow.clsfav obj = new nszillow.clsfav();
            nszillow.clsfavprp objprp = new nszillow.clsfavprp();
            objprp.favprpcod = Convert.ToInt32(Request.QueryString["pcod"]);
            objprp.favusrcod = Convert.ToInt32(Session["cod"]);
            objprp.favdat = DateTime.Now;
            obj.Save_Rec(objprp);
            Response.Redirect("frmfav.aspx");

        }
    }

    protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        if (Session["cod"] == null)
            Response.Redirect("index.aspx");
        else
        {
            Response.Redirect("frmapp.aspx?pcod=" + Request.QueryString["pcod"]);
        }
    }

    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if(e.Item.ItemType==ListItemType.Item)
        {
            if(Session["cod"]!=null)
            {
                nszillow.clsfav obj = new nszillow.clsfav();
                List<nszillow.clsfavprp> k = obj.Find_Rec(Convert.ToInt32(Request.QueryString["pcod"]),
                    Convert.ToInt32(Session["cod"]));
                if(k.Count>0)
                {
                    LinkButton lk1 = (LinkButton)(e.Item.FindControl("lk1"));
                    lk1.Visible = false;
                }
            }
        }
    }
}