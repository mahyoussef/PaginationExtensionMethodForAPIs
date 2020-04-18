using AutoMapper;
using PaginationExtensionMethodForAPIs.Entities;
using PaginationExtensionMethodForAPIs.Models;
using PaginationExtensionMethodForAPIs.PaginationExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationExtensionMethodForAPIs.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
