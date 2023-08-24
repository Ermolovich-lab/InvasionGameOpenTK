using EngineLibrary;
using EngineLibrary.ObjectComponents;
using GameLibrary.Effects;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Bonuses
{
    /// <summary>
    /// Класс реализующий фабричные методы бонуосов
    /// </summary>
    public class BonusFactory
    {
        /// <summary>
        /// Создание игрового объекта
        /// </summary>
        /// <param name="position">Позиция появления</param>
        /// <returns></returns>
        private GameObject CreateBonus(Vector2 position)
        {
            GameObject gameObject = new GameObject();
            gameObject.SetComponent(new TransformComponent(position, new Vector2(1f, 1f), new Vector2(0, 0), 0)); 
            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(gameObject));
            gameObject.SetComponent(collSyst);
            gameObject.GameObjectTag = "Bonus";

            return gameObject;
        }
        /// <summary>
        /// Создание игрового объекта замораживающей ловушки
        /// </summary>
        /// <param name="position">Позиция появления ловушки</param>
        /// <returns></returns>
        public GameObject CreateFreezeBonus(Vector2 position)
        {
            var gameObject = CreateBonus(position);
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("frezze left idle.png")));
            gameObject.SetComponent(new TransformComponent(position, new Vector2(3f, 3f), new Vector2(0, 0), 0));
            Bonus bonus = new Bonus();
            bonus.Initialize(gameObject);
            bonus.SetEffect(new FreezeEffect());
            gameObject.SetComponent(bonus);

            return gameObject;
        }
        /// <summary>
        /// Создание игрового объекта заммедляющей ловушки
        /// </summary>
        /// <param name="position">Позиция появления ловушки</param>
        /// <returns></returns>
        public GameObject CreateSlowdownBonus(Vector2 position)
        {
            var gameObject = CreateBonus(position);
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("slowdown left idle 1.png")));
            gameObject.SetComponent(new TransformComponent(position, new Vector2(3f, 3f), new Vector2(0, 0), 0));
            Bonus bonus = new Bonus();
            bonus.Initialize(gameObject);
            bonus.SetEffect(new SlowDownEffect());
            gameObject.SetComponent(bonus);

            return gameObject;
        }
        /// <summary>
        /// Создание игрового объекта бонуса повышающего урон
        /// </summary>
        /// <param name="position">Позиция появления бонуса</param>
        /// <returns></returns>
        public GameObject CreatePowerBonus(Vector2 position)
        {
            var gameObject = CreateBonus(position);
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Power.png")));

            Bonus bonus = new Bonus();
            bonus.Initialize(gameObject);
            bonus.SetEffect(new PowerEffect());
            gameObject.SetComponent(bonus);

            return gameObject;
        }
        /// <summary>
        /// Создание игрового объекта бонуса повышающего скорострельность
        /// </summary>
        /// <param name="position">Позиция появления бонуса</param>
        /// <returns></returns>
        public GameObject CreateReloadTimeBonus(Vector2 position)
        {
            var gameObject = CreateBonus(position);
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("ReloadTime.png")));

            Bonus bonus = new Bonus();
            bonus.Initialize(gameObject);
            bonus.SetEffect(new ReloadTimeEffect());
            gameObject.SetComponent(bonus);

            return gameObject;
        }
        /// <summary>
        /// Создание игрового объекта бонуса повышающего скорость полета пули
        /// </summary>
        /// <param name="position">Позиция появления бонуса</param>
        /// <returns></returns>
        public GameObject CreateSpeedBulletBonus(Vector2 position)
        {
            var gameObject = CreateBonus(position);
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("SpeedBullet.png")));

            Bonus bonus = new Bonus();
            bonus.Initialize(gameObject);
            bonus.SetEffect(new SpeedBulletEffect());
            gameObject.SetComponent(bonus);

            return gameObject;
        }
    }
}
