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
    /// Класс, описывающий эффект, отнимающий у игрока один шаг.
    /// </summary>
    public class StepBackEffect : Effect
    {
        public override void SetEffect(ObjectScript player)
        {
            (player as Player).PlayerProperities = new StepBackDecorator((player as Player).PlayerProperities);

            GameEvents.PlayerState(player.GameObject.GameObjectTag, "Step back effect");
        }
    }
}
