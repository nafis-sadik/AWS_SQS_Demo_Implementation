namespace Models
{
    public class CabinFilters : IBaseFilter
    {
        public string? SupervisorId { get; set; }
        public bool? OnlyPublished { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberOfBeds { get; set; }
        public string? Search { get ; set; }
        public int pageSize { get ; set; }
        public int pageNumber { get ; set; }
        public string? Sort { get; set; }

        string IBaseModel.MessageTypeName { get { return nameof(CabinFilters); } set { return; } }
    }
}
