using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Players
{
    /// <summary>
    /// Класс описывающий стандартные свойства игрока
    /// </summary>
    public class PlayerPropertiesStandart : PlayerProperties
    {
        /// <summary>
        /// Скорость передвижения
        /// </summary>
        public override float Speed { get; set; } = 200;

        /// <summary>
        /// Скорость полета пули
        /// </summary>
        public override float SpeedBullet { get; set; } = 300;

        /// <summary>
        /// Скорострельность
        /// </summary>
        public override float ReloadTime { get; set; } = 0.5f;
        /// <summary>
        /// Урон
        /// </summary>
        public override float Power { get; set; } = 2;
    }
}