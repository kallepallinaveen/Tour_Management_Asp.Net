using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Tour_Management
{
    public partial class userlogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Btn_Submit(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string passwordInput = txtPassword.Text.Trim();

            using (SqlConnection conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                conn.Open();

                string query = "SELECT password FROM Userinfo WHERE email = @email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);

                object result = cmd.ExecuteScalar();

                if (result != null && result.ToString() == passwordInput)
                {
                    // Success
                    Response.Redirect("MainProfilePage.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    // Failure
                    Response.Write("Password is not correct");
                }
            }
        }

        protected void Btn_reg(object sender, EventArgs e)
        {
            Response.Redirect("SignUpForm.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
