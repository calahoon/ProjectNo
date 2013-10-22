using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GrinsenDraft1.Objects;

namespace GrinsenDraft1
{
    class Player : SimpleModel
    {

       //Im testing this out now to see if I have to do this from now on
       
        public float forwardSpeed = 0.3f;
        public bool colliding = false;
        
        public Vector3 forwardMovement;

        public Player(string id, string asset, Vector3 pos): base(id, asset,pos)
        {

        }

        public override void Update(GameTime gametime)
        {
            //if (InputEngine.IsKeyPressed(Keys.W))
            //{
            //    model.BoneTransforms
            //}

            if (InputEngine.IsKeyHeld(Keys.B))
            {
                forwardMovement = BoneTransforms[1].Up * forwardSpeed;
                BoneTransforms[1] *= Matrix.CreateTranslation(forwardMovement);
                UpdateBoundBox(Matrix.CreateTranslation(forwardMovement));
            }

            if (InputEngine.IsKeyHeld(Keys.R))
            {
                Vector3 offset = BoneTransforms[1].Translation;

                BoneTransforms[1] *= Matrix.CreateTranslation(-offset);
                BoneTransforms[1] *= Matrix.CreateRotationY(MathHelper.ToRadians(1.0f));
                BoneTransforms[1] *= Matrix.CreateTranslation(offset);
            }

            if (InputEngine.IsKeyHeld(Keys.T))
            {
                Vector3 offset = BoneTransforms[1].Translation;

                BoneTransforms[1] *= Matrix.CreateTranslation(-offset);
                BoneTransforms[1] *= Matrix.CreateRotationY(MathHelper.ToRadians(-1.0f));
                BoneTransforms[1] *= Matrix.CreateTranslation(offset);

            }

            base.Update(gametime);
        }

    }
}
