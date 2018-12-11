using QuestionSet.Validation;
using System.Collections.Generic;
using static QuestionSet.Questions.Factory<QuestionSet.Products.v1.IncomeProtectionV1, QuestionSet.Validation.ValidationResult>;
using static QuestionSet.QuestionSpec.QuestionSpecification<QuestionSet.Products.v1.IncomeProtectionV1, QuestionSet.Validation.ValidationResult>;

namespace QuestionSet.Products.v1
{
    public class IncomeProtectionV1QuestionSet
        : IProductQuestionSet<IncomeProtectionV1>
    {
        private (IQuestion[], IValidation<IncomeProtectionV1, ValidationResult>[]) questionWithValidators; 

        public IncomeProtectionV1QuestionSet()
        {
            questionWithValidators = CreateQuestionWithValidations(
                Question("Have you been a resident in the UK for at least the last 3 years and is your income liable to UK tax?")
                    .NoValidationWarning()
                    .NoAdditionalStatement(),

                Question("Do you have a UK Bank or Building Society account?")
                    .NoValidationWarning()
                    .NoAdditionalStatement(),

                Question("Have you been registered with a UK medical practice for at least 36 months prior to this application?")
                    .NoValidationWarning()
                    .NoAdditionalStatement(),

                Question("Does any part of your paid or unpaid occupation(s) include any of the following?")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasSpecifiedOccupation
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .AvailableStatements("Any branch of the Armed Forces",
                            "Handling explosives",
                            "Underwater duties",
                            "Oil Rig or offshore work",
                            "Professional or Semi Professional Sports Persons",
                            "Nightclub Security Personnel, Bailiffs, or Bodyguards",
                            "Work with animals",
                            "Police Community Support Officers or Special Constables",
                            "Fire-fighters, including reserve or retained Fire-fighters",
                            "Working on board sea or ocean going vessels"),

                Question("Have you ever made an application to The Shepherds Friendly Society that has been postponed, declined, offered on special terms or cancelled?")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasApplicationToShepherdsWithSpecifiedStatus
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement(),

                Question("Do any of the following statements apply to you?")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasSpecifiedIllnessOrCondition
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .AvailableStatements("I am currently unable to work or am working reduced hours or on restricted duties due to sickness or accident.",
                            "I have suffered from symptoms of chronic fatigue syndrome, ME or fibromyalgia in the last 3 years.",
                            "I have suffered from cancer or malignant tumour which has been treated with radiotherapy or chemotherapy in the last 3 years.",
                            "I am currently suffering from an illness for which I am being prescribed methotrexate or chemotherapy in the last 3 years.",
                            "I am currently suffering from an illness for which I am being prescribed oral steroids or immunosuppressive treatment.",
                            "I have had a Stroke or mini Stroke (also known as Transient Ischaemic attack)",
                            "I have had a heart attack, or been diagnosed with angina or coronary disease.",
                            "I have been diagnosed with a disease of the central nervous system such as multiple sclerosis, Parkinson’s disease, Alzheimer’s disease or dementia.",
                            "I am suffering from paralysis, paraplegia or quadriplegia caused by damage to my spinal cord.",
                            "I have suffered from or been diagnosed with diabetes (other than during pregnancy)",
                            "I have been diagnosed with HIV or I am awaiting the results of a HIV test.",
                            "I have undergone major organ transplant."),

                Question("Have you ever been referred to see a psychiatrist.")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasBeenReferredToPsychiatrist
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement(),

                Question("Height and Weight for BMI")
                    .ValidationWarning("If >35, full underwriting",
                        incomeProtection => incomeProtection.HeightInMeter / incomeProtection.WeightInKg > 35
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement(),

                Question("How many cigarettes do you currently smoke per day?")
                    .ValidationWarning("If >20pc, full underwriting",
                        incomeProtection => incomeProtection.CigarettesPerDay > 20
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement(),

                Question("Do you consume more than 30 units of alcohol per week or have you ever been dependant on alcohol or been advised to reduce your intake?")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasOrHadAlcoholDependency
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement(),

                Question("Have you used cannabis within the past year, or do you intend to begin using cannabis?")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasUsedOrIntendToUseCannabis
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement(),

                Question("Other than cannabis, have you ever or do you intend to use any recreational or non prescription drugs (e.g. cannabis, ecstacy, cocaine, heroin, annabolic steroids etc?")
                    .ValidationWarning("If yes, full underwriting",
                        incomeProtection => incomeProtection.HasUsedOrIntendToUseAnyOtherReacreationalDrug
                            ? ValidationResult.Underwriting
                            : ValidationResult.Valid)
                    .NoAdditionalStatement());
        }


        public IQuestion[] GetQuestions() => questionWithValidators.Item1;

        public IValidationResultDetails Validate(IncomeProtectionV1 model)
        {
            var validators = questionWithValidators.Item2;
            var failedQuestions = new List<IQuestion>();
            foreach(var validator in validators)
            {
                var validationResult = validator.Validate(model);

                if (validationResult != ValidationResult.Valid)
                {
                    failedQuestions.Add(validator.Question);
                }
            }

            return new ValidationResultDetails
            {
                Result = failedQuestions.Count == 0 
                    ? ValidationResult.Valid.ToString() 
                    : ValidationResult.Underwriting.ToString(),
                FailedValidationQuestions = failedQuestions.ToArray()
            };
        }
    }
}
