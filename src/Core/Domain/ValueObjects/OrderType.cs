namespace Domain.ValueObjects
{
    public sealed record OrderType
    {
        public OrderType(string value)
        {
            Value = value;
        }
        public string Value { get; }
        public static readonly OrderType Standard = new("Standard");
        public static readonly OrderType Vip = new("Vip");

        public static OrderType Create(string orderType)
        {
            if (string.IsNullOrWhiteSpace(orderType))
                throw new ArgumentException("Тип не может быть пустым", nameof(orderType));

            string normalized = orderType.Trim().ToLowerInvariant();

            return normalized switch
            {
                "Standard" or "Base" or "standard" => Standard,
                "Vip" or "vip" => Vip,
                _ => throw new ArgumentException($"Неизвестная тип заказа: {orderType}", nameof(orderType))
            };
        }
        public bool IsStandardOrder => this == Standard;
        public bool IsVip => this == Vip;

        public override string ToString() => Value;
    }
}