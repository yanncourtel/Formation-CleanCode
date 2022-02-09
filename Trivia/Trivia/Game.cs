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
        private Dictionary<int,QuestionCategory> _categoryPosition = new Dictionary<int, QuestionCategory>();

        private Player CurrentPlayer => _players[_currentPlayerIndex];

        public bool HasAWinner { get; internal set; }

        public Game()
        {
            for (var i = 0; i < NumberOfQuestions; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }

        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool IsPlayable()
        {
            return HowManyPlayers() >= MinPlayers;
        }

        public bool AddPlayer(string playerName)
        {
            _players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(CurrentPlayer + " is the current player"); Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer.IsInJail())
            {
                if (roll % 2 != 0)
                {
                    //User is getting out of penalty box
                    CurrentPlayer.GetOutOfJail();
                    //Write that user is getting out
                    Console.WriteLine(CurrentPlayer + " is getting out of the penalty box");
                    // add roll to place
                    MoveCurrentPlayer(roll);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(CurrentPlayer + " is not getting out of the penalty box");
                }
            }
            else
            {
                MoveCurrentPlayer(roll);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void MoveCurrentPlayer(int roll)
        {
            CurrentPlayer.Move(roll, BoardSize);

            Console.WriteLine(CurrentPlayer
                              + "'s new location is "
                              + CurrentPlayer.Position);
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_sportQuestions.First());
                _sportQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        private string CurrentCategory()
        {
            //switch (CurrentPlayer.Position)
            //{
            //    case 0:
            //    case 4:
            //    case 8:
            //        return "Pop";
            //    case 1:
            //    case 5:
            //    case 9:
            //        return "Science";
            //    case 2:
            //    case 6:
            //    case 10:
            //        return "Sports";
            //    default:
            //        return "Rock";
            //}

            return _categoryPosition[CurrentPlayer.Position].ToString();
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
            Console.WriteLine("Answer was correct!!!!");
            CurrentPlayer.Score();
            Console.WriteLine(CurrentPlayer
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
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer + " was sent to the penalty box");
            CurrentPlayer.GoToJail();

            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;

        }
    }

    internal enum QuestionCategory
    {
        Pop,
        Science,
        Sports,
        Rock
    }
}
