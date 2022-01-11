namespace Store.Application.Dto
{
    public class AddStorePayload
    {
        public string Name { get; }
        public string Phone { get; }
        public string Address { get; }
        public string? ContactName { get; }
        public string? ContactPhone { get; }
        public string? Detail { get; }
        public string? Fax { get; }
        public int IsMarker { get; }


        public AddStorePayload(string name, string phone, string address, string? contactName = null,
            string? contactPhone = null, string? detail = null, string? fax = null, int isMarker = 0)
        {
            ContactName = contactName;
            ContactPhone = contactPhone;
            Detail = detail;
            Fax = fax;
            IsMarker = isMarker;
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}