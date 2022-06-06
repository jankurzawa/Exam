using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.View.DisplayManager.Interfaces
{
    public interface IMenuDisplayManager
    {
        public void DiplayOptions(List<string> options);
        public void DisplayMessage(string message);
        public void ClearScreen();
        
    }
}
