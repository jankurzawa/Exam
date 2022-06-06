using Exam.Data.Entities;
using Exam.View.InputManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Controller.Factories
{
    public class SongFactory : IFactory<Song>
    {
        private IInputSystem _inputSystem;
        private Predicate<string> CheckIfProvideStringIsCorrectForSongAttribute;
        private Predicate<string> CheckIfProvideLengthIsCorrectForSongAttribute;

        public SongFactory(IInputSystem inputSystem)
        {
            _inputSystem = inputSystem;
            CheckIfProvideStringIsCorrectForSongAttribute = value => value.Length > 0 && value != null;
            CheckIfProvideLengthIsCorrectForSongAttribute = value => value.Length > 3 && value[^3] == '.';
        }

        public Song Create()
        {
            string title = null, author = null, albumName = null, length = null, confirming = "n";
            double parsedLength;
            do
            {
                title = _inputSystem.FetchStringValueWithCondition("Title:", CheckIfProvideStringIsCorrectForSongAttribute);
                author = _inputSystem.FetchStringValueWithCondition("Author:", CheckIfProvideStringIsCorrectForSongAttribute);
                albumName = _inputSystem.FetchStringValueWithCondition("Album name:", CheckIfProvideStringIsCorrectForSongAttribute);
                length = _inputSystem.FetchStringValueWithCondition("Length (ex. 3.30):", CheckIfProvideLengthIsCorrectForSongAttribute);
                parsedLength = Double.Parse(length);
                confirming = _inputSystem.FetchStringValue($"Confirm? ([y] - yes, [n] - no)");
            } while (confirming == "n");
            return new Song(title, author, albumName, parsedLength);
        }
    }
}
