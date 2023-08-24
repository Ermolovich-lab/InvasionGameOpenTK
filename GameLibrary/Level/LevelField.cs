using EngineLibrary;
using EngineLibrary.ObjectComponents;
using GameLibrary.Players;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Level
{
    /// <summary>
    /// Класс генерирующий игровое поле
    /// </summary>
    public class LevelField
    {
        /// <summary>
        /// Фабрика противников
        /// </summary>
        public ElementsFactory ElementsFactory { get; private set; } = new ElementsFactory();
        /// <summary>
        /// Фабрика игрока
        /// </summary>
        public PlayerFactory PlayerFactory { get; set; }
        /// <summary>
        /// Метод, создающий игровое поле
        /// </summary>
        public void CreateLevel()
        {
            var game = Game.instance;

            Random random = new Random();

            float worldScale = Game.instance.HeightOfApplication / 15;

            Bitmap bitmap = new Bitmap(@"Content\map.bmp");

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    System.Drawing.Color color = bitmap.GetPixel(j, i);

                    GameObject gameObject = null;

                    if (color.R == 0 && color.G == 0 && color.B == 0)
                        gameObject = ElementsFactory.CreateWall(new Vector2(j, i) * worldScale);
                    else if (color.R == 125 && color.G == 125 && color.B == 125)
                        gameObject = ElementsFactory.CreateTransparentWall(new Vector2(j, i) * worldScale);
                    else if (color.R == 255 && color.G == 0 && color.B == 0)
                        PlayerFactory.StartPosition.Add("SecondPlayer", new Vector2(j, i) * worldScale);
                    else if (color.R == 0 && color.G == 0 && color.B == 255)
                        PlayerFactory.StartPosition.Add("FirstPlayer", new Vector2(j, i) * worldScale);

                    if (gameObject != null)
                        game.AddObjectOnScene(gameObject);
                }
            }
        }
    }
}
