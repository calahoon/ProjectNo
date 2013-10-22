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
    class Level : Scene
    {

        Camera _simpleCamera;
        SimpleModel hallway, hallwayBB1, hallwayBB2, hallwayBB3, hallwayBB4, hallwayBB5, hallwayBB6;
        Player p;

        public Level(GameEngine gameEngine): base("level1", gameEngine)
        {
            _simpleCamera = new Camera("cam0",
                new Vector3(0, 5, 120),
                new Vector3(0, 5, 10),
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.AspectRatio);

            Engine.Cameras.AddCamera(_simpleCamera);

            hallway = new SimpleModel("level0", "SampleHallway", new Vector3(0, 0, 0));
            hallwayBB1 = new SimpleModel("boundBox1", "hallwayBBblend", new Vector3(0, 0, 2.4f));
            hallwayBB2 = new SimpleModel("boundBox2", "hallwayBBblend", new Vector3(0, 0, -0.5f));
            hallwayBB3 = new SimpleModel("boundBox3", "hallwayBBblend2", new Vector3(-0.8f, 0, -2.6f));
            hallwayBB4 = new SimpleModel("boundBox4", "hallwayBBblend2", new Vector3(0.8f, 0, -2.6f));
            hallwayBB5 = new SimpleModel("boundBox5", "hallwayBBblend2", new Vector3(0.9f, 0, 2.9f));
            hallwayBB6 = new SimpleModel("boundBox6", "hallwayBBblend2", new Vector3(-0.9f, 0, 2.9f));
            
            p = new Player("Player", "sampleMan", new Vector3(-0.6f, 0.4f, 0));

            AddObject(hallway);
            AddObject(p);

            addBB(hallwayBB1);
            addBB(hallwayBB2);
            addBB(hallwayBB3);
            addBB(hallwayBB4);
            addBB(hallwayBB5);
            addBB(hallwayBB6);
            
        }

        protected override void HandleInput()
        {

            //if (InputEngine.IsKeyHeld(Keys.K))
            //{
            //    hallwayBB3.world *= Matrix.CreateRotationY(0.2f);
            //}

            //if (InputEngine.IsKeyHeld(Keys.L))
            //{
            //    hallwayBB3.world *= Matrix.CreateRotationY(-0.2f);
            //}

            //if (InputEngine.IsKeyHeld(Keys.N))
            //{
            //    hallwayBB3.world *= Matrix.CreateTranslation(new Vector3(0.1f, 0, 0));
            //    hallwayBB3._position += new Vector3(0.1f, 0, 0);
            //}

            //if (InputEngine.IsKeyHeld(Keys.M))
            //{
            //    hallwayBB3.world *= Matrix.CreateTranslation(new Vector3(-0.1f, 0, 0));
            //    hallwayBB3._position += new Vector3(-0.1f, 0, 0);
            //}

            //if (InputEngine.IsKeyHeld(Keys.H))
            //{
            //    hallwayBB3.world *= Matrix.CreateTranslation(new Vector3(0, 0, 0.1f));
            //    hallwayBB3._position += new Vector3(0, 0, 0.1f);
            //}

            //if (InputEngine.IsKeyHeld(Keys.J))
            //{
            //    hallwayBB3.world *= Matrix.CreateTranslation(new Vector3(0, 0, -0.1f));
            //    hallwayBB3._position += new Vector3(0, 0, -0.1f);
            //}

            base.HandleInput();
        }


        public override void Update(GameTime gameTime)
        {

            updateCameraPositions();

            base.Update(gameTime);
        }

        public bool DoesIntersectWith(BoundingBox _original, BoundingBox _otherBox)
        {
            return _original.Intersects(_otherBox);
        }

        public void updateCameraPositions()
        {
            if (DoesIntersectWith(p.AABB, hallwayBB1.AABB))
            {
                Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(1.349635f, 0.849736f, 2.570147f);
                Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(-0.9397489f, -0.3324139f, -0.0789137f);
            }

            if (DoesIntersectWith(p.AABB, hallwayBB2.AABB))
            {
                Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(0.6471494f, 0.7051401f, -0.2803672f);
                Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(-0.2896483f, -0.1713896f, -0.9415193f);
            }

            if (DoesIntersectWith(p.AABB, hallwayBB3.AABB))
            {
                Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(-0.07407543f, 0.5983807f, -2.624752f);
                Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(-0.9972172f, -0.02916069f, 0.01044261f);
            }

            if (DoesIntersectWith(p.AABB, hallwayBB4.AABB))
            {
                Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(-0.5616181f, 0.8102024f, -2.783839f);
                Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(0.9467457f, -0.2757824f, 0.1652343f);
            }

            if (DoesIntersectWith(p.AABB, hallwayBB5.AABB))
            {
                Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(0.4624078f, 0.8500673f, 2.491104f);
                Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(0.9198986f, -0.3229031f, 0.2106851f);
            }

            if (DoesIntersectWith(p.AABB, hallwayBB6.AABB))
            {
                Engine.Cameras.ActiveCamera.cameraPosition = new Vector3(-3.292135f, 0.8036986f, 2.571702f);
                Engine.Cameras.ActiveCamera.cameraDirection = new Vector3(0.9470115f, -0.1764359f, 0.2590732f);
            }
        }
       
    }
}
