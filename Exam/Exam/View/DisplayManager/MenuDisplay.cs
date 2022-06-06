using Exam.View.DisplayManager.Interfaces;
using static System.Console;

namespace Exam.View.DisplayManager
{
    public class MenuDisplay : IMenuDisplay
    {
        public void ClearScreen() => Clear();
        public void DiplayOptions(List<string> options) => options.ForEach(o => WriteLine(o));
        public void DisplayMessage(string message) => WriteLine(message);
    }
}
