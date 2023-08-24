using EngineLibrary;
using GameLibrary.Cubes;
using GameLibrary.Players;
using GameLibrary.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.BoardGame
{
    /// <summary>
    /// Класс отвечающий за ход игры
    /// </summary>
    public class StepManager : ObjectScript
    {
        private int currPlayer = 0;
        private bool isStep = false;

        public SectionMovement SectionsMovement { get; set; }
        public Player[] Players { get; set; }
        public Cube Cube { get; set; }

        public override void Start()
        {
            SectionsMovement.SetObjectsToStartSection(Players.Select(x => x.GameObject).ToArray());
        }

        public override void Update()
        {
            if (Input.GetButtonDawn((Players[currPlayer].Control.ThrowKey)))
            {
                Cube.Throw();
                isStep = true;
            }

            if (Cube.IsChange && isStep)
            {
                Players[currPlayer].ResetEffect();

                SectionsMovement.ChangePositionObject(Players[currPlayer].PlayerProperities.Step, Players[currPlayer].GameObject.GameObjectTag);

                isStep = false;

                currPlayer = currPlayer + 1 == Players.Length ? 0 : ++currPlayer;
            }
        }
    }
}
