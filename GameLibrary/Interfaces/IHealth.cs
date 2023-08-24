using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс, содержащий в себе данные о жизнях
    /// </summary>
    public interface IHealth
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        float Health { get; }
        /// <summary>
        /// Уменьшение количества жизней
        /// </summary>
        /// <param name="value">Количество жизней</param>
        void Remove(float value);
        /// <summary>
        /// Увеличение количества жизней
        /// </summary>
        /// <param name="value">Количество жизней</param>
        void Add(float value);
    }
}
