namespace WinFormsApp1
{
    public partial class LoginPage : Form
    {
        private AccountManager accountManager = new AccountManager();
        public LoginPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (accountManager.login(username, password))
            {
                if (accountManager.CheckForAdmin(username, password))
                {
                    Admin adminForm = new Admin();
                    adminForm.Show();
                }
                else
                {
                    User userForm = new User();
                    userForm.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password");
                return;
            }
            accountManager.AddAccount(new Account(textBox1.Text, textBox2.Text));
            accountManager.SaveToJson();
            MessageBox.Show("Account added please login");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
