namespace Store.Application.Dto
{
    public class UpdateStorePayload
    {
        public string Name { get; }
        public string Phone { get; }
        public string Address { get; }
        public int Id { get; }
        public string? ContactName { get; }
        public string? ContactPhone { get; }
        public string? Detail { get; }
        public string? Fax { get; }
        public int IsMarket { get; }


        public UpdateStorePayload(int id, string name, string phone, string address, string? contactName = null,
            string? contactPhone = null, string? detail = null, string? fax = null, int isMarket = 0)
        {
            Id = id;
            ContactName = contactName;
            ContactPhone = contactPhone;
            Detail = detail;
            Fax = fax;
            IsMarket = isMarket;
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}