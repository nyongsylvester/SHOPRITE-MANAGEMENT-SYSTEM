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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static string randPass = RandomString(8);

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();

            if(textBox1.Text!="" & textBox2.Text!=""  & comboBox1.Text != "")
            {
                try
                {
                    string countQuery = "select * from users where uname = '" + textBox1.Text + "' or uemail = '" + textBox2.Text + "'";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        label5.Visible = true;
                        label5.Text = "User already exists";
                        label5.ForeColor = Color.Crimson;
                    }
                    else
                    {
                        db.openConnection();
                        string query = "insert into users(uname, uemail, upass, utype) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + randPass + "', '" + comboBox1.Text + "')";
                        command = new MySqlCommand(query, db.connection);
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        label5.Visible = true;
                        label5.Text = "User created";
                        label5.ForeColor = Color.Green;
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
                label5.Text = "Complete the required fields";
                label5.ForeColor = Color.Crimson;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();

            if (textBox1.Text != "")
            {
                try
                {
                    string countQuery = "select * from users where uname = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                       

                        db.openConnection();
                        string query = "delete from users where uname = '" + textBox1.Text + "' ";
                        command = new MySqlCommand(query, db.connection);
                        command.ExecuteNonQuery();
                        db.closeConnection();

                        label5.Visible = true;
                        label5.Text = "User deleted";
                        label5.ForeColor = Color.Green;
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.Text = "User doesn't exist";
                        label5.ForeColor = Color.Crimson;
                    }
                }
                catch (Exception ex)
                {
                    label5.Visible = true;
                    label5.Text = ex.Message;
                    label5.ForeColor = Color.Crimson;
                }
            }
            else
            {
                label5.Visible = true;
                label5.Text = "Enter username to delete";
                label5.ForeColor = Color.Crimson;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();

            if (textBox1.Text != "")
            {
                try
                {
                    string countQuery = "select * from users where uname = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        if(textBox2.Text=="" & textBox3.Text=="" & comboBox1.Text == "")
                        {
                            label5.Visible = true;
                            label5.Text = "Enter something to update";
                            label5.ForeColor = Color.Crimson;
                        }
                        else
                        {
                            db.openConnection();
                            if (textBox2.Text != "")
                            {
                                db.openConnection();
                                string query = "update users set uemail = '" + textBox2.Text + "' where uname = '" + textBox1.Text + "' ";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                                db.closeConnection();
                            }

                            if (textBox3.Text != "" & textBox3.Text.Length >= 8)
                            {
                                db.openConnection();
                                string query = "update users set upass = '" + textBox3.Text + "' where uname = '" + textBox1.Text + "' ";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                                db.closeConnection();
                            }
                            

                            if (comboBox1.Text != "")
                            {
                                db.openConnection();
                                string query = "update users set utype = '" + comboBox1.Text + "' where uname = '" + textBox1.Text + "' ";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                                db.closeConnection();
                            }


                            label5.Visible = true;
                            label5.Text = "User updated successfully";
                            label5.ForeColor = Color.Green;
                        }
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.Text = "User doesn't exist";
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
                label5.Text = "Enter username to update";
                label5.ForeColor = Color.Crimson;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            if (Form4.utype == "Attendant")
            {
                button1.Enabled = false;
                button3.Enabled = false;
                comboBox1.Enabled = false;
                textBox3.Enabled = false;
            }
        }
    }
}
