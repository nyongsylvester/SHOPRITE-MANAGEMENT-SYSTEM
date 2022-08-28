using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prince
{
    public partial class Form4 : Form
    {
        Thread thread;
        public static string utype;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openApp(object form)
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();
            if(textBox1.Text!="" & textBox3.Text != "")
            {
                try
                {
                    string countQuery = "select * from users where uname = '" + textBox1.Text + "' and upass = '" + textBox3.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        db.openConnection();
                        string typeQuery = "select utype from users where uname =  '" + textBox1.Text + "' ";
                        command = new MySqlCommand(typeQuery, db.connection);
                        MySqlDataReader rd = command.ExecuteReader();
                        rd.Read();
                        //Form1.instance.tb1.Text = rd.GetValue(0).ToString();
                        utype = rd.GetValue(0).ToString();
                        //MessageBox.Show(utype);
                        db.closeConnection();

                        this.Close();
                        thread = new Thread(openApp);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();

                        
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.Text = "Incorrect email or password";
                        label5.ForeColor = Color.Crimson;
                    }
                }
                catch(Exception ex)
                {
                    label5.Visible = true;
                    label5.Text = ex.Message;
                    label5.ForeColor = Color.Crimson;
                }
            }
            else
            {
                label5.Visible = true;
                label5.Text = "username and password are required";
                label5.ForeColor = Color.Crimson;
            }
        }
    }
}
