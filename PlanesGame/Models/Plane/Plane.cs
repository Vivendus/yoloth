﻿using System.Collections.Generic;
using PlanesGame.GameGraphics;

namespace PlanesGame.Models.Plane
{
    public class Plane : IPlane
    {
        public int[,] PlaneMatrix { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfCollumns { get; set; }
        public List<MatrixCoordinate> KillPoints { get; set; }

        public Plane()
        {
            NumberOfRows = 4;
            NumberOfCollumns = 3;
            PlaneMatrix = new[,]
            {
                {0, 1, 0},
                {1, 1, 1},
                {0, 1, 0},
                {1, 1, 1},
            };
        }
    }
}