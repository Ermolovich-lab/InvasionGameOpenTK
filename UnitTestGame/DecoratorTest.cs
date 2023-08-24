using EngineLibrary;
using GameLibrary.Decorators;
using GameLibrary.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestGame
{
    [TestClass]
    public class DecoratorTest
    {
        PlayerPropertiesStandart playerProperities;

        [TestInitialize]
        public void InitalizeBullet()
        {
            playerProperities = new PlayerPropertiesStandart();
        }

        /// <summary>
        /// Тестирование декоратора
        /// </summary>
        [TestMethod]
        public void FeezeDecoratorTest()
        {

        }

        /// <summary>
        /// Тестирование декоратора
        /// </summary>
        [TestMethod]
        public void PowerDecoratorTest()
        {

        }
    }
}
