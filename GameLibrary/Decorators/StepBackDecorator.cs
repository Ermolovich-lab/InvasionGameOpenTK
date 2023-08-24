using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    public class StepBackDecorator : PlayerDecorator
    {
        public StepBackDecorator(PlayerProperties player) : base(player)
        {

        }

        public override int Step { get => base.Step - 1; set => base.Step = value; }
    }
}
