using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["stucod"] == null)
        //      Response.Redirect("student/stulogin.aspx"); 
            if (Session["cod"]==null)
        {
            lk1.Visible = false;
            lk2.Visible = false;
            lk3.Visible = true;
            lk4.Visible = true;
            LinkButton1.Visible = false;
        }
        else
        {
            LinkButton1.Visible = true; 
            lk3.Visible = false;
            lk4.Visible = false;
        }
     

    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        nszillow.clsusr obj = new nszillow.clsusr();
        Int32 cod;
        char rol;
        cod = obj.logincheck(txteml.Text, txtpwd.Text, out rol);
        if (cod == -1 || cod == -2)
        
            // Label1.Text = "Email Password Incorrect";
            Response.Write("<script>alert('Email Password Incorrect')</script>");
       
        else
        {
            FormsAuthenticationTicket tk = new FormsAuthenticationTicket
    (1, txteml.Text, DateTime.Now, DateTime.Now.AddHours(2),
    false, rol.ToString());
            String s = FormsAuthentication.Encrypt(tk);
            HttpCookie ck = new HttpCookie(FormsAuthentication.
                FormsCookieName, s);
            Response.Cookies.Add(ck);
            Session["cod"] = cod;
            if (rol == 'A')
                Response.Redirect("agent/frmprf.aspx");
            else if (rol == 'D')
                Response.Redirect("admin/frmprptyp.aspx");
            else if (rol == 'U')
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        nszillow.clsusr obj = new nszillow.clsusr();
        nszillow.clsusrprp objprp = new nszillow.clsusrprp();
        objprp.usreml = txteml1.Text;
        objprp.usrpwd = txtpwd1.Text;
        objprp.usrregdat = DateTime.Now;
        objprp.usrrol = 'U';
     //   try
       // {
            obj.Save_Rec(objprp);
        //}
        //catch(Exception exp)
        //{

        //}
    }

    protected void lk1_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmfav.aspx");
    }

    protected void lk2_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmrev.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
    }
}
