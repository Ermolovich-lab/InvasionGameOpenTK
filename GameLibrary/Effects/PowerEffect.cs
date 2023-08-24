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
    /// Класс, опсывающий эффект увеличения урона оружия
    /// </summary>
    public class PowerEffect : Effect
    {
        public override void SetEffect(Player player)
        {

            player.SetEffect(new PowerDecorator(player.PlayerProperities));
        }
    }
}
