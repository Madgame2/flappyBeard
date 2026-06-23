using FlappyBird.RunTime.Core.Services.Spawn;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core.Services.Spawn
{
    public class SpawnSystem: ISpawner
    {
        private readonly IObjectResolver _container;

        public SpawnSystem(IObjectResolver container)
        {
            _container = container;
        }

        public GameObject Spawn(GameObject prefab)
        {
            return _container.Instantiate(prefab);
        }

        public GameObject Spawn(GameObject prefab, Vector3 pos)
        {
            return _container.Instantiate(prefab, pos, Quaternion.identity);
        }
        
        public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
        {
            return _container.Instantiate(prefab, pos, rot);
        }
        
        public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent)
        {
            return _container.Instantiate(prefab, pos, rot, parent);
        }
    }
}
