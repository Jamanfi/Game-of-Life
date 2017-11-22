using System;
using System.Collections.Generic;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void WhenNeighboursLessThan2_CellDoesntSurvive()
        {
            Game game = new Game(new List<Cell>());
            Assert.IsFalse(game.CellShouldSurvive(1));
        }
        [TestMethod]
        public void WhenNeighboursGreaterThan3_CellDoesntSurvive()
        {
            Game game = new Game(new List<Cell>());
            Assert.IsFalse(game.CellShouldSurvive(4));
        }
        [TestMethod]
        public void WhenNeighbours2Or3_CellSurvives()
        {
            Game game = new Game(new List<Cell>());
            Assert.IsTrue(game.CellShouldSurvive(2));
            Assert.IsTrue(game.CellShouldSurvive(3));
        }


    }
}
