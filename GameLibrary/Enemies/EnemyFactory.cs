using EngineLibrary;
using EngineLibrary.ObjectComponents;
using GameLibrary.Weapons;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Enemies
{
    /// <summary>
    /// Класс реализующий фабрику инициализации противников
    /// </summary>
    public class EnemyFactory
    {
        /// <summary>
        /// Создание игрового объекта персонажа
        /// </summary>
        public GameObject Create(string tagWeapon, Vector2 position)
        {
            GameObject result = new GameObject();
            result.GameObjectTag = "Enemy";

            result.SetComponent(new TransformComponent(position, new Vector2(0.2f, 0.2f), new Vector2(0, 0), 0));

            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(result));
            result.SetComponent(collSyst);
            var sprite = new SpriteComponent(ContentPipe.LoadTexture("EnemyRight.png"));
            var anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture("EnemyRight.png"));
            sprite.AddAnimation("Right", new Animation(anim, 1, true));
            anim = new List<Texture2D>();
            anim.Add(ContentPipe.LoadTexture("EnemyLeft.png"));
            sprite.AddAnimation("Left", new Animation(anim, 1, true));
            result.SetComponent(sprite);
            Enemy script = new Enemy();
            script.Initialize(result);
            script.Start();
            result.SetComponent(script);

            result.SetChildGameObject(CreateWeapon(tagWeapon));

            return result;
        }
        /// <summary>
        /// Создание игрового объекта оружия
        /// </summary>
        /// <param name="tag">Тег оружия</param>
        /// <returns></returns>
        private GameObject CreateWeapon(string tag)
        {
            GameObject result = new GameObject();
            result.GameObjectTag = tag;

            result.SetComponent(new TransformComponent(new Vector2(0, 25), new Vector2(1.5f, 1.5f), new Vector2(0, 0), 0));

            var collSyst = new SystemCollider();
            collSyst.Add(new ColliderComponent(result, 5));
            collSyst.Add(new ColliderComponent(result, 3, new Vector2(80, 0)));
            collSyst.Add(new ColliderComponent(result, 3, new Vector2(-80, 0)));
            collSyst.Add(new ColliderComponent(result, 3, new Vector2(0, 80)));
            collSyst.Add(new ColliderComponent(result, 3, new Vector2(0, -80)));
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

            EnemyWeapon script = new EnemyWeapon();
            script.Initialize(result);
            script.Start();
            result.SetComponent(script);

            return result;
        }
    }
}
