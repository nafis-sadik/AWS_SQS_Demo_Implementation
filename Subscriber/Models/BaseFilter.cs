using System.Text.Json.Serialization;

namespace Models
{
    public interface IBaseFilter: IBaseModel
    {
        public string? Search { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string Sort { get; set; }

        public int PageNumber
        {
            get => pageNumber;
            set => pageNumber = value is <= 0 ? 1 : value;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value is <= 0 ? 10 : value;
        }
    }
}
