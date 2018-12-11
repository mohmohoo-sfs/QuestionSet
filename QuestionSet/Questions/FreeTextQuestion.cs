namespace QuestionSet.Questions
{
    public class FreeTextQuestion
        : IQuestion
    {
        public int Id { get; }

        public string Text { get; }

        public string Type { get; set; }

        public string ValidationDescription { get; }

        public FreeTextQuestion(int id, string text, string validationDescription)
        {
            Id = id;
            Text = text;
            Type = "Question to enter free text answer";
            ValidationDescription = validationDescription;
        }
    }
}
