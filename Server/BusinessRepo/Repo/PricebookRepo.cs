using BusinessRepo.IRepo;
using Dapper;
using Repo.Context;
using Repo.Entities;
using Repo.UnitOfWork;

namespace BusinessRepo.Repo
{
    public class PricebookRepo : BusinessBaseRepo<Pricebook>, IPricebookRepo
    {
        public PricebookRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }

        public async Task<int> InsertProductMapping(List<PricebookProductMapping>? productMapping)
        {
            var query = $"INSERT INTO pricebook_product_mapping(PricebookID, ProductID, ProductIDText, Price, Discount) VALUES (@PricebookID, @ProductID, @ProductIDText, @Price, @Discount)";
            var rowsAffected = await Cnn.ExecuteAsync(query, productMapping, UnitOfWork.GetTransaction());
            return rowsAffected;
        }

        public override async Task<Pricebook> GetEntityByID(long id)
        {
            var query = $"select p.*, ppm.*, pro.*, IFNULL(ppm.Price, pro.Price) AS price, ppm.Discount as Discount FROM pricebook p LEFT JOIN pricebook_product_mapping ppm ON p.ID = ppm.PricebookID LEFT JOIN product pro ON ppm.ProductID = pro.ID WHERE p.ID = @ID";
            var param = new DynamicParameters();
            param.Add("ID", id);

            var priceBook = new Pricebook();
            var result = (await Cnn.QueryAsync<Pricebook, Product, Pricebook>(query, (pricebook, product) => {
                var productInsert = new List<Product>();
                if (product.ID != 0)
                {
                    productInsert.Add(product);
                }
                pricebook.Products = productInsert;
                return pricebook;
            },
            splitOn: "PricebookID", transaction: UnitOfWork.GetTransaction(), param: param)).ToList();
            priceBook = result[0];
            for(int i=1; i<result.Count; i++)
            {
                priceBook.Products?.AddRange(result[i].Products);
            }
            return priceBook;
        }

        public async Task<int> UpdateProductMapping(long pricebookID, List<PricebookProductMapping>? productMapping)
        {
            if(productMapping != null)
            {
                var query = $"DELETE FROM pricebook_product_mapping WHERE ID IN ( SELECT * FROM ( SELECT ppm.ID FROM pricebook p JOIN pricebook_product_mapping ppm ON p.ID = ppm.PricebookID WHERE p.ID = @PricebookID ) AS c )";

                await Cnn.ExecuteAsync(query, new { PricebookID = pricebookID}, UnitOfWork.GetTransaction());
                return await this.InsertProductMapping(productMapping);
            }
            return 0;
        }
    }
}
