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
    /// Класс, описывающий эффект увеличения скорострельности
    /// </summary>
    public class ReloadTimeEffect : Effect
    {
        public override void SetEffect(Player player)
        {
            player.SetEffect(new ReloadTimeDecorator(player.PlayerProperities));
        }
    }
}
