using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hated.Core.Domain;
using MongoDB.Driver;

namespace Hated.Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static async Task<IEnumerable<T>> PaginateMongo<T>(this IMongoCollection<T> collection, int from, int number) 
            where T : ISort
        {
            return await Task.FromResult(collection.AsQueryable().OrderByDescending(x => x.CreatedAt).Skip(from).Take(number).ToList());
        }
    }
}
