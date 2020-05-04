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
        private UI_SelectSizePanel _selectSizePanel;

        [SerializeField]
        private Button _playButton;

        private void Awake()
        {
            _selectSizePanel.SizeSelected += OnMemoryGridSizeSelected;
            _playButton.onClick.AddListener(call: OnPlayButtonClicked);
        }

        private void Start()
        {
            Main.GetLastGameResult();
        }

        private void OnMemoryGridSizeSelected(Memory.Enums.GridSize size)
        {
            Memory.Logic.Game.OnGridSizeChosen(size);
            Core.Audio.PlaySound(Core.Enums.AudioType.BUTTON_UI);
        }

        private void OnMemoryResultFound(MemoryGameResult result)
        {
            _lastGameResult.SetResult(result: result);
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
            Core.Audio.PlaySound(Core.Enums.AudioType.BUTTON_UI);
        }
    }
}