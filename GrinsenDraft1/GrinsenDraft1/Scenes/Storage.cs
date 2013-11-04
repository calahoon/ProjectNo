using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GrinsenDraft1.Base;
using GrinsenDraft1.Engines;
using GrinsenDraft1.Objects;


namespace GrinsenDraft1.Scenes
{
    class Storage : Scene
    {

        Camera _Camera1;
        SimpleModel room, doorBB;
        Player p;

        public Storage(GameEngine gameEngine ) : base("Storage", gameEngine)
        {
            _Camera1 = new Camera("cam1",
               new Vector3(0, 5, 120),
               new Vector3(0, 5, 10),
               GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.AspectRatio);

            Engine.Cameras.AddCamera(_Camera1);

            Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(0.2897553f, 0.8654348f, -0.6233569f);
            Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(0.9293623f, -0.3014693f, -0.2369716f);

            room = new SimpleModel("Storage", "sampleRoom", new Vector3(0, 0, 0));
            p = new Player("Player", "sampleMan", new Vector3(2.43937f, 0.4f, -1.251225f));
            doorBB = new SimpleModel("Door1BB", "DoorBB", new Vector3(2.82998f, 0.18f, -1.259999f));

            AddObject(room);
            AddObject(p);

            addBB(doorBB);
            p.RotationRadians = -80.0f;
        
        }

        protected override void HandleInput()
        {
            if (InputEngine.IsKeyHeld(Keys.N))
            {
                doorBB.world *= Matrix.CreateTranslation(new Vector3(0.01f, 0, 0));
                doorBB._position += new Vector3(0.01f, 0, 0);
            }

            if (InputEngine.IsKeyHeld(Keys.M))
            {
                doorBB.world *= Matrix.CreateTranslation(new Vector3(-0.01f, 0, 0));
                doorBB._position += new Vector3(-0.01f, 0, 0);
            }

            if (InputEngine.IsKeyHeld(Keys.H))
            {
                doorBB.world *= Matrix.CreateTranslation(new Vector3(0, 0, 0.01f));
                doorBB._position += new Vector3(0, 0, 0.01f);
            }

            if (InputEngine.IsKeyHeld(Keys.J))
            {
                doorBB.world *= Matrix.CreateTranslation(new Vector3(0, 0, -0.01f));
                doorBB._position += new Vector3(0, 0, -0.01f);
            }

            if (InputEngine.IsKeyHeld(Keys.K))
            {
                doorBB.world *= Matrix.CreateTranslation(new Vector3(0, 0.01f, 0));
                doorBB._position += new Vector3(0, 0.01f, 0);
            }

            if (InputEngine.IsKeyHeld(Keys.L))
            {
                doorBB.world *= Matrix.CreateTranslation(new Vector3(0, -0.01f, 0));
                doorBB._position += new Vector3(0, -0.01f, 0);
            }

            base.HandleInput();
        }

        public override void Update(GameTime gameTime)
        {
            if (DoesIntersectWith(p.AABB, doorBB.AABB) && InputEngine.IsKeyHeld(Keys.Space))
            {
                Engine.LoadScene(new Level1(Engine));
            }

            base.Update(gameTime);
        }

        public bool DoesIntersectWith(BoundingBox _original, BoundingBox _otherBox)
        {
            return _original.Intersects(_otherBox);
        }

    }
}
