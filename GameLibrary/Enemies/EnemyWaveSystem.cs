using EngineLibrary;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Enemies
{
    /// <summary>
    /// Класс скрипт реализующий систему волн противников
    /// </summary>
    public class EnemyWaveSystem : ObjectScript
    {
        private float reloadTimeEnemy;
        private float currReloadTimeEnemy = 0;

        private float reloadTimeWave;
        private float currReloadTimeWave = 0;

        private int[] wave;
        /// <summary>
        /// Места появления противников
        /// </summary>
        public List<Vector2> Inputs { get; private set; } = new List<Vector2>();
        /// <summary>
        /// Теги оружия противников
        /// </summary>
        public List<string> TagWeapons { get; private set; } = new List<string>();
        /// <summary>
        /// Окончание волны
        /// </summary>
        public bool EndWave { get; private set; } = false;

        private EnemyFactory factory;
        /// <summary>
        /// Список объетов за которыми необходимо следить
        /// </summary>
        public List<GameObject> FollowGameObjects { get; private set; } = new List<GameObject>();

        private Game game;

        private Random random;

        private int currWave = 0;
        private int currEnemy = 0;

        public override void Start()
        {
            reloadTimeEnemy = 2;
            reloadTimeWave = 10;
            wave = new[] { 3, 5, 10, 15, 20, 30 };

            game = Game.instance;

            factory = new EnemyFactory();

            random = new Random();

            GameEvents.Wave.Invoke(currWave + "/" + wave.Length);
        }

        public override void Update()
        {

            if (Time.CurrentTime <= currReloadTimeWave) return;

            if (currWave == wave.Length && game.FindGameObject("Enemy").Length == 0)
            {
                EndWave = true;
                return;
            }

            if (Time.CurrentTime >= currReloadTimeEnemy)
            {
                currReloadTimeEnemy = reloadTimeEnemy + Time.CurrentTime;

                var obj = factory.Create(TagWeapons[random.Next(0, TagWeapons.Count)], Inputs[random.Next(0, Inputs.Count)]);
                (obj.Script as Enemy).SetFollowGameObject(FollowGameObjects.ToArray());
                game.AddObjectOnScene(obj);
                game.AddObjectOnScene(obj.ChildGameObject);

                currEnemy++;

                if (currEnemy == wave[currWave])
                {
                    currReloadTimeWave = reloadTimeWave + Time.CurrentTime;
                    currEnemy = 0;
                    currWave++;
                    GameEvents.Wave.Invoke(currWave + "/" + wave.Length);
                }
            }            
        }
    }
}
