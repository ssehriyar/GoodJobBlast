using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoodJobBlast
{
	public class Command : MonoBehaviour
	{
		private bool _isMapValid;
		private Tile[,] _map;
		private Stack<Tile> _tiles;
		[SerializeField] private int _minMatchNumber = 2;
		[SerializeField] private int _minShuffleCount = 2;
		[SerializeField] private int _maxShuffleCount = 7;
		[SerializeField] private Transform _itemParent;
		public UnityEvent<bool> OnMapFree;
		public Dictionary<ItemType, Item> dic;

		private void Start()
		{
			_tiles = new Stack<Tile>();
			dic = new Dictionary<ItemType, Item>();
			_map = TileManager.Instance.Map;
			GroupCheck();
		}

		public void GroupCheck()
		{
			ClearHasGroup();
			_isMapValid = false;
			Stack<Tile> temp;
			for (int x = 0; x < _map.GetLength(0); x++)
			{
				for (int y = 0; y < _map.GetLength(1); y++)
				{
					if (_map[x, y].item.HasGroup == false)
					{
						temp = MathcSearch(_map[x, y]);
						foreach (Tile tile in temp)
						{
							tile.item.HasGroup = true;
							tile.item.SetSprite(temp.Count);
						}
						if (temp.Count > 1)
						{
							_isMapValid = true;
						}
					}
					_tiles.Clear();
				}
			}
			if (_isMapValid == false)
			{
				Shuffle();
			}
			OnMapFree?.Invoke(true);
		}

		private void ClearHasGroup()
		{
			for (int x = 0; x < _map.GetLength(0); x++)
			{
				for (int y = 0; y < _map.GetLength(1); y++)
				{
					_map[x, y].item.HasGroup = false;
				}
			}
		}

		private void Shuffle()
		{
			dic.Clear();
			int magicNum = Random.Range(_minShuffleCount, _maxShuffleCount);
			int swapCounter = 0;
			for (int x = 0; x < _map.GetLength(0); x++)
			{
				for (int y = 0; y < _map.GetLength(1); y++)
				{
					if (swapCounter >= magicNum) return;

					if (dic.ContainsKey(_map[x, y].itemType))
					{
						swapCounter++;
						Tile tile = dic[_map[x, y].itemType].tile.GetNeigbour();
						Item temp = tile.item;
						ItemType tempType = tile.itemType;

						tile.item = _map[x, y].item;
						tile.itemType = _map[x, y].itemType;
						tile.item.SetTile(tile);
						tile.item.FallToPos(new Vector3(tile.x, tile.y));

						_map[x, y].item = temp;
						_map[x, y].itemType = tempType;
						_map[x, y].item.SetTile(_map[x, y]);
						_map[x, y].item.FallToPos(new Vector3(x, y));
					}
					else
					{
						dic.Add(_map[x, y].itemType, _map[x, y].item);
					}
				}
			}
			GroupCheck();
		}

		public void Fall()
		{
			_tiles.Clear();
			for (int x = 0; x < _map.GetLength(0); x++)
			{
				for (int y = 0; y < _map.GetLength(1); y++)
				{
					if (_map[x, y].item == null)
					{
						_map[x, y].item = ItemFactory.CreateRandomItem(_map[x, y], new Vector3(x, y + _map.GetLength(1)), _itemParent);
					}
					_map[x, y].item.HasGroup = false;
				}
			}
			GroupCheck();
		}

		public void Fill()
		{
			for (int x = 0; x < _map.GetLength(0); x++)
			{
				for (int y = 0; y < _map.GetLength(1); y++)
				{
					if (_map[x, y].item == null)
					{
						for (int i = y + 1; i < _map.GetLength(1); i++)
						{
							if (_map[x, i].item != null)
							{
								_map[x, y].item = _map[x, i].item;
								_map[x, y].itemType = _map[x, i].itemType;
								_map[x, i].item = null;
								_map[x, i].itemType = ItemType.None;
								_map[x, y].item.SetTile(_map[x, y]);
								_map[x, y].item.FallToPos(new Vector3(x, y));
								break;
							}
						}
					}
				}
			}
		}

		public ref Stack<Tile> MathcSearch(Tile tile)
		{
			_tiles.Clear();
			bool[,] visited = new bool[_map.GetLength(0), _map.GetLength(1)];
			FindMatch(tile, tile.item.matchType, visited);
			return ref _tiles;
		}

		private void FindMatch(Tile tile, MatchType matchType, bool[,] visited)
		{
			if (tile == null || visited[tile.x, tile.y]) return;

			visited[tile.x, tile.y] = true;

			if (tile.item.matchType == matchType)
			{
				for (int i = 0; i < tile.neighbourTiles.Length; i++)
				{
					FindMatch(tile.neighbourTiles[i], matchType, visited);
				}
				_tiles.Push(tile);
			}
		}

		public void DestroyMatchedTiles(ref Stack<Tile> tiles)
		{
			if (tiles.Count < _minMatchNumber) return;
			OnMapFree?.Invoke(false);
			foreach (var tile in tiles)
			{
				tile.item.Explode();
				tile.item = null;
			}
			Fill();
			Fall();
		}
	}
}