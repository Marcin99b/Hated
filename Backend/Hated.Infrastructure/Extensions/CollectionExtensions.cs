

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Hated.Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static async Task<IEnumerable<T>> PaginateMongo<T>(this IMongoCollection<T> collection, int from, int number)
        {
            return await Task.FromResult(collection.AsQueryable().Skip(from).Take(number).ToList());
        }
    }
}
