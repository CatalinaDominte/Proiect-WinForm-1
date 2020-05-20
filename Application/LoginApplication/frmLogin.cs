using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Data;

namespace LoginApplication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //Connection String
       // string cs = "Data Source=.;Initial Catalog=winform;Integrated Security=True";
        //btn_Submit Click event
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_UserName.Text=="" || txt_Password.Text=="")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            
            
                //Create SqlConnection
                using (var connection = DB.GetConnection())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Select * from Login where UserName=@username and Password=@password", connection);
                        cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                        cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                        connection.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapt.Fill(ds);
                      connection.Close();

                        int count = ds.Tables[0].Rows.Count;
                    //If count is equal to 1, than show frmMain form
                    connection.Close();
                    if (count == 1)
                        {
                            MessageBox.Show("Login Successful!");
                            this.Hide();
                            frmMain fm = new frmMain();
                            fm.Show();
                            connection.Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("Login Failed!");
                        }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Source);
                }

            }


            
           
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        
    }
}
