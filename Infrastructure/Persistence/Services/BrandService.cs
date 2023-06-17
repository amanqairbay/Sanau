using Application.Common.DTOs;
using Application.Repositories;
using Application.Services;
using AutoMapper;
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

    public IEnumerable<BrandDto> GetAllBrands(bool trackChanges)
    {
        var brands = _repository.BrandRepository.GetAllBrands(trackChanges);
        var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
        return brandsDto;
    }
}