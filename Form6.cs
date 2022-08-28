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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            db.openConnection();
            if(textBox2.Text!="" & textBox3.Text!="" & textBox5.Text!="" & comboBox1.Text!="" & comboBox2.Text != "")
            {
                try
                {
                    string query = "insert into trans(dat, cust, category, product, quantity, price) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox2.Text + "', '" + comboBox2.Text + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "' )";
                    command = new MySqlCommand(query, db.connection);
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    label5.Visible = true;
                    label5.Text = "Transaction posted";
                    label5.ForeColor = Color.Green;
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
                string countQuery = "select * from trans where id = '" + textBox1.Text + "' ";
                command = new MySqlCommand(countQuery, db.connection);
                Int32 count = Convert.ToInt32(command.ExecuteScalar());
                db.closeConnection();
                if (count > 0)
                {
                    db.openConnection();
                    string query = "delete from trans where id = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(query, db.connection);
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    label5.Visible = true;
                    label5.Text = "Transaction deleted";
                    label5.ForeColor = Color.Green;
                }
                else
                {
                    label5.Visible = true;
                    label5.Text = "There's no such transaction";
                    label5.ForeColor = Color.Crimson;
                }
            }
            else
            {
                label5.Visible = true;
                label5.Text = "Enter transaction ID";
                label5.ForeColor = Color.Crimson;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                string query = "select id, product from stock where category = '" + comboBox2.Text + "' ";
                MySqlCommand command = new MySqlCommand(query, db.connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "product";
                comboBox1.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                textBox3.Text = "";
                e.Handled = true;
            }
        }

        private void Form6_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
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

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id";
                textBox5.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int val;
            bool result = int.TryParse(textBox3.Text, out val);
            if (!result)
            {
                textBox3.Text = null;
            }
            else
            {
                if (textBox3.Text != null & Convert.ToDouble(textBox3.Text) > 0)
                {
                    db.openConnection();
                    MySqlCommand command;
                    try
                    {
                        string query = "select price from stock where product = '" + comboBox1.Text + "' ";
                        command = new MySqlCommand(query, db.connection);
                        MySqlDataReader price = command.ExecuteReader();
                        price.Read();
                        double setPrice = Convert.ToDouble(price.GetValue(0).ToString()) * Convert.ToDouble(textBox3.Text);
                        textBox5.Text = setPrice.ToString();
                        db.closeConnection();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //tPrice.Text = price.GetValue(0).ToString();
                }

                else
                {
                    textBox5.Text = "0.00";
                }
            }
        }
    }
}
