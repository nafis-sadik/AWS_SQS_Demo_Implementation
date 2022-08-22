namespace Models
{
    public class Cabin : IBaseModel
    {
        public string Id { get; set; }

        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? About { get; set; }
        public int NumberOfBeds { get; set; }

        string IBaseModel.MessageTypeName { get { return nameof(Cabin); } set { return; } }
    }
}
