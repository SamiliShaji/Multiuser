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
    public partial class Login : System.Web.UI.Page
    {
        Class1 conobj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select Count(Reg_Id) from Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = conobj.fn_Scalar(s);
            int cid1 = Convert.ToInt32(cid);
            if(cid1==1)
            {
                string str1 = "select Reg_Id from Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string regid = conobj.fn_Scalar(str1);
                Session["userid"] = regid;
                string str2 = "select Log_Type from Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string logtype = conobj.fn_Scalar(str2);
                if(logtype=="Admin")//Admin ennullath Login table il engane aahno athe pole thanne kodukkanam
                {
                    Label3.Text = "Admin";
                }
                else if (logtype == "User")//same as Login table
                                           
                {
                    Label3.Text = "User";
                }
            }
            else
            {
                Label3.Text = "Invalid Username and Password";
            }
        }
    }
}