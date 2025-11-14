using InsurancePremiumInquiry.Domain.Base;
using InsurancePremiumInquiry.Domain.Enums;
using InsurancePremiumInquiry.Domain.Models.BenefitRequests.Aggregate;

namespace InsurancePremiumInquiry.Domain.Models.BenefitRequests.ValueObjects
{
    public class Benefit
    {
        //Properties
        public Guid Id { get; private set; }
        public BenefitType BenefitType { get; private set; }
        public string Name { get; private set; }
        public decimal MinAmount { get; private set; }
        public decimal MaxAmount { get; private set; }
        public decimal Amount { get; private set; }
        public Guid BenefitRequestId { get; set; }
        //Navigation Properties
        public BenefitRequest BenefitRequest { get; private set; }

        //Constructor
        private Benefit()
        {

        }
        private Benefit(BenefitType benefitType, decimal amount, decimal minAmount, decimal maxAmount)
        {
            Id = Guid.NewGuid();
            BenefitType = benefitType;
            Name = benefitType.GetDescriptions();
            MinAmount = minAmount;
            MaxAmount = maxAmount;

            if (!IsValidAmount(amount, minAmount, maxAmount))
                throw new ArgumentException($"مبلغ واردشده برای {Name} خارج از محدوده مجاز است.");

            Amount = amount;
        }
        //Factory Method
        public static Benefit Create(BenefitType benefitType, decimal amount)
        {
            return benefitType switch
            {
                BenefitType.Surgery => new Benefit(benefitType, amount, 5000, 500000000),
                BenefitType.Dental => new Benefit(benefitType, amount, 4000, 400000000),
                BenefitType.Hospitalization => new Benefit(benefitType, amount, 2000, 200000000),
                _ => throw new ArgumentOutOfRangeException(nameof(benefitType), "نوع پوشش نامعتبر است.")
            };
        }
        //Validation
        private static bool IsValidAmount(decimal amount, decimal min, decimal max)
        => amount >= min && amount <= max;
    }
}
