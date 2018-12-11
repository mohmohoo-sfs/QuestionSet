namespace QuestionSet.Questions
{
    public class YesNoQuestion
        : IQuestion
    {
        public int Id { get; }

        public string Text { get; }

        public string Type { get; }

        public string ValidationDescription { get; }

        public YesNoQuestion(int id, string text, string validationDescription)
        {
            Id = id;
            Text = text;
            Type = "Question to select Yes or No";
            ValidationDescription = validationDescription;
        }
    }
}
