using EngineLibrary;
using GameLibrary.Bullets;
using GameLibrary.Players;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Weapons
{
    /// <summary>
    /// Класс скрипт описывающий оружие в игре
    /// </summary>
    public class Weapon : ObjectScript
    {
        /// <summary>
        /// Экземпляр сцены игры
        /// </summary>
        protected Game game;

        private float currentReloadTime = 0;

        private Player player;

        private bool isDown = false;

        public override void Start()
        {
            game = Game.instance;
        }

        public override void Update()
        {
            player = GameObject.ParentGameObject.Script as Player;

            if (player == null) return;

            currentReloadTime += Time.DeltaTime;

            if (Input.GetButtonDawn(player.Control.ShootKey) &&
                currentReloadTime > player.PlayerProperities.ReloadTime && !isDown)
            {
                currentReloadTime = 0;

                isDown = true;

                var position = GameObject.Transform.Position;
                var direction = player.Direction;

                SpawnBullet(position, direction, player.PlayerProperities.SpeedBullet, player.PlayerProperities.Power);
            }
            else if (!Input.GetButtonDawn(player.Control.ShootKey))
                isDown = false;
        }

        /// <summary>
        /// Создание пули из фабрики
        /// </summary>
        /// <param name="position">Позиция создания</param>
        /// <param name="direction">Направление пули</param>
        protected void SpawnBullet(Vector2 position, Vector2 direction, float speed, float power = 1)
        {
            BulletFactory factory = new BulletFactory();
            game.AddObjectOnScene(factory.CreateBullet(position, direction, speed, power, "Enemy", "Wall"));
        }
    }
}
