using EngineLibrary;
using GameLibrary.Bonuses;
using GameLibrary.Enemies;
using GameLibrary.Interfaces;
using GameLibrary.Level;
using GameLibrary.Players;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.InvasionGame
{
    /// <summary>
    /// Класс описывающий основную игровую сцену
    /// </summary>
    public class LevelScene : Scene
    {
        /// <summary>
        /// Фабрика игрока
        /// </summary>
        public PlayerFactory PlayerFactory { get; private set; }

        private string firstWeapon;
        private string secondWeapon;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="firstWeapon">Первый вид оружия</param>
        /// <param name="secondWeapon">Второй вид оружия</param>
        public LevelScene(string firstWeapon, string secondWeapon)
        {
            this.firstWeapon = firstWeapon;
            this.secondWeapon = secondWeapon;
        }

        public override void Init()
        {
            PlayerFactory = new PlayerFactory();

            LevelField levelField = new LevelField();
            levelField.PlayerFactory = PlayerFactory;
            levelField.CreateLevel();

            var firstPlayer = PlayerFactory.CreatePlayer("FirstPlayer");
            var secondPlayer = PlayerFactory.CreatePlayer("SecondPlayer");
            var weapon1 = PlayerFactory.CreateWeapon(firstWeapon);
            firstPlayer.SetChildGameObject(weapon1);
            var weapon2 = PlayerFactory.CreateWeapon(secondWeapon);
            secondPlayer.SetChildGameObject(weapon2);

            GameObject waveSystem = new GameObject();
            EnemyWaveSystem enemyWaveSystem = new EnemyWaveSystem();
            enemyWaveSystem.Inputs.Add(new Vector2(20, 350));
            enemyWaveSystem.Inputs.Add(new Vector2(1200, 350));
            enemyWaveSystem.TagWeapons.Add("EnemyAutoWeapon");
            enemyWaveSystem.TagWeapons.Add("BFG");
            enemyWaveSystem.TagWeapons.Add("EnemyMiniWeapon");
            enemyWaveSystem.FollowGameObjects.Add(firstPlayer);
            enemyWaveSystem.FollowGameObjects.Add(secondPlayer);
            enemyWaveSystem.Start();
            waveSystem.SetComponent(enemyWaveSystem);

            GameObject bonusSystem = new GameObject();
            BonusLauncher script = new BonusLauncher();
            script.SetSpawnPoint(new[] { new Vector2(50, 350), new Vector2(1150, 350), new Vector2(600, 50), new Vector2(600, 600) });
            script.Start();
            bonusSystem.SetComponent(script);

            GameObject endGame = new GameObject();
            EndGame endGame1 = new EndGame();
            endGame1.OnAction += delegate (string end) { EndScene(end); };
            endGame1.EnemyWaveSystem = enemyWaveSystem;
            endGame1.Healths = new[] { firstPlayer.Script as IHealth, secondPlayer.Script as IHealth };
            endGame.SetComponent(endGame1);

            game.AddObjectOnScene(firstPlayer);
            game.AddObjectOnScene(secondPlayer);
            game.AddObjectOnScene(weapon1);
            game.AddObjectOnScene(weapon2);
            game.AddObjectOnScene(waveSystem);
            game.AddObjectOnScene(bonusSystem);
            game.AddObjectOnScene(endGame);
        }

        /// <summary>
        /// Поведение при завершении сцены
        /// </summary>
        protected override void EndScene(string end)
        {
            GameEvents.EndGame(end);
        }
    }
}
