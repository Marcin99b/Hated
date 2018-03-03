using System;

namespace Hated.Core.Domain
{
    public interface ISort
    {
        DateTime ChangedAt { get; }
        DateTime CreatedAt { get; }
    }
}
