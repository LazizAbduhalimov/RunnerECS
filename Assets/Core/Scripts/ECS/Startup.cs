using Leopotam.EcsLite;
using UnityEngine;
using AB_Utility.FromSceneToEntityConverter;
using LeoEcsPhysics;

namespace RunnerECS {
    sealed class Startup : MonoBehaviour {
        private EcsWorld _world;        
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;
        private void Start () {
            _world = new EcsWorld ();
            _updateSystems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            EcsPhysicsEvents.ecsWorld = _world;

            AddSystems();
            AddEditorSystems();    

            _updateSystems.ConvertScene().Init ();
            _fixedUpdateSystems.Init();
        }

        private void Update () {
            _updateSystems?.Run ();
        }
        
        private void FixedUpdate() {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy () {
            EcsPhysicsEvents.ecsWorld = null;
            _updateSystems?.Destroy ();
            _updateSystems = null;

            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;

            _world?.Destroy ();
            _world = null;
        }
        
        private void AddSystems() {
            _updateSystems
                .Add(new MoveSystem())
                .Add(new FollowSystem())
                .Add(new BankTextSystem())
                .Add(new LevelCompletionSystem())
                .Add(new CoinCollectSystem())
                .Add(new PlayerInputSystem())
                ;
        }

        private void AddEditorSystems() {
            #if UNITY_EDITOR
                _updateSystems
                    .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ());
            #endif
        }
    }
}