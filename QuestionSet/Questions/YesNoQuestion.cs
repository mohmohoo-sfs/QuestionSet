namespace QuestionSet.Questions
{
    public class YesNoQuestion
        : IQuestion
    {
        public int Id { get; }

        public string Text { get; }

        public string Type { get; }

        public string ValidationDescription { get; }

        public string[] Statements { get; }

        public YesNoQuestion(int id, string text, string validationDescription, params string[] availableStatements)
        {
            Id = id;
            Text = text;
            Type = "Question to select Yes or No";
            ValidationDescription = validationDescription;
            Statements = availableStatements;
        }
    }
}
