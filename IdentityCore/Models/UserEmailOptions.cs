namespace IdentityCore.Models
{
    public class UserEmailOptions
    {
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; }
    }
}
