using Repo.Enums;

namespace Repo.Models
{
    /// <summary>
    /// 2 trường hợp sử dụng => key - value - operator || nestoperator và nestCondition
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Key 
        /// </summary>
        public string? Key { get; set; }
        /// <summary>
        /// Giá trị
        /// </summary>
        public object? Value { get; set; }
        /// <summary>
        /// toán tử của condition
        /// </summary>
        public Operator? Operator { get; set; }
        /// <summary>
        /// toán tử giữa các condition con
        /// </summary>
        public NestOperator? NestOperator {  get; set; }
        /// <summary>
        /// Condition lồng nhau
        /// </summary>
        public List<Condition>? NestCondition { get; set; }
    }
}