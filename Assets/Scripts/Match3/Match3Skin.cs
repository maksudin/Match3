using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Match3
{
    public class Match3Skin : MonoBehaviour
    {
        [SerializeField] Tile[] tilePrefabs;
        [SerializeField] Match3Game game;
        Grid2D<Tile> tilesGrid;
        float2 tileOffset;

        public bool IsPlaying => true;
        public bool IsBusy => false;
        public void StartNewGame()
        {
            game.StartNewGame();
            tileOffset = -0.5f * (float2)(game.Size - 1);
            if (tilesGrid == null)
                tilesGrid = new(game.Size);
            else
            {
                for (int y = 0; y < tilesGrid.SizeY; y++)
                    for (int x = 0; x < tilesGrid.SizeX; x++)
                    {
                        tilesGrid[x, y].Despawn();
                        tilesGrid[x, y] = null;
                    }
            }

            for (int y = 0; y < tilesGrid.SizeY; y++)
                for (int x = 0; x < tilesGrid.SizeX; x++)
                    tilesGrid[x, y] = SpawnTile(game[x, y], x, y);
        }

        Tile SpawnTile(TileState t, float x, float y) =>
            tilePrefabs[(int)t - 1].Spawn(new Vector3(x + tileOffset.x, y + tileOffset.y));

        public void DoWork() { }
    }
}