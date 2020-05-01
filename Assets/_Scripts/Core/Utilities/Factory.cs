using UnityEngine;

namespace Core
{
    public class Factory : MonoBehaviour
    {
        public GameObject CreateGameObjectFromResources(
            string path)
        {
            return Instantiate(
                original: Resources.Load<GameObject>(path: path),
                parent: transform);
        }
    }
}