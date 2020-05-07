using UnityEngine;

namespace Core.MonoBehaviours
{
    public class Factory : MonoBehaviour
    {
        public GameObject CreateGameObjectFromResources(
            string path,
            bool parentFactory = false)
        {
            return Instantiate(
                original: Resources.Load<GameObject>(path: path),
                parent: parentFactory ? transform : null);
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}