namespace Models
{
    public class User: IBaseModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        string IBaseModel.MessageTypeName { get => nameof(User); set { return; } }
    }
}
