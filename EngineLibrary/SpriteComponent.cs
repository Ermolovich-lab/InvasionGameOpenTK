using System.Collections.Generic;

namespace EngineLibrary.ObjectComponents
{
    /// <summary>
    /// Класс спрайта игровйо объекта
    /// </summary>
    public class SpriteComponent
    {
        /// <summary>
        /// Изображение игрового объекта
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Ширина спрайта
        /// </summary>
        public float WidthOfSprite { get; private set; }

        /// <summary>
        /// Высота спрайта
        /// </summary>
        public float HeightOfSprite { get; private set; }

        /// <summary>
        /// Инверсия по оси X
        /// </summary>
        public bool IsFlipX { get; set; }

        public Animation Animation
        {
            get => default;
            set
            {
            }
        }

        private Dictionary<string, Animation> animations;
        private string currentAnimation = "";

        /// <summary>
        /// Конструктор класса спрайта
        /// </summary>
        /// <param name="sprite">Изображение</param>
        public SpriteComponent(Texture2D sprite)
        {
            Texture = sprite;
            WidthOfSprite = sprite.Width;
            HeightOfSprite = sprite.Height;
            animations = new Dictionary<string, Animation>();
            animations.Add("inactive", new Animation(null, 1f, true));
        }

        /// <summary>
        /// Добавление анимации
        /// </summary>
        /// <param name="name">Ключ анимации</param>
        /// <param name="animation">Анимация</param>
        public void AddAnimation(string name, Animation animation)
        {
            animations.Add(name, animation);
        }

        /// <summary>
        /// Проигрывание анимации
        /// </summary>
        public void PlayAnimation()
        {
            if (currentAnimation == "") return;

            Texture = animations[currentAnimation].GetSpriteFromAnimation();
        }

        /// <summary>
        /// Установка текущей анимации
        /// </summary>
        /// <param name="name">Ключ анимации</param>
        public void SetAnimation(string name)
        {
            if (currentAnimation == name) return;

            if(currentAnimation != "")
                animations[currentAnimation].ResetAnimation();

            currentAnimation = name;
        }
    }
}