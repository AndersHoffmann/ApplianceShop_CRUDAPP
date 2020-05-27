using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Skupti.Data
{
    public interface IService
    {
        Task<bool> ProductInsert(Product product);
        Task<IEnumerable<Product>> ProductList();
        Task<Product> ProductGetOne(int id);
        Task<bool> ProductUpdate(Product product);
        Task<bool> ProductDelete(int id);
    }

    public class Service : IService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public Service(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ProductInsert(Product product)
        {
            await using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();

                parameters.Add("ProductName", product.ProductName, DbType.String);
                parameters.Add("BrandId", product.BrandId, DbType.String);
                parameters.Add("Price", product.Price, DbType.Double);
                parameters.Add("SubCategoryId", product.SubCategoryId, DbType.Int32);

                await conn.ExecuteAsync("sp_product_insert", parameters, commandType: CommandType.StoredProcedure);
            }

            return true;
        }

        public async Task<IEnumerable<Product>> ProductList()
        {
            IEnumerable<Product> products;
            await using (var conn = new SqlConnection(_configuration.Value))
            {
                products = await conn.QueryAsync<Product>("sp_product_GetAll", commandType: CommandType.StoredProcedure);
            }

            return products;

        }

        public async Task<Product> ProductGetOne(int id)
        {
            Product product = new Product();
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            await using (var conn = new SqlConnection(_configuration.Value))
            {
                product = await conn.QueryFirstOrDefaultAsync<Product>("sp_product_GetOne", parameters, commandType: CommandType.StoredProcedure);
            }

            return product;
        }

        public async Task<bool> ProductUpdate(Product product)
        {
            await using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductID", product.ProductID, DbType.Int32);
                parameters.Add("ProductName", product.ProductName, DbType.String);
                parameters.Add("BrandId", product.BrandId, DbType.String);
                parameters.Add("Price", product.Price, DbType.Double);
                parameters.Add("SubCategoryId", product.SubCategoryId, DbType.Int32);

                await conn.ExecuteAsync("sp_product_update", parameters, commandType: CommandType.StoredProcedure); //Stored Procedure Insert Product
            }

            return true;
        }
        public async Task<bool> ProductDelete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            await using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("sp_product_delete", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }


}
