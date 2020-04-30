﻿using UnityEngine;
using UnityEngine.Assertions;
using Core;
using Memory.GamePaths;
using Memory.Settings;

namespace Memory.Logic
{
    public static partial class Game
    {
        //TODO: MANAGE PUBLIC/PRIVATE ACCESS
        //TODO: ACROSS GAME CLASS
        private static Factory _factory;
        private static MonoBehaviours.Grid _grid;
        private static VisualSettings _visualSettings;
        private static GameplaySettings _gameplaySettings;

        public static void Awake(Factory factory, MonoBehaviours.Grid grid)
        {
            _factory = factory;
            _grid = grid;

            _visualSettings = Resources.Load<VisualSettings>(path: Paths.VisualSettingsPath);
            _gameplaySettings = Resources.Load<GameplaySettings>(path: Paths.GameplaySettingsPath);

            _grid.InitGrid(_gameplaySettings.GridRowsColumns);
            ;
            SetLevelDuration(_gameplaySettings.LevelDuration);
            SetCardPairsCount(_gameplaySettings.MemoryPairs);
        }

        public static void Start()
        {
            int pairCount = GetCardPairsCount();
            Assert.AreNotEqual(pairCount, -1);
            CreateCards(pairCount);
        }

        public static void Update()
        {
        }
    }
}