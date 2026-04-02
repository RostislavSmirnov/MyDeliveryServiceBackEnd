namespace Domain.ValueObjects;

/// <summary>Адрес постройки, например пукта выдачи</summary>
public sealed record Address
{
    private Address(string country, string region, string city, string street, string houseNumber)
    {
        if (country == null) throw new ArgumentNullException(nameof(country));

        if (region == null) throw new ArgumentNullException(nameof(region));

        if (city == null) throw new ArgumentNullException(nameof(city));

        if (street == null) throw new ArgumentNullException(nameof(street));

        if (houseNumber == null) throw new ArgumentNullException(nameof(houseNumber));

        Country = country;
        Region = region;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    /// <summary>Страна</summary>
    public string Country { get; private set; } = null!;

    /// <summary>Регион</summary>
    public string Region { get; private set; } = null!;

    /// <summary>Город</summary>
    public string City { get; private set; } = null!;

    /// <summary>Улица</summary>
    public string Street { get; private set; } = null!;

    /// <summary>Номер дома</summary>
    public string HouseNumber { get; private set; } = null!;

    public Address Create(string country, string region, string city, string street, string houseNumber) 
    {
        Address createdAddress = new(country, region, city, street, houseNumber);
        return createdAddress;
    }
}