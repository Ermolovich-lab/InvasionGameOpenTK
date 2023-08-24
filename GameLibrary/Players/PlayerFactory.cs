using EngineLibrary;
using EngineLibrary.ObjectComponents;
using GameLibrary.Weapons;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Players
{
    /// <summary>
    /// Фабрика по инициализации игрока
    /// </summary>
    public class PlayerFactory
    {
        public Dictionary<string, Vector2> StartPosition { get; private set; } = new Dictionary<string, Vector2>();

        /// <summary>
        /// Создание игрового объекта игрока
        /// </summary>
        public GameObject CreatePlayer(string tag)
        {
            GameObject result = new GameObject();
            result.GameObjectTag = tag;

            result.SetComponent(new TransformComponent(StartPosition[tag], new Vector2(0.25f, 0.25f), new Vector2(0, 0), 0));

            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(result));
            result.SetComponent(collSyst);
            var sprite = new SpriteComponent(ContentPipe.LoadTexture(tag + "Right.png"));
            var anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture(tag + "Right.png"));
            sprite.AddAnimation("Right", new Animation(anim, 1, true));
            anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture(tag + "Left.png"));
            sprite.AddAnimation("Left", new Animation(anim, 1, true));
            result.SetComponent(sprite);
            Player script = new Player();
            script.Initialize(result);
            script.SetStartPosition(StartPosition[tag]);
            script.Start();
            result.SetComponent(script);

            return result;
        }
        /// <summary>
        /// Создание игрового объекта оружия
        /// </summary>
        /// <param name="tag">Тег оружия</param>
        /// <returns></returns>
        public GameObject CreateWeapon(string tag)
        {
            GameObject result = new GameObject();
            result.GameObjectTag = tag;

            result.SetComponent(new TransformComponent(new Vector2(0, 25), new Vector2(1.5f, 1.5f), new Vector2(0, 0), 0));

            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(result));
            result.SetComponent(collSyst);

            var sprite = new SpriteComponent(ContentPipe.LoadTexture(tag + "Right.png"));
            var anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture(tag + "Right.png"));
            sprite.AddAnimation("Right", new Animation(anim, 1, true));
            anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture(tag + "Left.png"));
            sprite.AddAnimation("Left", new Animation(anim, 1, true));
            anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture(tag + "Top.png"));
            sprite.AddAnimation("Top", new Animation(anim, 1, true));
            anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture(tag + "Bottom.png"));
            sprite.AddAnimation("Bottom", new Animation(anim, 1, true));
            result.SetComponent(sprite);

            Weapon script = new Weapon();
            script.Initialize(result);
            script.Start();
            result.SetComponent(script);

            return result;
        }
    }
}
