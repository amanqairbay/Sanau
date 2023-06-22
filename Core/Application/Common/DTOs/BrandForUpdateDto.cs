namespace Application.Common.DTOs;

/// <summary>
/// Brand data transfer object for creation.
/// </summary>
/// <param name="Name">Brand name.</param>
/// <param name="Description">Brand description.</param>
/// <param name="Products">Product data transfer object for creation.</param>
/// <returns></returns>
public record BrandForUpdateDto(
    string Name, 
    string Description, 
    IEnumerable<ProductForCreationDto> Products);