using EngineLibrary;
using GameLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using System;

namespace UnitTestGame
{
    [TestClass]
    public class ColliderTest
    {
        /// <summary>
        /// Тестирование коллизий 
        /// </summary>
        [TestMethod]
        public void TestCollider()
        {
            var firstObject = new GameObject();
            firstObject.SetComponent(new TransformComponent(new Vector2(1f, 1f), new Vector2(1, 1), Vector2.Zero, 0));

            var firstCollider = new ColliderComponent(firstObject);
            firstCollider.SetGameObject(firstObject);

            var firstSystemCollider = new SystemCollider();
            firstSystemCollider.Add(firstCollider);

            firstObject.SetComponent(firstSystemCollider);

            var secondObject = new GameObject();
            secondObject.SetComponent(new TransformComponent(new Vector2(1f, 3f), new Vector2(1, 1), Vector2.Zero, 0));

            var secondCollider = new ColliderComponent(secondObject);
            secondCollider.SetGameObject(secondObject);

            var secondSystemCollider = new SystemCollider();
            secondSystemCollider.Add(secondCollider);

            secondObject.SetComponent(secondSystemCollider);

            Assert.IsFalse(firstObject.Colliders.CheckGameObjectIntersection(secondObject));

            secondObject.Transform.Position = new Vector2(1f, 1f);

            Assert.IsTrue(firstObject.Colliders.CheckGameObjectIntersection(secondObject));
        }
    }
}
