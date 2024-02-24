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
            nszillow.clsagt obj = new nszillow.clsagt();
            List<nszillow.clsagtprp> k = obj.find_rec(Convert.ToInt32(Session["cod"]));
            txtdsc.Text = k[0].agtprf;
            String s = k[0].agtser;
            String[] r = s.Split(',');
            for(Int32 i=0;i<r.Length;i++)
            {
                if (ck1.Items[i].Selected == true)
                {
                    ck1.Items.FindByValue(r[i]).Selected = true;
                }

                else
                {

                }
                    //Response.Write("Check first");

            }
            ViewState["pic"] = k[0].agtpic;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
        {
        nszillow.clsagt obj = new nszillow.clsagt();
        nszillow.clsagtprp objprp = new nszillow.clsagtprp();
        objprp.agtcod = Convert.ToInt32(Session["cod"]);
        objprp.agtprf = txtdsc.Text;
        String s = "";
        for(Int32 i=0;i<ck1.Items.Count;i++)
        {
            if (ck1.Items[i].Selected == true)
                s = s + ck1.Items[i].Value + ",";
        }
        if (s != "")
            s = s.Substring(0, s.Length - 1);
        objprp.agtser = s;
        String fp = filupl.PostedFile.FileName;
        if (fp != "")
        {
            fp = fp.Substring(fp.LastIndexOf('.'));
            objprp.agtpic = fp;
        }
        else
            objprp.agtpic = ViewState["pic"].ToString();
        obj.upd_rec(objprp);
        if(fp!="")
        {
         filupl.PostedFile.SaveAs(Server.MapPath("../agtpics") + "//" + Session["cod"] + fp);
            txtdsc.Text = string.Empty;
        }
    }
}