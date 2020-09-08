namespace SombraSoft.MovieRental.MongoDB.Collections
{
    public class Member : BaseCollection
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
