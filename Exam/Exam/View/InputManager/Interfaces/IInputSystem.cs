namespace Exam.View.InputManager.Interfaces
{
    public interface IInputSystem
    {
        public string FetchStringValue(string messege);
        public string FetchStringValueWithCondition(string messege, Predicate<string> contition);
    }
}
