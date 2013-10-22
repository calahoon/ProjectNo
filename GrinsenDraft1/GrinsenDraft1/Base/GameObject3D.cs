using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GrinsenDraft1
{
    public delegate void GameObjectEventHandler(string id);

    public class GameObject3D
    {
        public string ID { get; set; }
        public Matrix world { get; set; }

        public event GameObjectEventHandler Destroying;

        public GameObject3D(string id)
        {
            ID = id;
            world = Matrix.Identity;
        }

        public GameObject3D(string id, Vector3 position)
        {
            ID = id;
            world = Matrix.Identity * Matrix.CreateTranslation(position);
        }

        public virtual void Initialize() { }
        public virtual void LoadContent(ContentManager content) { }
        public virtual void Update(GameTime gametime) { }
        public virtual void Draw(Camera camera) { }

        public void Destroy()
        {
            if (Destroying != null)
                Destroying(ID);
        }

    }
}
