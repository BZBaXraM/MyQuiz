namespace ExamProject
{
    public class XmlQuestionData
    {
        public int ItemId { get; set; }
        public string? Question { get; set; }
        public List<string> PossibleOptionsList;
        public List<int> AnswersList;

        public XmlQuestionData(int itemId, string question, List<string> possibleOptionsList, List<int> answersList)
        {
            ItemId = itemId;
            Question = question;
            PossibleOptionsList = new List<string>(possibleOptionsList);
            AnswersList = new List<int>(answersList);
        }
    }
}