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

        private readonly int[] _places = new int[MaxPlayers];
        private readonly int[] _purses = new int[MaxPlayers];

        private readonly bool[] _inPenaltyBox = new bool[MaxPlayers];

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;
        private Player CurrentPlayer => _players[_currentPlayer];

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
            _places[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

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


            if (_inPenaltyBox[_currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    //User is getting out of penalty box
                    _isGettingOutOfPenaltyBox = true;
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
                    _isGettingOutOfPenaltyBox = false;
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
            _places[_currentPlayer] += roll;
            if (_places[_currentPlayer] >= BoardSize) _places[_currentPlayer] -= BoardSize;

            Console.WriteLine(CurrentPlayer
                              + "'s new location is "
                              + _places[_currentPlayer]);
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
            switch (_places[_currentPlayer])
            {
                case 0:
                case 4:
                case 8:
                    return "Pop";
                case 1:
                case 5:
                case 9:
                    return "Science";
                case 2:
                case 6:
                case 10:
                    return "Sports";
                default:
                    return "Rock";
            }
        }

        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public void WasCorrectlyAnswered()
        {
            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    CurrentPlayerCorrectlyAnswered();

                    HasAWinner = _purses[_currentPlayer] == GoldCoinsToWin;
                }
            }
            else
            {
                CurrentPlayerCorrectlyAnswered();

                HasAWinner = _purses[_currentPlayer] == GoldCoinsToWin;
            }
            NextPlayer();
        }

        private void CurrentPlayerCorrectlyAnswered()
        {
            Console.WriteLine("Answer was correct!!!!");
            _purses[_currentPlayer]++;
            Console.WriteLine(CurrentPlayer
                              + " now has "
                              + _purses[_currentPlayer]
                              + " Gold Coins.");
        }

        private void NextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        /// <summary>
        /// To call when the answer is wrong
        /// </summary>
        /// <returns></returns>
        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;

            return true;
        }
    }

}
