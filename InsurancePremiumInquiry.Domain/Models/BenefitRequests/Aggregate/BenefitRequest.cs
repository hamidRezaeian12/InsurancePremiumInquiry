using InsurancePremiumInquiry.Domain.Base;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.ValueObjects;

namespace InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate
{
    public class BenefitRequest : IAggregate
    {
        //Fields
        private readonly List<Benefit> _benefits = [];

        //Properties
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        //Navigation Properties
        public virtual IReadOnlyCollection<Benefit> Benefits => _benefits;

        //Constructor
        private BenefitRequest()
        {

        }
        private BenefitRequest(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("عنوان درخواست اجباری است.");
            Id = Guid.NewGuid();
            Title = title.Trim();
        }
        //Factory Method
        public static BenefitRequest Create(string title)
        => new(title);
        //Behaviors
        public void AddBenefit(List<Benefit> benefits)
        {
            _benefits.AddRange(benefits);
        }
    }
}
