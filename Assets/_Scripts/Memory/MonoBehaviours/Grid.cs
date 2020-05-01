using Memory.Logic;
using Memory.Structs;
using UnityEngine;

namespace Memory.MonoBehaviours
{
    public class Grid : MonoBehaviour
    {
        public Sprite _frameSprite;
        private Vector2 cellScale;

        private Vector2 cellSize;

        [SerializeField]
        private int cols;

        [SerializeField]
        private Vector2 gridOffset;

        [SerializeField]
        private Vector2 gridSize;

        [SerializeField]
        private int rows;

        private void Awake()
        {
            float targetaspect = 1.3333f;
            float windowaspect = Screen.height / (float) Screen.width;
            float scaleSize = windowaspect / targetaspect;
            gridSize *= scaleSize;
        }

        public void InitGrid(Vector2Int rowsColumns)
        {
            rows = rowsColumns.x;
            cols = rowsColumns.y;
            cellSize = _frameSprite.bounds.size;

            Vector2 newCellSize = new Vector2(x: gridSize.x / cols, y: gridSize.y / rows);

            cellScale.x = newCellSize.x / cellSize.x;
            cellScale.y = newCellSize.y / cellSize.y;

            cellSize = newCellSize;


            gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
            gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

            int index = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Vector2 pos = new Vector2(x: col * cellSize.x + gridOffset.x + transform.position.x,
                        y: row * cellSize.y + gridOffset.y + transform.position
                                                                      .y);
                    Game.RegisterMemorySlot(details: new SlotDetails(index: index, pos: pos, scale: cellScale));
                    index++;
                }
            }

            Game.OnGridInitialized();
        }
    }
}