using System;
using TMPro;
using UnityEngine;

namespace Memory.UserInterface
{
    public class UI_TopBar : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _progressText;

        [SerializeField]
        private TMP_Text _timerText;

        [SerializeField]
        private Animator _animator;

        private int _hideAnimationTriggerHash => Animator.StringToHash("hide");

        public void OnTimeChanged(TimeSpan timeLeft)
        {
            _timerText.text = timeLeft.TotalSeconds.ToString(format: "0");
        }

        public void OnProgressChanged(int current, int max)
        {
            _progressText.text = $"{current}/{max}";
        }

        public void Hide()
        {
            _animator.SetTrigger(_hideAnimationTriggerHash);
        }
    }
}