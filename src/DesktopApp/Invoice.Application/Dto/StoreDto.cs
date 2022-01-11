namespace Invoice.Application.Dto
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Detail { get; set; }
        public string? Fax { get; set; }
        public int IsMarket { get; set; }

        public StoreDto() {

        }

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