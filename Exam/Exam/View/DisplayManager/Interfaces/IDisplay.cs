namespace Exam.View.DisplayManager
{
    public interface IDisplay<T> where T : class
    {
        public void DisplaySingle(T entity);
        public void DisplayList(List<T> entities);
    }
}
