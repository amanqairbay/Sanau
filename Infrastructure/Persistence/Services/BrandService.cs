using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services;

/// <summary>
/// Represents a brand service.
/// </summary>
internal sealed class BrandService : IBrandService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    #region constructor

    public BrandService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion constructor

    #region get methods

    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool trackChanges)
    {
        var brands = await _repository.BrandRepository.GetAllBrandsAsync(trackChanges);
        var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
        return brandsDto;
    }

    /// <summary>
    /// Gets a brand by identifier.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    public async Task<BrandDto?> GetBrandByIdAsync(Guid brandId, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(brandId, trackChanges);
        
        var brandDto = _mapper.Map<BrandDto>(brand);
        return brandDto;
    }

    /// <summary>
    /// Gets the brands by identifiers.
    /// </summary>
    /// <param name="brandIds">Brands identifiers.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    public async Task<IEnumerable<BrandDto>> GetBrandsByIdsAsync(IEnumerable<Guid> brandIds, bool trackChanges)
    {
        if (brandIds is null)
            throw new IdParametersBadRequestException();

        var brands = await _repository.BrandRepository.GetBrandsByIdsAsync(brandIds, trackChanges);
        
        if (brandIds.Count() != brands.Count())
            throw new CollectionByIdsBadRequestException();

        var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);

        return brandsDto;
    }

    #endregion get methods

    #region create/update/delete methods

    /// <summary>
    /// Creates a brand.
    /// </summary>
    /// <param name="brandForCreationDto">Brand data transfer object for creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    public async Task<BrandDto> CreateBrandAsync(BrandForCreationDto brandForCreationDto)
    {
        var brand = _mapper.Map<Brand>(brandForCreationDto);

        _repository.BrandRepository.CreateBrand(brand);
        await _repository.SaveAsync();

        var brandDto = _mapper.Map<BrandDto>(brand);

        return brandDto;
    }

    /// <summary>
    /// Creates a collection of brands.
    /// </summary>
    /// <param name="BrandDtos">Brand data transfer object.</param>
    /// <param name="BrandIds">Brands identifiers.</param>
    /// <param name="brandForCreationDtos">Brand data transfer object for creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    public async Task<(IEnumerable<BrandDto> BrandDtos, string BrandIds)> CreateBrandCollectionAsync(
        IEnumerable<BrandForCreationDto> brandForCreationDtos)
    {
        if (brandForCreationDtos is null)
            throw new BrandCollectionBadRequest();

        var brands = _mapper.Map<IEnumerable<Brand>>(brandForCreationDtos);

        foreach (var brand in brands)
        {
            _repository.BrandRepository.CreateBrand(brand);
        }

        await _repository.SaveAsync();

        var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
        var brandIds = string.Join(",", brandDtos.Select(b => b.Id));

        return (BrandDtos: brandDtos, BrandIds: brandIds);
    }

    /// <summary>
    /// Updates a brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="brandForUpdateDto">Brand data transfer object for update.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateBrandAsync(Guid brandId, BrandForUpdateDto brandForUpdateDto, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(brandId, trackChanges);

        _mapper.Map(brandForUpdateDto, brand);
        await _repository.SaveAsync();
    }

    /// <summary>
    /// Deletes a brand.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteBrandAsync(Guid brandId, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(brandId, trackChanges);

        _repository.BrandRepository.DeleteBrand(brand);
        await _repository.SaveAsync();
    }

    #endregion create/update/delete methods

    #region private methods

    /// <summary>
    /// Gets a company and checks if it exits.
    /// </summary>
    /// <param name="brandId">Brand identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    private async Task<Brand> GetBrandAndCheckIfItExists(Guid brandId, bool trackChanges)
    {
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);
        if (brand is null)
            throw new BrandNotFoundException(brandId);
        
        return brand;
    }

    #endregion private methods
}