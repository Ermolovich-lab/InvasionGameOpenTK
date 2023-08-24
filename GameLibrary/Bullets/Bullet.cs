using EngineLibrary;
using GameLibrary.Interfaces;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Bullets
{
    /// <summary>
    /// Класс скрипт реализующий логику пули
    /// </summary>
    public class Bullet : ObjectScript
    {
        /// <summary>
        /// Скорость пули
        /// </summary>
        public float Speed { get; private set; }

        /// <summary>
        /// Экземпляр сцены игры
        /// </summary>
        protected Game invasion;

        private Vector2 flyDirection;
        protected string[] tagTarget;
        protected float power;

        /// <summary>
        /// Установление направления полета пули
        /// </summary>
        /// <param name="direction">Вектор направления</param>
        /// <param name="tag">Тег игрового объекта, создающий пулю</param>
        public void SetSettings(Vector2 direction, float power, float speed, params string[] tagTarget)
        {
            flyDirection = direction;
            this.power = power;
            this.tagTarget = tagTarget;
            Speed = speed;
        }

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start()
        {
            invasion = Game.instance;
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            Vector2 movement = new Vector2();

            movement = flyDirection * Speed * Time.DeltaTime;

            GameObject.Transform.SetMovement(movement);

            DetectCollision();
        }

        /// <summary>
        /// Распознавание столкновений и реакция на них
        /// </summary>
        private void DetectCollision()
        {
            if (GameObject.Colliders.CheckGameObjectIntersection(out GameObject otherGameObject, tagNames: tagTarget))
            {
                if(otherGameObject.Script is IHealth)
                    (otherGameObject.Script as IHealth).Remove(power);

                Game.instance.AddObjectsToRemove(GameObject);
            }
        }
    }
}
