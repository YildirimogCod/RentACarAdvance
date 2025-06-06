namespace Core.Application.Pipelines.Caching
{
    public interface ICachableRemoveRequest
    {
        string CacheKey { get; }

        string? CacheGroupKey { get; }
        bool ByPass { get; }
    }
}
