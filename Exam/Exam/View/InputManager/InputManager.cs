using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.View.InputManager
{
    public class InputManager : IInputSystem
    {
        public string FetchStringValue(string messege)
        {
            WriteLine(messege);
            return ReadLine();
        }
    }
}
