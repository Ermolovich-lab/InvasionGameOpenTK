using EngineLibrary;
using GameLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Effects
{
    /// <summary>
    /// Абстрактный класс описывающий эффект
    /// </summary>
    public abstract class Effect
    {
        /// <summary>
        /// Установка эффекта
        /// </summary>
        public abstract void SetEffect(Player player);
    }
}
