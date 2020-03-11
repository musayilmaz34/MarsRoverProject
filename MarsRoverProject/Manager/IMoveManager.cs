using MarsRoverProject.Enums;
using MarsRoverProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProject.Manager
{
    public interface IMoveManager
    {
        /// <summary>
        /// Aracı aldığı yönergerelere göre harekete başlatır.
        /// </summary>
        /// <param name="position">Aracın şu anki koordinat ve yön bilgilerini içerir.</param>
        /// <param name="moves">Aracın plato üzerindeki izleyeceği adımları içeren string bilgisidir.</param>
        /// <returns></returns>
        Position Move(Position position, string moves);
    }
}
