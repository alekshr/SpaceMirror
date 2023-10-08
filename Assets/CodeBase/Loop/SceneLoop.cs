using System;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Loop
{
    public class SceneLoop : IInitializable, IFixedTickable, ITickable, IDisposable
    {
        private readonly World _world;
        private readonly SystemsGroup _systems;
        
        [Inject]
        public SceneLoop(IReadOnlyList<IInitializer> initializers, IReadOnlyList<ISystem> systems)
        {
            _world = World.Create();
            _systems = _world.CreateSystemsGroup();
            //TODO: С такой шуткой нужно разобраться, регстрирует initializer у систем, так как ISystem
            //наследуется от IInitializer и два раза вызывает IInitializer, так как при update вызывает автоматом OnAwake у систем
            AddInitializerToGroup(initializers.Except(systems));
            AddSystemToGroup(systems);
        }

        void IInitializable.Initialize() => 
            _systems.Initialize();

        void IFixedTickable.FixedTick() => 
            _systems.FixedUpdate(Time.fixedDeltaTime); 

        void ITickable.Tick() =>             
            _systems.Update(Time.deltaTime); 


        public void Dispose()
        {
            _systems.Dispose();
            _world.Dispose();
        }

        private void AddSystemToGroup(IEnumerable<ISystem> systems)
        {
            foreach (var system in systems)
            {
                _systems.AddSystem(system);
            }
        }

        private void AddInitializerToGroup(IEnumerable<IInitializer> initializers)
        {
            foreach (var initializer in initializers)
            {
                _systems.AddInitializer(initializer);
                Debug.Log(initializer);
            }
        }
    }
}

