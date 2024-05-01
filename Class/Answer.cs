namespace Task_7.Class
{
    internal class Answer
    {
        internal string? UserAnswer { get; set; }
        internal string? CorrectAnswerContent { get; set; }

        internal bool IsCorrect()
        {
            return string.Equals(UserAnswer, CorrectAnswerContent, StringComparison.OrdinalIgnoreCase);
        }
    }
}