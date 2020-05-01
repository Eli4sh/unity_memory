using System;
using System.Threading.Tasks;
using Core;
using Memory.GamePaths;
using Memory.Settings;
using UnityEngine;
using Grid = Memory.MonoBehaviours.Grid;

namespace Memory.Logic
{
    public static partial class Game
    {
        private static Factory _factory;
        private static Grid _grid;
        private static VisualSettings _visualSettings;
        private static GameplaySettings _gameplaySettings;

        public static void Awake(Factory factory, Grid grid)
        {
            SetGameStarted(value: false);

            _factory = factory;
            _grid = grid;

            _visualSettings = Resources.Load<VisualSettings>(path: Paths.VisualSettingsPath);
            _gameplaySettings = Resources.Load<GameplaySettings>(path: Paths.GameplaySettingsPath);

            SetLevelDuration(value: _gameplaySettings.LevelDuration);
            SetCardPairsCount(value: _gameplaySettings.MemoryPairs);
            SetMatchedPairs(value: 0);
            _grid.InitGrid(rowsColumns: _gameplaySettings.GridRowsColumns);
        }

        public static async void Start()
        {
            SetGameStartedTime(value: DateTime.Now);
            TimeLeftChanged?.Invoke(obj: GetTimeLeft());
            ProgressChanged?.Invoke(arg1: 0, arg2: GetCardPairsCount());
            await Task.Delay(millisecondsDelay: 1000);
            HideAllCards?.Invoke();
            await Task.Delay(millisecondsDelay: 1000);
            GameStarted?.Invoke();
            SetGameStartedTime(value: DateTime.Now);
            SetGameStarted(value: true);
        }

        public static void Update()
        {
            if (GetGameStarted())
            {
                TimeSpan timeLeft = GetTimeLeft();
                if (timeLeft.TotalSeconds >= 0)
                {
                    TimeLeftChanged(obj: timeLeft);
                }
                else
                {
                    SetGameStarted(value: false);
                    PrepareGameResult();
                    GameFinished?.Invoke();
                }
            }
        }
    }
}