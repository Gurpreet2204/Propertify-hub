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

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public String getpath(String pic)
    {
        if (pic == "")
            return "nopic.png";
        else
            return pic;
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("frmdspapp.aspx?pcod=" + GridView1.DataKeys[e.NewEditIndex][0]);
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        nszillow.clsprp obj = new nszillow.clsprp();
        nszillow.clsprpprp objprp = new nszillow.clsprpprp();
        objprp.prpcod = Convert.ToInt32(GridView1.DataKeys[e.RowIndex][0]);
        objprp.prpsts = 'C';
        obj.updprpsts(objprp);
        GridView1.DataBind();
        e.Cancel = true;
    }
}