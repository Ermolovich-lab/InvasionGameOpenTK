using System.Collections.Generic;

namespace EngineLibrary.ObjectComponents
{
    /// <summary>
    /// Класс анимации 
    /// </summary>
    public class Animation
    {
        private List<Texture2D> sprites;

        private int currentIndexInAnimation;

        private float changeTime;

        private float deltaTimeAnimation;

        private bool isLoop;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sprites">Список спрайтов</param>
        /// <param name="changeTime">Время смены каждого спрайта</param>
        /// <param name="isLoop">Зацикленностб анимации</param>
        public Animation(List<Texture2D> sprites, float changeTime, bool isLoop)
        {
            this.sprites = sprites;
            this.changeTime = changeTime;
            this.isLoop = isLoop;
            deltaTimeAnimation = changeTime;
            currentIndexInAnimation = 0;
        }

        /// <summary>
        /// Сброс анимации
        /// </summary>
        public void ResetAnimation()
        {
            currentIndexInAnimation = 0;
        }

        /// <summary>
        /// Возращает текущее изображение анимации
        /// </summary>
        /// <returns>Текущее изображение в анимации</returns>
        public Texture2D GetSpriteFromAnimation()
        {
            if (sprites == null)
                return null;

            if (changeTime < Time.CurrentTime)
            {
                currentIndexInAnimation++;
                changeTime = Time.CurrentTime + deltaTimeAnimation;
            }

            if (currentIndexInAnimation >= sprites.Count)
                if (!isLoop)
                    return null;
                else
                    currentIndexInAnimation = 0;

            return sprites[currentIndexInAnimation];
        }
    }
}
