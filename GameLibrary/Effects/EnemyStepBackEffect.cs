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
    /// Класс, описывающий эффект, отнимающий один шаг у соперника.
    /// </summary>
    public class EnemyStepBackEffect : Effect
    {
        public override void SetEffect(ObjectScript player)
        {
            GameObject effectedPlayer;

            if(player.GameObject.GameObjectTag == "FirstPlayer")
                effectedPlayer = Game.instance.FindGameObject("SecondPlayer");
            else
                effectedPlayer = Game.instance.FindGameObject("FirstPlayer");

            (effectedPlayer.Script as Player).PlayerProperities = new StepBackDecorator((effectedPlayer.Script as Player).PlayerProperities);

            GameEvents.PlayerState(effectedPlayer.GameObjectTag, "Step back effect");
        }
    }
}
