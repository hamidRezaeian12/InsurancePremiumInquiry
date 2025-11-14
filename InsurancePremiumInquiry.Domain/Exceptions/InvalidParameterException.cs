using InsurancePremiumInquiry.Domain.Exceptions.Base;

namespace InsurancePremiumInquiry.Domain.Exceptions
{
    public class InvalidParameterException : BaseException
    {
        public InvalidParameterException()
        {

        }
        public InvalidParameterException(string message)
            : base(message)
        {

        }
        protected override void SetStatusCode()
        {
            StatusCode = 400;//BadRequest
        }
    }
}
