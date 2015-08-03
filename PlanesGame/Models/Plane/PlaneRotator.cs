﻿using PlanesGame.GameCore;
using PlanesGame.GameGraphics;

namespace PlanesGame.Models.Plane
{
    public class PlaneRotator
    {

        public void SetPlaneDown(Plane plane)
        {
            plane.Orientation = "down";
            
            for (var i = 0; i < 2; i++)
            {
                RotatePlaneMatrix(plane);
            }

            UpdateKillPoints(plane);
        }

        public void SetPlaneRight(Plane plane)
        {
            plane.Orientation = "right";
            RotatePlaneMatrix(plane);
            UpdateKillPoints(plane);
        }

        public void SetPlaneLeft(Plane plane)
        {
            plane.Orientation = "left";
            for (var i = 0; i < 3; i++)
            {
                RotatePlaneMatrix(plane);
            }
            UpdateKillPoints(plane);
        }

        private static void RotatePlaneMatrix(Plane plane)
        {
            var matrixOperation = new MatrixOperations();
            plane.PlaneMatrix = matrixOperation.Rotate(plane.PlaneMatrix, plane.NumberOfRows,
                plane.NumberOfColumns);
            var temp = plane.NumberOfRows;
            plane.NumberOfRows = plane.NumberOfColumns;
            plane.NumberOfColumns = temp;
        }

        private static void UpdateKillPoints(Plane plane)
        {
            plane.KillPoints.Clear();
            for (var i = 0; i < plane.NumberOfRows; i++)
            {
                for (var j = 0; j < plane.NumberOfColumns; j++)
                {
                    if (plane.PlaneMatrix[i, j] == 2)
                        plane.KillPoints.Add(new MatrixCoordinate(i, j));
                }
            }
        }
    }
}