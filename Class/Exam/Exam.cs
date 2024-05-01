using System.Diagnostics;
using Task_7.Class.Question;
using Task_7.Class.Question.Choose.Choose;

namespace Task_7.Class.Exam
{
    internal abstract class Exam
    {
        internal DateTime CurrentDateTime { get; set; }
        internal Subject? ExamSubject { get; set; }
        internal List<Answer> Answers { get; } = new List<Answer>();

        private int NumberOfQuestions = default;
        private int TotalMarks = default;

        internal abstract void ShowExam();

        internal virtual void TakeExam()
        {
            int studentMarks = 0;

            if (ExamSubject != null)
            {
                NumberOfQuestions = ExamSubject.Questions.Count;
                foreach (var question in ExamSubject.Questions)
                {
                    Console.Clear();
                    Stopwatch timer = Stopwatch.StartNew();

                    while (timer.Elapsed.TotalSeconds < question.TimeLimitSeconds)
                    {
                        Console.Clear();
                        CurrentDateTime = DateTime.Now;

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Current Date and Time: {CurrentDateTime:yyyy-MM-dd hh:mm:ss tt}");

                        int consoleWidth = Console.WindowWidth;
                        Console.SetCursorPosition(consoleWidth - $"Number Of Questions: {NumberOfQuestions}".Length, 0);
                        Console.WriteLine($"Number Of Questions: {NumberOfQuestions}");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n");
                        Console.SetCursorPosition((Console.WindowWidth - $"{ExamSubject.SubjectType} Exam".Length) / 2, Console.CursorTop);
                        Console.WriteLine($"{ExamSubject.SubjectType} Exam\n\n");

                        TimeSpan remainingTime = TimeSpan.FromSeconds(question.TimeLimitSeconds - timer.Elapsed.TotalSeconds);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"Time remaining: {remainingTime:mm\\:ss}\n\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        question.Display();
                        Console.Write("\nYour answer: ");

                        if (question is True___False || question is Choose_One_Answer)
                        {
                            if (Console.KeyAvailable)
                            {
                                break;
                            }
                        }
                        else if (question is Choose_Multiple_Answers chooseQuestion)
                        {
                            Console.Clear();
                            CurrentDateTime = DateTime.Now;

                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine($"Current Date and Time: {CurrentDateTime:yyyy-MM-dd hh:mm:ss tt}");

                            Console.SetCursorPosition(consoleWidth - $"Number Of Questions: {NumberOfQuestions}".Length, 0);
                            Console.WriteLine($"Number Of Questions: {NumberOfQuestions}");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n");
                            Console.SetCursorPosition((Console.WindowWidth - $"{ExamSubject.SubjectType} Exam".Length) / 2, Console.CursorTop);
                            Console.WriteLine($"{ExamSubject.SubjectType} Exam\n\n");

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"You have {chooseQuestion.TimeLimitSeconds} Seconds to answer.\n\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            question.Display();
                            Console.Write("\nYour answer: ");

                            string? userAnswerString = Console.ReadLine();

                            if (userAnswerString == null)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition((Console.WindowWidth - "Incorrect Input!".Length) / 2, Console.CursorTop);
                                Console.WriteLine("Incorrect Input!\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (timer.Elapsed.TotalSeconds > question.TimeLimitSeconds)
                            {
                                break;
                            }
                            else
                            {
                                // List<char> userAnswers = userAnswerString.Trim(' ').ToUpper().ToCharArray().ToList();

                                List<char> userAnswers = userAnswerString
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) //[A],[B],[C]
                                    .Select(answer => char.ToUpper(answer[0]))
                                    .ToList();

                                List<string> correctOptionsAsString = chooseQuestion.CorrectOptions
                                    .Select(option => option.ToString())
                                    .ToList();

                                Answers.Add(new Answer
                                {
                                    UserAnswer = string.Join(" ", userAnswers),
                                    CorrectAnswerContent = string.Join(" ", correctOptionsAsString),
                                });

                                bool allCorrect = userAnswers.All(answer => correctOptionsAsString.Contains(answer.ToString()));

                                if (allCorrect && userAnswers.Count == chooseQuestion.CorrectOptions.Count)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition((Console.WindowWidth - "Correct!".Length) / 2, Console.CursorTop);
                                    Console.WriteLine("Correct!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    studentMarks += question.Marks;
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition((Console.WindowWidth - "Incorrect!".Length) / 2, Console.CursorTop);
                                    Console.WriteLine("Incorrect!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadKey();
                                    break;
                                }
                            }
                        }

                        Thread.Sleep(350);
                    }

                    Console.Clear();

                    if (timer.Elapsed.TotalSeconds > question.TimeLimitSeconds)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition((Console.WindowWidth - "Time's up!".Length) / 2, Console.CursorTop);
                        Console.WriteLine("Time's up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                    }
                    else
                    {
                        if (question is True___False trueFalse)
                        {
                            char userAnswer = Console.ReadKey().KeyChar;
                            string UserAnswerToString = userAnswer.ToString().ToUpper();

                            UserAnswerToString = UserAnswerToString switch
                            {
                                "T" => "True",
                                "F" => "False",
                                _ => "Invalid",
                            };

                            Answers.Add(new Answer
                            {
                                UserAnswer = UserAnswerToString,
                                CorrectAnswerContent = trueFalse.CorrectAnswer.ToString(),
                            });

                            if (Answers.Last().IsCorrect())
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition((Console.WindowWidth - "Correct!".Length) / 2, Console.CursorTop);
                                Console.WriteLine("Correct!");
                                Console.ForegroundColor = ConsoleColor.White;
                                studentMarks += question.Marks;
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition((Console.WindowWidth - "Incorrect!".Length) / 2, Console.CursorTop);
                                Console.WriteLine("Incorrect!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                        }
                        else if (question is Choose_One_Answer chooseQuestion)
                        {
                            char userAnswer = Console.ReadKey().KeyChar;

                            string UserAnswerToString = userAnswer.ToString().ToUpper();

                            Answers.Add(new Answer
                            {
                                UserAnswer = UserAnswerToString,
                                CorrectAnswerContent = chooseQuestion.CorrectOption.ToString(),
                            });

                            if (Answers.Last().IsCorrect())
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition((Console.WindowWidth - "Correct!".Length) / 2, Console.CursorTop);
                                Console.WriteLine("Correct!");
                                Console.ForegroundColor = ConsoleColor.White;
                                studentMarks += question.Marks;
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition((Console.WindowWidth - "Incorrect!".Length) / 2, Console.CursorTop);
                                Console.WriteLine("Incorrect!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                        }
                    }

                    Console.Clear();
                    Console.WriteLine();

                    TotalMarks += question.Marks;
                }

                Console.WriteLine($"Total Marks: {studentMarks} / {TotalMarks}\n");
            }
            else
            {
                Console.WriteLine("Null Exception !!");
            }
        }
    }
}