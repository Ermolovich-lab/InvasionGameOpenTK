using EngineLibrary;
using EngineLibrary.ObjectComponents;
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
    /// Класс описывающий начальную сцену
    /// </summary>
    public class StartScene : Scene
    {
        private string firstWeapon;
        private string secondWeapon;

        protected override void EndScene(string end)
        {
            game.ChengeScene(new LevelScene(firstWeapon, secondWeapon));
        }

        public override void Init()
        {
            var factory = new PlayerFactory();

            var weapons = new[] { factory.CreateWeapon("SniperWeapon"), factory.CreateWeapon("AutoWeapon") };
            var weapons1 = new[] { factory.CreateWeapon("SniperWeapon"), factory.CreateWeapon("AutoWeapon") };

            GameObject gameObject = new GameObject();
            gameObject.GameObjectTag = "FirstPlayer";
            gameObject.SetComponent(new TransformComponent(new Vector2(400, 300), new Vector2(1.5f, 1.5f), new Vector2(0, 0), 0));
            gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("FirstPlayerRight.png")));

            PlayerChoice playerChoice = new PlayerChoice();
            playerChoice.Initialize(gameObject);
            playerChoice.SetWeapons(weapons);
            playerChoice.Start();
            gameObject.SetComponent(playerChoice);

            GameObject gameObject1 = new GameObject();
            gameObject1.GameObjectTag = "SecondPlayer";
            gameObject1.SetComponent(new TransformComponent(new Vector2(800, 300), new Vector2(1.5f, 1.5f), new Vector2(0, 0), 0));
            gameObject1.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("SecondPlayerRight.png")));

            PlayerChoice playerChoice1 = new PlayerChoice();
            playerChoice1.Initialize(gameObject1);
            playerChoice1.SetWeapons(weapons1);
            playerChoice1.Start();
            playerChoice1.OnAction += delegate ()
            {
                firstWeapon = gameObject.ChildGameObject.GameObjectTag;
                secondWeapon = gameObject1.ChildGameObject.GameObjectTag;
                EndScene("");
            };
            gameObject1.SetComponent(playerChoice1);

            game.AddObjectOnScene(gameObject);
            game.AddObjectOnScene(gameObject.ChildGameObject);
            game.AddObjectOnScene(gameObject1);
            game.AddObjectOnScene(gameObject1.ChildGameObject);
        }
    }
}
