using EngineLibrary;
using GameLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using System;

namespace UnitTestGame
{
    [TestClass]
    public class MovementTest
    {
        /// <summary>
        /// Тестирование движений игровых объектов
        /// </summary>
        [TestMethod]
        public void TestGameObjectMovement()
        {
            var gameObject = new GameObject();
            gameObject.SetComponent(new TransformComponent(new Vector2(0f, 0f), new Vector2(1, 1), Vector2.Zero, 0));

            Vector2 offset = new Vector2(1f, 1f);

            gameObject.Transform.SetMovement(offset);

            Vector2 expected = new Vector2(1f, 1f);
            Vector2 actual = gameObject.Transform.Position;

            Assert.AreEqual(expected, actual);
        }
    }
}
