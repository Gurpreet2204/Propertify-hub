using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        nszillow.clsfet obj = new nszillow.clsfet();
        nszillow.clsfetprp objprp = new nszillow.clsfetprp();
        objprp.fetdsc = txtfet.Text;
        if (Button1.Text == "Submit")
        {
            obj.save_rec(objprp);
        }
        else
        {
            objprp.fetcod = Convert.ToInt32(ViewState["cod"]);
            obj.upd_rec(objprp);
            Button1.Text = "Submit";
        }
        txtfet.Text = String.Empty;
        GridView1.DataBind();
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        nszillow.clsfet obj = new nszillow.clsfet();
        nszillow.clsfetprp objprp = new nszillow.clsfetprp();
        objprp.fetcod = Convert.ToInt32(GridView1.DataKeys[e.RowIndex][0]);
        obj.del_rec(objprp);
        GridView1.DataBind();
        e.Cancel = true;
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        nszillow.clsfet obj = new nszillow.clsfet();
        List<nszillow.clsfetprp> x = obj.find_rec(Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex][0]));
        txtfet.Text = x[0].fetdsc;
        ViewState["cod"] = x[0].fetcod;
        Button1.Text = "Update";
        e.Cancel = true;
    }
}