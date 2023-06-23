namespace Application.Common.RequestFeatures;

/// <summary>
/// Represents a meta data class.
/// </summary>
public class MetaData
{
    /// <summary>
    /// Gets or sets a current page.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets a total pages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets a page size.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Get or sets a total count.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Gets the previous page.
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;

    /// <summary>
    /// Gets the next page.
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}