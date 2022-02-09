using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private const int MaxPlayers = 6;
        private const int NumberOfQuestions = 50;
        private const int MinPlayers = 2;
        private const int BoardSize = 12;
        private const int GoldCoinsToWin = 6;

        private readonly List<Player> _players = new List<Player>();

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private int _currentPlayerIndex;

        private static readonly Dictionary<int,QuestionCategory> CategoryPosition = new Dictionary<int, QuestionCategory> {

            { 0, QuestionCategory.Pop },
            { 4, QuestionCategory.Pop },
            { 8, QuestionCategory.Pop },
            { 1, QuestionCategory.Science },
            { 5, QuestionCategory.Science },
            { 9, QuestionCategory.Science },
            { 2, QuestionCategory.Sports },
            { 6, QuestionCategory.Sports },
            { 10, QuestionCategory.Sports },
            { 3, QuestionCategory.Rock },
            { 7, QuestionCategory.Rock },
            { 11, QuestionCategory.Rock }
        };
        
        private readonly IOutputAdapter _outputAdapter;
        
        private Player CurrentPlayer => _players[_currentPlayerIndex];

        public bool HasAWinner { get; internal set; }

        public Game(IOutputAdapter outputAdapter)
        {
            _outputAdapter = outputAdapter;
            for (var i = 0; i < NumberOfQuestions; i++)
            {
                _popQuestions.AddLast(QuestionCategory.Pop + " Question " + i);
                _scienceQuestions.AddLast(QuestionCategory.Science + " Question " + i);
                _sportQuestions.AddLast(QuestionCategory.Sports + " Question " + i);
                _rockQuestions.AddLast(QuestionCategory.Rock + " Question " + i);
            }
        }

        public bool IsPlayable()
        {
            return HowManyPlayers() >= MinPlayers;
        }

        public bool AddPlayer(string playerName)
        {
            _players.Add(new Player(playerName));

            OutputMessage(playerName + " was added");
            OutputMessage("They are player number " + _players.Count);
            return true;
        }

        private void OutputMessage(string message)
        {
            //Console.WriteLine(message);

            _outputAdapter.SendMessage(message);
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            OutputMessage(CurrentPlayer + " is the current player"); 
            OutputMessage("They have rolled a " + roll);

            if (CurrentPlayer.IsInJail())
            {
                if (roll % 2 != 0)
                {
                    //User is getting out of penalty box
                    CurrentPlayer.GetOutOfJail();
                    //Write that user is getting out
                    OutputMessage(CurrentPlayer + " is getting out of the penalty box");
                    // add roll to place
                    MoveCurrentPlayer(roll);
                    OutputMessage("The category is " + CategoryPosition[CurrentPlayer.Position].ToString());
                    AskQuestion();
                }
                else
                {
                    OutputMessage(CurrentPlayer + " is not getting out of the penalty box");
                }
            }
            else
            {
                MoveCurrentPlayer(roll);
                OutputMessage("The category is " + CategoryPosition[CurrentPlayer.Position].ToString());
                AskQuestion();
            }
        }

        private void MoveCurrentPlayer(int roll)
        {
            CurrentPlayer.Move(roll, BoardSize);

            OutputMessage(CurrentPlayer
                              + "'s new location is "
                              + CurrentPlayer.Position);
        }

        private void AskQuestion()
        {
            if (CategoryPosition[CurrentPlayer.Position] == QuestionCategory.Pop)
            {
                OutputMessage(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CategoryPosition[CurrentPlayer.Position] == QuestionCategory.Science)
            {
                OutputMessage(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CategoryPosition[CurrentPlayer.Position] == QuestionCategory.Sports)
            {
                OutputMessage(_sportQuestions.First());
                _sportQuestions.RemoveFirst();
            }
            if (CategoryPosition[CurrentPlayer.Position] == QuestionCategory.Rock)
            {
                OutputMessage(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public void WasCorrectlyAnswered()
        {
            CurrentPlayerCorrectlyAnswered();
            HasAWinner = CurrentPlayer.IsTheWinner(GoldCoinsToWin);
            NextPlayer();
        }

        private void CurrentPlayerCorrectlyAnswered()
        {
            OutputMessage("Answer was correct!!!!");
            CurrentPlayer.Score();
            OutputMessage(CurrentPlayer
                              + " now has "
                              + CurrentPlayer.Purse
                              + " Gold Coins.");
        }

        private void NextPlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
        }


        public void CurrentPlayerIncorrectlyAnswered()
        {
            OutputMessage("Question was incorrectly answered");
            OutputMessage(CurrentPlayer + " was sent to the penalty box");
            CurrentPlayer.GoToJail();

            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;

        }
    }

    public interface IOutputAdapter
    {
        void SendMessage(string message);
    }

    internal enum QuestionCategory
    {
        Pop,
        Science,
        Sports,
        Rock
    }
}
