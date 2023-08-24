using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    /// <summary>
    /// Класс декоратор реализующий действие замораживающей ловушки
    /// </summary>
    public class FreezeDecorator : PlayerDecorator
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="player">Свойства игрока</param>
        public FreezeDecorator(PlayerProperties player) : base(player)
        {

        }

        public override float Speed { get => base.Speed * 0; set => base.Speed = value; }
    }
}
