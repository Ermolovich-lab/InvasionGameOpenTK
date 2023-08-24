using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace EngineLibrary
{
    /// <summary>
    /// Класс для работы с текстурами
    /// </summary>
    public class ContentPipe
    {
        /// <summary>
        /// Загрузка текстуры в память
        /// </summary>
        public static Texture2D LoadTexture(string path)
        {
            if (!File.Exists(@"Content\" + path))
                throw new FileNotFoundException(@"File not found at `Content\" + path + "`");

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(@"Content\" + path);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            int width = bmp.Width;
            int height = bmp.Height;

            bmp.Dispose();

            return new Texture2D(id, width, height);
        }

        public static List<Texture2D> LoadAnimation(string path,int countTextures)
        {
            List<Texture2D> animation = new List<Texture2D>();

            for (int i = 1; i <= countTextures; i++)
            {
                animation.Add(LoadTexture(path + i + ".png"));
            }

            return animation;
        }

        /// <summary>
        /// Удаление текстуры из памяти
        /// </summary>
        public static void DeletTexture(List<int> texturesId)
        {
            foreach (var id in texturesId)
                GL.DeleteTexture(id);
        }
    }
}
