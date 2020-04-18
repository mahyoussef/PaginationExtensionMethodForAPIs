using Microsoft.EntityFrameworkCore;
using PaginationExtensionMethodForAPIs.DbContexts;
using PaginationExtensionMethodForAPIs.Entities;
using PaginationExtensionMethodForAPIs.PaginationExtension;
using PaginationExtensionMethodForAPIs.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationExtensionMethodForAPIs.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly BookLibraryContext _context;

        public BookRepository(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Book>> GetBooks(BookResourceParameters bookResourceParameters)
        {   
            if(bookResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(bookResourceParameters));
            }

            // Casting books into IQueryable to expand tree queries
            var books =  _context.Books as IQueryable<Book>;
            
            // Getting new version of PagedList<Book> 
            // After Pagination
            return await PagedList<Book>.Create(books,
                bookResourceParameters.PageNumber,
                bookResourceParameters.PageSize);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BookService()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
