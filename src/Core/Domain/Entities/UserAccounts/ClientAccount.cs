using Domain.ValueObjects;

namespace Domain.Entities.UserAccounts;

public sealed class ClientAccount : BaseAccount
{
    private ClientAccount()
    { }

    private ClientAccount(string idemPotencyKey, Guid userId, string login, string password, string role) : base(idemPotencyKey, userId, login, password)
    {
        if (role == null) throw new ArgumentNullException("Роль не может быть пустой");

        Role = ClientRole.Create(role);
    }

    /// <summary>Роль клиента</summary>
    public ClientRole Role { get; private set; } = null!;

    public static ClientAccount Create(string idemPotencyKey, Guid userId, string login, string password, string role)
    {
        ClientAccount createdClientAccount = new(idemPotencyKey, userId, login, password, role);
        return createdClientAccount;
    }
}