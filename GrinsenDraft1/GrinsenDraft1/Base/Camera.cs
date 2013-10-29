using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GrinsenDraft1
{
    public class Camera : GameObject3D
    {
        protected Vector3 cameraTarget;
        protected Vector3 cameraUpDirection;
        public Vector3 cameraDirection;
        public Vector3 cameraPosition;

        float speed = 3;
        protected Matrix view;
        protected Matrix projection;

        protected float fieldOfView = MathHelper.PiOver4;
        protected float nearPlane = 0.25f;
        protected float farPlane = 10000;

        protected Vector3 startTarget;
        Vector3 pos;

        protected float _aspectRatio = 1.7f;

        public Camera(string id, Vector3 position, Vector3 target, float aspectRatio)
            : base(id, position)
        {
            startTarget = target;
            _aspectRatio = aspectRatio;
            pos = position;
        }

        public override void Initialize()
        {

            cameraPosition = new Vector3(0.6536992f, 0.5900002f, 3.009872f);
            cameraDirection = new Vector3(-0.2789911f, 0, -0.9662936f);
            //cameraDirection = startTarget - pos;
            //cameraDirection.Normalize();
            cameraUpDirection = Vector3.Up;
            //cameraTarget = world.Translation + cameraDirection;

            CreateLookAt(startTarget);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, _aspectRatio, nearPlane, farPlane);

            base.Initialize();
        }

        public override void Update(GameTime gametime)
        {
            #region MoveingCameraInput
            //Move Forward/Backward
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                cameraPosition += cameraDirection * speed / 100;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                cameraPosition -= cameraDirection * speed / 100;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                cameraPosition += Vector3.Cross(cameraUpDirection, cameraDirection) * speed / 100;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                cameraPosition -= Vector3.Cross(cameraUpDirection, cameraDirection) * speed / 100;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cameraPosition += new Vector3(0, 0.01f, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cameraPosition -= new Vector3(0, 0.01f, 0);
            }


            //yaw Rotation
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                cameraDirection = Vector3.Transform(cameraDirection,
                Matrix.CreateFromAxisAngle(cameraUpDirection, (-MathHelper.PiOver4 / 150)));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                cameraDirection = Vector3.Transform(cameraDirection,
                Matrix.CreateFromAxisAngle(cameraUpDirection, (MathHelper.PiOver4 / 150)));
            }

            //Pitch rotation
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                cameraDirection = Vector3.Transform(cameraDirection,
                    Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUpDirection, cameraDirection), (MathHelper.PiOver4 / 100)));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.V))
            {
                cameraDirection = Vector3.Transform(cameraDirection,
                    Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUpDirection, cameraDirection), (-MathHelper.PiOver4 / 100)));
            }
            #endregion

            #region CameraSetPositions
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                cameraPosition = new Vector3(0.6536992f, 0.5900002f, 3.009872f);
                cameraDirection = new Vector3(-0.2789911f, 0, -0.9662936f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                cameraPosition = new Vector3(-0.6392952f, 0.7708824f, 1.077051f);
                cameraDirection = new Vector3(0.2907656f, -0.1029412f, -0.9573004f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                cameraPosition = new Vector3(0.001380169f, 0.655294f, -1.431122f);
                cameraDirection = new Vector3(0.01214204f, -0.1029412f, -1.00041f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D4))
            {
                cameraPosition = new Vector3(0.1668746f, 0.7107349f, -2.935163f);
                cameraDirection = new Vector3(0.9793568f, -0.1501261f, 0.1726054f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D5))
            {
                cameraPosition = new Vector3(0.01676146f, 0.7382159f, -2.93677f);
                cameraDirection = new Vector3(-0.9771445f, -0.1501261f, 0.1847154f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D6))
            {
                cameraPosition = new Vector3(1.632991f, 0.5485632f, 2.797397f);
                cameraDirection = new Vector3(1.004516f, -0.04017189f, 0.02797749f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D7))
            {
                cameraPosition = new Vector3(2.26632f, 0.8370246f, 2.48168f);
                cameraDirection = new Vector3(-0.968888f, -0.2192282f, 0.1570063f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D8))
            {
                cameraPosition = new Vector3(0.2617446f, 0.7660785f, 3.207691f);
                cameraDirection = new Vector3(-0.96538f, -0.1580832f, -0.2334675f);
            }

            #endregion

            CreateLookAt();

            base.Update(gametime);
        }

        public virtual void CreateLookAt()
        {
            //cameraTarget = world.Translation + cameraDirection;
            //view = Matrix.CreateLookAt(world.Translation, cameraTarget, cameraUpDirection);
            //view = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            view = Matrix.CreateLookAt(cameraPosition, cameraPosition + cameraDirection, cameraUpDirection);
        }

        public virtual void CreateLookAt(Vector3 target)
        {
            //Matrix.CreateLookAt(world.Translation, target, cameraUpDirection);
            cameraTarget = world.Translation + cameraDirection;
            view = Matrix.CreateLookAt(world.Translation, target, Vector3.Up);
            
        }

        public Matrix View
        {
            get { return view; }
            set { view = value; }
        }

        public Matrix Projection
        {
            get { return projection; }
            set { projection = value; }
        }
    }
}
