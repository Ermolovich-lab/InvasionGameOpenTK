using EngineLibrary;
using GameLibrary.Bullets;
using GameLibrary.Enemies;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Weapons
{
    /// <summary>
    /// Класс скрипт описывающий оружие противника
    /// </summary>
    public class EnemyWeapon : ObjectScript
    {
        /// <summary>
        /// Экземпляр сцены игры
        /// </summary>
        protected Game game;

        private float currentReloadTime = 0;

        private bool isShoot = false;
        /// <summary>
        /// Скорострельность
        /// </summary>
        public float ReloadTime = 2;
        /// <summary>
        /// Скорость передвижения
        /// </summary>
        public float Speed;

        private Enemy enemy;

        public override void Start()
        {
            game = Game.instance;
        }

        public override void Update()
        {
            enemy = GameObject.ParentGameObject.Script as Enemy;

            currentReloadTime += Time.DeltaTime;

            if (GameObject.Colliders.CheckGameObjectIntersection(out GameObject gameObject, tagNames: new[] { "FirstPlayer", "SecondPlayer" })
                && currentReloadTime > ReloadTime)
            {
                if (enemy.Direction.X > 0 
                    && !GameObject.Colliders.CheckGameObjectIntersection(out GameObject wall, 1,"Wall"))
                {
                    isShoot = true;
                }
                else if(enemy.Direction.X < 0
                    && !GameObject.Colliders.CheckGameObjectIntersection(out GameObject wall1, 2, "Wall"))
                {
                    isShoot = true;
                }

                if (enemy.Direction.Y > 0
                    && !GameObject.Colliders.CheckGameObjectIntersection(out GameObject wall2, 3, "Wall"))
                {
                    isShoot = true;
                }
                else if (enemy.Direction.Y < 0
                    && !GameObject.Colliders.CheckGameObjectIntersection(out GameObject wall3, 4, "Wall"))
                {
                    isShoot = true;
                }
                else
                    isShoot = false;

                if (isShoot)
                {
                    currentReloadTime = 0;

                    var position = GameObject.Transform.Position;
                    var direction = enemy.Direction;

                    SpawnBullet(position, direction, 300);
                }
            }
        }

        /// <summary>
        /// Создание пули из фабрики
        /// </summary>
        /// <param name="position">Позиция создания</param>
        /// <param name="direction">Направление пули</param>
        protected void SpawnBullet(Vector2 position, Vector2 direction, float speed, float power = 1)
        {
            BulletFactory factory = new BulletFactory();
            game.AddObjectOnScene(factory.CreateBullet(position, direction, speed, power, "FirstPlayer", "SecondPlayer", "Wall"));
        }
    }
}
