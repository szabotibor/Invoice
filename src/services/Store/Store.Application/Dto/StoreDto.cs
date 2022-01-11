namespace Store.Application.Dto
{
    public class StoreDto
    {
        public int Id { get; }
        public string Name { get; }
        public string Phone { get; }
        public string Address { get; }
        public string? ContactName { get; }
        public string? ContactPhone { get; }
        public string? Detail { get; }
        public string? Fax { get; }
        public int IsMarket { get; }


        public StoreDto(int id, string name, string phone, string address, string? contactName = null,
            string? contactPhone = null, string? detail = null, string? fax = null, int isMarket = 0)
        {
            ContactName = contactName;
            ContactPhone = contactPhone;
            Detail = detail;
            Fax = fax;
            IsMarket = isMarket;
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}