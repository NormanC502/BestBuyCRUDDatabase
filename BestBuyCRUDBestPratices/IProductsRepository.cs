using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPratices
{
    interface IProductsRepository
    {

        // Method for calling the products which returns a collection that is Ienumerable<T> which is replaced with products as well sets implementation standards for classes that inherit
        IEnumerable<Products> SearchProducts(string search);

        // Method for creating new product file
        void CreateProduct(int productId, string name, decimal price, int categoryId, int onSale, int stockLevel);

        IEnumerable<Products> GetAllProducts();
    }
}
