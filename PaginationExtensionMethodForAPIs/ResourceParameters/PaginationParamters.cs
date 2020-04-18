using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationExtensionMethodForAPIs
{
    public class PaginationParamters
    {
        private int _maxPageSize = 20;
        private int _defaultPageSize = 10;
        public int PageSize
        {
            get => _defaultPageSize;
            set => _defaultPageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
        public int PageNumber { get; set; } = 1;
    }
}
