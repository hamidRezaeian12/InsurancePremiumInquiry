using System.ComponentModel;

namespace InsurancePremiumInquiry.Domain.Enums
{
    public enum BenefitType
    {
        [Description("پوشش جراحی")]
        Surgery = 1,
        [Description("پوشش دندان")]
        Dental = 2,
        [Description("پوشش بستری")]
        Hospitalization = 3
    }
}
