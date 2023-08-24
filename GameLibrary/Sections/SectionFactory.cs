using EngineLibrary;
using EngineLibrary.ObjectComponents;
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
    /// Фабрика по инициализации секций
    /// </summary>
    public class SectionFactory
    {
        /// <summary>
        /// Точки расположений
        /// </summary>
        public Vector2[] Points { get; private set; }

        private const int countEffects = 3;

        Random random = new Random();

        /// <summary>
        /// Создание игровых объектов секций
        /// </summary>
        public GameObject[] Create()
        {
            if (Points == null) return null;

            GameObject[] result = new GameObject[Points.Length];

            for (int i = 0; i < Points.Length; i++)
            {
                GameObject gameObject = new GameObject();
                var script = new Section();
                script.Start();
                script.Initialize(gameObject);
                gameObject.SetComponent(script);

                if (i == 0)
                {
                    script.SetTypeSection(TypeSection.Start);
                    gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Sections/SectionStart.png")));
                } 
                else if (i == Points.Length - 1)
                {
                    script.SetTypeSection(TypeSection.Finish);
                    gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Sections/SectionFinish.png")));
                }
                else
                    gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Sections/SectionSimple.png")));

                if (random.Next(1,4) == 2 && script.TypeSection == TypeSection.Simple)
                    SetEffect(random.Next(1, countEffects + 1), gameObject);

                gameObject.SetComponent(new TransformComponent(Points[i], new Vector2(0.22f, 0.22f), new Vector2(5, 5), 0));
                var systColl = new SystemCollider();
                systColl.Add(new ColliderComponent(gameObject, 1));
                gameObject.SetComponent(systColl);

                result[i] = gameObject;
            }

            return result;
        }

        private void SetEffect(int number, GameObject gameObject)
        {
            switch (number)
            {
                case 1:
                    (gameObject.Script as Section).SetEffectSection(new EnemyStepBackEffect());
                    gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Sections/SectionEnemyFailure.png")));
                    break;
                case 2:
                    (gameObject.Script as Section).SetEffectSection(new StepBackEffect());
                    gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Sections/SectionStepBack.png")));
                    break;
                case 3:
                    (gameObject.Script as Section).SetEffectSection(new ThreeStepsForwardEffect());
                    gameObject.SetComponent(new SpriteComponent(ContentPipe.LoadTexture("Sections/Section3StepsForward.png")));
                    break;
            }
        }

        /// <summary>
        /// Установка точек расположений
        /// </summary>
        public void SetPoints(Vector2[] points)
        {
            Points = points;
        }
    }
}
