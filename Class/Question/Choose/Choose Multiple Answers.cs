namespace Task_7.Class.Question.Choose.Choose
{
    internal class Choose_Multiple_Answers : Question
    {
        internal List<string> Options { get; set; } = new List<string>();
        internal List<char> CorrectOptions { get; set; } = new List<char>();

        internal override void Display()
        {
            base.Display();
            Console.WriteLine("Choose All that Apply " +
                "(If there is multiple answers, then sperate them by space. Example: 'A B C' or 'B C' ... etc): \n");

            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {Options[i]}");
            }
        }

        internal override bool CheckAnswer(char userAnswer)
        {
            userAnswer = char.ToUpper(userAnswer);

            return userAnswer >= 'A' && userAnswer <= 'Z'
                && userAnswer - 'A' < Options.Count
                && CorrectOptions.Contains(userAnswer);
        }
    }
}