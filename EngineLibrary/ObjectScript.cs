using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Абстрактный класс сценария поведения игрового объекта
    /// </summary>
    public abstract class ObjectScript
    {
        /// <summary>
        /// Игровой объект, которым управляет сценарий
        /// </summary>
        public GameObject GameObject { get; protected set; }

        /// <summary>
        /// Инициализация сценария
        /// </summary>
        /// <param name="gameObject">Игровой объект, который выполняет сценарий</param>
        public void Initialize(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public abstract void Update();
    }
}
