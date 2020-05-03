using Core.Enums;
using Memory.Logic;
using Memory.Structs;
using UnityEngine;

namespace Memory.MonoBehaviours
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        private Sprite _frameSprite;

        [SerializeField]
        private PresentationType _presentationType;

        [SerializeField]
        private Vector2 gridOffset;

        [SerializeField]
        private Vector2 gridSize;

        private int _cols;
        private int _rows;
        private Vector2 _cellScale;
        private Vector2 _cellSize;

        private void Awake()
        {
            float targetaspect = 1.3333f;
            float windowaspect = Screen.height / (float) Screen.width;

            if (windowaspect > 1)
            {
                enabled = _presentationType == PresentationType.PORTRAIT;
                gameObject.SetActive(_presentationType == PresentationType.PORTRAIT);
            }
            else if (windowaspect < 1)
            {
                enabled = _presentationType == PresentationType.LANDSCAPE;
                gameObject.SetActive(_presentationType == PresentationType.LANDSCAPE);
            }

            float scaleSize = windowaspect / targetaspect;
            gridSize *= scaleSize;
        }

        public void InitGrid(Vector2Int rowsColumns)
        {
            _rows = rowsColumns.x;
            _cols = rowsColumns.y;
            _cellSize = _frameSprite.bounds.size;

            Vector2 newCellSize = new Vector2(x: gridSize.x / _cols, y: gridSize.y / _rows);

            _cellScale.x = newCellSize.x / _cellSize.x;
            _cellScale.y = newCellSize.y / _cellSize.y;

            _cellSize = newCellSize;


            gridOffset.x = -(gridSize.x / 2) + _cellSize.x / 2;
            gridOffset.y = -(gridSize.y / 2) + _cellSize.y / 2;

            int index = 0;
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    Vector2 pos = new Vector2(x: col * _cellSize.x + gridOffset.x + transform.position.x,
                        y: row * _cellSize.y + gridOffset.y + transform.position
                                                                       .y);
                    Game.RegisterMemorySlot(details: new SlotDetails(index: index, pos: pos, scale: _cellScale));
                    index++;
                }
            }

            Game.OnGridInitialized();
        }
    }
}