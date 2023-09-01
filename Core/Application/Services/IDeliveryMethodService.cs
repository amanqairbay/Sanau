namespace Application.Services
{
    public interface IDeliveryMethodService
    {
        Task CheckDeliveryMethodExists(Guid deliveryMethodId);
    }
}