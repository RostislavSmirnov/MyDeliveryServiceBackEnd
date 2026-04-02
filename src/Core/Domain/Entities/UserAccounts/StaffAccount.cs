using Domain.ValueObjects;

namespace Domain.Entities.UserAccounts;

public sealed class StaffAccount : BaseAccount
{
    private StaffAccount()
    { }

    private StaffAccount(string idemPotencyKey, Guid userId, string login, string password, string role) : base(idemPotencyKey, userId, login, password)
    {
        if (role == null) throw new ArgumentNullException("Роль не может быть пустой");

        Role = StaffRole.Create(role);
    }

    /// <summary>Роль сотрудника</summary>
    public StaffRole Role { get; private set; } = null!;

    public static StaffAccount Create(string idemPotencyKey, Guid userId, string login, string password, string role)
    {
        StaffAccount createdStaffAccount = new(idemPotencyKey, userId, login, password, role);
        return createdStaffAccount;
    }
}