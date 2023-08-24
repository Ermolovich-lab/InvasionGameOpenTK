using EngineLibrary;
using GameLibrary.Interfaces;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Enemies
{
    /// <summary>
    /// Класс скрипт, описывающий противника
    /// </summary>
    public class Enemy : ObjectScript, IHealth
    {
        /// <summary>
        /// Возможность движения
        /// </summary>
        public bool IsCanMove { get; set; } = true;
        /// <summary>
        /// Направление движения противника
        /// </summary>
        public Vector2 Direction = Vector2.Zero;
        /// <summary>
        /// Скорость
        /// </summary>
        public float Speed { get; private set; } = 100;
        /// <summary>
        /// Количество здоровья
        /// </summary>
        public float Health { get; private set; } = 2;

        private List<GameObject> followGameObjects = new List<GameObject>();

        private GameObject followGameObject;

        public override void Start()
        {
            
        }

        public override void Update()
        {
            CheckCurrFollowObject();

            if (followGameObject != null)
            {
                Move();
            }

            if (Health <= 0)
            {
                Death();
            }

            if (followGameObject != null && followGameObject.Script is IHealth 
                && (followGameObject.Script as IHealth).Health <= 0)
            {
                followGameObjects.Remove(followGameObject);
                IsCanMove = false;
            }
        }
        /// <summary>
        /// Метод, реализующий движение
        /// </summary>
        private void Move()
        {
            Direction = GetDirection(followGameObject);

            if (Direction.X > 0)
            {
                GameObject.Texture.SetAnimation("Right");
                GameObject.ChildGameObject.Texture.SetAnimation("Right");
            }
            else if (Direction.X < 0)
            {
                GameObject.Texture.SetAnimation("Left");
                GameObject.ChildGameObject.Texture.SetAnimation("Left");
            }

            GameObject.Transform.SetMovement(new Vector2(Direction.X, Direction.Y) * Speed * Time.DeltaTime);
            GameObject.ChildGameObject.Transform.SetMovement(new Vector2(Direction.X, Direction.Y) * Speed * Time.DeltaTime);

            DetectCollision();
        }
        /// <summary>
        /// Установка объектов за которыми необходимо следить
        /// </summary>
        /// <param name="gameObjects">Игровой объект</param>
        public void SetFollowGameObject(GameObject[] gameObjects)
        {
            followGameObjects.AddRange(gameObjects);
        }
        /// <summary>
        /// Просчет траектории движения
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private Vector2 GetDirection(GameObject gameObject)
        {
            Vector2 result = gameObject.Transform.Position - GameObject.Transform.Position;
            result.Normalize();

            return result;
        }

        /// <summary>
        /// Распознавание столкновений и реакция на них
        /// </summary>
        private void DetectCollision()
        {
            if (GameObject.Colliders.CheckGameObjectIntersection(out GameObject otherGameObject, tagNames: new[] { "FirstPlayer", "SecondPlayer", "Wall" }))
            {
                GameObject.Transform.ResetMovement();
                GameObject.ChildGameObject.Transform.ResetMovement();
            }
        }
        /// <summary>
        /// Проверка ближайшего объекта для слежения
        /// </summary>
        private void CheckCurrFollowObject()
        {
            float distance = 10000;
            float newDistance;

            foreach (var obj in followGameObjects)
            {
                newDistance = (obj.Transform.Position - GameObject.Transform.Position).Length;

                if(newDistance <= distance)
                {
                    followGameObject = obj;
                    distance = newDistance;
                }
            }
        }
        /// <summary>
        /// Уменьшеие количества жизней
        /// </summary>
        /// <param name="value">Количество жизней</param>
        public void Remove(float value)
        {
            if(value > 0)
                Health -= value;
        }
        /// <summary>
        /// Добавление количества жизней
        /// </summary>
        /// <param name="value">Количество жизней</param>
        public void Add(float value)
        {
            if(value > 0)
                Health += value;
        }
        /// <summary>
        /// Смерть
        /// </summary>
        private void Death()
        {
            GameObject.ChildGameObject.Colliders.DelGameObject(GameObject.ChildGameObject);
            GameObject.Colliders.DelGameObject(GameObject);
            Game.instance.AddObjectsToRemove(GameObject.ChildGameObject);
            Game.instance.AddObjectsToRemove(GameObject);
        }
    }
}
