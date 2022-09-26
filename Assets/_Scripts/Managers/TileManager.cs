using UnityEngine;
using DG.Tweening;

namespace GoodJobBlast
{
	public class TileManager : MonoBehaviour
	{
		public static TileManager Instance { get; private set; }
		[SerializeField] private Board board;
		[SerializeField] private Transform _tileParent;

		public Tile[,] Map { get; private set; }

		private void Awake()
		{
			Instance = this;
			GetBoardInfo();
			InitTiles();
			DOTween.SetTweensCapacity(500, 100);
		}

		private void GetBoardInfo()
		{
			Map = new Tile[board.GetGrid.columns, board.GetGrid.rows];
			int counter = 0;
			for (int x = 0; x < board.GetGrid.columns; x++)
			{
				for (int y = 0; y < board.GetGrid.rows; y++)
				{
					Tile tile = _tileParent.GetChild(counter).GetComponent<Tile>();
					Map[x, y] = tile;
					counter++;
				}
			}
		}

		private void InitTiles()
		{
			for (int x = 0; x < board.GetGrid.columns; x++)
			{
				for (int y = 0; y < board.GetGrid.rows; y++)
				{
					Map[x, y].Init(TileNeighbours(x, y), x, y);
				}
			}
		}

		public Tile[] TileNeighbours(int x, int y)
		{
			Tile[] neig = new Tile[4];
			neig[(int)Direction.Left] = GetNeighbourWithDirection(x, y, Direction.Left);
			neig[(int)Direction.Up] = GetNeighbourWithDirection(x, y, Direction.Up);
			neig[(int)Direction.Right] = GetNeighbourWithDirection(x, y, Direction.Right);
			neig[(int)Direction.Down] = GetNeighbourWithDirection(x, y, Direction.Down);
			return neig;
		}

		public Tile GetNeighbourWithDirection(int x, int y, Direction direction)
		{
			switch (direction)
			{
				case Direction.Left:
					x -= 1;
					break;
				case Direction.Up:
					y += 1;
					break;
				case Direction.Right:
					x += 1;
					break;
				case Direction.Down:
					y -= 1;
					break;
			}

			if (x >= Map.GetLength(0) || x < 0 || y >= Map.GetLength(1) || y < 0) return null;

			return Map[x, y];
		}
	}
}