using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GrinsenDraft1.Objects;

namespace GrinsenDraft1.Base
{
    class Scene
    {
        public string ID { get; set; }

        protected List<SimpleModel> _sceneObjects = new List<SimpleModel>();
        protected List<SimpleModel> _BBObjects = new List<SimpleModel>();
        public List<SimpleModel> Objects { get { return _sceneObjects; } }
        public List<SimpleModel> BBObjs { get { return _BBObjects; } }

        protected GameEngine Engine;

        public Scene(string id, GameEngine engine)
        {
            ID = id;
            Engine = engine;
        }

        public virtual void Initialize()
        {
            for (int i = 0; i < _sceneObjects.Count; i++)
            {
                _sceneObjects[i].Initialize();
            }

            for (int i = 0; i < _BBObjects.Count; i++)
            {
                _BBObjects[i].Initialize();
            }
        }


        public virtual void Update(GameTime gameTime)
        {
            HandleInput();

            for (int i = 0; i < _sceneObjects.Count; i++)
            {
                _sceneObjects[i].Update(gameTime);
            }

            for (int i = 0; i < _BBObjects.Count; i++)
            {
                _BBObjects[i].Update(gameTime);
            }
        }

        protected virtual void HandleInput() { }

        public void AddObject(SimpleModel _newObject)
        {
            _newObject.Destroying += new GameObjectEventHandler(_newObject_Destroying);
            _sceneObjects.Add(_newObject);
        }


        void _newObject_Destroying(string id)
        {
            RemoveObject(id);
        }

        public void RemoveObject(string id)
        {
            for (int i = 0; i < _sceneObjects.Count; i++)
            {
                if (_sceneObjects[i].ID == id)
                {
                    _sceneObjects.RemoveAt(i);
                }
            }
        }

        public GameObject3D GetObject(string id)
        {
            for (int i = 0; i < _sceneObjects.Count; i++)
            {
                if (_sceneObjects[i].ID == id)
                    return _sceneObjects[i];
            }


            return null;
        }

        public void addBB(SimpleModel obj)
        {
            _BBObjects.Add(obj);
        }

    }
}
