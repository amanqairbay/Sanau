namespace Application.Common.RequestFeatures;

/// <summary>
/// Represents a paged list.
/// </summary>
/// <typeparam name="T">Type of entity.</typeparam>
public class PagedList<T> : List<T>
{
    /// <summary>
    /// Gets or sets a meta data.
    /// </summary>
    public MetaData MetaData { get; set; }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize) 
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
        
        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}