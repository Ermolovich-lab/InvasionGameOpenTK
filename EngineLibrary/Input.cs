using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Класс, позволяющий управлять вводом с клавиатуры
    /// </summary>
    public static class Input
    {

        /// <summary>
        /// Метод, возращающий значение ввода основных осей направления
        /// </summary>
        /// <param name="axis">Ось направления</param>
        /// <returns>Положительное или отрицательное значение оси</returns>
        public static int GetAxis(AxisOfInput axis)
        {
            KeyboardState keystate = Keyboard.GetState();

            int move = 0;

            switch (axis)
            {
                case AxisOfInput.Horizontal:
                    if (keystate.IsKeyDown(Key.D)) move++;
                    if (keystate.IsKeyDown(Key.A)) move--;
                    break;
                case AxisOfInput.Vertical:
                    if (keystate.IsKeyDown(Key.W)) move--;
                    if (keystate.IsKeyDown(Key.S)) move++;
                    break;
                case AxisOfInput.AlternativeHorizontal:
                    if (keystate.IsKeyDown(Key.Right)) move++;
                    if (keystate.IsKeyDown(Key.Left)) move--;
                    break;
                case AxisOfInput.AlternativeVertical:
                    if (keystate.IsKeyDown(Key.Up)) move--;
                    if (keystate.IsKeyDown(Key.Down)) move++;
                    break;
            }

            return move;
        }

        /// <summary>
        /// Метод, возращающий реакцию на нажатие клавиши ввода
        /// </summary>
        /// <param name="key">Клавиша ввода</param>
        /// <returns>Реакция true или false</returns>
        public static bool GetButtonDawn(Key key)
        {
            KeyboardState keystate = Keyboard.GetState();

            return keystate.IsKeyDown(key);
        }

        /// <summary>
        /// Ось направления ввода
        /// </summary>
        public enum AxisOfInput
        {
            /// <summary>
            /// Горизонтальная ось
            /// </summary>
            Horizontal = 0,
            /// <summary>
            /// Вертикальная ось
            /// </summary>
            Vertical = 1,
            /// <summary>
            /// Альтернативная горизонтальная ось
            /// </summary>
            AlternativeHorizontal = 2,
            /// <summary>
            /// Альтернативная вертикальная ось 
            /// </summary>
            AlternativeVertical = 3,
        }
    }
}
