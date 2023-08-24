using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    /// <summary>
    /// Класс декоратор реализующий увеличение урона
    /// </summary>
    public class PowerDecorator : PlayerDecorator
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="player"></param>
        public PowerDecorator(PlayerProperties player) : base(player)
        {

        }

        public override float Power { get => base.Power * 2; set => base.Power = value; }
    }
}
