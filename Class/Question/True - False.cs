namespace Task_7.Class.Question
{
    internal class True___False : Question
    {
        internal bool CorrectAnswer { get; set; }

        internal override void Display()
        {
            base.Display();
            Console.WriteLine("True or False? (Press 'T' for true or 'F' for false)");
        }

        internal override bool CheckAnswer(char userAnswer)
        {
            /*
            switch (userAnswer)
            {
                case 't':
                case 'T':
                    return CorrectAnswer;

                case 'f':
                case 'F':
                    return !CorrectAnswer;

                default:
                    return false;
            }
            */

            //return userAnswer switch
            //{
            //    't' or 'T' => CorrectAnswer,
            //    'f' or 'F' => !CorrectAnswer,
            //    _ => false,
            //};
            return userAnswer.ToString().Equals(CorrectAnswer.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}