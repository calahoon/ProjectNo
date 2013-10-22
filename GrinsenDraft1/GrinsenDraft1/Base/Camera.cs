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

            cameraPosition = new Vector3(0.5700018f, 0.5900002f, 2.719984f);
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
                cameraPosition = new Vector3(0.5700018f, 0.5900002f, 2.719984f);
                cameraDirection = new Vector3(-0.2789911f, 0, -0.9662936f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                cameraPosition = new Vector3(2.301701f, 0.8416111f, 2.47299f);
                cameraDirection = new Vector3(0.8824925f, -0.3465354f, 0.3177167f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                cameraPosition = new Vector3(1.349635f, 0.849736f, 2.570147f);
                cameraDirection = new Vector3(-0.9397489f, -0.3324139f, -0.0789137f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D4))
            {
                cameraPosition = new Vector3(0.6471494f, 0.7051401f, -0.2803672f);
                cameraDirection = new Vector3(-0.2896483f, -0.1713896f, -0.9415193f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D5))
            {
                cameraPosition = new Vector3(-0.07407543f, 0.5983807f, -2.624752f);
                cameraDirection = new Vector3(-0.9972172f, -0.02916069f, 0.01044261f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D6))
            {
                cameraPosition = new Vector3(0.5522006f, 0.7921423f, -2.230762f);
                cameraDirection = new Vector3(-0.9458208f, -0.221339f, -0.2270722f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D7))
            {
                cameraPosition = new Vector3(0.644692f, 0.7806085f, -0.448325f);
                cameraDirection = new Vector3(-0.3662033f, -0.1764359f, 0.9109585f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D8))
            {
                cameraPosition = new Vector3(-3.292135f, 0.8036986f, 2.571702f);
                cameraDirection = new Vector3(0.9470115f, -0.1764359f, 0.2590732f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D9))
            {
                cameraPosition = new Vector3(1.045394f, 0.8128154f, 0.1592962f);
                cameraDirection = new Vector3(-0.1276103f, -0.3399076f, 0.9315752f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D0))
            {
                cameraPosition = new Vector3(1.535715f, 0.8610196f, 2.449051f);
                cameraDirection = new Vector3(0.8810356f, -0.3229031f, 0.338198f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                cameraPosition = new Vector3(0.7123739f, 0.811753f, 0.0364262f);
                cameraDirection = new Vector3(0.9124609f, -0.3192243f, 0.2547633f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                cameraPosition = new Vector3(0.8053413f, 0.8135188f, -2.20073f);
                cameraDirection = new Vector3(0.2748153f, -0.3543718f, 0.8933015f);
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
