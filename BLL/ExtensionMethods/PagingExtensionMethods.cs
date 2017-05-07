using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class PagingExtensionMethods
    {
           
        public static IList<T> Paging<T>(this IList<T> list, int page, int pageSize)
        {
            IList<T> query = list.Skip((page - 1) * pageSize).Take(pageSize).ToList<T>(); 
            return query;
        }
    }
}
