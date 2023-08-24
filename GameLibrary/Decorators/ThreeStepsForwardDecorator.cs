using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Decorators
{
    public class ThreeStepsForwardDecorator : PlayerDecorator
    {
        public ThreeStepsForwardDecorator(PlayerProperties player) : base(player)
        {

        }

        public override int Step { get => base.Step + 3; set => base.Step = value; }
    }
}
