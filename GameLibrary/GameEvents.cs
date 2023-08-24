using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    /// <summary>
    /// Статический класс событий игры
    /// </summary>
    public static class GameEvents
    {

        /// <summary>
        /// Делегат события окончания игры
        /// </summary>
        public delegate void EndGameDelegate(string winPlayer = null);

        /// <summary>
        /// Событие окончания игры
        /// </summary>
        public static EndGameDelegate EndGame { get; set; }

        /// <summary>
        /// Делегат события состояния игрока
        /// </summary>
        public delegate void PlayerStateDelegate(string player, string state);

        /// <summary>
        /// Событие состояния игрока
        /// </summary>
        public static PlayerStateDelegate PlayerState { get; set; }

        /// <summary>
        /// Делегат вывода текущей волны
        /// </summary>
        public delegate void WaveDelegate(string wave);

        /// <summary>
        /// Событие вывода текущей волны
        /// </summary>
        public static WaveDelegate Wave { get; set; }
    }
}
