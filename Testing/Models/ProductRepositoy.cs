using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Testing.Models
{
	public class ProductRepository : IProductRepository
	{
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }
    }
}

