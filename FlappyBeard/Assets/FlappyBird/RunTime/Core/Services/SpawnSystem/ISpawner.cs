using UnityEngine;

namespace FlappyBird.RunTime.Core.Services.Spawn
{
    public interface ISpawner
    {
        GameObject Spawn(GameObject prefab);
        GameObject Spawn(GameObject prefab, Vector3 pos);
        GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot);
        GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent);
    }
}