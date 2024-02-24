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

    protected void Button1_Click(object sender, EventArgs e)
    {
        nszillow.clsapp obj = new nszillow.clsapp();
        nszillow.clsappprp objprp = new nszillow.clsappprp();
        objprp.appdat = Convert.ToDateTime(TextBox1.Text);
        objprp.appdsc = TextBox3.Text;
        objprp.appphn = TextBox2.Text;
        objprp.appprpcod = Convert.ToInt32(Request.QueryString["pcod"]);
        objprp.appsts = 'B';
        objprp.appusrcod = Convert.ToInt32(Session["cod"]);
        obj.Save_Rec(objprp);
        TextBox1.Text = String.Empty;
        TextBox2.Text = String.Empty;
        TextBox3.Text = String.Empty;
        Label2.Text = "Appointment Booked Successfully.Agent will contact you soon.";
    }
}