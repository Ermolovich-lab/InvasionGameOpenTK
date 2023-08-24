using EngineLibrary;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Bonuses
{
    /// <summary>
    /// Класс скрипт реализующий спавн бонусов и ловушек на игровой сцене
    /// </summary>
    public class BonusLauncher : ObjectScript
    {
        private float reloadTimeSpawn;
        private float currRealoadTimeSpawn;
        private Random random;
        private Game game;
        private BonusFactory bonusFactory;
        private Vector2[] spawnPoint;

        public override void Start()
        {
            reloadTimeSpawn = 10;
            currRealoadTimeSpawn = reloadTimeSpawn;
            random = new Random();
            game = Game.instance;
            bonusFactory = new BonusFactory();
        }
        /// <summary>
        /// Установка точек появления бонусов и ловушек
        /// </summary>
        /// <param name="spawnPoint">Точка появления</param>
        public void SetSpawnPoint(Vector2[] spawnPoint)
        {
            this.spawnPoint = spawnPoint;
        }

        public override void Update()
        {
            if (Time.CurrentTime >= currRealoadTimeSpawn)
            {
                currRealoadTimeSpawn = reloadTimeSpawn + Time.CurrentTime;

                GameObject bonus = null;
                Vector2 position = spawnPoint[random.Next(0, spawnPoint.Length)];

                switch (random.Next(0, 5))
                {
                    case 0:
                        bonus = bonusFactory.CreateFreezeBonus(position);
                        break;
                    case 1:
                        bonus = bonusFactory.CreatePowerBonus(position);
                        break;
                    case 2:
                        bonus = bonusFactory.CreateReloadTimeBonus(position);
                        break;
                    case 3:
                        bonus = bonusFactory.CreateSlowdownBonus(position);
                        break;
                    case 4:
                        bonus = bonusFactory.CreateSpeedBulletBonus(position);
                        break;
                }

                game.AddObjectOnScene(bonus);
            }
        }
    }
}
