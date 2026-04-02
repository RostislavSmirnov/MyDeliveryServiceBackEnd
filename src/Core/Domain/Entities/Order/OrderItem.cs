namespace Domain.Entities.Order;

public class OrderItem
{
    private OrderItem()
    { }

    public OrderItem(Guid orderId, float weight, float length, float width, float height)
    {
        if (weight <= 0) throw new ArgumentOutOfRangeException("Вес элемента посылки не может быть меньше нуля");

        if (length <= 0) throw new ArgumentOutOfRangeException("Длина элемента посылки не может быть меньше нуля");

        if (width <= 0) throw new ArgumentOutOfRangeException("Высота элемента посылки не может быть меньше нуля");

        if (height <= 0) throw new ArgumentOutOfRangeException("Высота элемента посылки не может быть меньше нуля");

        Id = Guid.NewGuid();
        OrderId = orderId;
        Weight = weight;
        Length = length;
        Width = width;
        Height = height;
    }

    /// <summary>ID элемента посылки</summary>
    public Guid Id { get; private set; }

    /// <summary>ID посылки которой принадлежит этот элемент</summary>
    public Guid OrderId { get; private set; }

    /// <summary>Вес элемента посылки</summary>
    public float Weight { get; private set; }

    /// <summary>Длина элемента посылки в см</summary>
    public float Length { get; private set; }

    /// <summary>Ширина элемента посылки в см</summary>
    public float Width { get; private set; }

    /// <summary>Высота элемента посылки в см</summary>
    public float Height { get; private set; }

    /// <summary>Объём элемента посылки в см кубических</summary>
    public float VolumeV3InCm => Length * Width * Height;

    /// <summary>Создать элемент посылки</summary>
    /// <param name="orderId"></param>
    /// <param name="weight"></param>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static OrderItem Create(Guid orderId, float weight, float length, float width, float height)
    {
        OrderItem createdOrderItem = new(orderId, weight, length, width, height);
        return createdOrderItem;
    }

    /// <summary>Обновить размер посылки</summary>
    /// <param name="weight"></param>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void UpdateSizeParameters(float? weight, float? length, float? width, float? height)
    {
        if (weight.HasValue)
        {
            if (weight <= 0) throw new ArgumentOutOfRangeException("Вес элемента посылки не может быть меньше нуля");
            Weight = weight.Value;
        }

        if (length.HasValue)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("Длина элемента посылки не может быть меньше нуля");
            Length = length.Value;
        }

        if (width.HasValue)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException("Высота элемента посылки не может быть меньше нуля");
            Width = width.Value;
        }

        if (height.HasValue)
        {
            if (height <= 0) throw new ArgumentOutOfRangeException("Высота элемента посылки не может быть меньше нуля");
            Height = height.Value;
        }
    }
}