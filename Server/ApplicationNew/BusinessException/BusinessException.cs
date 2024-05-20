namespace Business
{
    public class BusinessException : Exception
    {
        public BusinessException(List<string>? errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        /// <summary>
        /// Status Code luôn bằng 288
        /// </summary>
        public int StatusCode { get { return 288; } }
        
        /// <summary>
        /// Messages là gì
        /// </summary>
        public List<string>? ErrorMessages { get; set; }
    }
}
