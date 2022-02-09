﻿using System;
using System.Collections.Generic;
using System.Text;
using Trivia;
using Xunit;

namespace Tests
{
    [Collection("Game")]
    public class GameTests
    {
        [Fact]
        public void Should_game_be_finished_if_one_player_has_6_golden_coins()
        {
            //Arrange
            var game = new Game(new FakeAdapter());
            game.AddPlayer("Michel");
            game.WasCorrectlyAnswered();
            game.WasCorrectlyAnswered();
            game.WasCorrectlyAnswered();
            game.WasCorrectlyAnswered();
            game.WasCorrectlyAnswered();
            game.WasCorrectlyAnswered();

            //Assert
            Assert.True(game.HasAWinner); 
        }
    }

    public class FakeAdapter : IOutputAdapter
    {
        public void SendMessage(string message)
        {
            //fait rien
        }
    }
}
