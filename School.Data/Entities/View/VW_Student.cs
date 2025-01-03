namespace School.Domain.Entities.View
{
    public class VW_Student
    {
        public int StudId { get; set; }
        public string NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? DepId { get; set; }
        public string DepartmentName { get; set; }

    }
}
