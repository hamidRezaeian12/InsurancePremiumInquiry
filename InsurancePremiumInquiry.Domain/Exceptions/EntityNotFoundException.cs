using InsurancePremiumInquiry.Domain.Exceptions.Base;

namespace InsurancePremiumInquiry.Domain.Exceptions
{
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException()
        {

        }
        public EntityNotFoundException(string message)
            : base(message)
        {

        }
        protected override void SetStatusCode()
        {
            StatusCode = 404;//not found
        }
    }
}
