using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace nszillow
{
    // interface classes
    public interface intstu
    {
        Int32 stucod
        {
            get;
            set;
        }
        String stunam
        {
            get;
            set;
        }
        String stucol
        {
            get;
            set;
        }
        String sturolno
        {
            get;
            set;
        }
        DateTime stutrgstrdat
        {
            get;
            set;
        }
        DateTime stutrgenddat
        {
            get;
            set;
        }
        String stupic
        {
            get;
            set;
        }
        String stuusrnam
        {
            get;
            set;
        }
        String stupwd
        {
            get;
            set;
        }
    }
    public class clsstuprp : intstu
    {
        private Int32 pstucod;
        private String pstunam, pstucol, psturolno, pstupic, pstuusrnam, pstupwd;
        private DateTime pstutrgstrdat, pstutrgenddat;
        public int stucod
        {
            get
            {
                return pstucod;
            }
            set
            {
                pstucod = value;
            }
        }

        public string stunam
        {
            get
            {
                return pstunam;
            }
            set
            {
                pstunam = value;
            }
        }

        public string stucol
        {
            get
            {
                return pstucol;
            }
            set
            {
                pstucol = value;
            }
        }

        public string sturolno
        {
            get
            {
                return psturolno;
            }
            set
            {
                psturolno = value;
            }
        }

        public DateTime stutrgstrdat
        {
            get
            {
                return pstutrgstrdat;
            }
            set
            {
                pstutrgstrdat = value;
            }
        }

        public DateTime stutrgenddat
        {
            get
            {
                return pstutrgenddat;
            }
            set
            {
                pstutrgenddat = value;
            }
        }

        public string stupic
        {
            get
            {
                return pstupic;
            }
            set
            {
                pstupic = value;
            }
        }

        public string stuusrnam
        {
            get
            {
                return pstuusrnam;
            }
            set
            {
                pstuusrnam = value;
            }
        }

        public string stupwd
        {
            get
            {
                return pstupwd;
            }
            set
            {
                pstupwd = value;
            }
        }
    }
    public class clsstu : clscon
    {
        public Int32 logstu(String usrnam, String pwd)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("logstu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@stuusrnam", SqlDbType.VarChar, 50).Value = usrnam;
            cmd.Parameters.Add("@stupwd", SqlDbType.VarChar, 50).Value = pwd;
            cmd.Parameters.Add("@r", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@r"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }
        public List<clsstuprp> find_rec(Int32 stucod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("fndstu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@stucod", SqlDbType.Int).Value = stucod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsstuprp> obj = new List<clsstuprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsstuprp k = new clsstuprp();
                k.stucod = Convert.ToInt32(dr[0]);
                k.stunam = dr[1].ToString();
                k.stucol = dr[2].ToString();
                k.sturolno = dr[3].ToString();
                k.stutrgstrdat = Convert.ToDateTime(dr[4]);
                k.stutrgenddat = Convert.ToDateTime(dr[5]);
                k.stupic = dr[6].ToString();
                k.stuusrnam = dr[7].ToString();
                k.stupwd = dr[8].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public Int32 save_rec(clsstuprp p)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("insstu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@stunam", SqlDbType.VarChar, 50).Value = p.stunam;
            cmd.Parameters.Add("@stucol", SqlDbType.VarChar, 50).Value = p.stucol;
            cmd.Parameters.Add("@sturolno", SqlDbType.VarChar, 50).Value = p.sturolno;
            cmd.Parameters.Add("@stutrgstrdat", SqlDbType.DateTime).Value = p.stutrgstrdat;
            cmd.Parameters.Add("@stutrgenddat", SqlDbType.DateTime).Value = p.stutrgenddat;
            cmd.Parameters.Add("@stupic", SqlDbType.VarChar, 50).Value = p.stupic;
            cmd.Parameters.Add("@stuusrnam", SqlDbType.VarChar, 50).Value = p.stuusrnam;
            cmd.Parameters.Add("@stupwd", SqlDbType.VarChar, 50).Value = p.stupwd;
            cmd.Parameters.Add("@r", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@r"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }

    }
    public interface intcty
    {
        Int32 ctycod { get; set; }
        String ctynam { get; set; }
    }
    public interface intloc
    {
        Int32 loccod { get; set; }
        String locnam { get; set; }
        Int32 locctycod { get; set; }
        String loccrd { get; set; }
    }
    public interface intprptyp
    {
        Int32 prptypcod { get; set; }
        String prptypnam { get; set; }
    }
    public interface intfet
    {
        Int32 fetcod { get; set; }
        String fetdsc { get; set; }
    }
    public interface intagt
    {
        Int32 agtcod { get; set; }
        String agtnam { get; set; }
        Int32 agtloccod { get; set; }
        String agtser { get; set; }
        String agtpic { get; set; }
        String agtprf { get; set; }
        Int32 agtusrcod { get; set; }
    }
    public interface intusr
    {
        Int32 usrcod { get; set; }
        String usreml { get; set; }
        String usrpwd { get; set; }
        DateTime usrregdat { get; set; }
        Char usrrol { get; set; }
    }
    public interface intprp
    {
        Int32 prpcod { get; set; }
        String prptit { get; set; }
        Int32 prpagtcod { get; set; }
        Int32 prpprptypcod { get; set; }
        String prpadd { get; set; }
        String prpcrd { get; set; }
        Char prpsalsts { get; set; }
        String prpdsc { get; set; }
        float prpprc { get; set; }
        DateTime prplstdat { get; set; }
        Int32 prpmanpiccod { get; set; }
        Char prpsts { get; set; }
    }
    public interface intprppic
    {
        Int32 prppiccod { get; set; }
        Int32 prppicprpcod { get; set; }
        String prppicfil { get; set; }
        String prppicdsc { get; set; }
        Char prppicsts { get; set; }
    }
    public interface intprpfet
    {
        Int32 prpfetcod { get; set; }
        Int32 prpfetprpcod { get; set; }
        Int32 prpfetfetcod { get; set; }
        String prpfetdsc { get; set; }
    }
    public interface intfav
    {
        Int32 favcod { get; set; }
        Int32 favusrcod { get; set; }
        Int32 favprpcod { get; set; }
        DateTime favdat { get; set; }
    }
    public interface intapp
    {
        Int32 appcod { get; set; }
        Int32 appusrcod { get; set; }
        Int32 appprpcod { get; set; }
        DateTime appdat { get; set; }
        String appdsc { get; set; }
        String appphn { get; set; }
        Char appsts { get; set; }
    }
    public interface intagtrev
    {
        Int32 agtrevcod { get; set; }
        Int32 agtrevagtcod { get; set; }
        Int32 agtrevusrcod { get; set; }
        Int32 agtrevprpcod { get; set; }
        DateTime agtrevdat { get; set; }
        String agtrevtit { get; set; }
        String agtrevdsc { get; set; }
        Int32 agtrevscr { get; set; }
    }
    // property classes
    public class clsctyprp : intcty
    {
        private Int32 pctycod;
        private String pctynam;
        public int ctycod
        {
            get
            {
                return pctycod;
            }

            set
            {
                pctycod = value;
            }
        }
        public string ctynam
        {
            get
            {
                return pctynam;
            }

            set
            {
                pctynam = value;
            }
        }
    }
    public class clslocprp : intloc
    {
        private Int32 ploccod, plocctycod;
        private String plocnam, ploccrd;
        public int loccod
        {
            get
            {
                return ploccod;
            }

            set
            {
                ploccod = value;
            }
        }
        public string loccrd
        {
            get
            {
                return ploccrd;
            }

            set
            {
                ploccrd = value;
            }
        }
        public int locctycod
        {
            get
            {
                return plocctycod;
            }

            set
            {
                plocctycod = value;
            }
        }
        public string locnam
        {
            get
            {
                return plocnam;
            }

            set
            {
                plocnam = value;
            }
        }
    }
    public class clsprptypprp : intprptyp
    {
        private Int32 pprptypcod;
        private String pprptypnam;
        public int prptypcod
        {
            get
            {
                return pprptypcod;
            }

            set
            {
                pprptypcod = value;
            }
        }
        public string prptypnam
        {
            get
            {
                return pprptypnam;
            }

            set
            {
                pprptypnam = value;
            }
        }
    }
    public class clsfetprp : intfet
    {
        private Int32 pfetcod;
        private String pfetdsc;

        public int fetcod
        {
            get
            {
                return pfetcod;
            }

            set
            {
                pfetcod = value;
            }
        }

        public string fetdsc
        {
            get
            {
                return pfetdsc;
            }

            set
            {
                pfetdsc = value;
            }
        }
    }
    public class clsagtprp : intagt
    {
        private Int32 pagtcod, pagtloccod, pagtusrcod;
        private String pagtnam, pagtser, pagtpic, pagtprf;

        public int agtcod
        {
            get
            {
                return pagtcod;
            }

            set
            {
                pagtcod = value;
            }
        }
        public int agtloccod
        {
            get
            {
                return pagtloccod;
            }

            set
            {
                pagtloccod = value;
            }
        }
        public string agtnam
        {
            get
            {
                return pagtnam;
            }

            set
            {
                pagtnam = value;
            }
        }
        public string agtpic
        {
            get
            {
                return pagtpic;
            }

            set
            {
                pagtpic = value;
            }
        }
        public string agtprf
        {
            get
            {
                return pagtprf;
            }

            set
            {
                pagtprf = value;
            }
        }
        public string agtser
        {
            get
            {
                return pagtser;
            }

            set
            {
                pagtser = value;
            }
        }
        public int agtusrcod
        {
            get
            {
                return pagtusrcod;
            }

            set
            {
                pagtusrcod = value;
            }
        }
    }
    public class clsusrprp : intusr
    {
        private Int32 pusrcod;
        private String pusreml, pusrpwd;
        private DateTime pusrregdat;
        private Char pusrrol;

        public int usrcod
        {
            get
            {
                return pusrcod;
            }

            set
            {
                pusrcod = value;
            }
        }

        public string usreml
        {
            get
            {
                return pusreml;
            }

            set
            {
                pusreml = value;
            }
        }

        public string usrpwd
        {
            get
            {
                return pusrpwd;
            }

            set
            {
                pusrpwd = value;
            }
        }

        public DateTime usrregdat
        {
            get
            {
                return pusrregdat;
            }

            set
            {
                pusrregdat = value;
            }
        }

        public char usrrol
        {
            get
            {
                return pusrrol;
            }

            set
            {
                pusrrol = value;
            }
        }
    }
    public class clsprpprp : intprp
    {
        private Int32 pprpcod, pprpagtcod, pprpprptypcod, pprpmanpiccod;
        private String pprptit, pprpadd, pprpcrd, pprpdsc;
        private DateTime pprplstdat;
        private float pprpprc;
        private Char pprpsalsts, pprpsts;

        public int prpcod
        {
            get
            {
                return pprpcod;
            }

            set
            {
                pprpcod = value;
            }
        }

        public string prptit
        {
            get
            {
                return pprptit;
            }

            set
            {
                pprptit = value;
            }
        }

        public int prpagtcod
        {
            get
            {
                return pprpagtcod;
            }

            set
            {
                pprpagtcod = value;
            }
        }

        public int prpprptypcod
        {
            get
            {
                return pprpprptypcod;
            }

            set
            {
                pprpprptypcod = value;
            }
        }

        public string prpadd
        {
            get
            {
                return pprpadd;
            }

            set
            {
                pprpadd = value;
            }
        }

        public string prpcrd
        {
            get
            {
                return pprpcrd;
            }

            set
            {
                pprpcrd = value;
            }
        }

        public char prpsalsts
        {
            get
            {
                return pprpsalsts;
            }

            set
            {
                pprpsalsts = value;
            }
        }

        public string prpdsc
        {
            get
            {
                return pprpdsc;
            }

            set
            {
                pprpdsc = value;
            }
        }

        public float prpprc
        {
            get
            {
                return pprpprc;
            }

            set
            {
                pprpprc = value;
            }
        }

        public DateTime prplstdat
        {
            get
            {
                return pprplstdat;
            }

            set
            {
                pprplstdat = value;
            }
        }

        public int prpmanpiccod
        {
            get
            {
                return pprpmanpiccod;
            }

            set
            {
                pprpmanpiccod = value;
            }
        }

        public char prpsts
        {
            get
            {
                return pprpsts;
            }

            set
            {
                pprpsts = value;
            }
        }
    }
    public class clsprppicprp : intprppic
    {
        private Int32 pprppiccod, pprppicprpcod;
        private String pprppicfil, pprppicdsc;
        private Char pprppicsts;

        public int prppiccod
        {
            get
            {
                return pprppiccod;
            }

            set
            {
                pprppiccod = value;
            }
        }

        public string prppicdsc
        {
            get
            {
                return pprppicdsc;
            }

            set
            {
                pprppicdsc = value;
            }
        }

        public string prppicfil
        {
            get
            {
                return pprppicfil;
            }

            set
            {
                pprppicfil = value;
            }
        }

        public int prppicprpcod
        {
            get
            {
                return pprppicprpcod;
            }

            set
            {
                pprppicprpcod = value;
            }
        }

        public char prppicsts
        {
            get
            {
                return pprppicsts;
            }

            set
            {
                pprppicsts = value;
            }
        }
    }
    public class clsprpfetprp : intprpfet
    {
        private Int32 pprpfetcod, pprpfetprpcod, pprpfetfetcod;
        private String pprpfetdsc;

        public int prpfetcod
        {
            get
            {
                return pprpfetcod;
            }

            set
            {
                pprpfetcod = value;
            }
        }

        public string prpfetdsc
        {
            get
            {
                return pprpfetdsc;
            }

            set
            {
                pprpfetdsc = value;
            }
        }

        public int prpfetfetcod
        {
            get
            {
                return pprpfetfetcod;
            }

            set
            {
                pprpfetfetcod = value;
            }
        }

        public int prpfetprpcod
        {
            get
            {
                return pprpfetprpcod;
            }

            set
            {
                pprpfetprpcod = value;
            }
        }
    }
    public class clsfavprp : intfav
    {
        private Int32 pfavcod, pfavusrcod, pfavprpcod;
        private DateTime pfavdat;

        public int favcod
        {
            get
            {
                return pfavcod;
            }

            set
            {
                pfavcod = value;
            }
        }

        public DateTime favdat
        {
            get
            {
                return pfavdat;
            }

            set
            {
                pfavdat = value;
            }
        }

        public int favprpcod
        {
            get
            {
                return pfavprpcod;
            }

            set
            {
                pfavprpcod = value;
            }
        }

        public int favusrcod
        {
            get
            {
                return pfavusrcod;
            }

            set
            {
                pfavusrcod = value;
            }
        }
    }
    public class clsappprp : intapp
    {
        private Int32 pappcod, pappusrcod, pappprpcod;
        private String pappdsc, pappphn;
        private DateTime pappdat;
        private Char pappsts;

        public int appcod
        {
            get
            {
                return pappcod;
            }

            set
            {
                pappcod = value;
            }
        }

        public int appusrcod
        {
            get
            {
                return pappusrcod;
            }

            set
            {
                pappusrcod = value;
            }
        }

        public int appprpcod
        {
            get
            {
                return pappprpcod;
            }

            set
            {
                pappprpcod = value;
            }
        }

        public DateTime appdat
        {
            get
            {
                return pappdat;
            }

            set
            {
                pappdat = value;
            }
        }

        public string appdsc
        {
            get
            {
                return pappdsc;
            }

            set
            {
                pappdsc = value;
            }
        }

        public string appphn
        {
            get
            {
                return pappphn;
            }

            set
            {
                pappphn = value;
            }
        }

        public char appsts
        {
            get
            {
                return pappsts;
            }

            set
            {
                pappsts = value;
            }
        }
    }
    public class clsagtrevprp : intagtrev
    {
        private Int32 pagtrevcod, pagtrevagtcod, pagtrevusrcod, pagtrevprpcod, pagtrevscr;
        private String pagtrevtit, pagtrevdsc;
        private DateTime pagtrevdat;

        public int agtrevcod
        {
            get
            {
                return pagtrevcod;
            }

            set
            {
                pagtrevcod = value;
            }
        }

        public int agtrevagtcod
        {
            get
            {
                return pagtrevagtcod;
            }

            set
            {
                pagtrevagtcod = value;
            }
        }

        public int agtrevusrcod
        {
            get
            {
                return pagtrevusrcod;
            }

            set
            {
                pagtrevusrcod = value;
            }
        }

        public int agtrevprpcod
        {
            get
            {
                return pagtrevprpcod;
            }

            set
            {
                pagtrevprpcod = value;
            }
        }

        public DateTime agtrevdat
        {
            get
            {
                return pagtrevdat;
            }

            set
            {
                pagtrevdat = value;
            }
        }

        public string agtrevtit
        {
            get
            {
                return pagtrevtit;
            }

            set
            {
                pagtrevtit = value;
            }
        }

        public string agtrevdsc
        {
            get
            {
                return pagtrevdsc;
            }

            set
            {
                pagtrevdsc = value;
            }
        }

        public int agtrevscr
        {
            get
            {
                return pagtrevscr;
            }

            set
            {
                pagtrevscr = value;
            }
        }
    }


    //*********** abstract class
    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
    //************* main classes
    public class clscty : clscon
    {
        public void save_rec(clsctyprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("inscty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ctynam", SqlDbType.VarChar, 100).Value = p.ctynam;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void upd_rec(clsctyprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updcty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ctycod", SqlDbType.Int).Value = p.ctycod;
            cmd.Parameters.Add("@ctynam", SqlDbType.VarChar, 100).Value = p.ctynam;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clsctyprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delcty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ctycod", SqlDbType.Int).Value = p.ctycod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsctyprp> disp_rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispcty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsctyprp> obj = new List<clsctyprp>();
            while (dr.Read())
            {
                clsctyprp k = new clsctyprp();
                k.ctycod = Convert.ToInt32(dr[0]);
                k.ctynam = dr[1].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsctyprp> find_rec(Int32 ctycod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findcty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ctycod", SqlDbType.Int).Value = ctycod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsctyprp> obj = new List<clsctyprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsctyprp k = new clsctyprp();
                k.ctycod = Convert.ToInt32(dr[0]);
                k.ctynam = dr[1].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }
    }

    public class clsloc : clscon
    {
        public void save_rec(clslocprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insloc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@locnam", SqlDbType.VarChar, 100).Value = p.locnam;
            cmd.Parameters.Add("@locctycod", SqlDbType.Int).Value = p.locctycod;
            cmd.Parameters.Add("@loccrd", SqlDbType.VarChar, 200).Value = p.loccrd;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void upd_rec(clslocprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updloc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@loccod", SqlDbType.Int).Value = p.loccod;
            cmd.Parameters.Add("@locnam", SqlDbType.VarChar, 100).Value = p.locnam;
            cmd.Parameters.Add("@locctycod", SqlDbType.Int).Value = p.locctycod;
            cmd.Parameters.Add("@loccrd", SqlDbType.VarChar, 200).Value = p.loccrd;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clslocprp p)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delloc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@loccod", SqlDbType.Int).Value = p.loccod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clslocprp> disp_rec(Int32 ctycod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("disploc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ctycod", SqlDbType.Int).Value = ctycod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clslocprp> obj = new List<clslocprp>();
            while (dr.Read())
            {
                clslocprp k = new clslocprp();
                k.loccod = Convert.ToInt32(dr[0]);
                k.locnam = dr[1].ToString();
                k.locctycod = Convert.ToInt32(dr[2]);
                k.loccrd = dr[3].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clslocprp> find_rec(Int32 loccod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findloc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@loccod", SqlDbType.Int).Value = loccod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clslocprp> obj = new List<clslocprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clslocprp k = new clslocprp();
                k.loccod = Convert.ToInt32(dr[0]);
                k.locnam = dr[1].ToString();
                k.locctycod = Convert.ToInt32(dr[2]);
                k.loccrd = dr[3].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsprptyp : clscon
    {
        public void save_rec(clsprptypprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insprptyp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prptypnam", SqlDbType.VarChar, 100).Value = p.prptypnam;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void upd_rec(clsprptypprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updprptyp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prptypcod", SqlDbType.Int).Value = p.prptypcod;
            cmd.Parameters.Add("@prptypnam", SqlDbType.VarChar, 100).Value = p.prptypnam;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clsprptypprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delprptyp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prptypcod", SqlDbType.Int).Value = p.prptypcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsprptypprp> disp_rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispprptyp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprptypprp> obj = new List<clsprptypprp>();
            while (dr.Read())
            {
                clsprptypprp k = new clsprptypprp();
                k.prptypcod = Convert.ToInt32(dr[0]);
                k.prptypnam = dr[1].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsprptypprp> find_rec(Int32 prptypcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findprptyp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prptypcod", SqlDbType.Int).Value = prptypcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprptypprp> obj = new List<clsprptypprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsprptypprp k = new clsprptypprp();
                k.prptypcod = Convert.ToInt32(dr[0]);
                k.prptypnam = dr[1].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsfet : clscon
    {
        public void save_rec(clsfetprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fetdsc", SqlDbType.VarChar, 200).Value = p.fetdsc;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void upd_rec(clsfetprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fetcod", SqlDbType.Int).Value = p.fetcod;
            cmd.Parameters.Add("@fetdsc", SqlDbType.VarChar, 200).Value = p.fetdsc;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clsfetprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fetcod", SqlDbType.Int).Value = p.fetcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsfetprp> disp_rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsfetprp> obj = new List<clsfetprp>();
            while (dr.Read())
            {
                clsfetprp k = new clsfetprp();
                k.fetcod = Convert.ToInt32(dr[0]);
                k.fetdsc = dr[1].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsfetprp> find_rec(Int32 fetcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fetcod", SqlDbType.Int).Value = fetcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsfetprp> obj = new List<clsfetprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsfetprp k = new clsfetprp();
                k.fetcod = Convert.ToInt32(dr[0]);
                k.fetdsc = dr[1].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsagt : clscon
    {
        public DataSet dspagtprf(Int32 agtcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspagtprf", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@agtcod", SqlDbType.Int).Value = agtcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public DataSet dspagtrev(Int32 agtcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspagtrev", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@agtcod", SqlDbType.Int).Value = agtcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public DataSet dspagtbyloc(Int32 loccod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspagtbyloc", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@loccod", SqlDbType.Int).Value = loccod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public void save_rec(clsagtprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insagt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agtnam", SqlDbType.VarChar, 100).Value = p.agtnam;
            cmd.Parameters.Add("@agtloccod", SqlDbType.Int).Value = p.agtloccod;
            cmd.Parameters.Add("@agtser", SqlDbType.VarChar, 100).Value = p.agtser;
            cmd.Parameters.Add("@agtpic", SqlDbType.VarChar, 50).Value = p.agtpic;
            cmd.Parameters.Add("@agtprf", SqlDbType.NVarChar, 1000).Value = p.agtprf;
            cmd.Parameters.Add("@agtusrcod", SqlDbType.Int).Value = p.agtusrcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void upd_rec(clsagtprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updagt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agtcod", SqlDbType.Int).Value = p.agtcod;
          //  cmd.Parameters.Add("@agtnam", SqlDbType.VarChar, 100).Value = p.agtnam;
           // cmd.Parameters.Add("@agtloccod", SqlDbType.Int).Value = p.agtloccod;
            cmd.Parameters.Add("@agtser", SqlDbType.VarChar, 100).Value = p.agtser;
            cmd.Parameters.Add("@agtpic", SqlDbType.VarChar, 50).Value = p.agtpic;
            cmd.Parameters.Add("@agtprf", SqlDbType.NVarChar, 1000).Value = p.agtprf;
          //  cmd.Parameters.Add("@agtusrcod", SqlDbType.Int).Value = p.agtusrcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clsagtprp p)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delagt", con);
            cmd.Parameters.Add("@agtcod", SqlDbType.Int).Value = p.agtcod;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsagtprp> disp_rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispagt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsagtprp> obj = new List<clsagtprp>();
            while (dr.Read())
            {
                clsagtprp k = new clsagtprp();
                k.agtcod = Convert.ToInt32(dr[0]);
                k.agtnam = dr[1].ToString();
                k.agtloccod = Convert.ToInt32(dr[2]);
                k.agtser = dr[3].ToString();
                k.agtpic = dr[4].ToString();
                k.agtprf = dr[5].ToString();
                k.agtusrcod = Convert.ToInt32(dr[6]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsagtprp> find_rec(Int32 agtcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findagt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agtcod", SqlDbType.Int).Value = agtcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsagtprp> obj = new List<clsagtprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsagtprp k = new clsagtprp();
                k.agtcod = Convert.ToInt32(dr[0]);
                k.agtnam = dr[1].ToString();
                k.agtloccod = Convert.ToInt32(dr[2]);
                k.agtser = dr[3].ToString();
                k.agtpic = dr[4].ToString();
                k.agtprf = dr[5].ToString();
                k.agtusrcod = Convert.ToInt32(dr[6]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsusr : clscon
    {
        public Int32 logincheck(String eml,String pwd,out char rol)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("logincheck", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@eml", SqlDbType.VarChar, 100).Value = eml;
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 100).Value = pwd;
            cmd.Parameters.Add("@rol", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@cod", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            Int32 cod = Convert.ToInt32(cmd.Parameters["@cod"].Value);
            rol = Convert.ToChar(cmd.Parameters["@rol"].Value);
            con.Close();
            return cod;
        }

        public Int32 Save_Rec(clsusrprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insusr", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usreml", SqlDbType.VarChar, 100).Value = p.usreml;
            cmd.Parameters.Add("@usrpwd", SqlDbType.VarChar, 100).Value = p.usrpwd;
            cmd.Parameters.Add("@usrregdat", SqlDbType.DateTime).Value = p.usrregdat;
            cmd.Parameters.Add("@usrrol", SqlDbType.Char, 1).Value = p.usrrol;
cmd.Parameters.Add("@r", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@r"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }
        public void Upd_Rec(clsusrprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updusr", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usrcod", SqlDbType.Int).Value = p.usrcod;
            cmd.Parameters.Add("@usreml", SqlDbType.VarChar, 100).Value = p.usreml;
            cmd.Parameters.Add("@usrpwd", SqlDbType.VarChar, 100).Value = p.usrpwd;
            cmd.Parameters.Add("@usrregdat", SqlDbType.DateTime).Value = p.usrregdat;
            cmd.Parameters.Add("@usrrol", SqlDbType.Char, 1).Value = p.usrrol;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Del_Rec(clsusrprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delusr", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usrcod", SqlDbType.Int).Value = p.usrcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsusrprp> Disp_Rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispusr", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsusrprp> obj = new List<clsusrprp>();
            while (dr.Read())
            {
                clsusrprp k = new clsusrprp();
                k.usrcod = Convert.ToInt32(dr[0]);
                k.usreml = dr[1].ToString();
                k.usrpwd = dr[2].ToString();
                k.usrregdat = Convert.ToDateTime(dr[3]);
                k.usrrol = Convert.ToChar(dr[4]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }
        public List<clsusrprp> Find_Rec(Int32 usrcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findusr", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usrcod", SqlDbType.Int).Value = usrcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsusrprp> obj = new List<clsusrprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsusrprp k = new clsusrprp();
                k.usrcod = Convert.ToInt32(dr[0]);
                k.usreml = dr[1].ToString();
                k.usrpwd = dr[2].ToString();
                k.usrregdat = Convert.ToDateTime(dr[3]);
                k.usrrol = Convert.ToChar(dr[4]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsprp : clscon
    {
        public DataSet dspfav(Int32 usrcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspfav", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@usrcod", SqlDbType.Int).Value = usrcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public DataSet dspagtprp(Int32 agtcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspagtprp", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@agtcod", SqlDbType.Int).Value = agtcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public DataSet dspprpdet(Int32 prpcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspprpdet", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@prpcod", SqlDbType.Int).Value = prpcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public DataSet srcprp(Int32 loccod,Int32 prptypcod,char sts)
        {
            SqlDataAdapter adp = new SqlDataAdapter("srcprp", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@loccod", SqlDbType.Int).Value = loccod;
            adp.SelectCommand.Parameters.Add("@prptypcod", SqlDbType.Int).Value = prptypcod;
            adp.SelectCommand.Parameters.Add("@sts", SqlDbType.Char, 1).Value = sts;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }


        public Int32 save_rec(clsprpprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insprp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prptit", SqlDbType.VarChar, 100).Value = p.prptit;
            cmd.Parameters.Add("@prpagtcod", SqlDbType.Int).Value = p.prpagtcod;
            cmd.Parameters.Add("@prpprptypcod", SqlDbType.Int).Value = p.prpprptypcod;
            cmd.Parameters.Add("@prpadd", SqlDbType.VarChar, 200).Value = p.prpadd;
            cmd.Parameters.Add("@prpcrd", SqlDbType.VarChar, 200).Value = p.prpcrd;
            cmd.Parameters.Add("@prpsalsts", SqlDbType.Char, 1).Value = p.prpsalsts;
            cmd.Parameters.Add("@prpdsc", SqlDbType.VarChar, 2000).Value = p.prpdsc;
            cmd.Parameters.Add("@prpprc", SqlDbType.Float).Value = p.prpprc;
            cmd.Parameters.Add("@prplstdat", SqlDbType.DateTime).Value = p.prplstdat;
            cmd.Parameters.Add("@prpmanpiccod", SqlDbType.Int).Value = p.prpmanpiccod;
            cmd.Parameters.Add("@prpsts", SqlDbType.Char, 1).Value = p.prpsts;
cmd.Parameters.Add("@r", SqlDbType.Int).Direction = ParameterDirection
                                             .ReturnValue;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@r"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }
        public void updprp_rec(clsprpprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updprpdet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prptit", SqlDbType.VarChar, 100).Value = p.prptit;
            cmd.Parameters.Add("@prpagtcod", SqlDbType.Int).Value = p.prpagtcod;
            cmd.Parameters.Add("@prpprptypcod", SqlDbType.Int).Value = p.prpprptypcod;
            cmd.Parameters.Add("@prpadd", SqlDbType.VarChar, 200).Value = p.prpadd;
            cmd.Parameters.Add("@prpcrd", SqlDbType.VarChar, 200).Value = p.prpcrd;
            cmd.Parameters.Add("@prpsalsts", SqlDbType.Char, 1).Value = p.prpsalsts;
            cmd.Parameters.Add("@prpdsc", SqlDbType.VarChar, 2000).Value = p.prpdsc;
            cmd.Parameters.Add("@prpprc", SqlDbType.Float).Value = p.prpprc;
            cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = p.prpcod;
            cmd.ExecuteNonQuery();
           
            cmd.Dispose();
            con.Close();
            
        }
        public void upd_rec(clsprpprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updprp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = p.prpcod;
            cmd.Parameters.Add("@prpmanpiccod", SqlDbType.Int).Value = p.prpmanpiccod;
        
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void updprpsts(clsprpprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updprpsts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = p.prpcod;
            cmd.Parameters.Add("@prpsts", SqlDbType.Char,1).Value = p.prpsts;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clsprpprp p)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delprp", con);
            cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = p.prpcod;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsprpprp> disp_rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispprp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprpprp> obj = new List<clsprpprp>();
            while (dr.Read())
            {
                clsprpprp k = new clsprpprp();
                k.prpcod = Convert.ToInt32(dr[0]);
                k.prptit = dr[1].ToString();
                k.prpagtcod = Convert.ToInt32(dr[2]);
                k.prpprptypcod = Convert.ToInt32(dr[3]);
                k.prpadd = dr[4].ToString();
                k.prpcrd = dr[5].ToString();
                k.prpsalsts = Convert.ToChar(dr[6]);
                k.prpdsc = dr[7].ToString();
                k.prpprc = Convert.ToInt32(dr[8]);
                k.prplstdat = Convert.ToDateTime(dr[9]);
                k.prpmanpiccod = Convert.ToInt32(dr[10]);
                k.prpsts = Convert.ToChar(dr[11]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsprpprp> find_rec(Int32 prpcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findprp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = prpcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprpprp> obj = new List<clsprpprp>();
            if (dr.HasRows)
            {
                dr.Read();

                clsprpprp k = new clsprpprp();
                k.prpcod = Convert.ToInt32(dr[0]);
                k.prptit = dr[1].ToString();
                k.prpagtcod = Convert.ToInt32(dr[2]);
                k.prpprptypcod = Convert.ToInt32(dr[3]);
                k.prpadd = dr[4].ToString();
                k.prpcrd = dr[5].ToString();
                k.prpsalsts = Convert.ToChar(dr[6]);
                k.prpdsc = dr[7].ToString();
                k.prpprc = Convert.ToInt32(dr[8]);
                k.prplstdat = Convert.ToDateTime(dr[9]);
                k.prpmanpiccod = Convert.ToInt32(dr[10]);
                k.prpsts = Convert.ToChar(dr[11]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsprppic : clscon
    {
        public Int32 Save_Rec(clsprppicprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insprppic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prppicprpcod", SqlDbType.Int).Value = p.prppicprpcod;
            cmd.Parameters.Add("@prppicfil", SqlDbType.VarChar, 50).Value = p.prppicfil;
            cmd.Parameters.Add("@prppicdsc", SqlDbType.VarChar, 1000).Value = p.prppicdsc;
            cmd.Parameters.Add("@prppicsts", SqlDbType.Char, 1).Value = p.prppicsts;
            cmd.Parameters.Add("@r", SqlDbType.Int).Direction =
                         ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            Int32 a = Convert.ToInt32(cmd.Parameters["@r"].Value);
            cmd.Dispose();
            con.Close();
            return a;
        }
        public void Upd_Rec(clsprppicprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updprppic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prppiccod", SqlDbType.Int).Value = p.prppiccod;
            cmd.Parameters.Add("@prppicprpcod", SqlDbType.Int).Value = p.prppicprpcod;
            cmd.Parameters.Add("@prppicfil", SqlDbType.VarChar, 50).Value = p.prppicfil;
            cmd.Parameters.Add("@prppicdsc", SqlDbType.VarChar, 1000).Value = p.prppicdsc;
            cmd.Parameters.Add("@prppicsts", SqlDbType.Char, 1).Value = p.prppicsts;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Del_Rec(clsprppicprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delprppic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prppiccod", SqlDbType.Int).Value = p.prppiccod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsprppicprp> Disp_Rec(Int32 prpcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispprppic", con);
            cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = prpcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprppicprp> obj = new List<clsprppicprp>();
            while (dr.Read())
            {
                clsprppicprp k = new clsprppicprp();
                k.prppiccod = Convert.ToInt32(dr[0]);
                k.prppicprpcod = Convert.ToInt32(dr[1]);
                k.prppicfil = dr[2].ToString();
                k.prppicdsc = dr[3].ToString();
                k.prppicsts = Convert.ToChar(dr[4]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }
        public List<clsprppicprp> Find_Rec(Int32 prppiccod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findprppic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prppiccod", SqlDbType.Int).Value = prppiccod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprppicprp> obj = new List<clsprppicprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsprppicprp k = new clsprppicprp();
                k.prppiccod = Convert.ToInt32(dr[0]);
                k.prppicprpcod = Convert.ToInt32(dr[1]);
                k.prppicfil = dr[2].ToString();
                k.prppicdsc = dr[3].ToString();
                k.prppicsts = Convert.ToChar(dr[4]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsprpfet : clscon
    {
        public DataSet dispprpfet(Int32 prpcod)
        {
   SqlDataAdapter adp = new SqlDataAdapter("dispprpfet", con);
   adp.SelectCommand.CommandType = CommandType.StoredProcedure;
   adp.SelectCommand.Parameters.Add("@prpcod", SqlDbType.Int).Value =
                         prpcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public void Save_Rec(clsprpfetprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insprpfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpfetprpcod", SqlDbType.Int).Value = p.prpfetprpcod;
            cmd.Parameters.Add("@prpfetfetcod", SqlDbType.Int).Value = p.prpfetfetcod;
            cmd.Parameters.Add("@prpfetdsc", SqlDbType.VarChar, 1000).Value = p.prpfetdsc;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Upd_Rec(clsprpfetprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updprpfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpfetcod", SqlDbType.Int).Value = p.prpfetcod;
            cmd.Parameters.Add("@prpfetprpcod", SqlDbType.Int).Value = p.prpfetprpcod;
            cmd.Parameters.Add("@prpfetfetcod", SqlDbType.Int).Value = p.prpfetfetcod;
            cmd.Parameters.Add("@prpfetdsc", SqlDbType.VarChar, 1000).Value = p.prpfetdsc;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Del_Rec(clsprpfetprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delprpfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpfetcod", SqlDbType.Int).Value = p.prpfetcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsprpfetprp> Disp_Rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispprpfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprpfetprp> obj = new List<clsprpfetprp>();
            while (dr.Read())
            {
                clsprpfetprp k = new clsprpfetprp();
                k.prpfetcod = Convert.ToInt32(dr[0]);
                k.prpfetprpcod = Convert.ToInt32(dr[1]);
                k.prpfetfetcod = Convert.ToInt32(dr[2]);
                k.prpfetdsc = dr[3].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }
        public List<clsprpfetprp> Find_Rec(Int32 prpfetcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findprpfet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpfetcod", SqlDbType.Int).Value = prpfetcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsprpfetprp> obj = new List<clsprpfetprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsprpfetprp k = new clsprpfetprp();
                k.prpfetcod = Convert.ToInt32(dr[0]);
                k.prpfetprpcod = Convert.ToInt32(dr[1]);
                k.prpfetfetcod = Convert.ToInt32(dr[2]);
                k.prpfetdsc = dr[3].ToString();
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsfav : clscon
    {
        public void Save_Rec(clsfavprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insfav", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@favusrcod", SqlDbType.Int).Value = p.favusrcod;
            cmd.Parameters.Add("@favprpcod", SqlDbType.Int).Value = p.favprpcod;
            cmd.Parameters.Add("@favdat", SqlDbType.DateTime).Value = p.favdat;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Upd_Rec(clsfavprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updfav", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@favcod", SqlDbType.Int).Value = p.favcod;
            cmd.Parameters.Add("@favusrcod", SqlDbType.Int).Value = p.favusrcod;
            cmd.Parameters.Add("@favprpcod", SqlDbType.Int).Value = p.favprpcod;
            cmd.Parameters.Add("@favdat", SqlDbType.DateTime).Value = p.favdat;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Del_Rec(clsfavprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delfav", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@favcod", SqlDbType.Int).Value = p.favcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsfavprp> Disp_Rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispfav", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsfavprp> obj = new List<clsfavprp>();
            while (dr.Read())
            {
                clsfavprp k = new clsfavprp();
                k.favcod = Convert.ToInt32(dr[0]);
                k.favusrcod = Convert.ToInt32(dr[1]);
                k.favprpcod = Convert.ToInt32(dr[2]);
                k.favdat = Convert.ToDateTime(dr[3]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }
        public List<clsfavprp> Find_Rec(Int32 prpcod,Int32 usrcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findfav", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prpcod", SqlDbType.Int).Value = prpcod;
            cmd.Parameters.Add("@usrcod", SqlDbType.Int).Value = usrcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsfavprp> obj = new List<clsfavprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsfavprp k = new clsfavprp();
                k.favcod = Convert.ToInt32(dr[0]);
                k.favusrcod = Convert.ToInt32(dr[1]);
                k.favprpcod = Convert.ToInt32(dr[2]);
                k.favdat = Convert.ToDateTime(dr[3]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
    public class clsapp : clscon
    {

        public DataSet dspusrapp(Int32 usrcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dspusrapp", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@usrcod", SqlDbType.Int).Value = usrcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public DataSet dspapp(Int32 prpcod)
        {
            SqlDataAdapter adp = new SqlDataAdapter("dispapp", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@prpcod", SqlDbType.Int).Value = prpcod;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public void Save_Rec(clsappprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insapp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@appusrcod", SqlDbType.Int).Value = p.appusrcod;
            cmd.Parameters.Add("@appprpcod", SqlDbType.Int).Value = p.appprpcod;
            cmd.Parameters.Add("@appdat", SqlDbType.DateTime).Value = p.appdat;
            cmd.Parameters.Add("@appdsc", SqlDbType.VarChar, 2000).Value = p.appdsc;
            cmd.Parameters.Add("@appphn", SqlDbType.VarChar, 100).Value = p.appphn;
            cmd.Parameters.Add("@appsts", SqlDbType.Char, 1).Value = p.appsts;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void Upd_Rec(clsappprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updapp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@appcod", SqlDbType.Int).Value = p.appcod;
            cmd.Parameters.Add("@appusrcod", SqlDbType.Int).Value = p.appusrcod;
            cmd.Parameters.Add("@appprpcod", SqlDbType.Int).Value = p.appprpcod;
            cmd.Parameters.Add("@appdat", SqlDbType.DateTime).Value = p.appdat;
            cmd.Parameters.Add("@appdsc", SqlDbType.VarChar, 2000).Value = p.appdsc;
            cmd.Parameters.Add("@appphn", SqlDbType.VarChar, 100).Value = p.appphn;
            cmd.Parameters.Add("@appsts", SqlDbType.Char, 1).Value = p.appsts;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void Del_Rec(clsappprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delapp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@appcod", SqlDbType.Int).Value = p.appcod;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsappprp> Disp_Rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispapp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsappprp> obj = new List<clsappprp>();
            while (dr.Read())
            {
                clsappprp k = new clsappprp();
                k.appcod = Convert.ToInt32(dr[0]);
                k.appusrcod = Convert.ToInt32(dr[1]);
                k.appprpcod = Convert.ToInt32(dr[2]);
                k.appdat = Convert.ToDateTime(dr[3]);
                k.appdsc = dr[4].ToString();
                k.appphn = dr[5].ToString();
                k.appsts = Convert.ToChar(dr[6]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsappprp> Find_Rec(Int32 appcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findapp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@appcod", SqlDbType.Int).Value = appcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsappprp> obj = new List<clsappprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsappprp k = new clsappprp();
                k.appcod = Convert.ToInt32(dr[0]);
                k.appusrcod = Convert.ToInt32(dr[1]);
                k.appprpcod = Convert.ToInt32(dr[2]);
                k.appdat = Convert.ToDateTime(dr[3]);
                k.appdsc = dr[4].ToString();
                k.appphn = dr[5].ToString();
                k.appsts = Convert.ToChar(dr[6]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;

        }
    }
    public class clsagtrev : clscon
    {
        public void save_rec(clsagtrevprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insagtrev", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agtrevagtcod", SqlDbType.Int).Value = p.agtrevagtcod;
            cmd.Parameters.Add("@agtrevusrcod", SqlDbType.Int).Value = p.agtrevusrcod;
            cmd.Parameters.Add("@agtrevprpcod", SqlDbType.Int).Value = p.agtrevprpcod;
            cmd.Parameters.Add("@agtrevdat", SqlDbType.DateTime).Value = p.agtrevdat;
            cmd.Parameters.Add("@agtrevtit", SqlDbType.VarChar, 100).Value = p.agtrevtit;
            cmd.Parameters.Add("@agtrevdsc", SqlDbType.VarChar, 500).Value = p.agtrevdsc;
            cmd.Parameters.Add("@agtrevscr", SqlDbType.Int).Value = p.agtrevscr;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void upd_rec(clsagtrevprp p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("updagtrev", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agtrevcod", SqlDbType.Int).Value = p.agtrevcod;
            cmd.Parameters.Add("@agtrevagtcod", SqlDbType.Int).Value = p.agtrevagtcod;
            cmd.Parameters.Add("@agtrevusrcod", SqlDbType.Int).Value = p.agtrevusrcod;
            cmd.Parameters.Add("@agtrevprpcod", SqlDbType.Int).Value = p.agtrevprpcod;
            cmd.Parameters.Add("@agtrevdat", SqlDbType.DateTime).Value = p.agtrevdat;
            cmd.Parameters.Add("@agtrevtit", SqlDbType.VarChar, 100).Value = p.agtrevtit;
            cmd.Parameters.Add("@agtrevdsc", SqlDbType.VarChar, 500).Value = p.agtrevdsc;
            cmd.Parameters.Add("@agtrevscr", SqlDbType.Int).Value = p.agtrevscr;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void del_rec(clsagtrevprp p)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delagtrev", con);
            cmd.Parameters.Add("@agtrevcod", SqlDbType.Int).Value = p.agtrevcod;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public List<clsagtrevprp> disp_rec()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("dispagtrev", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsagtrevprp> obj = new List<clsagtrevprp>();
            while (dr.Read())
            {
                clsagtrevprp k = new clsagtrevprp();
                k.agtrevcod = Convert.ToInt32(dr[0]);
                k.agtrevagtcod = Convert.ToInt32(dr[1]);
                k.agtrevusrcod = Convert.ToInt32(dr[2]);
                k.agtrevprpcod = Convert.ToInt32(dr[3]);
                k.agtrevdat = Convert.ToDateTime(dr[4]);
                k.agtrevtit = dr[5].ToString();
                k.agtrevdsc = dr[6].ToString();
                k.agtrevscr = Convert.ToInt32(dr[7]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
        public List<clsagtrevprp> find_rec(Int32 agtrevcod)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("findagtrev", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agtrevcod", SqlDbType.Int).Value = agtrevcod;
            SqlDataReader dr = cmd.ExecuteReader();
            List<clsagtrevprp> obj = new List<clsagtrevprp>();
            if (dr.HasRows)
            {
                dr.Read();
                clsagtrevprp k = new clsagtrevprp();
                k.agtrevcod = Convert.ToInt32(dr[0]);
                k.agtrevagtcod = Convert.ToInt32(dr[1]);
                k.agtrevusrcod = Convert.ToInt32(dr[2]);
                k.agtrevprpcod = Convert.ToInt32(dr[3]);
                k.agtrevdat = Convert.ToDateTime(dr[4]);
                k.agtrevtit = dr[5].ToString();
                k.agtrevdsc = dr[6].ToString();
                k.agtrevscr = Convert.ToInt32(dr[7]);
                obj.Add(k);
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            return obj;
        }
    }
}
