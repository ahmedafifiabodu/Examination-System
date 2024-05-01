namespace Task_7.Class.Exam
{
    internal class Final_Exam : Exam
    {
        internal override void ShowExam()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            Console.SetCursorPosition((Console.WindowWidth - "Final Exam - Questions Only.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Final Exam - Questions Only.\n");
            Console.SetCursorPosition((Console.WindowWidth - "Press any key to continue.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal override void TakeExam()
        {
            ShowExam();
            base.TakeExam();
        }
    }
}