using MarsRoverProject.Enums;
using MarsRoverProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProject.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class MoveManager : IMoveManager
    {
        private Position Position { get; set; }

        private readonly IDictionary<Routes, Action> routeMethodDictionary;
        private readonly IDictionary<Directions, Action> leftMoveDictionary;
        private readonly IDictionary<Directions, Action> rightMoveDictionary;
        private readonly IDictionary<Directions, Action> forwardMoveDictionary;

        /// <summary>
        /// 
        /// </summary>
        public MoveManager()
        {
            routeMethodDictionary = new Dictionary<Routes, Action>
            {
                {Routes.L, () => leftMoveDictionary[Position.Direction].Invoke()},
                {Routes.R, () => rightMoveDictionary[Position.Direction].Invoke()},
                {Routes.M, () => forwardMoveDictionary[Position.Direction].Invoke()}
            };

            leftMoveDictionary = new Dictionary<Directions, Action>
            {
                {Directions.N, () => Position.Direction = Directions.W},
                {Directions.E, () => Position.Direction = Directions.N},
                {Directions.S, () => Position.Direction = Directions.E},
                {Directions.W, () => Position.Direction = Directions.S}
            };

            rightMoveDictionary = new Dictionary<Directions, Action>
            {
                {Directions.N, () => Position.Direction = Directions.E},
                {Directions.E, () => Position.Direction = Directions.S},
                {Directions.S, () => Position.Direction = Directions.W},
                {Directions.W, () => Position.Direction = Directions.N}
            };

            forwardMoveDictionary = new Dictionary<Directions, Action>
            {
                {Directions.N, () => {Position.Y = Position.Y + 1;}},
                {Directions.E, () => {Position.X = Position.X + 1;}},
                {Directions.S, () => {Position.Y = Position.Y - 1;}},
                {Directions.W, () => {Position.X = Position.X - 1;}}
            };
        }

        /// <summary>
        /// Aracı aldığı yönergerelere göre harekete başlatır.
        /// </summary>
        /// <param name="position">Aracın şu anki koordinat ve yön bilgilerini içerir.</param>
        /// <param name="moves">Aracın plato üzerindeki izleyeceği adımları içeren string bilgisidir.</param>
        /// <returns></returns>
        public Position Move(Position position, string moves)
        {
            Position = position;
            foreach (var move in moves)
            {
                routeMethodDictionary[(Routes)Enum.Parse(typeof(Routes), move.ToString())].Invoke();

                if (position.X < 0 || position.X > position.MaxX || position.Y < 0 || position.Y > position.MaxY)
                {
                    throw new Exception($"Hatalı Giriş Parametreleri. Aracın gidebileceği koordinatlar (0 , 0) and ({position.MaxX} , {position.MaxY}) aralığında olmalı.");
                }
            }

            return position;
        }
    }
}
