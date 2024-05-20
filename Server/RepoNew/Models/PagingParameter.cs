using Repo.Enums;

namespace Repo.Models
{
    public class PagingParameter
    {
        /// <summary>
        /// Số lượng bản ghi lấy
        /// </summary>
        
        public long? Limit { get; set; }

        /// <summary>
        /// Số lượng bản ghi bỏ qua
        /// </summary>
        public long? Skip { get; set; }

        public List<OrderBy> OrderBy { get; set; }

        /// <summary>
        /// Toán tử giữa các paging condition
        /// </summary>
        public NestOperator? NestOperator { get; set; }

        /// <summary>
        /// Build động câu where
        /// </summary>
        public List<Condition>? PagingCondition { get; set; }
    }
}
