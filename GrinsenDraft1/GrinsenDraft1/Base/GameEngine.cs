using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrinsenDraft1.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GrinsenDraft1.Objects;

namespace GrinsenDraft1.Base
{
    class GameEngine : DrawableGameComponent
    {

        public InputEngine Input { get; set; }
        public CameraEngine Cameras { get; set; }
        public AudioEngine Audio { get; set; }
        public DebugEngine Debug { get; set; }
        public FrameRateCounter FPSCounter { get; set; }

        public Scene ActiveScene { get; set; }

        public GameEngine(Game _game)
            : base(_game)
        {
            _game.Components.Add(this);

            Input = new InputEngine(_game);
            Cameras = new CameraEngine(_game);
            Audio = new AudioEngine(_game);
            FPSCounter = new FrameRateCounter(_game, new Vector2(10, 10));
            Debug = new DebugEngine();

        }

        public override void Initialize()
        {
            Debug.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Debug.LoadContent(Game.Content);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (ActiveScene != null)
                ActiveScene.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Draw3D();
            Draw2D();


            base.Draw(gameTime);
        }

        private void Draw2D()
        {

        }

        private void Draw3D()
        {
            if (Cameras.ActiveCamera != null)
            {
                for (int i = 0; i < ActiveScene.Objects.Count; i++)
                {
                    ActiveScene.Objects[i].Draw(Cameras.ActiveCamera);
                }

                //for (int i = 0; i < ActiveScene.BBObjs.Count; i++)
                //{
                //    ActiveScene.BBObjs[i].Draw(Cameras.ActiveCamera);
                //}
            }

            Debug.Draw(Cameras.ActiveCamera);
        }


        public void LoadScene(Scene _scene)
        {
            if (_scene != null)
            {
                ActiveScene = _scene;
                ActiveScene.Initialize();


                for (int i = 0; i < ActiveScene.Objects.Count; i++)
                {
                    ActiveScene.Objects[i].LoadContent(Game.Content);
                }

                for (int i = 0; i < ActiveScene.BBObjs.Count; i++)
                {
                    ActiveScene.BBObjs[i].LoadContent(Game.Content);
                }

            }
        }

        public bool DoesIntersectWith(BoundingBox _original, BoundingBox _otherBox)
        {
            return _original.Intersects(_otherBox);
        }
       

    }
}
