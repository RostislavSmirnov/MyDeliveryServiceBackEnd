using Domain.ValueObjects;

namespace Domain.Entities.User;

/// <summary>Общая сущнсоть пользователя для клиентов, и сотрудников</summary>
public class User
{
    private User()
    { }

    protected User(string idemPotencyKey, string name, string surname, string secondname, string email, string phoneNumber)
    {
        if (idemPotencyKey == null) throw new ArgumentNullException("Ключ идемпотентности не может быть пустым");

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Имя пользователя не может быть пустым");

        if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentNullException("Фамилия пользователя не может быть пустым");

        if (string.IsNullOrWhiteSpace(secondname)) throw new ArgumentNullException("Отчество пользователя не может быть пустым");

        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("Email пользователя не может быть пустым");

        if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentNullException("Номер телефона пользователя не может быть пустым");

        Id = new Guid();
        IdemPotencyKey = idemPotencyKey;
        Name = name;
        Surname = surname;
        SecondName = secondname;
        Email = Email.Create(email);
        PhoneNumber = PhoneNumber.Create(phoneNumber);
    }

    /// <summary>ID пользователя</summary>
    public Guid Id { get; protected set; }

    /// <summary>Ключ идемпотентнсоти</summary>
    public string IdemPotencyKey { get; private set; } = null!;

    /// <summary>Имя пользователя</summary>
    public string Name { get; protected set; } = null!;

    /// <summary>Фамилия пользователя</summary>
    public string Surname { get; protected set; } = null!;

    /// <summary>Отчество пользователя или второе имя</summary>
    public string SecondName { get; protected set; } = null!;

    /// <summary>Электронная почта пользователя</summary>
    public Email Email { get; protected set; } = null!;

    /// <summary>Номер телефона пользователя</summary>
    public PhoneNumber PhoneNumber { get; protected set; } = null!;

    public DateTime DateCreated { get; protected set; } = DateTime.Now;

    /// <summary>Создать нового пользователя</summary>
    /// <param name="name"></param>
    /// <param name="surname"></param>
    /// <param name="secondname"></param>
    /// <param name="email"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static User Create(string idemPotencyKey, string name, string surname, string secondname, string email, string phoneNumber)
    {
        User createdUser = new(idemPotencyKey, name, surname, secondname, email, phoneNumber);
        return createdUser;
    }

    /// <summary>Обновить данные пользователя</summary>
    /// <param name="name"></param>
    /// <param name="surname"></param>
    /// <param name="secondname"></param>
    /// <param name="email"></param>
    /// <param name="phoneNumber"></param>
    public void Update(string idemPotencyKey, string name, string surname, string secondname, string email, string phoneNumber)
    {
        if (!string.IsNullOrWhiteSpace(IdemPotencyKey)) throw new ArgumentNullException("Ключ идемпотентности не может быть пустым");

        if (!string.IsNullOrWhiteSpace(name)) Name = name;

        if (!string.IsNullOrWhiteSpace(surname)) Surname = surname;

        if (!string.IsNullOrWhiteSpace(secondname)) SecondName = secondname;

        if (!string.IsNullOrWhiteSpace(email)) Email = Email.Create(email);

        if (!string.IsNullOrWhiteSpace(phoneNumber)) PhoneNumber = PhoneNumber.Create(phoneNumber);
    }
}