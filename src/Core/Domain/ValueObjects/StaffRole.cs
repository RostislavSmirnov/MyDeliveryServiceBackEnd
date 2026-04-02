namespace Domain.ValueObjects;

public sealed record StaffRole
{
    private StaffRole(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static readonly StaffRole PostalOfficeClerk = new("PostalOfficeClerk");
    public static readonly StaffRole Manager = new("Manager");

    public static StaffRole Create(string? roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentException("Роль не может быть пустой", nameof(roleName));

        var normalized = roleName.Trim().ToLowerInvariant();

        return normalized switch
        {
            "postalofficeclerk" or "postalclerk" or "clerk" => PostalOfficeClerk,
            "manager" => Manager,
            _ => throw new ArgumentException($"Неизвестная роль: {roleName}", nameof(roleName))
        };
    }
    public bool IsPostalClerk => this == PostalOfficeClerk;
    public bool IsManager => this == Manager;

    public override string ToString() => Value;
}