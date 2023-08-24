using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class TexturesBox : IDisposable
    {
        /// <summary>
        /// Текущая текстура
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Список всех текстур
        /// </summary>
        private Dictionary<string, Texture2D> TextureDictionary;

        float delta = 0;

        float currTime = 0;

        private bool isLoop = true;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public TexturesBox(Texture2D texture)
        {
            TextureDictionary = new Dictionary<string, Texture2D>();

            TextureDictionary.Add("default", texture);

            Texture = texture;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public TexturesBox()
        {
            TextureDictionary = new Dictionary<string, Texture2D>();
        }

        /// <summary>
        /// Добавление текстуры в список
        /// </summary>
        /// <param name="name">тэг текстуры</param>
        /// <param name="texture2D">текстура</param>
        public void Add(string name, Texture2D texture2D)
        {
            TextureDictionary.Add(name, texture2D);
        }

        /// <summary>
        /// Удаление текстуры из списка
        /// </summary>
        /// <param name="name">тэг текстуры</param>
        public void Del(string name)
        {
            TextureDictionary.Remove(name);
        }

        /// <summary>
        /// Замена текстуры по тэгу
        /// </summary>
        /// <param name="texture2D">текстура</param>
        /// <param name="name">тэг текстуры</param>
        public void Edit(Texture2D texture2D, string name)
        {
            TextureDictionary[name] = texture2D;
        }

        /// <summary>
        /// Установка текущей текстуры
        /// </summary>
        /// <param name="name">тэг текстуры</param>
        public void Set(string name)
        {
            if (IsTimeOver())
            {
                Texture = TextureDictionary[name];

                currTime = Time.CurrentTime;

                delta = 0;

                isLoop = false;
            }

            //changeTime -= 1;
        }

        /// <summary>
        ///  Установка текущей текстуры на определённое время
        /// </summary>
        /// <param name="name">тэг текстуры</param>
        /// <param name="delta">время установки</param>
        public void Set(string name, float delta)
        {
            if (IsTimeOver())
            {
                Texture = TextureDictionary[name];

                this.delta = delta;
                currTime = Time.CurrentTime;

                isLoop = true;
            }

            //changeTime -= 1;
        }

        /// <summary>
        /// Собирает список id текстур
        /// </summary>
        /// <returns>Список id текстур</returns>
        public List<int> GetIdTextures()
        {
            List<int> result = new List<int>(10);

            foreach (var textur in TextureDictionary)
                result.Add(textur.Value.ID);

            return result;
        }

        /// <summary>
        /// Обновление текстуры
        /// </summary>
        public void Update()
        {
            if (isLoop && IsTimeOver())
            {
                Texture = TextureDictionary["default"];
            }
        }

        bool IsTimeOver()
        {
            if(Time.CurrentTime - currTime >= delta)
                return true;

            return false;
        }

        /// <summary>
        /// освобождение памяти
        /// </summary>
        public void Dispose()
        {
            ContentPipe.DeletTexture(GetIdTextures());
            TextureDictionary.Clear();
        }
    }
}
