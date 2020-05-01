using UnityEngine;

namespace Core
{
    public class CameraSizeAspectRatioFitter : MonoBehaviour
    {
        private const float _targetAspect = 1.3333f;

        private void Start()
        {
            float windowAspect = Screen.height / (float) Screen.width;
            float scaleSize = windowAspect / _targetAspect;
            Camera camera = GetComponent<Camera>();
            camera.orthographicSize *= scaleSize;
        }
    }
}