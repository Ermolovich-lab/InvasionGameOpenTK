
using EngineLibrary;
using GameLibrary.Effects;
using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Bonuses
{
    /// <summary>
    /// Класс скрипт реализующий логику бонуса
    /// </summary>
    public class Bonus : ObjectScript
    {
        private Effect effect;

        public override void Start()
        {
            
        }
        /// <summary>
        /// Установк эффекта на объект
        /// </summary>
        /// <param name="effect">Эффект</param>
        public void SetEffect(Effect effect)
        {
            this.effect = effect;
        }

        public override void Update()
        {
            if (GameObject.Colliders.CheckGameObjectIntersection(out GameObject gameObject, tagNames: new[] { "FirstPlayer", "SecondPlayer" }))
            {
                effect.SetEffect(gameObject.Script as Player);

                Game.instance.AddObjectsToRemove(GameObject);
            }
            else if (GameObject.Colliders.CheckGameObjectIntersection(out GameObject bonus, tagNames: new[] { "Bonus" }))
            {
                Game.instance.AddObjectsToRemove(GameObject);
            }
        }
    }
}
