using Exam.Controller.Handlers;
using Exam.Data.DAL;
using Exam.Data.Entities;
using Exam.View.DisplayManager.Interfaces;
using Exam.View.InputManager.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests
{
    public class SongHandlerTests
    {
        private Mock<IBaseRepository<Song>> repositoryMock;
        private Mock<IMenuDisplay> menuDisplayMock;
        private Mock<IInputSystem> inputMock;
        private SongHandler songHandler;

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IBaseRepository<Song>>();
            menuDisplayMock = new Mock<IMenuDisplay>();
            inputMock = new Mock<IInputSystem>();
            songHandler = new(repositoryMock.Object, menuDisplayMock.Object, inputMock.Object);
        }


        [Theory]
        [TestCase(null, null, null)]
        [TestCase("edfbbwer", "sdfbrfr", null)]
        [TestCase("z", null, null)]
        [TestCase(null, "z", null)]

        public void FindSong_ForDifferentArduments_ReturnsCorrectValue(string title, string author, Song expectedResult)
        {
            var returnedValue = songHandler.FindSong(title, author);

            Assert.AreEqual(expectedResult, returnedValue);
        }

        [Test]
        public void DeleteSong_ForNullArgument_WorksCorrect()
        {
            Action action = () => songHandler.DeleteSong(null);
            Assert.DoesNotThrow(() => action());
        }
    }
}

