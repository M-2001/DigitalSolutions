using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


using DigitalSolutions.Domain;


namespace DigitalSolutions.Services
{
	/// <summary>
	/// Global DB Context
	/// </summary>
	public class GlobalDbContext : DbContext, IDbContext
	{

		public GlobalDbContext()
			: base("info")
		{
			//Disable initializer
			Database.SetInitializer<GlobalDbContext>(null);

			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}

        /// <summary>
        /// Model mapping
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            //modelBuilder.Configurations.Add(new BlogEntryModel());
            modelBuilder.Configurations.Add(new CustomerEntryModel());
        }


        /// <summary>
        /// Access to blog entries table 
        /// </summary>
        //public IQueryable<BlogEntry> BlogEntries(bool trackChanges = false)
        //{
        //    return trackChanges == false ? this.Set<BlogEntry>().AsNoTracking() : this.Set<BlogEntry>();         
        //}

        public IQueryable<CustomerEntry> CustomerEntries(bool trackChanges = false)
        {
            return trackChanges == false ? this.Set<CustomerEntry>().AsNoTracking() : this.Set<CustomerEntry>();
        }



        void IDbContext.Add<T>(T element)
        {
            this.Set<T>().Add(element);
        }


        void IDbContext.Remove<T>(T element)
        {
            this.Set<T>().Remove(element);
        }

    }
}
