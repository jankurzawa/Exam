using Exam.View.DisplayManager.Interfaces;
using Exam.View.InputManager.Interfaces;

namespace Exam.Controller.Handlers
{
    public abstract class BaseHandler<T> where T : class
    {
        protected IMenuDisplay _menuDisplay;
        protected IDisplay<T> _display;
        protected IInputSystem _inputSystem;
        protected string[] options;

        public BaseHandler(IMenuDisplay menuDisplay, IDisplay<T> display, IInputSystem inputSystem)
        {
            _menuDisplay = menuDisplay;
            _display = display;
            _inputSystem = inputSystem;
            options = GetAvailableCommands();
        }

        public void Run()
        {
            string userInput = "";
            while (!userInput.Equals("quit"))
            {
                _menuDisplay.ClearScreen();
                _menuDisplay.DiplayOptions(new List<string>(options));
                userInput = _inputSystem.FetchStringValue("Provide option ");
                RunFeatureBasedOn(userInput);
                _inputSystem.FetchStringValue("Press enter to continue");
                _menuDisplay.ClearScreen();
            }
        }
        protected abstract void RunFeatureBasedOn(string option);
        protected abstract string[] GetAvailableCommands();

    }
}
