namespace Application.Common.RequestFeatures;

/// <summary>
/// Represents a request parameters.
/// </summary>
public abstract class RequestParameters
{
    /// <summary>
    /// Maximum of 50 rows per page.
    /// </summary>
    const int maxPageSize = 50;

    /// <summary>
    /// Gets or sets page number.
    /// </summary>
    public int PageNumber { get; set;} = 1;

    /// <summary>
    /// Page size.
    /// </summary>
    private int _pageSize = 10;

    /// <summary>
    /// Gets or sets a page size.
    /// </summary>
    public int PageSize
    {
        get 
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

    /// <summary>
    /// Gets or sets the elements by name.
    /// </summary>
    public string? OrderBy { get; set; }
}