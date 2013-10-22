using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using GrinsenDraft1.Base;
using GrinsenDraft1.Engines;
using Microsoft.Xna.Framework.Input;

namespace GrinsenDraft1.Objects
{
    class SimpleModel : GameObject3D
    {
        public Model Model3D { get; set; }
        public Matrix[] BoneTransforms { get; set; }
        string _asset;
        public Vector3 _position;
        RasterizerState _rasterState;
        public BoundingBox AABB { get; set; }

        public SimpleModel(string id, string asset, Vector3 position)
            : base(id, position)
        {
            _asset = asset;
            _position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            if (!string.IsNullOrEmpty(_asset))
            {
                Model3D = content.Load<Model>("Models\\" + _asset);

                BoneTransforms = new Matrix[Model3D.Bones.Count];
                Model3D.CopyAbsoluteBoneTransformsTo(BoneTransforms);

                List<Vector3> _vertices = new List<Vector3>();

                foreach (ModelMesh mesh in Model3D.Meshes)
                {
                    _vertices.AddRange(Helpers.ExtractVector3FromMesh(mesh, BoneTransforms));
                }

                AABB = BoundingBox.CreateFromPoints(_vertices);

                UpdateBoundBox(world);
            }

            _rasterState = new RasterizerState();
            _rasterState.FillMode = FillMode.Solid;
            _rasterState.CullMode = CullMode.None;

            base.LoadContent(content);
        }

        public override void Update(GameTime gametime)
        {

            //DebugEngine.AddBoundingBox(AABB, Color.Yellow);

            base.Update(gametime);
        }

        public override void Draw(Camera camera)
        {
            var _state = Helpers.GraphicsDevice.RasterizerState;
            Helpers.GraphicsDevice.RasterizerState = _rasterState;

            foreach (ModelMesh mesh in Model3D.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = camera.View;
                    effect.Projection = camera.Projection;
                    effect.World = BoneTransforms[mesh.ParentBone.Index] * world;

                    //effect.PreferPerPixelLighting = true;
                    effect.EnableDefaultLighting();
                }

                mesh.Draw();
            }

            Helpers.GraphicsDevice.RasterizerState = _state;

            base.Draw(camera);
        }//end of draw

        public void UpdateBoundBox(Matrix _transform)
        {
            AABB = Helpers.transformBoundingBox(AABB, _transform);
        }

    }
}
