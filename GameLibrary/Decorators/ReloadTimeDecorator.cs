using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    /// <summary>
    /// Класс декоратор релизующий увеличение скорострельности оружия
    /// </summary>
    public class ReloadTimeDecorator : PlayerDecorator
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="player"></param>
        public ReloadTimeDecorator(PlayerProperties player) : base(player)
        {

        }

        public override float ReloadTime { get => base.ReloadTime / 2; set => base.ReloadTime = value; }
    }
}
