using EngineLibrary;
using GameLibrary.Decorators;
using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Effects
{
    /// <summary>
    /// Класс, описывающий эффект замедления игрока
    /// </summary>
    public class SlowDownEffect : Effect
    {
        public override void SetEffect(Player player)
        {

            player.SetEffect(new SlowdownDecorator(player.PlayerProperities));
        }
    }
}
