using MarsRoverProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProject.Model
{
    public class Position
    {
        /// <summary>
        /// Aracın Plato üzerindeki X koordinat bilgisi.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Aracın Plato üzerindeki Y koordinat bilgisi.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Aracın Plato üzerindeki gidebileceği maximum X koordinat bilgisi.
        /// </summary>
        public int MaxX { get; set; }

        /// <summary>
        /// Aracın Plato üzerindeki gidebileceği maximum Y koordinat bilgisi.
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// Aracın Plato üzerindeki yönü.
        /// </summary>
        public Directions Direction { get; set; }

        /// <summary>
        /// Araç oluşturulurken koordinatları, gidebileceği max koordinatları ve yön bilgisi ile tanımlanır.
        /// </summary>
        /// <param name="_X"></param>
        /// <param name="_Y"></param>
        /// <param name="_maxX"></param>
        /// <param name="_maxY"></param>
        /// <param name="_Direction"></param>
        public Position(int _X, int _Y, int _maxX, int _maxY, Directions _Direction)
        {
            X = _X;
            Y = _Y;
            MaxX = _maxX;
            MaxY = _maxY;
            Direction = _Direction;
        }
    }
}
