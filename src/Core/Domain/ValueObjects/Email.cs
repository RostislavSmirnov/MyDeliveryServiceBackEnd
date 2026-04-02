using System.Text.RegularExpressions;

namespace Domain.ValueObjects;
/// <summary>Свойство для почты</summary>
public sealed record Email
{
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    // Приватный конструктор — чтобы нельзя было создать экземпляр без валидации
    private Email(string value)
    {
        Value = value;
    }

    /// <summary>Фабричный метод основной способ создания Email</summary>
    public static Email Create(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("Email не может быть пустым.", nameof(email));

        //Trim для удаления проблелов по краям
        var trimmed = email.Trim();

        if (trimmed.Length > 254) throw new ArgumentException("Email слишком длинный (максимум 254 символа).", nameof(email));

        if (!EmailRegex.IsMatch(trimmed)) throw new ArgumentException("Некорректный формат email-адреса.", nameof(email));

        if (!trimmed.Contains('@') || trimmed.Split('@')[1].Split('.').Length < 2) throw new ArgumentException("Некорректный формат email-адреса.", nameof(email));

        return new Email(trimmed.ToLowerInvariant());
    }
}