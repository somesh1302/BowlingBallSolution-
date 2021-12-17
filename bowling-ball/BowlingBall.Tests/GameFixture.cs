using System;
using BowlingBall;// added bowling ball refrence
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;

namespace BowlingBall.Tests
{
    [TestFixture()]
    public class GameFixture
    {
        Game game;

        [SetUp]
        public void SetUPBallingBallGame()
        {
            game= new Game();
        }

        public void SameScoreInManyRolls(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        [Test]
        public void Gutter_game_score_should_be_zero_test()
        {
            SameScoreInManyRolls(20,0);
            Assert.That(game.GetScore(),Is.EqualTo(0));
        }
        [Test]
        public void TestCaseInProblem()
        {
            game.Roll(10);
            game.Roll(9); game.Roll(1);
            game.Roll(5); game.Roll(5);
            game.Roll(7); game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9); game.Roll(0);
            game.Roll(8); game.Roll(2);
            game.Roll(9); game.Roll(1); game.Roll(10);

            Assert.That(game.GetScore(), Is.EqualTo(187));
        }
        [Test]
        public void Gutter_game_score_one_ineveryroll()
        {
            SameScoreInManyRolls(20, 1);

            Assert.That(game.GetScore(), Is.EqualTo(20));
        }
        [Test]
        public void FirstFrameSpareThenOneInEveryFrame()
        {
            game.Roll(9);
            game.Roll(1);
            SameScoreInManyRolls(18, 1);
            Assert.That(game.GetScore(), Is.EqualTo(29));
        }
        [Test]
        public void SparesEveryFrame()
        {
           for(int i=0;i<10;i++)
            {
                game.Roll(9);
                game.Roll(1);
            }
            game.Roll(9);
            Assert.That(game.GetScore(), Is.EqualTo(190));
        }
        [Test]
        public void StrikeInEveryFrame()
        {

            SameScoreInManyRolls(12, 10);
            Assert.That(game.GetScore(), Is.EqualTo(300));
        }


    }
}
