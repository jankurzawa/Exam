using Exam.View.InputManager.Interfaces;
using static System.Console;

namespace Exam.View.InputManager
{
    public class InputManager : IInputSystem
    {
        public string FetchStringValue(string messege)
        {
            WriteLine(messege);
            return ReadLine();
        }

        public string FetchStringValueWithCondition(string messege, Predicate<string> contition)
        {
            string value = "";
            do
            {
                WriteLine(messege);
                value = ReadLine();
            } while (!contition.Invoke(value));
            return value;
        }
    }
}
