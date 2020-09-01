using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D = Microsoft.DirectX.Direct3D;

namespace DriverGame
{
    public partial class DriverGame : Form
    {
        private Device device = null;

        //Game board mesh information
        private Mesh roadMesh = null;
        private Material[] roadMaterials = null;
        private Texture[] roadTextures = null;

        //Constants for the locations
        public const float RoadLocationLeft = 2.5f;
        public const float RoadLocationRight = -2.5f;
        private const float RoadSize = 100.0f;
        private const float MaximumRoadSpeed = 250.0f;
        private const float RoadSpeedIncrement = 0.5f;

        //depth locations of the two road meshes we will draw
        private float RoadDepth0 = 0.0f;
        private float RoadDepth1 = -100.0f;
        private float RoadSpeed = 30.0f;

        //timer variable
        private float elapsedTime = 0.0f;

        //Car
        private Car car = null;

        //Obstacle information
        private Obstacles obstacles;
        private const float obstacleHeight = Car.Height * 0.85f;

        //Game Info
        private bool isGameOver = true;
        private int gameOverTick = 0;
        private bool hasGameStarted = false;
        private int score = 0;

        //fonts
        private Direct3D.Font scoreFont = null;
        private Direct3D.Font gameFont = null;

        //High score info
        private HighScore[] highScores = new HighScore[3];
        private string defaultHighScoreName = string.Empty;

        public struct HighScore
        {
            private int realScore;
            private string playerName;
            public int Score
            {
                get { return realScore; }
                set { realScore = value; }
            }
            public string Name
            {
                get { return playerName; }
                set { playerName = value; }
            }
        }

        public DriverGame()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            this.Text = "Crazy Driver";

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
            LoadHighScores();
        }

        #region Deal with Scores
        /// <summary>
        /// Check to see what the best high score is.  If this beats it, 
        /// store the index, and ask for a name
        /// </summary>
        private void CheckHighScore()
        {
            int index = -1;
            for (int i = highScores.Length - 1; i >= 0; i--)
            {
                if (score >= highScores[i].Score) // We beat this score
                {
                    index = i;
                }
            }

            // We beat the score if index is greater than 0
            if (index >= 0)
            {
                for (int i = highScores.Length - 1; i > index; i--)
                {
                    // Move each existing score down one
                    highScores[i] = highScores[i - 1];
                }
                highScores[index].Score = score;
                highScores[index].Name = Input.InputBox("You got a high score!!",
                    "Please enter your name.", defaultHighScoreName);
            }
        }
        private void LoadHighScores()
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\\MDXBoox\\Dodger");
            try
            {

                for (int i = 0; i < highScores.Length; i++)
                {
                    highScores[i].Name = (string)key.GetValue(
                        string.Format("Player{0}", i), string.Empty);

                    highScores[i].Score = (int)key.GetValue(
                        string.Format("Score{0}", i), 0);
                }
                defaultHighScoreName = (string)key.GetValue(
                    "PlayerName", System.Environment.UserName);
            }
            finally
            {
                if (key != null)
                {
                    key.Close(); // Make sure to close the key
                }
            }
        }

        /// <summary>
        /// Save all the high score information to the registry
        /// </summary>
        public void SaveHighScores()
        {
            Microsoft.Win32.RegistryKey key =
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey(
                "Software\\MDXBoox\\Dodger");

            try
            {
                for (int i = 0; i < highScores.Length; i++)
                {
                    key.SetValue(string.Format("Player{0}", i), highScores[i].Name);
                    key.SetValue(string.Format("Score{0}", i), highScores[i].Score);
                }
                key.SetValue("PlayerName", defaultHighScoreName);
            }
            finally
            {
                if (key != null)
                {
                    key.Close(); // Make sure to close the key
                }
            }
        }
        #endregion

        #region Graphics Device
        /// <summary>
        /// Initialize graphics device here.
        /// </summary>
        public void InitializeGraphics()
        {
            //set our presentParams
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;
            presentParams.EnableAutoDepthStencil = true;

            //store the default adapter
            int adapterOrdinal = Manager.Adapters.Default.Adapter;
            CreateFlags flags = CreateFlags.SoftwareVertexProcessing;

            //check to see if we can use a pure hardware device
            Caps caps = Manager.GetDeviceCaps(adapterOrdinal, DeviceType.Hardware);

            //do we support hardware vertex processing?
            if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
                //replace the software vertex processing
                flags = CreateFlags.HardwareVertexProcessing;

            //do we support a pure device?
            if (caps.DeviceCaps.SupportsPureDevice)
                flags |= CreateFlags.PureDevice;

            //Create the device
            device = new Device(adapterOrdinal, DeviceType.Hardware, this, flags, presentParams);

            //hook the device reset event
            device.DeviceReset += new EventHandler(this.OnDeviceReset);
            this.OnDeviceReset(device, null);

            //create our founts
            scoreFont = new Direct3D.Font(device, new System.Drawing.Font("Arial", 12.0f, FontStyle.Bold));
            gameFont = new Direct3D.Font(device, new System.Drawing.Font("Arial", 36.0f, FontStyle.Bold | FontStyle.Italic));
        }


        /// <summary>
        /// When the device is loaded for the first time or when it resets come here to check 
        /// the caps of the device for lighting and set up the Projection and view.
        /// </summary>
        /// <param name="sender">Device</param>
        /// <param name="e">usally null, either way we dont care about it.</param>
        private void OnDeviceReset(object sender, EventArgs e)
        {
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, (float)this.Width / (float)this.Height, 1.0f, 1000.0f);

            device.Transform.View = Matrix.LookAtLH(new Vector3(0.0f, 9.5f, 17.0f), new Vector3(), new Vector3(0, 1, 0));

            //try to set up a texture minify filter, pick anisotropic first
            if (device.DeviceCaps.TextureFilterCaps.SupportsMinifyAnisotropic)
                device.SamplerState[0].MinFilter = TextureFilter.Anisotropic;
            else if (device.DeviceCaps.TextureFilterCaps.SupportsMinifyLinear)
                device.SamplerState[0].MinFilter = TextureFilter.Linear;

            //do the same thing for magnify filter
            if (device.DeviceCaps.TextureFilterCaps.SupportsMagnifyAnisotropic)
                device.SamplerState[0].MagFilter = TextureFilter.Anisotropic;
            else if (device.DeviceCaps.TextureFilterCaps.SupportsMagnifyLinear)
                device.SamplerState[0].MagFilter = TextureFilter.Linear;

            //Do we have enough support for lights?
            if ((device.DeviceCaps.VertexProcessingCaps.SupportsDirectionalLights) && (device.DeviceCaps.MaxActiveLights > 1))
            {
                //first light
                device.Lights[0].Type = LightType.Directional;
                device.Lights[0].Diffuse = Color.White;
                device.Lights[0].Direction = new Vector3(1, -1, -1);
                device.Lights[0].Enabled = true;

                //second light
                device.Lights[1].Type = LightType.Directional;
                device.Lights[1].Diffuse = Color.White;
                device.Lights[1].Direction = new Vector3(-1, 1, -1);
                device.Lights[1].Enabled = true;
            }
            else
            {
                //no light support, just use ambient lighting.
                device.RenderState.Ambient = Color.White;
            }

            roadMesh = LoadMesh(device, @"..\..\road.x", ref roadMaterials, ref roadTextures);

            //create teh car
            car = new Car(device);

            //create the obstacles
            obstacles = new Obstacles();
        }
        #endregion

        /// <summary>
        /// Override the OnPaint method.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Before this render, we should update any state
            OnFrameUpdate();

            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
            device.BeginScene();
            //draw the two roads
            DrawRoad(0.0f, 0.0f, RoadDepth0);
            DrawRoad(0.0f, 0.0f, RoadDepth1);
            //draw the car
            car.Draw(device);
            foreach (Obstacle o in obstacles)
            {
                o.Draw(device);
            }

            if (hasGameStarted)
            {
                // Draw the score
                scoreFont.DrawText(null, string.Format("Current score: {0}", score),
                    new Rectangle(5, 5, 0, 0), DrawTextFormat.NoClip, Color.Yellow);
            }

            if (isGameOver)
            {
                // Game over, man!
                if (hasGameStarted)
                {
                    gameFont.DrawText(null, "You crashed.  The game is over.", new Rectangle(25, 45, 0, 0), DrawTextFormat.NoClip, Color.Red);
                }
                if ((System.Environment.TickCount - gameOverTick) >= 1000)
                {
                    gameFont.DrawText(null, "Press any key to begin.", new Rectangle(25, 100, 0, 0), DrawTextFormat.NoClip, Color.WhiteSmoke);
                }

                // display high scores
                gameFont.DrawText(null, "High Scores: ", new Rectangle(25, 155, 0, 0),
                    DrawTextFormat.NoClip, Color.CornflowerBlue);

                for (int i = 0; i < highScores.Length; i++)
                {
                    gameFont.DrawText(null, string.Format("Player: {0} : {1}", highScores[i].Name,
                        highScores[i].Score),
                        new Rectangle(25, 210 + (i * 55), 0, 0), DrawTextFormat.NoClip, Color.CornflowerBlue);
                }

            }

            device.EndScene();
            device.Present();
            this.Invalidate();
        }

        private void OnFrameUpdate()
        {
            if ((isGameOver) || (!hasGameStarted))
                return;

            // First, get the elapsed time
            elapsedTime = Utility.Timer(DirectXTimer.GetElapsedTime);

            RoadDepth0 += (RoadSpeed * elapsedTime);
            RoadDepth1 += (RoadSpeed * elapsedTime);

            // We have two "roads" here a top and bottom, check to see where they are located and if
            //they exceed their bounds, then swap them.
            if (RoadDepth0 > 75.0f)
            {
                RoadDepth0 = RoadDepth1 - 100.0f;
                AddObstacles(RoadDepth0);
            }

            if (RoadDepth1 > 75.0f)
            {
                RoadDepth1 = RoadDepth0 - 100.0f;
                AddObstacles(RoadDepth1);
            }

            // Remove any obstacles that are past the car
            // Increase the score for each one, and also increase
            // the road speed to make the game harder.
            Obstacles removeObstacles = new Obstacles();
            foreach (Obstacle o in obstacles)
            {
                if (o.Depth > car.Diameter - (Car.Depth * 2))
                {
                    // Add this obstacle to our list to remove
                    removeObstacles.Add(o);
                    // Increase roadspeed
                    RoadSpeed += RoadSpeedIncrement;

                    // Make sure the road speed stays below max
                    if (RoadSpeed >= MaximumRoadSpeed)
                    {
                        RoadSpeed = MaximumRoadSpeed;
                    }

                    // Increase the car speed as well
                    car.IncrementSpeed();

                    // Add the new score
                    score += (int)(RoadSpeed * (RoadSpeed / car.Speed));
                }
            }
            // Remove the obstacles in the list
            foreach (Obstacle o in removeObstacles)
            {
                obstacles.Remove(o);
                // May as well dispose it as well
                o.Dispose();
            }
            removeObstacles.Clear();

            // Move our obstacles
            foreach (Obstacle o in obstacles)
            {
                // Update the obstacle, check to see if it hits the car
                o.Update(elapsedTime, RoadSpeed);
                if (o.IsHittingCar(car.Location, car.Diameter))
                {
                    // If it does hit the car, the game is over.
                    isGameOver = true;
                    gameOverTick = System.Environment.TickCount;
                    // Stop our timer
                    Utility.Timer(DirectXTimer.Stop);
                    // Check to see if we want to add this to our high scores list
                    CheckHighScore();
                }
            }
            car.Update(elapsedTime);
        }

        /// <summary>
        /// Loads a mesh
        /// </summary>
        /// <param name="device">Graphics Device</param>
        /// <param name="file">File name of mesh</param>
        /// <param name="meshMaterials">Array of meshMaterials</param>
        /// <param name="meshTextures">Array of meshTextures</param>
        /// <returns>Loaded Mesh</returns>
        public static Mesh LoadMesh(Device device, string file, ref Material[] meshMaterials, ref Texture[] meshTextures)
        {
            ExtendedMaterial[] mtrl;

            //load the mesh
            Mesh tempMesh = Mesh.FromFile(file, MeshFlags.Managed, device, out mtrl);

            //if we have any materials, store them
            if ((mtrl != null) && (mtrl.Length > 0))
            {
                meshMaterials = new Material[mtrl.Length];
                meshTextures = new Texture[mtrl.Length];

                //store each material and texture
                for (int i = 0; i < mtrl.Length; i++)
                {
                    meshMaterials[i] = mtrl[i].Material3D;
                    if ((mtrl[i].TextureFilename != null) && (mtrl[i].TextureFilename != string.Empty))
                    {
                        //we have a texture, try to load it
                        meshTextures[i] = TextureLoader.FromFile(device, @"..\..\" + mtrl[i].TextureFilename);
                    }
                }
            }
            return tempMesh;
        }

        /// <summary>
        /// Draw the road.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        private void DrawRoad(float x, float y, float z)
        {
            device.Transform.World = Matrix.Translation(x, y, z);

            for (int i = 0; i < roadMaterials.Length; i++)
            {
                device.Material = roadMaterials[i];
                device.SetTexture(0, roadTextures[i]);
                roadMesh.DrawSubset(i);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //handle the esc key for quitting
            if (e.KeyCode == Keys.Escape)
            {
                //close the form and return
                this.Close();
                return;
            }

            // Ignore keystrokes for a second after the game is over
            if ((System.Environment.TickCount - gameOverTick) < 1000)
            {
                return;
            }

            //handle the left and right keys
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.NumPad4))
            {
                car.IsMovingLeft = true;
                car.IsMovingRight = false;
            }

            if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.NumPad6))
            {
                car.IsMovingRight = true;
                car.IsMovingLeft = false;
            }

            //stop moving
            if ((e.KeyCode == Keys.NumPad5) || (e.KeyCode == Keys.Up))
            {
                car.IsMovingLeft = false;
                car.IsMovingRight = false;
            }
            if (isGameOver)
            {
                LoadDefaultGameOptions();
            }
            isGameOver = false;
            hasGameStarted = true;
        }

        private void AddObstacles(float minDepth)
        {
            //add the right number of obstacles
            int numberToAdd = (int)((RoadSize / car.Diameter - 1) / 2.0f);
            //get the min space between obstacles in this section
            float minSize = ((RoadSize / numberToAdd) - car.Diameter) / 2.0f;

            for (int i = 0; i < numberToAdd; i++)
            {
                //get a random number in the min size range
                float depth = minDepth - ((float)Utility.Rnd.NextDouble() * minSize);
                //make sure its in the right range
                depth -= (i * (car.Diameter * 2));

                //pick right or left side of road
                float location = (Utility.Rnd.Next(50) > 25) ? RoadLocationLeft : RoadLocationRight;

                //add the obstacle
                obstacles.Add(new Obstacle(device, location, obstacleHeight, depth));
            }
        }

        private void LoadDefaultGameOptions()
        {
            score = 0;
            //Road Information
            RoadDepth0 = 0.0f;
            RoadDepth1 = -100.0f;
            RoadSpeed = 30.0f;
            //car data info
            car.Location = RoadLocationLeft;
            car.Speed = 10.0f;
            car.IsMovingRight = false;
            car.IsMovingLeft = false;

            //remove any obstacles currently in the game
            foreach (Obstacle o in obstacles)
            {
                //dispose it
                o.Dispose();
            }
            obstacles.Clear();

            //add some obstacles
            AddObstacles(RoadDepth1);

            //Start our timer
            Utility.Timer(DirectXTimer.Start);
        }

    }
}