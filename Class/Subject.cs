namespace Task_7.Class
{
    internal class Subject
    {
        internal List<Question.Question> Questions { get; set; } = new List<Question.Question>();
        internal string? SubjectType { get; set; }
    }
}