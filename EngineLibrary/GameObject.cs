using EngineLibrary.ObjectComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Класс, представляющий игровой объект.
    /// </summary>
    public class GameObject : IDisposable
    {
        /// <summary>
        /// Родительский игровой объект
        /// </summary>
        public GameObject ParentGameObject { get; set; }

        public GameObject ChildGameObject { get; private set; }

        /// <summary>
        /// Свойство, хранящее текстуру объекта
        /// </summary>
        public virtual SpriteComponent Texture { get; protected set; }

        /// <summary>
        /// Класс, хранящее позицию объекта
        /// </summary>
        public virtual TransformComponent Transform { get; protected set; }

        /// <summary>
        /// Сценарий выполения
        /// </summary>
        public virtual ObjectScript Script { get; protected set; }

        /// <summary>
        /// Класс, описывающее твёрдое тело
        /// </summary>
        public virtual SystemCollider Colliders { get; protected set; }

        /// <summary>
        /// Тэг игрового объекта
        /// </summary>
        public string GameObjectTag { get; set; }

        /// <summary>
        /// Активность игрового объекта
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Конструктор игрового объекта.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public GameObject()
        {
            //Texture = null;
            //Script = null;
            //Colliders = new SystemCollider();
            //Transform = null;
        }

        /// <summary>
        /// Установка игровых объектов
        /// </summary>
        public virtual void SetComponent(object component)
        {
            switch (component)
            {
                case SpriteComponent textureBox:
                    Texture = textureBox;
                    break;
                case ObjectScript objectScript:
                    Script = objectScript;
                    break;
                case SystemCollider systemCollider:
                    Colliders = systemCollider;
                    break;
                case TransformComponent transform:
                    Transform = transform;
                    break;
            }
        }

        /// <summary>
        /// Метод для модификации и обновления отрисовки кадров на игровом пространстве
        /// </summary>
        public void Update()
        {
            if (Colliders != null)
                Colliders.SetIsInactive(!IsActive);

            if (Texture != null)
                Texture.PlayAnimation();

            if (Script != null)
                Script.Update();

            //if (!IsActive || (ParentGameObject != null && !ParentGameObject.IsActive)) return;
        }

        /// <summary>
        /// Установка дочернего объекта 
        /// </summary>
        /// <param name="gameObject">Дочерний объект</param>
        public void SetChildGameObject(GameObject gameObject)
        {
            ChildGameObject = gameObject;
            ChildGameObject.Transform.SetMovement(Transform.Position);
            ChildGameObject.ParentGameObject = this;
        }

        /// <summary>
        /// Метод для освобождения ресурсов
        /// </summary>
        public void Dispose()
        {
            //Texture.Dispose();
            if(Colliders != null)
                Colliders.Dispose();
        }
    }
}
