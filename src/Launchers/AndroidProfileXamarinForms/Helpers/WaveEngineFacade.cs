using System;
using System.Collections.Generic;
using WaveEngine.Components.Animation;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using XamarinForms3DCarSampleXamarinForms;

namespace XamarinForms3DCarSample.Helpers
{
    public static class WaveEngineFacade
    {

        private static Entity _currentPrefab;
        private static Entity _physicalCamera;
        private static MyScene _scene;

        public static event EventHandler<EventArgs> Initialized;

        public static void Initialize(MyScene scene)
        {
            _scene = scene;

            Init(Machines.SDM100);

            Initialized?.Invoke(null, new EventArgs());

            PlayAnimation(Animations.InternalWorking);            
        }

        private static void Init(string machineName)
        {
            _currentPrefab = _scene.EntityManager.Instantiate("Content/Assets/" + machineName + ".wpref");
            _currentPrefab = SDM_100_Setup(_currentPrefab);

            _currentPrefab.IsVisible = true;
            _currentPrefab.IsActive = true;

            _scene.EntityManager.Add(_currentPrefab);
        }

        public static void PlayAnimation(string animationName)
        {
            var items = new List<Entity>(_physicalCamera.ChildEntities);
            foreach (Entity item in items)
            {
                item.IsVisible = false;
            }

            Entity ent;
            switch (animationName)
            {
                case Animations.Bucks1:
                    ent = items.Find(ef => ef.Name.Equals("Cartela_500"));
                    ent.IsVisible = true;
                    break;
                case Animations.Bucks2:
                    ent = items.Find(ef => ef.Name.Equals("Cartela_1000"));
                    ent.IsVisible = true;
                    break;
                case Animations.Bucks3:
                    ent = items.Find(ef => ef.Name.Equals("Cartela_1700"));
                    ent.IsVisible = true;
                    break;
                case Animations.Bucks4:
                    ent = items.Find(ef => ef.Name.Equals("Cartela_2400"));
                    ent.IsVisible = true;
                    break;
                case Animations.InternalWorking:
                    break;
            }

            var animation3D = _currentPrefab.FindComponent<Animation3D>();
            animation3D.CurrentAnimation = animationName;
            animation3D.PlayAnimation(animationName, loop: false);
            animation3D.IsActive = true;
        }

        private static Entity SDM_100_Setup(Entity entity)
        {
            var childEntities = entity.ChildEntities;
            foreach (var childEntity in childEntities)
            {
                RemoveCameras(childEntity);

                if (childEntity.Name.Equals("PhysCamera001"))
                {
                    _physicalCamera = childEntity;
                    CreateCamera(childEntity);
                }
            }            

            return entity;
        }

        private static void CreateCamera(Entity entity)
        {
            var camera = new Camera3D
            {
                BackgroundColor = new WaveEngine.Common.Graphics.Color(229, 220, 211),
                FieldOfView = 0.6f
            };
            entity.AddComponent(camera);
        }

        private static void RemoveCameras(Entity entity)
        {
            var cameras = new List<Camera3D>(entity.FindComponents<Camera3D>());
            if (cameras.Count != 0)
            {
                entity.RemoveAllComponentsOfType<Camera3D>();
            }
        }

    }
}