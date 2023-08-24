using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    /// <summary>
    /// Класс декоратор реализующий увеличение скорости полета пули
    /// </summary>
    public class SpeedBulletDecorator : PlayerDecorator
    {
        /// <summary>
        /// Конструкор класса
        /// </summary>
        /// <param name="player">Свойства игрока</param>
        public SpeedBulletDecorator(PlayerProperties player) : base(player)
        {

        }

        public override float SpeedBullet { get => base.SpeedBullet * 1.5f ; set => base.SpeedBullet = value; }
    }
}
