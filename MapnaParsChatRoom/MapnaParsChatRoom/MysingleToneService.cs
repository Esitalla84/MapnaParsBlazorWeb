namespace MapnaParsChatRoom;

public class MysingleToneService
{
    public event EventHandler OnChanged;
    List<string> ListUsers { get; set; } = new List<string>();
    public void AddToListUsers(string user)
    {
        ListUsers.Add(user);
        OnChanged?.Invoke(this, EventArgs.Empty);
    }
    public bool IsExisted(string user)
    {
        if (ListUsers.Any(q => q == user)) return true;
        return false;
    }
    public string ListUsersString => string.Join(Environment.NewLine,
        ListUsers);

    List<(string Name, string Text, DateTime dt)> ListChatText { get; set; } = new();
    public void AddToListchattext(string Name, string Text, DateTime dt)
    {
        ListChatText.Add((Name, Text, dt));
        OnChanged?.Invoke(this, EventArgs.Empty);
    }


    public string ListChatTextString => string.Join(Environment.NewLine,
        ListChatText.Select(q => $"{q.Name} {q.dt.ToString("HH:mm:ss")}: {q.Text}"));
}
