using Domain.ValueObjects;

namespace Domain.Entities.BusinessBuildings;

public sealed class PickUpPoint : BaseBuilding
{
    private PickUpPoint()
    { }

    private PickUpPoint(string idemPotencyKey, string name, string postalCode, Address address) : base(idemPotencyKey, name, postalCode, address)
    {
    }

    public static PickUpPoint Create(string idemPotencyKey, string name, string postalCode, Address address)
    {
        PickUpPoint createdPickUpPoint = new(idemPotencyKey , name, postalCode, address);
        return createdPickUpPoint;
    }
}