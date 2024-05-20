using Repo.Enums;

namespace Repo.Models
{
    public class OrderBy
    {
        public string Field { get; set; }
        public OrderPaging Order { get; set; }
    }
}
