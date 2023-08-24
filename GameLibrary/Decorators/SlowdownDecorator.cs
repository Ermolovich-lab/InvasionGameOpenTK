using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    /// <summary>
    /// Класс декоратор реализующий уменьшение скорости передвижения
    /// </summary>
    public class SlowdownDecorator : PlayerDecorator
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="player"></param>
        public SlowdownDecorator(PlayerProperties player) : base(player)
        {
        }

        public override float Speed { get => base.Speed / 2; set => base.Speed = value; }
    }
}
