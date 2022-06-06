namespace Exam.View.DisplayManager.Interfaces
{
    public interface IDisplay<T> where T : class
    {
        public void DisplaySingle(T entity);
        public void DisplayList(List<T> entities);
    }
}
