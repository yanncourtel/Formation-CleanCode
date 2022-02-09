using System;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using Trivia;
using Xunit;


namespace Tests
{
    [Collection("Game")]
    [UseReporter(typeof(DiffReporter))]
    public class AcceptanceGameTest
    {
        [Fact]
        public void Test1()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game();
            game.AddPlayer("Cedric");
            game.Roll(12);
            game.CurrentPlayerIncorrectlyAnswered();
            game.Roll(2);
            game.Roll(13);
            game.WasCorrectlyAnswered();
            game.Roll(13);
            Approvals.Verify(fakeconsole.ToString());
        }
        
        [Fact]
        public void Test2()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game();
            game.AddPlayer("Cedric");
            game.AddPlayer("Eloïse");
            game.Roll(1);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            Approvals.Verify(fakeconsole.ToString());
        }
        
        [Fact]
        public void Test3()
        {
            var fakeconsole = new StringWriter();
            Console.SetOut(fakeconsole);
            var game = new Game();
            game.AddPlayer("Cedric");
            game.AddPlayer("Eloïse");
            game.Roll(1);
            game.CurrentPlayerIncorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            game.Roll(2);
            game.WasCorrectlyAnswered();
            Approvals.Verify(fakeconsole.ToString());
        }
    }
}
