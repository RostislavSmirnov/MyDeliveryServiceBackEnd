using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public sealed record PhoneNumber
{
    // Простое, но надёжное регулярное выражение для международных номеров
    private static readonly Regex PhoneRegex = new(
        @"^\+?[1-9]\d{1,14}$",
        RegexOptions.Compiled);

    public string Value { get; }

    // Приватный конструктор
    private PhoneNumber(string value)
    {
        Value = value;
    }

    /// <summary>Фабричный метод для создания PhoneNumber</summary>
    public static PhoneNumber Create(string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Номер телефона не может быть пустым.", nameof(phoneNumber));

        var trimmed = phoneNumber.Trim();

        // Убираем все пробелы, тире, скобки и точки для нормализации
        var cleaned = Regex.Replace(trimmed, @"[\s\-\(\)\.]", "");

        if (string.IsNullOrEmpty(cleaned)) throw new ArgumentException("Номер телефона не может быть пустым после очистки.", nameof(phoneNumber));

        // Проверка длины (E.164 рекомендует максимум 15 цифр)
        if (cleaned.Length > 15) throw new ArgumentException("Номер телефона слишком длинный (максимум 15 цифр).", nameof(phoneNumber));

        if (!PhoneRegex.IsMatch(cleaned)) throw new ArgumentException("Некорректный формат номера телефона. Используйте международный формат (например: +79161234567).", nameof(phoneNumber));

        // Дополнительная проверка: должен начинаться с + или цифры
        if (!cleaned.StartsWith("+") && !char.IsDigit(cleaned[0])) throw new ArgumentException("Номер телефона должен начинаться с '+' или цифры.", nameof(phoneNumber));

        return new PhoneNumber(cleaned);
    }

    public override string ToString() => Value;

    // Для удобства сравнения и хранения
    public static bool operator ==(PhoneNumber? left, string? right) => left?.Value == right;
    public static bool operator !=(PhoneNumber? left, string? right) => !(left == right);
}