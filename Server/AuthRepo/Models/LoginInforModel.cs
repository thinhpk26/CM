namespace AuthRepo.Models
{
    public class LoginInforModel
    {
        /// <summary>
        /// Tài khoản
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// CompanyCode
        /// </summary>
        public string? CompanyCode { get; set; }
    }
}
