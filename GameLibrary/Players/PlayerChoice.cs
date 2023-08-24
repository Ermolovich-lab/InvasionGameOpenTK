using EngineLibrary;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EngineLibrary.Input;

namespace GameLibrary.Players
{
    /// <summary>
    /// Класс, описывающий момент выбора оружия игрока
    /// </summary>
    public class PlayerChoice : ObjectScript
    {
        private GameObject[] weapons;

        private int currWeapons = 0;

        private bool isDown = false;

        private AxisOfInput axis;
        /// <summary>
        /// Действие при выборе оружия
        /// </summary>
        public Action OnAction;
        /// <summary>
        /// Установка оружия
        /// </summary>
        /// <param name="weapons">Объекты оружия</param>
        public void SetWeapons(GameObject[] weapons)
        {
            this.weapons = weapons;
        }

        public override void Start()
        {
            weapons[currWeapons].Transform.Position = new Vector2(0, 180);
            weapons[currWeapons].Transform.Scale = new Vector2(6, 6);
            GameObject.SetChildGameObject(weapons[currWeapons]);

            if (GameObject.GameObjectTag == "FirstPlayer")
                axis = AxisOfInput.Horizontal;
            else
                axis = AxisOfInput.AlternativeHorizontal;
        }

        public override void Update()
        {
            var directionX = Input.GetAxis(axis);

            if ((directionX > 0 || directionX < 0) && !isDown)
            {
                isDown = true;

                currWeapons += directionX;

                if (currWeapons < 0)
                    currWeapons = weapons.Length - 1;
                else if (currWeapons >= weapons.Length)
                    currWeapons = 0;

                Game.instance.AddObjectsToRemove(GameObject.ChildGameObject);

                weapons[currWeapons].Transform.Position = new Vector2(0, 180);
                weapons[currWeapons].Transform.Scale = new Vector2(6, 6);

                GameObject.SetChildGameObject(weapons[currWeapons]);
                Game.instance.AddObjectOnScene(weapons[currWeapons]);
            }
            else if (directionX == 0)
                isDown = false;

            if (Input.GetButtonDawn(Key.Enter) && OnAction != null)
            {
                OnAction.Invoke();
            }
        }
    }
}
