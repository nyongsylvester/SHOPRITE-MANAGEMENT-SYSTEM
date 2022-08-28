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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();
            if (textBox4.Text != "")
            {
                try
                {
                    string countQuery = "select * from category where name = '" + textBox4.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        label7.Visible = true;
                        label7.Text = "Category exist already";
                        label7.ForeColor = Color.Crimson;
                    }
                    else
                    {
                        db.openConnection();
                        string query = "insert into category (dat, name) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox4.Text + "')";
                        command = new MySqlCommand(query, db.connection);
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        label7.Visible = true;
                        label7.Text = "Category added";
                        label7.ForeColor = Color.Green;
                    }
                }
                catch(Exception ex)
                {
                    label7.Visible = true;
                    label7.Text = ex.Message;
                    label7.ForeColor = Color.Crimson;
                }
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Enter a name for the category";
                label7.ForeColor = Color.Crimson;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();
            if (textBox4.Text != "")
            {
                try
                {
                    string countQuery = "select * from category where name = '" + textBox4.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        db.openConnection();
                        string query = "delete from category where name = '" + textBox4.Text + "' ";
                        command = new MySqlCommand(query, db.connection);
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        label7.Visible = true;
                        label7.Text = "Category deleted";
                        label7.ForeColor = Color.Green;

                    }
                    else
                    {
                        label7.Visible = true;
                        label7.Text = "Category doesn't exist";
                        label7.ForeColor = Color.Crimson;
                    }
                }
                catch (Exception ex)
                {
                    label7.Visible = true;
                    label7.Text = ex.Message;
                    label7.ForeColor = Color.Crimson;
                }
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Enter a name for the category";
                label7.ForeColor = Color.Crimson;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();
            if(textBox2.Text!="" & textBox3.Text!="" & textBox5.Text!="" & comboBox1.Text != "")
            {
                try
                {
                    string query = "insert into stock(dat, product, category, quantity, price) values ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "')";
                    command = new MySqlCommand(query, db.connection);
                    command.ExecuteNonQuery();
                    label5.Visible = true;
                    label5.Text = "Stock added";
                    label5.ForeColor = Color.Green;
                    db.closeConnection();
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
                label5.Text = "Complete the required fileds";
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
                    string countQuery = "select * from stock where id = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        db.openConnection();
                        string query = "delete from stock where id = '" + textBox1.Text + "' ";
                        command = new MySqlCommand(query, db.connection);
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        label5.Visible = true;
                        label5.Text = "Stock deleted";
                        label5.ForeColor = Color.Green;
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.Text = "There's no such stock";
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
                label5.Text = "Enter the ID of the stock";
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
                    string countQuery = "select * from stock where id = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuery, db.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    db.closeConnection();
                    if (count > 0)
                    {
                        if(textBox2.Text=="" & textBox3.Text=="" & textBox5.Text=="" & comboBox1.Text == "")
                        {
                            label5.Visible = true;
                            label5.Text = "Enter something to update";
                            label5.ForeColor = Color.Crimson;
                        }
                        else
                        {
                           

                            if (textBox2.Text != "")
                            {
                                db.openConnection();
                                string query = "update stock set product = '" + textBox2.Text + "' where id = '"+textBox1.Text+"'";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                            }

                            if (textBox3.Text != "")
                            {
                                db.openConnection();
                                string query = "update stock set quantity = '" + textBox3.Text + "'  where id = '" + textBox1.Text + "'";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                            }

                            if (textBox5.Text != "")
                            {
                                db.openConnection();
                                string query = "update stock set price = '" + textBox5.Text + "'  where id = '" + textBox1.Text + "'";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                            }

                            if (comboBox1.Text != "")
                            {
                                db.openConnection();
                                string query = "update stock set category = '" + comboBox1.Text + "'  where id = '" + textBox1.Text + "'";
                                command = new MySqlCommand(query, db.connection);
                                command.ExecuteNonQuery();
                            }

                            db.closeConnection();
                            label5.Visible = true;
                            label5.Text = "Stock updated";
                            label5.ForeColor = Color.Green;

                        }
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.Text = "There's no such stock";
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
                label5.Text = "Enter the Id of the stock";
                label5.ForeColor = Color.Crimson;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            db.openConnection();
            string query = "select id, name from category";
            MySqlCommand command = new MySqlCommand(query, db.connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //DataRow item = dt.NewRow();
            //item[1] = "categories";
            //dt.Rows.InsertAt(item, 0);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }
    }
}
