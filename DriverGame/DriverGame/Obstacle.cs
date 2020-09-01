using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Collections;

namespace DriverGame
{
    public class Obstacle : IDisposable
    {        
        private const float Scale = 0.85f;
        private const float Height = 2.5f;

        // obstacle colors
        private static readonly Color[] ObstacleColors = { 
                Color.Red, Color.Blue, Color.Green, 
                Color.Bisque, Color.Cyan, Color.DarkKhaki,
                Color.OldLace, Color.PowderBlue, Color.DarkTurquoise, 
                Color.Azure, Color.Violet, Color.Tomato,
                Color.Yellow, Color.Purple, Color.AliceBlue, 
                Color.Honeydew, Color.Crimson, Color.Firebrick };

        // Mesh information
        private Mesh obstacleMesh = null;
        //private Material obstacleMaterial;
        private Material[] obstacleMaterials = null;
        private Texture[] obstacleTextures = null;

        private Vector3 position;

        public Obstacle(Device device, float x, float y, float z)
        {
            //create our obstacle mesh from the car
            obstacleMesh = DriverGame.LoadMesh(device, @"..\..\car.x", ref obstacleMaterials, ref obstacleTextures);
            // Store our position
            position = new Vector3(x, y, z);


            // Set the obstacle color
            //obsMaterials = new Material();
            //Color objColor = ObstacleColors[Utility.Rnd.Next(ObstacleColors.Length)];
            //obstacleMaterials[0].Ambient = objColor;
            //obstacleMaterials[0].Diffuse = objColor;

        }

        public void Update(float elapsedTime, float speed)
        {
            position.Z += (speed * elapsedTime);
        }

        public void Draw(Device device)
        {
            // The car is a little bit too big, scale it down
            device.Transform.World = Matrix.Scaling(Scale,
                Scale, Scale) * Matrix.Translation(position.X, Height, Depth);

            for (int i = 0; i < obstacleMaterials.Length; i++)
            {
                device.Material = obstacleMaterials[i];
                device.SetTexture(0, obstacleTextures[i]);
                obstacleMesh.DrawSubset(i);
            }
        }

        public float Depth
        {
            get { return position.Z; }
        }

        public bool IsHittingCar(float carLocation, float carDiameter)
        {
            // In order for the obstacle to be hitting the car,
            // it must be on the same side of the road and
            // hitting the car

            if (position.Z > (Car.Depth - (carDiameter / 2.0f)))
            {
                // are we on the right side of the car
                if ((carLocation < 0) && (position.X < 0))
                    return true;

                if ((carLocation > 0) && (position.X > 0))
                    return true;
            }
            return false;
        }

        #region Cleanup Code
        /// <summary>
        /// Dispose the mesh and any related information
        /// </summary>
        public void Dispose()
        {
            obstacleMesh.Dispose();
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for this object
        /// </summary>
        ~Obstacle()
        {
            // Just call dispose
            this.Dispose();
        }
        #endregion

    }

    public class Obstacles : IEnumerable
    {
        private ArrayList obstacleList = new ArrayList();

        /// <summary>
        /// Indexer for this class
        /// </summary>
        public Obstacle this[int index]
        {
            get
            {
                return (Obstacle)obstacleList[index];
            }
        }

        // Get the enumerator from our arraylist
        public IEnumerator GetEnumerator()
        {
            return obstacleList.GetEnumerator();
        }

        /// <summary>
        /// Add an obstacle to our list
        /// </summary>
        /// <param name="obstacle">The obstacle to add</param>
        public void Add(Obstacle obstacle)
        {
            obstacleList.Add(obstacle);
        }

        /// <summary>
        /// Remove an obstacle from our list
        /// </summary>
        /// <param name="obstacle">The obstacle to remove</param>
        public void Remove(Obstacle obstacle)
        {
            obstacleList.Remove(obstacle);
        }

        /// <summary>
        /// Clear the obstacle list
        /// </summary>
        public void Clear()
        {
            obstacleList.Clear();
        }
    }
}
