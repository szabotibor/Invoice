using Ardalis.GuardClauses;

namespace Store.Domain.Entity
{
    public class Store
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
        public bool IsMyStore { get; }

        public Store(string name, string phone, string address, string? contactName = null, string? contactPhone = null,
            string? detail = null, string? fax = null, int isMarket = 0, bool isMyStore = false)
        {
            ContactName = contactName;
            ContactPhone = contactPhone;
            Detail = detail;
            Fax = fax;
            IsMarket = isMarket;
            IsMyStore = isMyStore;
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Address = Guard.Against.NullOrEmpty(address, nameof(address));
        }

        public Store(int id, string name, string phone, string address, string? contactName = null,
            string? contactPhone = null, string? detail = null, string? fax = null, int isMarket = 0, bool isMyStore = false)
        {
            ContactName = contactName;
            ContactPhone = contactPhone;
            Detail = detail;
            Fax = fax;
            IsMarket = isMarket;
            IsMyStore = isMyStore;
            Id = id;
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Address = Guard.Against.NullOrEmpty(address, nameof(address));
        }
    }
}