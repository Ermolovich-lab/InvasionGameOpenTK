using EngineLibrary;
using GameLibrary.Enemies;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.InvasionGame
{
    /// <summary>
    /// Класс скрипт реализующий событие окончания игры
    /// </summary>
    public class EndGame : ObjectScript
    {
        /// <summary>
        /// Действие при окончании игры
        /// </summary>
        public Action<string> OnAction;
        /// <summary>
        /// Система волн противников
        /// </summary>
        public EnemyWaveSystem EnemyWaveSystem { get; set; }

        public IHealth[] Healths { get; set; }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            if (EnemyWaveSystem.EndWave)
                OnAction.Invoke("You Win.");
            else if(Healths.All(x => x.Health <= 0))
                OnAction.Invoke("Game Over.");
        }
    }
}
