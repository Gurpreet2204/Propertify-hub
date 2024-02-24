using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using SendGrid;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsub_Click(object sender, EventArgs e)
    {
        //to store record to tbusr
        nszillow.clsusr obj = new nszillow.clsusr();
        nszillow.clsusrprp objprp = new nszillow.clsusrprp();
        objprp.usreml = txteml.Text;
        objprp.usrregdat = DateTime.Now;
        objprp.usrrol = 'A';
        String pwd = Guid.NewGuid().ToString();
        pwd = pwd.Substring(0, 9);
        objprp.usrpwd = pwd;
        Int32 ucod=obj.Save_Rec(objprp);
        //to tbagt
        nszillow.clsagt obj1 = new nszillow.clsagt();
        nszillow.clsagtprp objprp1 = new nszillow.clsagtprp();
        objprp1.agtloccod = Convert.ToInt32(drploc.SelectedValue);
        objprp1.agtnam = txtnam.Text;
        objprp1.agtpic = "";
        objprp1.agtprf = "";
        objprp1.agtser = "";
        objprp1.agtusrcod = ucod;
        obj1.save_rec(objprp1);
        var msg = "Login CredentialsYour password is " + pwd;
        sendmail(txteml.Text, msg);
        txtnam.Text = "";
        txteml.Text = "";
    }
    public void sendmail(String to, String body)
    {
        // Create the email object first, then add the properties.
        SendGridMessage myMessage = new SendGridMessage();
        myMessage.AddTo(to);
        myMessage.From = new MailAddress("cs@cssoftsolutions.com", "Zillow");
        myMessage.Subject = "Registration mail";
        myMessage.Text = body;

        var credentials = new NetworkCredential("Nitinsuimui", "cssoft123#");

        var transportWeb = new Web("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");

        // Send the email.
        try
        {
            transportWeb.DeliverAsync(myMessage);

            Console.WriteLine("Sent!");
            Response.Write("Registration Successful");
        }
        catch (Exception ex)
        {
            Console.WriteLine("E-Mail Already Exists!!");
        }
        txtnam.Text = String.Empty;
        txteml.Text = String.Empty;
        //TextBox3.Text = String.Empty;
        //Label1.Text = "Registration Successful";
        Response.Redirect("frmagt.aspx");

    }


    // MailMessage mm = new MailMessage("admin@zillow.com", txteml.Text,
    //    "Password Information", "Your Password is " + pwd);
    //  SmtpClient c = new SmtpClient("mail.connectzone.in", 25);
    //  c.Send(mm);
    
    
}