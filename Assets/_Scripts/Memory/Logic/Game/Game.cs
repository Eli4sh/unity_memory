using System;
using System.Threading.Tasks;
using Core;
using Core.MonoBehaviours;
using Memory.Enums;
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

        public static void Init(Factory factory, Grid grid)
        {
            SetGameStarted(value: false);
            SetPrevioslySelectedCards(new Vector2Int(-1, -1));
            SetCurrentlySelectedPair(-1);

            _factory = factory;
            _grid = grid;

            _visualSettings = Resources.Load<VisualSettings>(path: Paths.VisualSettingsPath);
            _gameplaySettings = Resources.Load<GameplaySettings>(path: Paths.GameplaySettingsPath(GetGridSize()));

            SetLevelDuration(value: _gameplaySettings.LevelDuration);
            SetCardPairsCount(value: _gameplaySettings.CarPairs.Count);
            SetMatchedPairs(value: 0);
        }

        public static void Start()
        {
            _grid.InitGrid(rowsColumns: _gameplaySettings.GridRowsColumns);
            SetGameStartedTime(value: DateTime.Now);
            TimeLeftChanged?.Invoke(obj: GetTimeLeft());
            ProgressChanged?.Invoke(arg1: 0, arg2: GetCardPairsCount());
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
                    GameFinished?.Invoke(CompletenessType.LOST);
                }
            }
        }

        private static void ChooseGameplaySettings()
        {
            GridSize size = GetGridSize();
            switch (size)
            {
                case GridSize.SMALL:

                    break;
                case GridSize.MEDIUM:

                    break;
                case GridSize.LARGE:

                    break;
                case GridSize.BIGGEST:

                    break;
            }
        }
    }
}