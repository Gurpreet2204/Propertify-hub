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
        

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        nszillow.clsagtrev obj = new nszillow.clsagtrev();
        nszillow.clsagtrevprp objprp = new nszillow.clsagtrevprp();
        objprp.agtrevtit = TextBox1.Text;
        objprp.agtrevdsc = TextBox2.Text;
        objprp.agtrevusrcod = Convert.ToInt32(Session["cod"]);
        objprp.agtrevscr = Convert.ToInt32(Rating1.CurrentRating);
        nszillow.clsapp obj1 = new nszillow.clsapp();
        DataSet ds = obj1.dspusrapp(Convert.ToInt32(Session["cod"]));
        for(Int32 i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            if(Convert.ToInt32(ds.Tables[0].Rows[i]["appcod"])==
                Convert.ToInt32(DropDownList1.SelectedValue))
            {
                objprp.agtrevagtcod = Convert.ToInt32(ds.Tables[0].Rows[i]["agtcod"]);
                objprp.agtrevprpcod = Convert.ToInt32(ds.Tables[0].Rows[i]["prpcod"]);
            }
        }
        objprp.agtrevdat = DateTime.Now;
        obj.save_rec(objprp);
        Response.Redirect("frmprf.aspx?acod="+objprp.agtrevagtcod);
    }
}