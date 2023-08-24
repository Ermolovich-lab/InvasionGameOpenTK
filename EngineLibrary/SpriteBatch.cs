using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Класс для отрисовки тексуры
    /// </summary>

    public class SpriteBatch
    {
        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-screenWidth / 2f, screenWidth / 2f, screenHeight / 2f, -screenHeight / 2f, 0f, 1f);
        }

        /// <summary>
        /// Метод для отрисовки текстуры
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Draw(GameObject gameObject)
        {
            var texture = gameObject.Texture.Texture;
            var scale = gameObject.Transform.Scale;
            var position = gameObject.Transform.Position;
            var angle = gameObject.Transform.Angle;
            var centre = gameObject.Transform.Centre;

            Vector2 buff;

            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
            };

            GL.BindTexture(TextureTarget.Texture2D, gameObject.Texture.Texture.ID);
            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < 4; i++)
            {
                GL.TexCoord2(vertices[i]);

                buff = vertices[i] - centre;
                vertices[i].X = buff.X * (float)Math.Cos(angle) - buff.Y * (float)Math.Sin(angle);
                vertices[i].Y = buff.X * (float)Math.Sin(angle) + buff.Y * (float)Math.Cos(angle);
                vertices[i] += centre;

                vertices[i].X *= texture.Width;
                vertices[i].Y *= texture.Height;
                vertices[i] *= scale;
                vertices[i] += position;

                GL.Vertex2(vertices[i]);
            }

            GL.End();
        }
    }
}
