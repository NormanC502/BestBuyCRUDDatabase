using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPratices
{
    class Products
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int OnSale { get; set; }

        public int StockLevel { get; set; }


    }
}
