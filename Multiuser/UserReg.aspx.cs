using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Multiuser
{
    public partial class UserReg : System.Web.UI.Page
    {
        Class1 conobj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_Id) from Login";
            string regid = conobj.fn_Scalar(sel);
            int reg_id = 0;
            if(regid=="")
            {
                reg_id = 1;
            }

            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string ins = "insert into Userreg values(" + reg_id + ",'" + TextBox1.Text + "'," + TextBox2.Text + ")";
            int i = conobj.fn_Non_Query(ins);
            if(i==1)
            {
                string inslog = "insert into Login values(" + reg_id + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','User','active')";
                int j= conobj.fn_Non_Query(inslog);
            }
        }
    }
}