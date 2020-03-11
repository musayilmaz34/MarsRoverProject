using MarsRoverProject.Enums;
using MarsRoverProject.Manager;
using MarsRoverProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProject
{
    public class Rover : IVehicle
    {
        private readonly IMoveManager _moveManager;
        private Position _position;

        public Rover(IMoveManager moveManager, Position position)
        {
            _moveManager = moveManager;
            _position = position;
        }

        public void StartMoving(string moves)
        {
            Position position = _moveManager.Move(_position, moves);
            Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
        }
    }
}
