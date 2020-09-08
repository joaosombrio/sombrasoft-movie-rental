namespace SombraSoft.MovieRental.MongoDB.DTO
{
    public class MemberSummary
    {
        public string MemberId { get; set; }
        public string MemberFullName { get; set; }
        public int TotalRentals { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
