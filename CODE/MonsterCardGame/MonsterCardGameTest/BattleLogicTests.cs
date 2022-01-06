using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonsterCardGame;

namespace MonsterCardGameTest
{
    [TestFixture]
    class BattleLogicTests
    {

        [Test]
        public void GoblinDragonTest()
        {
            //Arrange
            BattleLogic battle = new BattleLogic();

            //Act
            string winner = battle.SetWinner("Farhan", "Farasat", "Goblin", "spell", "water", 67, "Dragon", "monster", "fire", 72);

            //Assert
            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void DragonGoblinTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Dragon", "monster", "fire", 72, "Goblin", "spell", "water", 67);

            Assert.AreEqual("Farhan", winner);

        }
        [Test]
        public void WizzardOrkTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Wizzard", "spell", "normal", 39, "Ork", "monster", "water", 69);

            Assert.AreEqual("Farhan", winner);

        }
        [Test]
        public void OrkWizzardTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Ork", "monster", "water", 69, "Wizzard", "spell", "normal", 39);

            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void KnightWizzardTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Knight", "monster", "normal", 41, "Wizzard", "spell", "normal",39);

            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void WizzardKnightTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Wizzard", "spell", "normal",39, "Knight", "monster", "normal", 41);

            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void KnightSpellWaterTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Knight", "monster", "normal", 41, "Goblin", "spell", "water", 39);

            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void SpellWaterKnightTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Goblin", "spell", "water", 39, "Knight", "monster", "normal", 41);

            Assert.AreEqual("Farhan", winner);

        }
        [Test]
        public void KrakenKrakenTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Kraken", "monster", "water", 73, "Kraken", "monster", "water", 73);

            Assert.AreEqual("draw", winner);

        }
        [Test]
        public void KrakenSpellTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Kraken", "monster", "water", 73, "Goblin", "spell", "water", 67);

            Assert.AreEqual("Farhan", winner);

        }
        [Test]
        public void SpellKrakenTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farasat", "Farhan", "Kraken", "monster", "water", 73, "Goblin", "spell", "water", 67);

            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void FireElvesDragonTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Elves", "monster", "fire", 29, "Dragon", "monster", "fire", 42);

            Assert.AreEqual("Farhan", winner);

        }
        [Test]
        public void DragonFireElvesTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farasat", "Farhan", "Elves", "monster", "fire", 59, "Dragon", "monster", "fire", 72);

            Assert.AreEqual("Farasat", winner);

        }
        [Test]
        public void SpellWaterSpellFireTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farhan", "Farasat", "Goblin", "spell", "water", 67, "Spell", "spell", "fire", 74);

            Assert.AreEqual("Farhan", winner);

        }
        [Test]
        public void SpellFireSpellWaterTest()
        {
            BattleLogic battle = new BattleLogic();

            string winner = battle.SetWinner("Farasat", "Farhan", "Goblin", "spell", "water", 67, "Spell", "spell", "fire", 74);

            Assert.AreEqual("Farasat", winner);

        }

    }
}
