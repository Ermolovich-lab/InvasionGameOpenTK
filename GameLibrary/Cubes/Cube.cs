using EngineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Cubes
{
    /// <summary>
    /// Класс описывающий игральный кубик
    /// </summary>
    public class Cube : ObjectScript
    {
        public event Action<int> SetStep;

        /// <summary>
        /// Время броска
        /// </summary>
        public float ThrowTime { get; private set; } = 3;

        /// <summary>
        /// Текушая сторона
        /// </summary>
        public int Side { get; private set; }

        private float currThrowTime = 0;

        private Random rand;

        /// <summary>
        /// Свойство обозначающее изменение стороны
        /// </summary>
        public bool IsChange { get; private set; } = false;

        public override void Start()
        {
            rand = new Random();
        }

        public override void Update()
        { 
            if(Time.CurrentTime < currThrowTime) 
            {
                GameObject.Texture.SetAnimation("throw");
            }
            else if (!IsChange)
            {
                Side = rand.Next(1, 7);
                GameObject.Texture.SetAnimation($"side{Side}");
                SetStep.Invoke(Side);
                IsChange = true;
            }
        }

        /// <summary>
        /// Бросок кубика
        /// </summary>
        public void Throw()
        {
            currThrowTime = Time.CurrentTime + ThrowTime;
            IsChange = false;
        }
    }
}
