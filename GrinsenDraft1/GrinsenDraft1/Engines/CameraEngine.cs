using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GrinsenDraft1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class CameraEngine : GameComponent
    {
        private Dictionary<string, Camera> cameras;
        private Camera activeCamera;
        private string activeCameraID;

        public Camera ActiveCamera
        {
            get { return activeCamera; }
        }

        public CameraEngine(Game game)
            : base(game)
        {
            cameras = new Dictionary<string, Camera>();

            game.Components.Add(this);
        }

        public List<string> GetCurrentCameras()
        {
            return cameras.Keys.ToList();
        }

      
        public override void Initialize()
        {
           
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            if (activeCamera != null)
            {
                activeCamera.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public void SetActiveCamera(string id)
        {
            if (cameras.ContainsKey(id))
            {
                if (activeCameraID != id)
                {
                    activeCamera = cameras[id];
                    activeCamera.Initialize();

                    activeCameraID = id;
                }
            }
        }


        public void AddCamera(Camera camera)
        {
            if (!cameras.ContainsKey(camera.ID))
            {
                cameras.Add(camera.ID, camera);

                if (cameras.Count == 1)
                {
                    SetActiveCamera(camera.ID);
                }
            }
        }

        public void RemoveCamera(string id)
        {
            if (cameras.ContainsKey(id))
            {
                if (cameras.Count > 1)
                {
                    cameras.Remove(id);
                }
            }
        }

    }
}
