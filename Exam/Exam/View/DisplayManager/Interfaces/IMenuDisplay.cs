namespace Exam.View.DisplayManager.Interfaces
{
    public interface IMenuDisplay
    {
        public void DiplayOptions(List<string> options);
        public void DisplayMessage(string message);
        public void ClearScreen();
        
    }
}
