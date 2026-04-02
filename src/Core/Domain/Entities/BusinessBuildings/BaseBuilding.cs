using Domain.ValueObjects;
using System.Diagnostics.Metrics;

namespace Domain.Entities.BusinessBuildings;

/// <summary>Класс для описания базовой сущности постройки</summary>
public class BaseBuilding
{
    protected BaseBuilding()
    { }

    protected BaseBuilding(string idemPotencyKey, string name, string postalCode, Address address)
    {
        if (string.IsNullOrWhiteSpace(idemPotencyKey)) throw new ArgumentNullException("Ключ идемпотентности не может быть пустым");

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Название бизнес строения не может быть пустым");

        if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentNullException("Почтовый индекс бизнес строения не может быть пустым");

        if (address == null) throw new ArgumentNullException("адрес бизнес строения не может быть пустым");

        Id = Guid.NewGuid();
        IdemPotencyKey = idemPotencyKey;
        Name = name;
        PostalCode = postalCode;
        Address = Address.Create(address.Country, address.Region, address.City, address.Street, address.HouseNumber);
    }

    /// <summary>ID постройки</summary>
    public Guid Id { get; protected set; }

    public string IdemPotencyKey { get; protected set; } = null!;

    /// <summary>Название пострйоки</summary>
    public string Name { get; protected set; } = null!;

    /// <summary>Почтовый индекс постройки</summary>
    public string PostalCode { get; protected set; } = null!;

    /// <summary>Адрес постройки</summary>
    public Address Address { get; protected set; } = null!;
}