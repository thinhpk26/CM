namespace AuthAppication.DTO
{
    public class UserPlatFormGetDTO
    {
        public long ID { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAllowAccess { get; set; }
    }
}
