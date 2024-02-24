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
        if(Request.QueryString["pcod"]!=null)
        {
            nszillow.clsprp obj = new nszillow.clsprp();
     List<nszillow.clsprpprp> k = obj.find_rec(Convert.ToInt32(Request.QueryString["pcod"]));
            Literal1.Text = "<h3>" + k[0].prptit + "</h3>";
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}