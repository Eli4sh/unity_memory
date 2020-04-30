using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class CameraSizeAspectRatioFitter : MonoBehaviour
    {
        private const float _targetAspect = 1.3333f;
        void Start()
        {
            float windowAspect = (float) Screen.height / (float) Screen.width;
            float scaleSize = windowAspect / _targetAspect;
            Camera camera = GetComponent<Camera>();
            camera.orthographicSize *= scaleSize;
        }
    }
}