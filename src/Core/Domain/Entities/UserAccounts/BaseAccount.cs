using System.Data;

namespace Domain.Entities.UserAccounts;

/// <summary>Класс базы для создания аккаунта</summary>
public class BaseAccount
{
    protected BaseAccount()
    { }

    protected BaseAccount(string idemPotencyKey, Guid userId, string login, string password)
    {
        if (idemPotencyKey == null) throw new ArgumentNullException("Ключ идемпотентности не может быть пустым");

        if (login == null) throw new ArgumentNullException("Логин не может быть пустым");

        if (password == null) throw new ArgumentNullException("Пароль не может быть пустым");

        UserId = userId;
        Login = login;
        HashPassword = password;
    }

    /// <summary>ID аккаунта</summary>
    public Guid Id { get; protected set; }

    /// <summary>Ключ идемпотентнсоти</summary>
    public string IdemPotencyKey { get; private set; } = null!;

    /// <summary>ID пользователя которому пренадлежит аккаунт</summary>
    public Guid UserId { get; protected set; }

    /// <summary>Логин аккаунта</summary>
    public string Login { get; protected set; } = null!;

    /// <summary>хэшированный пароль от аккаунта </summary>
    public string HashPassword { protected get; set; } = null!;

    /// <summary>Дата создания аккаунта</summary>
    public DateTime DateCreated { get; protected set; }
}