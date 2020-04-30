using UnityEngine;

namespace Memory.Settings
{
    [CreateAssetMenu(fileName = "Visual Settings", menuName = "Memory/Settings/Visual", order = 0)]
    public class VisualSettings : ScriptableObject
    {
        public Sprite Background;
        public Sprite CardFrame;
        public Sprite[] Animals;
    }
}