using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginationExtensionMethodForAPIs.Models;
using PaginationExtensionMethodForAPIs.ResourceParameters;
using PaginationExtensionMethodForAPIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaginationExtensionMethodForAPIs.Controllers
{   
    [ApiController]
    [Route("/api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        // Injecting the constructor with Registered Services 
        public BooksController(IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository
                ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        // Book Resource Parameters are Query Params
        public async Task<IActionResult> GetBooks(
            [FromQuery] BookResourceParameters bookResourceParameters)
        {   
            // Getting the books from the repository
            var books = await _bookRepository.GetBooks(bookResourceParameters);
            
            // Creating books pagination info object
            var paginationParamters = new
            {
                currentPage = books.CurrentPage,
                pageSize = books.PageSize,
                totalItems = books.TotalItems,
                totalPages = books.TotalPages                
            };

            // Adding X-Pagination Header to Header Responses
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationParamters));
            
            // Mapping Book to BookDto Implementing Outer Facing Contract
            var booksToReturn = _mapper.Map<IEnumerable<BookDto>>(books);
            
            // Returning Status Code 200
            return Ok(booksToReturn);
        }
    }
}
