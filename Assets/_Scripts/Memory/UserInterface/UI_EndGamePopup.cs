using System;
using Memory.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Memory.UserInterface
{
    public class UI_EndGamePopup : MonoBehaviour
    {
        public event Action BackToMenuRequested;
        public event Action ReplayRequested;

        [SerializeField]
        private Animator _starPanelAnimator;

        [SerializeField]
        private Button _replayButton;

        [SerializeField]
        private Button _menuButton;

        [SerializeField]
        private GameObject _haloObject;

        private void Awake()
        {
            _replayButton.onClick.AddListener(OnReplayButtonClicked);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
        }

        private int _oneStarAnimationTriggerHash => Animator.StringToHash("one_star");
        private int _twoStarAnimationTriggerHash => Animator.StringToHash("two_stars");
        private int _threeStarAnimationTriggerHash => Animator.StringToHash("three_stars");

        public void SetResult(CompletenessType completeness)
        {
            switch (completeness)
            {
                case CompletenessType.LOST:
                    _haloObject.SetActive(false);
                    break;
                case CompletenessType.OK:
                    _starPanelAnimator.SetTrigger(_oneStarAnimationTriggerHash);
                    break;
                case CompletenessType.GOOD:
                    _starPanelAnimator.SetTrigger(_twoStarAnimationTriggerHash);
                    break;
                case CompletenessType.PERFECT:
                    _starPanelAnimator.SetTrigger(_threeStarAnimationTriggerHash);
                    break;
            }
        }

        private void OnReplayButtonClicked()
        {
            ReplayRequested?.Invoke();
        }

        private void OnMenuButtonClicked()
        {
            BackToMenuRequested?.Invoke();
        }
    }
}