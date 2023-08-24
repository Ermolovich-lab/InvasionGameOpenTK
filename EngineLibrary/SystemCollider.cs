using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Класс компонента, описывающий твердые тела
    /// </summary>
    public class SystemCollider : IDisposable
    {
        public List<ColliderComponent> colliders;

        /// <summary>
        /// Неактивность элемента
        /// </summary>
        public bool IsInactive { get; private set; }

        /// <summary>
        /// Изменение ативности элемента
        /// </summary>
        public void SetIsInactive(bool active)
        {
            foreach (var obj in colliders)
                obj.SetIsInactive(active);

            IsInactive = active;
        }

        /// <summary>
        /// Добавление коллайдера
        /// </summary>
        /// <param name="collider">коллайдер</param>
        /// <param name="tag">тэг коллайдера</param>
        public void Add(ColliderComponent collider)
        {
            if (colliders == null)
                colliders = new List<ColliderComponent>();

            if (collider != null)
                colliders.Add(collider);
        }

        /// <summary>
        /// Удаление коллайдера по тэгу
        /// </summary>
        public void Del(int id)
        {
            if (colliders != null && colliders.Count != 0)
                colliders.RemoveAt(id);
        }

        /// <summary>
        /// Обновление вершинвсех коллайдеров
        /// </summary>
        /// <returns></returns>
        public List<Vector2[]> GetBoundCorners()
        {
            List<Vector2[]> BoundCorners = new List<Vector2[]>();

            foreach (var obj in colliders)
            {
                obj.UpdateBounds();
                BoundCorners.Add(obj.BoundCorners);
            }

            return BoundCorners;
        }

        /// <summary>
        /// Проверка на пересечение со всеми объектами
        /// </summary>
        /// <returns>true - если есть пересечение</returns>
        public bool CheckGameObjectIntersection()
        {
            foreach (var obj in colliders)
                if (obj.CheckGameObjectIntersection())
                    return true;

            return false;
        }

        /// <summary>
        /// Проверка на перечесение с данным объектом
        /// </summary>
        /// <returns>true - если есть пересечение</returns>
        public bool CheckGameObjectIntersection(GameObject otherGameObject)
        {
            foreach (var obj in colliders)
                if (obj.CheckGameObjectIntersection(otherGameObject))
                    return true;

            return false;
        }

        /// <summary>
        /// Проверка на пересечение со всеми объектами данного типа
        /// </summary>
        /// <returns>true - если есть пересечение</returns>
        public bool CheckGameObjectIntersection(out List<GameObject> intersecredGameObjects)
        {
            foreach (var obj in colliders)
                if (obj.CheckGameObjectIntersection(out intersecredGameObjects))
                    return true;

            intersecredGameObjects = null;
            return false;
        }

        /// <summary>
        /// Проверка на пересечение с данными объектами
        /// </summary>
        /// <returns>true - если есть пересечение</returns>
        public bool CheckGameObjectIntersection(out GameObject otherGameObject, int? id = null, params string[] tagNames)
        {
            if(id == null)
            {
                foreach (var obj in colliders)
                    if (obj.CheckGameObjectIntersection(out otherGameObject, id, tagNames))
                        return true;
            }
            else
            {
                if (colliders[id.Value].CheckGameObjectIntersection(out otherGameObject, 0, tagNames))
                    return true;
            }

            otherGameObject = null;
            return false;
        }

        /// <summary>
        /// Находит номер пересечённого коллайдера
        /// </summary>
        /// <param name="intersecredGameObject"></param>
        /// <returns></returns>
        public virtual int? GetNumberColliderIntersection(GameObject intersecredGameObject)
        {
            int number = 0;

            foreach (var obj in colliders)
            {
                number++;
                if (obj.CheckGameObjectIntersection(intersecredGameObject))
                    return number;
            }

            return null;
        }

        /// <summary>
        /// Удаление игрового объекта из листа
        /// </summary>
        public void DelGameObject(GameObject gameObject)
        {
            foreach (var obj in colliders)
            {
                obj.DelGameObject(gameObject);
            }
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            colliders.Clear();
        }
    }
}
