using System.Text.Json;
public class AccountManager
{
    private List<Account> accounts = new List<Account>();
    public AccountManager()
    {
        LoadFromJson();
    }
    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }
    public bool login(string userName, string password)
    {
        foreach (Account account in accounts)
        {
            if (account.UserName == userName && account.Password == password)
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckForAdmin(string username, string password)
    {
        var account = accounts.Find(account => account.UserName == username && account.Password == password);
        return account != null && account.IsAdmin;
    }

    public void Register(string userName, string password)
    {
        Account account = new Account(userName, password);
        AddAccount(account);
    }
    public void LoadFromJson()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string jsonString = File.ReadAllText("accounts.json");
        accounts = JsonSerializer.Deserialize<List<Account>>(jsonString, options);
    }
    public void SaveToJson()
    {
        string jsonString = JsonSerializer.Serialize(accounts);
        File.WriteAllText("accounts.json", jsonString);
    }
}