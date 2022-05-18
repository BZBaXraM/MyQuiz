namespace ExamProject
{

    public class Quiz
    {
        public int QuizId;
        public string? QuizName;
        public List<XmlQuestionData> QuizList;

        public Quiz(int quizId, string quizName, List<XmlQuestionData> quizList)
        {
            QuizId = quizId;
            QuizName = quizName;
            QuizList = new List<XmlQuestionData>(quizList);
        }
    }
}