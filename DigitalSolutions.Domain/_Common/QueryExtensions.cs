using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DigitalSolutions.Domain
{
    public static class AggregateQueryExtensions
    {

        /// <summary>
        /// Get aggregate by ID
        /// </summary>
        public static Task<T> WithID<T>(this IQueryable<T> query, int ID) where T:Aggregate
        {
            return query.Where(c => c.ID == ID).FirstOrDefaultAsync();
        }


        /// <summary>
        /// Get aggregate by ID
        /// </summary>
        public static IQueryable<T> HavingID<T>(this IQueryable<T> query, int ID) where T : Aggregate
        {
            return query.Where(c => c.ID == ID);
        }

    }
}
