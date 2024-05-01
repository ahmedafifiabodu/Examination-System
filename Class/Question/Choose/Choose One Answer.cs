namespace Task_7.Class.Question.Choose.Choose
{
    internal class Choose_One_Answer : Question
    {
        internal List<string> Options { get; set; } = new List<string>();
        internal char CorrectOption { get; set; }

        internal override void Display()
        {
            base.Display();
            Console.WriteLine("Choose One:");

            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {Options[i]}");
            }
        }

        internal override bool CheckAnswer(char userAnswer)
        {
            userAnswer = char.ToUpper(userAnswer);

            if (userAnswer >= 'A' && userAnswer <= 'Z' && userAnswer - 'A' < Options.Count)
            {
                return userAnswer == CorrectOption;
            }

            return false;
        }
    }
}