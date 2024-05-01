using Task_7.Class.Question;
using Task_7.Class.Question.Choose.Choose;

namespace Task_7.Class.Exam
{
    internal class Practical_Exam : Exam
    {
        //Exam => question, answer

        internal override void ShowExam()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            Console.SetCursorPosition((Console.WindowWidth - "Practice Exam - Show Correct Answers.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Practice Exam - Show Correct Answers.\n");
            Console.SetCursorPosition((Console.WindowWidth - "Press any key to continue.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal override void TakeExam()
        {
            ShowExam();
            base.TakeExam();
            ShowCorrectAnswers();
        }

        private void ShowCorrectAnswers()
        {
            Console.WriteLine("Correct Answers:");

            foreach (var question in ExamSubject!.Questions)
            {
                if (question is True___False trueFalseQuestion)
                {
                    Console.WriteLine($"\tQuestion {ExamSubject.Questions.IndexOf(question) + 1}: {trueFalseQuestion.CorrectAnswer}");
                }
                else if (question is Choose_One_Answer chooseOne)
                {
                    string correctOptions = string.Join(", ", chooseOne.CorrectOption);
                    Console.WriteLine($"\tQuestion {ExamSubject.Questions.IndexOf(question) + 1}: {correctOptions}");
                }
                else if (question is Choose_Multiple_Answers chooseMultiple)
                {
                    string correctOptions = string.Join(", ", chooseMultiple.CorrectOptions);
                    Console.WriteLine($"\tQuestion {ExamSubject.Questions.IndexOf(question) + 1}: {correctOptions}");
                }
                else
                {
                    Console.WriteLine($"\t{question.Header}: N/A (Only TrueFalse questions have correct answers in this practice exam)");
                }
            }
        }
    }
}