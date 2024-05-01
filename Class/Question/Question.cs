namespace Task_7.Class.Question
{
    internal abstract class Question
    {
        internal int Marks { get; set; }
        internal string? Header { get; set; }
        internal string? Body { get; set; }
        internal int TimeLimitSeconds { get; set; } = 10;

        internal virtual void Display()
        {
            Console.WriteLine($"{Header}: {Body}");
        }

        internal abstract bool CheckAnswer(char userAnswer);
    }
}