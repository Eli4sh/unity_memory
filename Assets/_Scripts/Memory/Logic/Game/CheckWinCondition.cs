using UnityEngine;namespace Memory.Logic{    public static partial class Game    {        private static void CheckWinCondition()        {            if (GetMatchedPairs() == GetCardPairsCount())            {                Debug.Log(message: "GAME WON");                PrepareGameResult();                SetGameStarted(value: false);                GameFinished?.Invoke();            }        }    }}