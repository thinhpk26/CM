using BusinessRepo.IRepo;
using Dapper;
using Repo.Context;
using Repo.Entities;
using Repo.UnitOfWork;

namespace BusinessRepo.Repo
{
    public class OrderRepo : BusinessBaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }
        public async Task<int> InsertProductMapping(List<OrderProductMapping>? productMapping)
        {
            var query = $"INSERT INTO order_product_mapping(OrderID, OrderText, ProductID, ProductText, UnitID, UnitText, Price, Description, TaxID, TaxIDText, MoneyAfterTax, Discount, MoneyAfterDiscount, TotalMoney, Amount) VALUES (@OrderID, @OrderText, @ProductID, @ProductText, @UnitID, @UnitText, @Price, @Description, @TaxID, @TaxIDText, @MoneyAfterTax, @Discount, @MoneyAfterDiscount, @TotalMoney, @Amount)";
            var rowsAffected = await Cnn.ExecuteAsync(query, productMapping, UnitOfWork.GetTransaction());
            return rowsAffected;
        }

        public override async Task<Order> GetEntityByID(long id)
        {
            var query = $"SELECT o.*, p.*, opm.ProductID, p.ProductCode, p.ID, p.ProductName as ProductText, opm.OrderID, opm.UnitID, opm.UnitText, opm.Price, opm.Description, opm.TaxID, opm.TaxIDText, opm.MoneyAfterTax, opm.Discount, opm.MoneyAfterDiscount, opm.TotalMoney, opm.Amount FROM `order` o LEFT JOIN order_product_mapping opm ON o.ID = opm.OrderID LEFT JOIN product p ON opm.ProductID = p.ID WHERE o.ID = @ID";
            var param = new DynamicParameters();
            param.Add("ID", id);

            var order = new Order();
            var result = (await Cnn.QueryAsync<Order, OrderProductMapping, Order>(query, (pricebook, product) => {
                var productInsert = new List<OrderProductMapping>();
                if (product != null && product.ID != 0)
                {
                    productInsert.Add(product);
                }
                pricebook.Products = productInsert;
                return pricebook;
            },
            splitOn: "ProductID", transaction: UnitOfWork.GetTransaction(), param: param)).ToList();
            order = result[0];
            for (int i = 1; i < result.Count; i++)
            {
                order.Products?.AddRange(result[i].Products);
            }
            return order;
        }
    }
}
