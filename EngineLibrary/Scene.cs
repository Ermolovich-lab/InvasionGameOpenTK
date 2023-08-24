using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Абстрактный класс реализующий игровую сцену
    /// </summary>
    public abstract class Scene
    {
        protected Game game;
        /// <summary>
        /// Конструктор класса сцены
        /// </summary>
        public Scene()
        {
            game = Game.instance;
        }
        /// <summary>
        /// Инициализация сцены
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Поведение при завершении сцены
        /// </summary>
        protected abstract void EndScene(string end);
    }
}
