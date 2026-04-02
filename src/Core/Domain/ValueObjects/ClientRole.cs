namespace Domain.ValueObjects;
/// <summary>Свойство для ролей клиентов</summary>
public sealed record ClientRole
{
    private ClientRole(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static readonly ClientRole StandardClient = new("StandardClient");
    public static readonly ClientRole VipClient = new("VipClient");

    public static ClientRole Create(string? roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentNullException("Роль не может быть пустой", nameof(roleName));

        string normalized = roleName.Trim().ToLowerInvariant();

        return normalized switch
        {
            "StandartClient" or "client" or "standartclient" => StandardClient,
            "VipClient" or "Vip" => VipClient,
            _ => throw new ArgumentException($"Неизвестная роль: {roleName}", nameof(roleName))
        };
    }
    public bool IsStandardClient => this == StandardClient;
    public bool IsVipClient => this == VipClient;

    public override string ToString() => Value;
}