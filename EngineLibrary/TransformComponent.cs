using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Класс описывающий положение
    /// </summary>
    public class TransformComponent
    {
        /// <summary>
        /// Позиция игрового объекта
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Позиция игрового объекта
        /// </summary>
        public Vector2 Centre { get; set; }

        /// <summary>
        /// Позиция игрового объекта
        /// </summary>
        public float Angle { get; private set; }

        /// <summary>
        /// Размер игрового объекта
        /// </summary>
        public Vector2 Scale { get; set; }

        private Vector2 movementInCurrentFrame;

        /// <summary>
        /// Конструктор компонента
        /// </summary>
        /// <param name="position">начальная позиция</param>
        /// <param name="scale">Начальный размер</param>
        public TransformComponent(Vector2 position, Vector2 scale, Vector2 centre, float angle)
        {
            Position = position;
            Scale = scale;
            Centre = centre;
            Angle = angle;
        }

        /// <summary>
        /// Перемещение объкта
        /// </summary>
        /// <param name="movement">Вектор перемещения</param>
        public void SetMovement(Vector2 movement)
        {
            movementInCurrentFrame = movement;

            Position += movement;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="movement">Вектор перемещения</param>
        public void SetAngle(float angle)
        {
            Angle += angle;

            if (Angle > Math.PI * 2)
                Angle -= (float) Math.PI * 2;
            else if (Angle < 0)
                Angle += (float) Math.PI * 2;
        }

        /// <summary>
        /// Возврат позиция в этом кадре
        /// </summary>
        public void ResetMovement()
        {
            Position -= movementInCurrentFrame;
        }
    }
}
