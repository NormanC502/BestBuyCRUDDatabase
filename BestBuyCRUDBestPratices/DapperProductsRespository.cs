using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyCRUDBestPratices
{
    class DapperProductsRespository:IProductsRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductsRespository(IDbConnection connection) 
        {
            _connection = connection;
        }

        public void CreateProduct(int newProductId, string newName, decimal newPrice, int newCategoryid, int newOnSale, int newStockLevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS (PRODUCTID, NAME, PRICE, CATEGORYID," +

                " ONSALE, STOCKLEVEL) VALUES (@ProductId, @Name, " +

                "@Price, @CategoryID, @OnSale, @StockLevel);", 
                
                new { ProductId = newProductId, Name = newName, Price = newPrice,

                      CategoryId = newCategoryid, OnSale = newOnSale, StockLevel = newStockLevel});
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM PRODUCTS");
        }

        public IEnumerable<Products> SearchProducts(string search)
        {
            return _connection.Query<Products>("SELECT * FROM PRODUCTS WHERE NAME LIKE @name;",
                new { name = "%" + search + "%" });

            
        }

        
        
    }
}
