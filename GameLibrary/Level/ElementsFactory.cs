using EngineLibrary;
using EngineLibrary.ObjectComponents;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Level
{
    public class ElementsFactory
    {
        /// <summary>
        /// Создает элемент стен
        /// </summary>
        /// <param name="position">Позиция объекта на сцене</param>
        /// <param name="TagName">Тег игрового объекта</param>
        /// <returns>Созданный игровой объект</returns>
        public GameObject CreateWall(Vector2 position)
        {
            float mapScale = Game.instance.HeightOfApplication / 15;

            GameObject gameObject = new GameObject();

            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Wall.png")));
            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(gameObject));
            gameObject.SetComponent(collSyst);
            gameObject.SetComponent(new TransformComponent(position, new Vector2(1f, 1f) * mapScale / gameObject.Texture.Texture.Width, new Vector2(1, 1), 0));

            gameObject.GameObjectTag = "Wall";

            return gameObject;
        }
        /// <summary>
        /// Метод создания прозрачной стены
        /// </summary>
        /// <param name="position">Позиция объекта на сцене</param>
        /// <returns></returns>
        public GameObject CreateTransparentWall(Vector2 position)
        {
            float mapScale = Game.instance.HeightOfApplication / 15;

            GameObject gameObject = new GameObject();

            //gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Wall.png")));
            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(gameObject));
            gameObject.SetComponent(collSyst);
            gameObject.SetComponent(new TransformComponent(position, new Vector2(1f, 1f) * mapScale / 25, new Vector2(1, 1), 0));

            gameObject.GameObjectTag = "Wall";

            return gameObject;
        }
    }
}
