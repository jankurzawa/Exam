using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.View.DisplayManager
{
    public interface IDisplayManager<T> where T : class
    {
        public void DisplaySingle(T entity);
        public void DisplayList(List<T> entities);
    }
}
