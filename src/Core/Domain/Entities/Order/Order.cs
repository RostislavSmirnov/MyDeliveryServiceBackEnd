using Domain.ValueObjects;

namespace Domain.Entities.Order;

/// <summary>Сущнсоть Заказа</summary>
public sealed class Order
{
    private Order()
    { }

    private Order(string idemPotencyKey, Guid clientAccountId, decimal price, string? description, string orderType, Guid senderOfficeId, Guid recipientOfficeId)
    {
        if (string.IsNullOrWhiteSpace(idemPotencyKey)) throw new ArgumentNullException("Ключ идемпотентности не может быть пустым");

        if (clientAccountId == Guid.Empty) throw new ArgumentNullException("ID клиента заказа не может быть пустым");

        if (price <= 0) throw new ArgumentNullException("цена заказа не может быть равна нулю, или меньше нуля");

        if (string.IsNullOrWhiteSpace(orderType)) throw new ArgumentNullException("Тип заказа не может быть пустым");

        if (senderOfficeId == Guid.Empty) throw new ArgumentNullException("ID офиса отправителя заказа не может быть пустым");

        if (recipientOfficeId == Guid.Empty) throw new ArgumentNullException("ID офиса получателя заказа не может быть пустым");

        Id = Guid.NewGuid();
        IdemPotencyKey = idemPotencyKey;
        ClientAccountId = clientAccountId;
        Price = price;
        Description = description;
        OrderType = OrderType.Create(orderType);
        DateCreated = DateTime.UtcNow;
        SenderOfficeId = senderOfficeId;
        RecipientOfficeId = recipientOfficeId;
    }

    /// <summary>ID заказа</summary>
    public Guid Id { get; private set; }

    /// <summary>Ключ идемпотентнсоти</summary>
    public string IdemPotencyKey { get; private set; } = null!;

    /// <summary>ID аккаунта которому принадлежит заказ</summary>
    public Guid ClientAccountId { get; private set; }

    /// <summary>Цена заказа</summary>
    public decimal Price { get; private set; }

    /// <summary>Описание заказа</summary>
    public string? Description { get; private set; } = null!;

    /// <summary>Объём заказа в кубических сантиметрах</summary>
    public float VolumeV3InCm => OrderItems.Sum(v => v.VolumeV3InCm);

    /// <summary>Вес заказа в кг</summary>
    public float Weight => OrderItems.Sum(v => v.Weight);

    /// <summary>Тип заказа</summary>
    public OrderType OrderType { get; private set; } = null!;

    /// <summary>Состав заказа</summary>
    private readonly List<OrderItem> _orderItems = [];

    /// <summary>Свойство для легкого просмотра состава заказа</summary>
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    /// <summary>Дата создания</summary>
    public DateTime DateCreated { get; private set; }

    /// <summary>Дата когда его доставили</summary>
    public DateTime? DateDelivered { get; private set; }

    /// <summary>ID офиса отправителя</summary>
    public Guid SenderOfficeId { get; private set; }

    /// <summary>ID офиса получателя</summary>
    public Guid RecipientOfficeId { get; private set; }

    /// <summary>Создать пустой заказ</summary>
    /// <param name="clientAccountId"></param>
    /// <param name="price"></param>
    /// <param name="description"></param>
    /// <param name="orderType"></param>
    /// <param name="senderOfficeId"></param>
    /// <param name="recipientOfficeId"></param>
    /// <returns></returns>
    public static Order Create(string idemPotencyKey , Guid clientAccountId, decimal price, string description, string orderType, Guid senderOfficeId, Guid recipientOfficeId)
    {
        Order createdOrder = new Order(idemPotencyKey, clientAccountId, price, description, orderType, senderOfficeId, recipientOfficeId);
        return createdOrder;
    }

    /// <summary>Добавить элемент заказа</summary>
    /// <param name="item"></param>
    public void AddOrderItem(OrderItem item)
    {
        _orderItems.Add(item);
    }
}