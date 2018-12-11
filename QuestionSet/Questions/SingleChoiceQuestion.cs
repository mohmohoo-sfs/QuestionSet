using System.Collections.Generic;

namespace QuestionSet.Questions
{
    public class SingleChoiceQuestion
        : IQuestion
    {
        private List<IAnswerOptionItem> _options;

        private IAnswerValidator _validator;

        public int Id { get; }

        public string Text { get; }

        public string Type { get; }

        public string ValidationDescription { get; set; }

        public IAnswerOptionItem[] Options { get => _options.ToArray(); }

        public SingleChoiceQuestion(int id, string text, string validationDescription, IAnswerValidator validator)
        {
            Id = id;
            Text = text;
            Type = "Question to select one option which applies";
            _options = new List<IAnswerOptionItem>();
            _validator = validator;
            ValidationDescription = validationDescription;
        }

        public void AddOption(IAnswerOptionItem option)
        {
            _options.Add(option);
        }
    }
}
