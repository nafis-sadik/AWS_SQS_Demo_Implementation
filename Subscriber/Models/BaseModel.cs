namespace Models
{
    public interface IBaseModel
    {
        public string MessageTypeName { get; set; }
    }

    public class BaseModel: IBaseModel
    {
        public string MessageTypeName { get; set; }
    }
}
