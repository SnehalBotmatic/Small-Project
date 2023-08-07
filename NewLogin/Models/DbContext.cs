using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace NewLogin.Models
{
    
    public class DbContext
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public List<LoginViewModel> GetUser()
        {
            List<LoginViewModel> lst = new List<LoginViewModel>();
            SqlCommand cmd = new SqlCommand("select * from users", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();//source where we can get info so we have data reader and data table
            adp.Fill(dt);//adapter will fill, update or do connection automatically
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new LoginViewModel
                {
                    ID = Convert.ToInt32(dr[0]),
                    Emailid = Convert.ToString(dr[1]),
                    Password = Convert.ToString(dr[2])

                });

            }
            return lst;
        }

        public List<LoginViewModel> GetById(string email)
        {
            List<LoginViewModel> lst = new List<LoginViewModel>();
            SqlCommand cmd = new SqlCommand("select * from users where emailid= '" + email + "'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new LoginViewModel
                {
                    ID = Convert.ToInt32(dr[0]),
                    Emailid = Convert.ToString(dr[1]),
                    Password = Convert.ToString(dr[2])

                });

            }
            return lst;
        }
    }
}