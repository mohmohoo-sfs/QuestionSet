namespace QuestionSet.Products.v1
{
    public class IncomeProtectionV1
    {
        public bool IsUKResidentForAtLeast3Years { get; set; }

        public bool IsIncomeLiableToUKTax { get; set; }

        public bool HasUKBankOrBuildingSocietyAccount { get; set; }

        public bool HasSpecifiedOccupation { get; set; }

        public bool HasApplicationToShepherdsWithSpecifiedStatus { get; set; }

        public bool HasSpecifiedIllnessOrCondition { get; set; }

        public bool HasBeenReferredToPsychiatrist { get; set; }

        public int HeightInCentimeter { get; set; }

        public decimal WeightInKg { get; set; }

        public int CigarettesPerDay { get; set; }

        public bool HasOrHadAlcoholDependency { get; set; }

        public bool HasUsedOrIntendToUseCannabis { get; set; }

        public bool HasUsedOrIntendToUseAnyOtherDrug { get; set; }
    }
}
