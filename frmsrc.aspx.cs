using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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
        Response.Redirect("frmprpdet.aspx?pcod=" + GridView1.DataKeys[e.NewEditIndex][0]);
    }
}