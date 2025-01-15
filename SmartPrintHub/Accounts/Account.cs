public class Account
{
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public bool IsAdmin { get; set; }
    public Account(string userName, string password)
    {
        UserName = userName;
        Password = password;
        IsAdmin = false;
    }
}