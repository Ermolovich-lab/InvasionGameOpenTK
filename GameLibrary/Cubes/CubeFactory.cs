using EngineLibrary;
using EngineLibrary.ObjectComponents;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Cubes
{
    /// <summary>
    /// Фабрика по инициализации куба
    /// </summary>
    public class CubeFactory
    {
        /// <summary>
        /// Создание игрового объекта куба
        /// </summary>
        public GameObject Create(Vector2 position)
        {
            GameObject cube = new GameObject();
            cube.SetComponent(new TransformComponent(position, new Vector2(0.8f, 0.8f), new Vector2(0, 0), 0));
            cube.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("cube/side1.png")));

            Animation animation = new Animation(ContentPipe.LoadAnimation("cube/side", 6), 0.2f, true);

            Animation animation1 = new Animation(ContentPipe.LoadAnimation("cube/side1", 1), 0.2f, true);
            Animation animation2 = new Animation(ContentPipe.LoadAnimation("cube/side2", 1), 0.2f, true);
            Animation animation3 = new Animation(ContentPipe.LoadAnimation("cube/side3", 1), 0.2f, true);
            Animation animation4 = new Animation(ContentPipe.LoadAnimation("cube/side4", 1), 0.2f, true);
            Animation animation5 = new Animation(ContentPipe.LoadAnimation("cube/side5", 1), 0.2f, true);
            Animation animation6 = new Animation(ContentPipe.LoadAnimation("cube/side6", 1), 0.2f, true);

            cube.Texture.AddAnimation("throw", animation);

            cube.Texture.AddAnimation("side1", animation1);
            cube.Texture.AddAnimation("side2", animation2);
            cube.Texture.AddAnimation("side3", animation3);
            cube.Texture.AddAnimation("side4", animation4);
            cube.Texture.AddAnimation("side5", animation5);
            cube.Texture.AddAnimation("side6", animation6);

            Cube script = new Cube();
            script.Start();
            script.Initialize(cube);
            cube.SetComponent(script);

            return cube;
        }
    }
}
