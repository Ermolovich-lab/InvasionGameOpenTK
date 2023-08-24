using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Players
{
    public abstract class PlayerProperties
    {
        /// <summary>
        /// Скорость передвижения
        /// </summary>
        public abstract float Speed { get; set; }

        /// <summary>
        /// Скорость полета пули
        /// </summary>
        public abstract float SpeedBullet { get; set; }

        /// <summary>
        /// Скорострельность
        /// </summary>
        public abstract float ReloadTime { get; set; }
        /// <summary>
        /// Урон
        /// </summary>
        public abstract float Power { get; set; }
    }
}
