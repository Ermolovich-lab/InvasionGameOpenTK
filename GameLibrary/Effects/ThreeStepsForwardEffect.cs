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
    /// Класс, опсывающий эффект, прибавляющий игроку три шага.
    /// </summary>
    public class ThreeStepsForwardEffect : Effect
    {
        public override void SetEffect(ObjectScript player)
        {
            (player as Player).PlayerProperities = new ThreeStepsForwardDecorator((player as Player).PlayerProperities);

            GameEvents.PlayerState(player.GameObject.GameObjectTag, "Three steps forward effect");
        }
    }
}
