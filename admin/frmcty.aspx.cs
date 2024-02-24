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
        nszillow.clscty obj = new nszillow.clscty();
        nszillow.clsctyprp objprp = new nszillow.clsctyprp();
        objprp.ctynam = txtcty.Text;
        if(Button1.Text=="Submit")
        {
            obj.save_rec(objprp);
        }
        else
        {
            objprp.ctycod = Convert.ToInt32(ViewState["cod"]);
            obj.upd_rec(objprp);
        }
        txtcty.Text = String.Empty;
        GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        nszillow.clscty obj = new nszillow.clscty();
        nszillow.clsctyprp objprp = new nszillow.clsctyprp();
        objprp.ctycod = Convert.ToInt32(GridView1.DataKeys[e.RowIndex][0]);
        obj.del_rec(objprp);
        GridView1.DataBind();
        e.Cancel = true;
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        nszillow.clscty obj = new nszillow.clscty();
        List<nszillow.clsctyprp> k = obj.find_rec(Convert.ToInt32(GridView1
            .DataKeys[e.NewEditIndex][0]));
        txtcty.Text = k[0].ctynam;
        ViewState["cod"] = k[0].ctycod;
        Button1.Text = "Update";
        e.Cancel = true;
    }
}