using System.Xml;
using System.IO;

namespace ExamProject
{

    public class AllQuizzez
    {
        public static string Path = "quizes.xml";
        public List<Quiz> AllQuizzezList;

        public AllQuizzez()
        {
            AllQuizzezList = new List<Quiz>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path);
            XmlElement xmlElement = xDoc.DocumentElement;

            foreach (XmlNode quiz in xmlElement)
            {
                XmlNode? quizAttr = quiz.Attributes.GetNamedItem("id");
                int quizAttrId = Convert.ToInt32(quizAttr.Value); // Для получение id викторины
                quizAttr = quiz.Attributes.GetNamedItem("name");
                string? quizAttrName = quizAttr.Value; // Название викторины

                List<XmlQuestionData> questionList = new List<XmlQuestionData>();

                foreach (XmlNode item in quiz)
                {
                    XmlNode? itemAttr = item.Attributes.GetNamedItem("id");
                    int itemAttrId = Convert.ToInt32(itemAttr.Value); // получили id вопроса

                    string? question = null;
                    List<string> options = new List<string>();
                    List<int> answers = new List<int>();

                    foreach (XmlNode childItem in item.ChildNodes)
                    {
                        if (childItem.Name == "question")
                            question = childItem.InnerText;
                        if (childItem.Name == "possible")
                            options.Add(childItem.InnerText);
                        if (childItem.Name == "answer")
                            answers.Add(Convert.ToInt32(childItem.InnerText));
                    }

                    XmlQuestionData currentQuestion = new XmlQuestionData(itemAttrId, question, options, answers);
                    questionList.Add(currentQuestion);
                }

                Quiz currentQuiz = new Quiz(quizAttrId, quizAttrName, questionList);
                AllQuizzezList.Add(currentQuiz);
            }
        }
    }
}