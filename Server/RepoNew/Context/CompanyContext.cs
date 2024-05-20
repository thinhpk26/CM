namespace Repo.Context
{
    public class CompanyContext
    {
        /// <summary>
        /// Mã công ty
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// tên cơ sở dữ liệu đang lưu trữ dữ liệu công ty
        /// </summary>
        public string DBSave { get; set; }
    }
}
