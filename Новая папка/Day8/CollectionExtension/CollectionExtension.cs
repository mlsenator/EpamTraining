using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionExtension
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Returns custom enumerator
        /// </summary>
        /// <param name="itemsFilter">Specific items selection rule. Type null to use default (include all items).</param>
        /// <param name="indexesFilter">Specific indexes selection rule. Type null to use default (include all indexes).</param>
        public static IEnumerable<T> CustomEnumerator<T>(this IEnumerable<T> collection, Func<T, bool> itemsFilter, Func<int, bool> indexesFilter)
        {
            if (collection == null)
                throw new NullReferenceException("Collection is null");
            if (itemsFilter == null)
                itemsFilter = (T param) => true;
            if (indexesFilter == null)
                indexesFilter = (int param) => true;
            int i = 0;
            foreach (T item in collection)
            {
                if (indexesFilter(i))
                    if (itemsFilter(item))
                        yield return item;
                i++;
            }
        }

    }
}
