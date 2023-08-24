using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class Game
    {
        /// <summary>
        /// Статическая ссылка на класс
        /// </summary>
        public static Game instance = null;

        public Scene Scene { get; private set; }

        public int WidthOfApplication { get; private set; } = 1280;
        public int HeightOfApplication { get; private set; } = 720;

        List<GameObject> gameObjects = new List<GameObject>(17);
        List<GameObject> gameObjectsToRemove = new List<GameObject>(17);
        List<GameObject> gameObjectsToAdd = new List<GameObject>(17);

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Game()
        {
            if (instance == null)
                instance = this;
        }

        public void ChengeScene(Scene scene)
        {
            gameObjectsToAdd.Clear();
            gameObjectsToRemove.AddRange(gameObjects);

            Scene = scene;
            Scene.Init();
        }

        /// <summary>
        /// Подсчёт игровых объектов
        /// </summary>
        /// <param name="typeObjects">Тип объекта</param>
        /// <returns>количество объектов</returns>
        public int CountGameObject(params string[] tagObjects)
        {
            int countObjects = 0;

            foreach (var gameObject in gameObjects)
            {
                foreach (var typeObject in tagObjects)
                {
                    if (gameObject.GameObjectTag == typeObject)
                    {
                        countObjects++;
                    }
                }
            }

            return countObjects;
        }

        /// <summary>
        /// Поиск объекта по тегу
        /// </summary>
        /// <param name="gameTag">тег объекта</param>
        /// <returns></returns>
        public GameObject[] FindGameObject(string gameTag)
        {
            return gameObjects.Where(x => x.GameObjectTag == gameTag).ToArray();
        }

        /// <summary>
        /// Добавление объекта в лист отрисовки
        /// </summary>
        /// <param name="gameObject">Игровой объект</param>
        public void AddObjectOnScene(GameObject gameObject)
        {
            gameObjectsToAdd.Add(gameObject);
        }

        private void RemoveRenderGameObjects()
        {
            foreach (GameObject removeGameObject in gameObjectsToRemove)
            {
                gameObjects.Remove(removeGameObject);

                removeGameObject.Dispose();
            }

            gameObjectsToRemove.Clear();
        }

        private void AddRenderGameObjects()
        {
            gameObjects.AddRange(gameObjectsToAdd);
            gameObjectsToAdd.Clear();
        }

        /// <summary>
        /// Метод для добавления игрового объекта
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddObjectsToRemove(GameObject gameObject)
        {
            gameObjectsToRemove.Add(gameObject);
        }

        /// <summary>
        /// Рендеринг кадра
        /// </summary>
        public void Rendering()
        {
            Time.UpdateTime();

            RemoveRenderGameObjects();
            AddRenderGameObjects();

            foreach (var obj in gameObjects)
            {
                obj.Update();

                if (obj.Texture != null && obj.IsActive)
                    SpriteBatch.Draw(obj);
            }
        }
    }
}
