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
    /// Класс компонента, описывающий твердое тело
    /// </summary>
    public class ColliderComponent
    {
        /// <summary>
        /// Лист игровых объектов имеющих твёрдое тело
        /// </summary>
        private static List<GameObject> collidersOfGameObjects;

        /// <summary>
        /// игровой объект имеющее твёрдое тело
        /// </summary>
        private GameObject gameObject;

        /// <summary>
        /// Масштаб твёрдого тела
        /// </summary>
        private float colliderScale;

        /// <summary>
        /// Смещение твёрдого тела
        /// </summary>
        private Vector2 offsetCollider;

        /// <summary>
        /// Вершины твёрдого тела
        /// </summary>
        public Vector2[] BoundCorners { get; private set; }

        /// <summary>
        /// Неактивность элемента
        /// </summary>
        public bool IsInactive { get; private set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="gameObject">Игровой объект, которому принадлежит компонент</param>
        /// <param name="scale">Размер коллайдера</param>
        /// <param name="offset">Cмещения коллайдера от центра</param>
        public ColliderComponent(GameObject gameObject, float scale = 1, Vector2 offset = new Vector2())
        {
            if (collidersOfGameObjects == null)
                collidersOfGameObjects = new List<GameObject>(50);

            this.gameObject = gameObject;
            collidersOfGameObjects.Add(gameObject);

            colliderScale = scale;
            offsetCollider = offset;

            IsInactive = false;

            BoundCorners = new Vector2[4];
        }

        /// <summary>
        /// Изменение активности твёрдого тела
        /// </summary>
        /// <param name="active"></param>
        public void SetIsInactive(bool active)
        {
            IsInactive = active;
        }

        /// <summary>
        /// Изменение игрового объекта
        /// </summary>
        /// <param name="gameObject"></param>
        public void SetGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
            collidersOfGameObjects.Add(gameObject);
        }

        /// <summary>
        /// Удаление игрового объекта из листа
        /// </summary>
        public void DelGameObject(GameObject gameObject)
        {
            collidersOfGameObjects.Remove(gameObject);
        }

        /// <summary>
        /// Проверка на пересечение со всеми объектами
        /// </summary>
        /// <returns>true - если есть пересечение</returns>
        public bool CheckGameObjectIntersection()
        {
            foreach (var otherGameObject in collidersOfGameObjects)
            {
                if (otherGameObject == gameObject || otherGameObject.Colliders.IsInactive) continue;

                float otherGameObjectX = otherGameObject.Transform.Position.X + (otherGameObject.Texture.Texture.Width * otherGameObject.Transform.Scale.X);
                float otherGameObjectY = otherGameObject.Transform.Position.Y + (otherGameObject.Texture.Texture.Height * otherGameObject.Transform.Scale.Y) / 2;

                if (otherGameObjectX <= gameObject.Transform.Position.X + (gameObject.Texture?.Texture.Width ?? 1) * gameObject.Transform.Scale.X && otherGameObjectX >= gameObject.Transform.Position.X)
                {
                    if (otherGameObjectY <= gameObject.Transform.Position.Y + (gameObject.Texture?.Texture.Height ?? 1) * gameObject.Transform.Scale.Y && otherGameObjectY >= gameObject.Transform.Position.Y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Проверка на перечесение с данным объектом
        /// </summary>
        /// <param name="otherGameObject"></param>
        /// <returns></returns>
        public bool CheckGameObjectIntersection(GameObject otherGameObject)
        {
            if (otherGameObject.Colliders == null || otherGameObject == gameObject || otherGameObject.Colliders.IsInactive) return false;

            UpdateBounds();
            List<Vector2[]> otherBoundCornersList = otherGameObject.Colliders.GetBoundCorners();

            foreach (var otherBoundCorners in otherBoundCornersList)
            {
                if (BoundCorners[1].X >= otherBoundCorners[0].X && BoundCorners[0].X <= otherBoundCorners[1].X
                    && BoundCorners[0].Y <= otherBoundCorners[1].Y && BoundCorners[1].Y >= otherBoundCorners[0].Y)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка на пересечение с данными объектами
        /// </summary>
        /// <param name="intersecredGameObject"></param>
        /// <returns></returns>
        public bool CheckGameObjectIntersection(out List<GameObject> intersecredGameObjects)
        {
            intersecredGameObjects = new List<GameObject>();

            foreach (var otherGameObject in collidersOfGameObjects)
            {
                if (otherGameObject.Colliders == null || otherGameObject == gameObject || otherGameObject.Colliders.IsInactive) continue;

                UpdateBounds();
                List<Vector2[]> otherBoundCornersList = otherGameObject.Colliders.GetBoundCorners();

                foreach (var otherBoundCorners in otherBoundCornersList)
                {
                    if (BoundCorners[1].X >= otherBoundCorners[0].X && BoundCorners[0].X <= otherBoundCorners[1].X
                        && BoundCorners[0].Y <= otherBoundCorners[1].Y && BoundCorners[1].Y >= otherBoundCorners[0].Y)
                    {
                        intersecredGameObjects.Add(otherGameObject);
                    }
                }
            }

            if(intersecredGameObjects.Count > 0)
            {
                return true;
            }
            else
            {
                intersecredGameObjects = null;
                return false;
            }
        }

        /// <summary>
        /// Проверка на пересечение с данными объектами
        /// </summary>
        /// <param name="intersecredGameObject"></param>
        /// <returns></returns>
        public bool CheckGameObjectIntersection(out GameObject intersecredGameObject, int? idColl = null, params string[] tagNames)
        {
            foreach (var otherGameObject in collidersOfGameObjects)
            {
                if (otherGameObject.Colliders == null || otherGameObject == gameObject || otherGameObject.Colliders.IsInactive) continue;

                bool hasTag = false;

                for (int i = 0; i < tagNames.Length && !hasTag; i++)
                {
                    hasTag = otherGameObject.GameObjectTag == tagNames[i];
                }

                if (hasTag)
                {
                    UpdateBounds();

                    if (idColl == null)
                    {
                        List<Vector2[]> otherBoundCornersList = otherGameObject.Colliders.GetBoundCorners();

                        foreach (var otherBoundCorners in otherBoundCornersList)
                        {
                            if (BoundCorners[1].X >= otherBoundCorners[0].X && BoundCorners[0].X <= otherBoundCorners[1].X
                            && BoundCorners[0].Y <= otherBoundCorners[1].Y && BoundCorners[1].Y >= otherBoundCorners[0].Y)
                            {
                                intersecredGameObject = otherGameObject;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        Vector2[] otherBoundCorners = otherGameObject.Colliders.GetBoundCorners()[idColl.Value];

                        if (BoundCorners[1].X >= otherBoundCorners[0].X && BoundCorners[0].X <= otherBoundCorners[1].X
                            && BoundCorners[0].Y <= otherBoundCorners[1].Y && BoundCorners[1].Y >= otherBoundCorners[0].Y)
                        {
                            intersecredGameObject = otherGameObject;
                            return true;
                        }
                    }
                    
                }

            }

            intersecredGameObject = null;
            return false;
        }

        /// <summary>
        /// Обновление вершин твёрдого тела
        /// </summary>
        public void UpdateBounds()
        {
            Vector2 position = gameObject.Transform.Position;

            var angle = gameObject.Transform.Angle;
            var centre = gameObject.Transform.Centre;
            Vector2 buff;

            Vector2[] vertices = new Vector2[2]
            {
                new Vector2(0, 0),
                new Vector2(1, 1)
            };

            for (int i = 0; i < 2; i++)
            {
                //buff = vertices[i] - centre;
                //vertices[i].X = buff.X * (float)Math.Cos(angle) - buff.Y * (float)Math.Sin(angle);
                //vertices[i].Y = buff.X * (float)Math.Sin(angle) + buff.Y * (float)Math.Cos(angle);
                //vertices[i] += centre;

                vertices[i].X *= gameObject.Texture?.Texture.Width ?? 1;
                vertices[i].Y *= gameObject.Texture?.Texture.Height ?? 1;
                vertices[i] *= gameObject.Transform.Scale * colliderScale;
                vertices[i] += offsetCollider + position;
            }

            BoundCorners = vertices;
        }
    }
}
