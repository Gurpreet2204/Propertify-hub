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
        nszillow.clsloc obj = new nszillow.clsloc();
        nszillow.clslocprp objprp = new nszillow.clslocprp();
        objprp.locnam = txtloc.Text;
        objprp.locctycod = Convert.ToInt32(drpcty.SelectedValue);
        objprp.loccrd = Hidden1.Value;
        if (Button1.Text == "Submit")
            obj.save_rec(objprp);
        txtloc.Text = String.Empty;
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        nszillow.clsloc obj = new nszillow.clsloc();
        List<nszillow.clslocprp> x = obj.find_rec(Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex][0]));
       txtloc.Text = x[0].locnam;
        lblcrd.Text = x[0].loccrd;
        drpcty.Text = x[0].locctycod.ToString();
        
        ViewState["cod"] = x[0].loccod;
        Button1.Text = "Update";
        e.Cancel = true;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        nszillow.clsloc obj = new nszillow.clsloc();
        nszillow.clslocprp objprp = new nszillow.clslocprp();
        objprp.loccod = Convert.ToInt32(GridView1.DataKeys[e.RowIndex][0]);
        obj.del_rec(objprp);
        GridView1.DataBind();
        e.Cancel = true;
    }
}