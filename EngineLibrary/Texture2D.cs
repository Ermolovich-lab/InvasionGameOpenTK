using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Класс для хранения текстуры
    /// </summary>
    public class Texture2D
    {
        private int id;
        private int width, height;

        /// <summary>
        /// Свойство, хранящее id текстуры
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
        }
        /// <summary>
        /// Ширина текстуры
        /// </summary>
        public int Width
        {
            get { return width; }
        }
        /// <summary>
        /// Высота текстуры
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>
        /// Конструктор создания объекта класса 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Texture2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }
    }
}
