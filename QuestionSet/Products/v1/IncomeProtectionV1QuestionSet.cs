using QuestionSet.Questions;
using QuestionSet.QuestionSpec;

namespace QuestionSet.Products.v1
{
    public class IncomeProtectionV1QuestionSet
        : IProductQuestionSet
    {
        public IQuestion[] GetQuestions()
        {
            return QuestionFactory

                .Init()

                .YesNo(
                    QuestionSpecification
                        .Text( "Have you been a resident in the UK for at least the last 3 years and is your income liable to UK tax?")
                        .NoValidation()
                        .YesNoOption())

                .YesNo(
                    QuestionSpecification
                        .Text("Do you have a UK Bank or Building Society account?")
                        .NoValidation()
                        .YesNoOption())

                .YesNo(
                    QuestionSpecification
                        .Text("Have you been registered with a UK medical practice for at least 36 months prior to this application?")
                        .NoValidation()
                        .YesNoOption())

                .SingleChoice(
                    QuestionSpecification
                        .Text("Does any part of your paid or unpaid occupation(s) include any of the following?")
                        .Validation("If yes, full underwriting")
                        .Options(
                            new[] { "Any branch of the Armed Forces",
                                "Handling explosives",
                                "Underwater duties",
                                "Oil Rig or offshore work",
                                "Professional or Semi Professional Sports Persons",
                                "Nightclub Security Personnel, Bailiffs, or Bodyguards",
                                "Work with animals",
                                "Police Community Support Officers or Special Constables",
                                "Fire-fighters, including reserve or retained Fire-fighters",
                                "Working on board sea or ocean going vessels" }))

                .YesNo(
                    QuestionSpecification
                        .Text("Have you ever made an application to The Shepherds Friendly Society that has been postponed, declined, offered on special terms or cancelled?")
                        .Validation("If yes, full underwriting")
                        .YesNoOption())

                .MultipleChoice(
                    QuestionSpecification
                        .Text("Do any of the following statements apply to you?")
                        .Validation("If yes, full underwriting")
                        .Options(
                            new[] { "I am currently unable to work or am working reduced hours or on restricted duties due to sickness or accident.",
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
                                "I have undergone major organ transplant."
                            }))

                .YesNo(
                    QuestionSpecification
                        .Text("Have you ever been referred to see a psychiatrist.")
                        .Validation("If yes, full underwriting")
                        .YesNoOption())

                .FreeText(
                    QuestionSpecification
                        .Text("Height and Weight for BMI")
                        .Validation("If >35, full underwriting")
                        .YesNoOption())

                .FreeText(
                    QuestionSpecification
                        .Text("How many cigarettes do you currently smoke per day?")
                        .Validation("If >20pc, full underwriting")
                        .YesNoOption())

                .YesNo(
                    QuestionSpecification
                        .Text("Do you consume more than 30 units of alcohol per week or have you ever been dependant on alcohol or been advised to reduce your intake?")
                        .Validation("If yes, full underwriting")
                        .YesNoOption())

                .YesNo(
                    QuestionSpecification
                        .Text("Have you used cannabis within the past year, or do you intend to begin using cannabis?")
                        .Validation("If yes, full underwriting")
                        .YesNoOption())

                .YesNo(
                    QuestionSpecification
                        .Text("Other than cannabis, have you ever or do you intend to use any recreational or non prescription drugs (e.g. cannabis, ecstacy, cocaine, heroin, annabolic steroids etc?")
                        .Validation("If yes, full underwriting")
                        .YesNoOption())
                .Completed();

        }
    }
}
