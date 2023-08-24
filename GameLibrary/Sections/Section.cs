using EngineLibrary;
using GameLibrary.Effects;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Sections
{
    /// <summary>
    /// Класс описывающий секцию
    /// </summary>
    public class Section : ObjectScript
    {
        private List<GameObject> childGameObjects;

        private Effect effect;

        /// <summary>
        /// Тип секции
        /// </summary>
        public TypeSection TypeSection { get; private set; }

        public override void Start()
        {
            childGameObjects = new List<GameObject>();
            TypeSection = TypeSection.Simple;
        }

        public override void Update()
        {
            if (TypeSection == TypeSection.Finish && childGameObjects.Count != 0)
            {
                Game.instance.EndScene(childGameObjects[0].GameObjectTag);
            }
        }

        /// <summary>
        /// Установка типа секции
        /// </summary>
        /// <param name="typeSection"></param>
        public void SetTypeSection(TypeSection typeSection)
        {
            TypeSection = typeSection;
        }

        /// <summary>
        /// Установка эффекта секции
        /// </summary>
        /// <param name="effect"></param>
        public void SetEffectSection(Effect effect)
        {
            this.effect = effect;
        }

        /// <summary>
        /// Установка дочернего объекта в секцию
        /// </summary>
        /// <param name="childGameObject"></param>
        public void SetChildGameObject (GameObject childGameObject)
        {
            childGameObject.Transform.Position = GameObject.Transform.Position;
            if(childGameObjects.Count != 0)
            {
                childGameObjects[0].Transform.SetMovement(new Vector2(20, -25));
                childGameObject.Transform.SetMovement(new Vector2(20, 25));
            }

            if(effect != null)
                effect.SetEffect(childGameObject.Script);

            childGameObjects.Add(childGameObject);
        }

        /// <summary>
        /// Получить дочерний объект
        /// </summary>
        public GameObject GetChildGameObject(string tag)
        {
            return childGameObjects.Find(x => x.GameObjectTag == tag);
        }

        /// <summary>
        /// Удалить дочерний объект
        /// </summary>
        public void DelChildGameObject(string tag)
        {
            childGameObjects.Remove(childGameObjects.Find(x => x.GameObjectTag == tag));
        }
    }
}
