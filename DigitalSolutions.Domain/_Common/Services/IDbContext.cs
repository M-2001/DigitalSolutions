using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigitalSolutions.Domain;

namespace DigitalSolutions
{
    /// <summary>
    /// Main DB Access Context class
    /// </summary>
    public interface IDbContext : IDisposable
    {
        //IQueryable<BlogEntry> BlogEntries(bool trackChanges = false);
        IQueryable<CustomerEntry> CustomerEntries(bool trackChanges = false);

        /// <summary>
        /// Add new object to DB (INSERT)
        /// </summary>
        void Add<T>(T element) where T : class;

        /// <summary>
        /// Remove object from DB (DELETE)
        /// </summary>
        void Remove<T>(T element) where T : class;

        /// <summary>
        /// Commit changes to database
        /// </summary>
        Task<int> SaveChangesAsync();

    }
}
