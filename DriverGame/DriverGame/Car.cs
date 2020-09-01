using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace DriverGame
{
    public class Car
    {// Car constants
        public const float Height = 2.5f;
        public const float Depth = 3.0f;
        public const float SpeedIncrement = 0.1f;
        private const float Scale = 0.85f;

        // Car data information
        private float carLocation = DriverGame.RoadLocationLeft;
        private float carDiameter;
        private float carSpeed = 10.0f;
        private bool movingLeft = false;
        private bool movingRight = false;

        // Our car mesh information
        private Mesh carMesh = null;
        private Material[] carMaterials = null;
        private Texture[] carTextures = null;

        /// <summary>
        /// Create a new car device, and load the mesh data for it
        /// </summary>
        /// <param name="device">D3D device to use</param>
        public Car(Device device)
        {
            // Create our car mesh
            carMesh = DriverGame.LoadMesh(device, @"..\..\car.x", ref carMaterials, ref carTextures);

            // We need to calculate a bounding sphere for our car
            VertexBuffer vb = carMesh.VertexBuffer;
            try
            {
                // We need to lock the entire buffer to calculate this
                GraphicsStream stm = vb.Lock(0, 0, LockFlags.None);
                Vector3 center; // We won't use the center, but it's required
                float radius = Geometry.ComputeBoundingSphere(stm,
                    carMesh.NumberVertices, carMesh.VertexFormat, out center);

                // All we care about is the diameter.  Store that
                carDiameter = (radius * 2) * Scale;
            }
            finally
            {
                // No matter what, make sure we unlock and dispose this vertex
                // buffer.
                vb.Unlock();
                vb.Dispose();
            }
        }

        /// <summary>
        /// Render the car given the current properties
        /// </summary>
        /// <param name="device">The device used to render the car</param>
        public void Draw(Device device)
        {
            // The car is a little bit too big, scale it down
            device.Transform.World = Matrix.Scaling(Scale,
                Scale, Scale) * Matrix.Translation(carLocation, Height, Depth);

            for (int i = 0; i < carMaterials.Length; i++)
            {
                device.Material = carMaterials[i];
                device.SetTexture(0, carTextures[i]);
                carMesh.DrawSubset(i);
            }
        }

        /// <summary>
        /// Increment the movement speed of the car
        /// </summary>
        public void IncrementSpeed()
        {
            carSpeed += SpeedIncrement;
        }

        /// <summary>
        /// Update the cars state based on the elapsed time
        /// </summary>
        /// <param name="elapsedTime">Amount of time that has elapsed</param>
        public void Update(float elapsedTime)
        {
            if (movingLeft)
            {
                // Move the car
                carLocation += (carSpeed * elapsedTime);
                // Is the car all the way to the left?
                if (carLocation >= DriverGame.RoadLocationLeft)
                {
                    movingLeft = false;
                    carLocation = DriverGame.RoadLocationLeft;
                }
            }

            if (movingRight)
            {
                // Move the car
                carLocation -= (carSpeed * elapsedTime);
                // Is the car all the way to the right?
                if (carLocation <= DriverGame.RoadLocationRight)
                {
                    movingRight = false;
                    carLocation = DriverGame.RoadLocationRight;
                }
            }
        }

        // Public properties for car data
        public float Location
        {
            get { return carLocation; }
            set { carLocation = value; }
        }
        public float Diameter
        {
            get { return carDiameter; }
        }
        public float Speed
        {
            get { return carSpeed; }
            set { carSpeed = value; }
        }
        public bool IsMovingLeft
        {
            get { return movingLeft; }
            set { movingLeft = value; }
        }
        public bool IsMovingRight
        {
            get { return movingRight; }
            set { movingRight = value; }
        }
    }
}
