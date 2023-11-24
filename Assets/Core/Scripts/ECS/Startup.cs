using Leopotam.EcsLite;
using UnityEngine;
using AB_Utility.FromSceneToEntityConverter;
using LeoEcsPhysics;
using SevenBoldPencil.EasyEvents;
using Leopotam.EcsLite.Unity.Ugui;

namespace RunnerECS {
    sealed class Startup : MonoBehaviour {
        [SerializeField] EcsUguiEmitter _uguiEmitter;

        private EcsWorld _world;        
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;
        private SharedData sharedData;

        private void Start () {
            var data = AllDataLinkContainer.GetAllDataLinks("AllDataLinks");
            sharedData = new SharedData { EventsBus = new EventsBus(), AllData = data };

            _world = new EcsWorld ();
            _updateSystems = new EcsSystems (_world, sharedData);
            _fixedUpdateSystems = new EcsSystems(_world);
            EcsPhysicsEvents.ecsWorld = _world;

            AddSystems();
            AddEditorSystems();

            AddInjections();
            AddEventsDestroyer();

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
            _updateSystems.GetWorld("ugui-events")?.Destroy();
            _updateSystems?.Destroy ();
            _updateSystems = null;

            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;

            _world?.Destroy ();
            _world = null;

            sharedData.EventsBus.Destroy();
        }
        
        private void AddSystems() {
            _updateSystems
                .Add(new CoinsGenerateSystem())
                .Add(new MoveSystem())
                .Add(new FollowSystem())
                .Add(new RotationSystem())
                .Add(new PlayerInputSystem())

                .Add(new BankTextSystem())
                .Add(new AnimationSystem())
                .Add(new CoinCollectSystem())
                .Add(new LevelCompletionSystem())

                .Add(new UIEventsSystem())
                .Add(new VFXSystem())
                ;
        }

        private void AddEditorSystems() {
            #if UNITY_EDITOR
                _updateSystems
                    .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ());
            #endif
        }

        private void AddEventsDestroyer()
        {
            _updateSystems
                .Add(sharedData.EventsBus.GetDestroyEventsSystem()
                .IncReplicant<CreateVFXEvent>());
        }

        private void AddInjections()
        {
            _updateSystems.InjectUgui(_uguiEmitter);
        }
    }
}