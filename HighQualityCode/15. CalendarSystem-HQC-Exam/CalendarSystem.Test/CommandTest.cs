using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;

namespace CalendarSystemTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void ParseCommandNameTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            Command parseCommand = Command.Parse(command);

            string expected = "AddEvent";
            string actual = parseCommand.CommandName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseCommandWith3ParametersTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            Command parseCommand = Command.Parse(command);

            string[] expected = 
            {
                "2012-01-21T20:00:00",
                "party Viki",
                "home"
            };
            string[] actual = parseCommand.Parameters;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseCommandWith2ParametersTest()
        {
            string command = "AddEvent 2012-03-26T09:00:00 | C# exam";
            Command parseCommand = Command.Parse(command);

            string[] expected = 
            {
                "2012-03-26T09:00:00",
                "C# exam"
            };
            string[] actual = parseCommand.Parameters;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseMultipleCommandsTest()
        {
            for (int i = 0; i < 200; i++)
            {
                string command = "AddEvent 2012-03-26T09:00:00 | C# exam" + i;
                Command parseCommand = Command.Parse(command);
                Command expected = new Command 
                {
                    CommandName = "AddEvent",
                    Parameters = new string[]
                    {
                        "2012-03-26T09:00:00",
                        "C# exam" + i
                    }
                };

                Assert.AreEqual(parseCommand.CommandName, expected.CommandName);
                CollectionAssert.AreEqual(parseCommand.Parameters, expected.Parameters);
            }
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseCommandNOParametersTest()
        {
            Command parseCommand = Command.Parse("AddEvent");
        }
    }
}
