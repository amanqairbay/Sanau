namespace Application.Common.Exceptions;

public sealed class BrandNotFoundException : NotFoundException
{
    public BrandNotFoundException(Guid brandId) 
        : base($"The brand with id: {brandId} doesn't exist in the database.")
    { }
}