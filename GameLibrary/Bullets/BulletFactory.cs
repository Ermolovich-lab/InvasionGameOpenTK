using EngineLibrary;
using EngineLibrary.ObjectComponents;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Bullets
{
    /// <summary>
    /// Класс реализующий фабрику пули
    /// </summary>
    public class BulletFactory
    {
        /// <summary>
        /// Создание игрового объекта пули, которая убивает
        /// </summary>
        /// <param name="position">Позиция появления пули</param>
        /// <param name="direction">Направление пули</param>
        /// <param name="tag">Тег игрового объекта, создающий пулю</param>
        /// <returns>Игровой объект</returns>
        public GameObject CreateBullet(Vector2 position, Vector2 direction, float speed, float power = 1, params string[] tagTarget)
        {
            GameObject gameObject = new GameObject();
            gameObject.SetComponent(new TransformComponent(position, new Vector2(0.02f, 0.02f), new Vector2(0, 0), 0));
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Bullet.png")));
            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(gameObject));
            gameObject.SetComponent(collSyst);
            gameObject.GameObjectTag = "Bullet";

            Bullet bullet = new Bullet();
            bullet.Initialize(gameObject);
            bullet.SetSettings(direction, power, speed, tagTarget);
            gameObject.SetComponent(bullet);

            return gameObject;
        }
    }
}
