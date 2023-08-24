using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    /// <summary>
    /// Декоратор класса свойств игрока
    /// </summary>
    public abstract class PlayerDecorator : PlayerProperties
    {
        protected PlayerProperties player;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="player"></param>
        public PlayerDecorator(PlayerProperties player)
        {
            this.player = player;
        }

        public override float Speed { get => player.Speed; set => player.Speed = value; }

        public override float SpeedBullet { get => player.SpeedBullet; set => player.SpeedBullet = value; }

        public override float ReloadTime { get => player.ReloadTime; set => player.ReloadTime = value; }

        public override float Power { get => player.Power; set => player.Power = value; }
    }
}
