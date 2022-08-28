namespace Prince
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
            showForm(new Form2());
        }
        private void showForm(object form)
        {
            panel3.Controls.Clear();
            Form currentForm = form as Form;
            currentForm.TopLevel = false;
            currentForm.Dock = DockStyle.Fill;
            panel3.Tag = currentForm;
            panel3.Controls.Add(currentForm);
            currentForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Form4.utype == "Admin")
            {
                label4.Text = "Admin";
                button1.Enabled = false;
            }
            else if(Form4.utype == "Attendant")
            {
                label4.Text = "Attendant";
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showForm(new Form3());
            label2.Text = "User Account Management";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showForm(new Form2());
            label2.Text = "Home";
        }
        private void openApp(object form)
        {
            Application.Run(new Form4());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(openApp);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            showForm(new Form5());
            label2.Text = "Stock Management";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showForm(new Form6());
            label2.Text = "Transactions";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showForm(new Form7());
            label2.Text = "All Users";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showForm(new Form8());
            label2.Text = "Sales Report";
        }
    }
}