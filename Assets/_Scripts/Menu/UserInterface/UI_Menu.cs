using System.Collections;
using System.Collections.Generic;
using Core.Management;
using Memory.Structs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.UserInterface
{
    public class UI_Menu : MonoBehaviour
    {
        [SerializeField]
        private UI_LastGameResult _lastGameResult;

        [SerializeField]
        private Button _playButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
            Main.GetLastGameResult();
        }

        private void OnEnable()
        {
            Main.MemoryResultFound += OnMemoryResultFound;
        }

        private void OnDisable()
        {
            Main.MemoryResultFound -= OnMemoryResultFound;
        }

        private void OnMemoryResultFound(MemoryGameResult result)
        {
            _lastGameResult.SetResult(result);
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(1);
        }
    }
}