using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Logging;

namespace Persistence.Services;

/// <summary>
/// Represents a brand service.
/// </summary>
internal sealed class BrandService : IBrandService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

#region constructor
    public BrandService(
        IRepositoryManager repository, 
        ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

#endregion constructor

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
        var brand = await _repository.BrandRepository.GetBrandByIdAsync(brandId, trackChanges);
        
        if (brand is null) 
            throw new BrandNotFoundException(brandId);
        
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
}