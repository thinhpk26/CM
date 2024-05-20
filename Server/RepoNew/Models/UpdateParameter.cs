using Repo.Enums;

namespace Repo.Models
{
    public class UpdateParameter
    {
        public Dictionary<string, object> EntityUpdate { get; set; }
        /// <summary>
        /// Toán tử giữa các paging condition
        /// </summary>
        public NestOperator? NestOperator { get; set; }

        /// <summary>
        /// Build động câu where
        /// </summary>
        public List<Condition>? Condition { get; set; }
    }
}
