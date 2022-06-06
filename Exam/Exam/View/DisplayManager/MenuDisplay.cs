using Exam.View.DisplayManager.Interfaces;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.View.DisplayManager
{
    public class MenuDisplay : IMenuDisplay
    {
        public void ClearScreen() => Clear();
        public void DiplayOptions(List<string> options) => options.ForEach(o => WriteLine(o));
        public void DisplayMessage(string message) => WriteLine(message);
    }
}
