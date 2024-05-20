namespace AuthRepo.Models
{
    public class CompanyUserMapping
    {
        public long CompanyID { get; set; }
        public long UserID { get; set; }
        public string CompanyCode { get; set; }
        public string UserCode { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
    }
}
