using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Memory.Structs;

namespace Memory.MonoBehaviours
{
    public class Grid : MonoBehaviour
    {
        //grid specifics
        [SerializeField]
        private int rows;

        [SerializeField]
        private int cols;

        [SerializeField]
        private Vector2 gridSize;

        [SerializeField]
        private Vector2 gridOffset;

        private Vector2 cellSize;
        private Vector2 cellScale;
        public Sprite _frameSprite;

        [SerializeField]
        private GameObject _slotPrefab;

        [SerializeField]
        private Dictionary<GameObject, bool> _slotOccupiedDictionary = new Dictionary<GameObject, bool>();

        void Awake()
        {
            float targetaspect = 1.3333f;
            float windowaspect = (float) Screen.height / (float) Screen.width;
            float scaleSize = windowaspect / targetaspect;
            gridSize *= scaleSize;
        }

        public void InitGrid(Vector2Int rowsColumns)
        {
            rows = rowsColumns.x;
            cols = rowsColumns.y;
            cellSize = _frameSprite.bounds.size;

            Vector2 newCellSize = new Vector2(gridSize.x / (float) cols, gridSize.y / (float) rows);

            cellScale.x = newCellSize.x / cellSize.x;
            cellScale.y = newCellSize.y / cellSize.y;

            cellSize = newCellSize;


            gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
            gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x + transform.position.x,
                        row * cellSize.y + gridOffset.y + transform.position
                                                                   .y);

                    GameObject tempSlot = Instantiate((_slotPrefab), pos, Quaternion.identity);
                    tempSlot.transform.localScale = new Vector2(cellScale.x, cellScale.y);
                    tempSlot.transform.parent = transform;
                    _slotOccupiedDictionary.Add(tempSlot, false);
                }
            }
        }

        public SlotDetails GetSlotDetails()
        {
            var freeSlot = _slotOccupiedDictionary.First((kvp) => kvp.Value == false).Key;
            _slotOccupiedDictionary[freeSlot] = true;
            return new SlotDetails(freeSlot.transform.position, freeSlot.transform.localScale);
        }
    }
}