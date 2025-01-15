namespace WinFormsApp1
{
    public partial class Login : Form
    {
        private AccountManager accountManager = new AccountManager();
        public Login()
        {
            InitializeComponent();
            accountManager.AddAccount(new Account("adminUser", "123") { IsAdmin = true });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (accountManager.login(username, password))
            {
                MessageBox.Show($"{accountManager.CheckForAdmin(username, password)}");
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
            accountManager.AddAccount(new Account(textBox1.Text, textBox2.Text));
            accountManager.SaveToJson();    
            MessageBox.Show("Account added pleas login");
        }
    }
}
