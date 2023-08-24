using EngineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Sections
{
    /// <summary>
    /// Класс описывающий движение по секциям
    /// </summary>
    public class SectionMovement
    {
        private Section[] sections;

        public SectionMovement(Section[] sections)
        {
            this.sections = sections;
        }

        public Section this[int index]
        {
            get => sections[index];
        }

        /// <summary>
        /// Установка игровых объектов на старт
        /// </summary>
        public void SetObjectsToStartSection(GameObject[] gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                sections.First(x => x.TypeSection == TypeSection.Start).SetChildGameObject(gameObject);
            }
        }

        /// <summary>
        /// Изменение секции игрового объекта
        /// </summary>
        public void ChangePositionObject(int newPosition, string objectTag)
        {
            for (int i = 0; i < sections.Length; i++)
            {
                if (sections[i].GetChildGameObject(objectTag) != null)
                {
                    var obj = sections[i].GetChildGameObject(objectTag);

                    if (i + newPosition >= sections.Length)
                        sections[sections.Length - 1].SetChildGameObject(obj);
                    else
                        sections[i + newPosition].SetChildGameObject(obj);

                    sections[i].DelChildGameObject(objectTag);

                    break;
                }
            }
        }
    }
}
