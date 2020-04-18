using PaginationExtensionMethodForAPIs.Entities;
using PaginationExtensionMethodForAPIs.PaginationExtension;
using PaginationExtensionMethodForAPIs.ResourceParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaginationExtensionMethodForAPIs.Services
{
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetBooks(BookResourceParameters bookResourceParameters);
    }
}