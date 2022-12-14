using UnityEngine;

namespace GoodJobBlast
{
	public class Board : MonoBehaviour
	{
		[SerializeField] private MyGrid _grid;
		[SerializeField] private Camera _cam;
		[Space(5)]
		[SerializeField] private Transform _tileParent;
		[SerializeField] private Transform _itemParent;
		[SerializeField] private Transform _borderParent;
		[SerializeField] private GameObject _tilePrefab;
		[SerializeField] private GameObject _borderPrefab;
		public MyGrid GetGrid => _grid;

		// Editor function
		public void GenerateBoard()
		{
			for (int x = 0; x < _grid.columns; x++)
			{
				for (int y = 0; y < _grid.rows; y++)
				{
					GameObject spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, _tileParent);
					spawnedTile.name = $"Tile {x} {y}";
					Tile tile = spawnedTile.GetComponent<Tile>();
					tile.itemType = ItemType.RedCube;
					tile.item = ItemFactory.CreateItem(tile, tile.itemType, new Vector3(x, y), _itemParent);
				}
			}
			_cam.transform.position = new Vector3(_grid.columns * 0.5f - 0.5f, _grid.rows * 0.5f - 0.5f, _cam.transform.position.z);

			var border = Instantiate(_borderPrefab, _borderParent);
			border.transform.position = new Vector3(_grid.columns * 0.5f - 0.5f, _grid.rows * 0.5f - 0.5f, 1);
			border.GetComponent<SpriteRenderer>().size = new Vector2(_grid.columns + 0.2f, _grid.rows + 0.5f);
		}

		// Editor function
		public void ClearBoard()
		{
			if (_tileParent.childCount != 0)
			{
				for (int i = _tileParent.childCount; i > 0; --i)
				{
					DestroyImmediate(_tileParent.GetChild(0).gameObject);
				}
			}

			if (_itemParent.childCount != 0)
			{
				for (int i = _itemParent.childCount; i > 0; --i)
				{
					DestroyImmediate(_itemParent.GetChild(0).gameObject);
				}
			}

			if (_borderParent.childCount != 0)
			{
				for (int i = _borderParent.childCount; i > 0; --i)
				{
					DestroyImmediate(_borderParent.GetChild(0).gameObject);
				}
			}
		}
	}
}