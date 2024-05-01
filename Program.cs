using Task_7.Class;
using Task_7.Class.Exam;
using Task_7.Class.Question;
using Task_7.Class.Question.Choose.Choose;

namespace Task_7
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                #region English Subject

                Subject englishSubject = new()
                {
                    SubjectType = "English",
                    Questions = new List<Question>
                    {
                        new True___False
                        {
                            Body = "English is the most widely spoken language in the world.",
                            CorrectAnswer = true,
                            Header = "Recall and process",
                            Marks = 2,
                            TimeLimitSeconds = 20
                        },
                        new Choose_One_Answer
                        {
                            Body = "Which of the following is a vowel?",
                            Options = new List<string> { "A", "B", "C", "D" },
                            CorrectOption = 'A',
                            Marks = 3,
                            Header = "Comparison",
                            TimeLimitSeconds = 5
                        },
                        new Choose_Multiple_Answers
                        {
                            Body = "Select the vowels from the following:",
                            Options = new List<string> { "A", "B", "C", "D", "E" },
                            CorrectOptions = new List<char> { 'A', 'E' },
                            Marks = 5,
                            Header = "Evaluation",
                            TimeLimitSeconds = 10
                        },
                    }
                };

                #endregion English Subject

                #region Computer Science

                Subject ComputerScience = new()
                {
                    SubjectType = "Computer Science",
                    Questions = new List<Question>
                    {
                        #region True False

                        new True___False
                        {
                            Body = "C# is a programming language.",
                            Marks = 1,
                            Header = "Programming",
                            CorrectAnswer = true,
                            TimeLimitSeconds = 5
                        },
                        new True___False
                        {
                            Body = "Can you inherit from interface?",
                            Marks = 1,
                            Header = "Programming",
                            CorrectAnswer = false
                        },
                        new True___False
                        {
                            Body = "C# is an open-source programming language.",
                            Marks = 1,
                            Header = "Programming",
                            CorrectAnswer = false
                        },
                        new True___False
                        {
                            Body = "JavaScript can only be executed in a web browser.",
                            Marks = 1,
                            Header = "Web Development",
                            CorrectAnswer = false
                        },

                        #endregion True False

                        #region Choose One

                        new Choose_One_Answer
                        {
                            Body = "Which of the following is a compiled language?",
                            Marks = 1,
                            Header = "Programming",
                            Options = new List<string> { "Python", "Java", "C#", "JavaScript" },
                            CorrectOption = 'C'
                        },
                        new Choose_One_Answer
                        {
                            Body = "What does HTML stand for?",
                            Marks = 1,
                            Header = "Web Development",
                            Options = new List<string> { "HyperText Markup Language", "High-level Text Management Language", "HyperTransfer Markup Language", "HyperText Management Language" },
                            CorrectOption = 'A'
                        },
                        new Choose_One_Answer
                        {
                            Body = "Which programming language is known for its simplicity and readability?",
                            Marks = 1,
                            Header = "Programming Languages",
                            Options = new List<string> { "C", "Java", "Python", "Assembly" },
                            CorrectOption = 'C'
                        },

                        #endregion Choose One

                        #region Choose Multiple

                        new Choose_Multiple_Answers
                        {
                            Body = "Select object-oriented programming languages:",
                            Marks = 1,
                            Header = "Programming",
                            Options = new List<string> { "C#", "Python", "Java", "HTML" },
                            CorrectOptions = new List<char> { 'A', 'B', 'C' }
                        },
                        new Choose_Multiple_Answers
                        {
                            Body = "Select front-end web development technologies:",
                            Marks = 1,
                            Header = "Web Development",
                            Options = new List<string> { "React", "Node.js", "Java", "CSS" },
                            CorrectOptions = new List<char> { 'A', 'D' }
                        },

                        #endregion Choose Multiple

                        new True___False
                        {
                            Body = "Are you still alive?",
                            Marks = 1,
                            Header = "Life Skill",
                            CorrectAnswer = true,
                            TimeLimitSeconds = 30
                        }
                    }
                };

                #endregion Computer Science

                Console.WriteLine(
                    "Select The Subject:\n" +
                    "\t1. English.\n" +
                    "\t2. Computer Science.\n"
                    );

                char key = Console.ReadKey().KeyChar;

                Exam selectedExam = null!;

                switch (key)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine(
                            "Select The Exam Type:\n" +
                            "\t1. Practice Exam.\n" +
                            "\t2. Final Exam.\n"
                            );

                        char EnglishExamTypekey = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        switch (EnglishExamTypekey)
                        {
                            case '1':
                                selectedExam = new Practical_Exam();
                                break;

                            case '2':
                                selectedExam = new Final_Exam();
                                break;
                        }

                        if (selectedExam != null)
                        {
                            selectedExam.ExamSubject = englishSubject;
                            selectedExam.ShowExam();
                            Console.ReadKey();
                            selectedExam.TakeExam();
                            return;
                        }

                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine(
                            "Select The Exam Type:\n" +
                            "\t1. Practice Exam.\n" +
                            "\t2. Final Exam.\n"
                            );

                        char ComputerScienceExamTypekey = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        switch (ComputerScienceExamTypekey)
                        {
                            case '1':
                                selectedExam = new Practical_Exam();
                                break;

                            case '2':
                                selectedExam = new Final_Exam();
                                break;
                        }

                        if (selectedExam != null)
                        {
                            selectedExam.ExamSubject = ComputerScience;
                            selectedExam.ShowExam();
                            Console.ReadKey();
                            selectedExam.TakeExam();
                            return;
                        }

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect Choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}