using UnityEngine;

namespace GoodJobBlast
{
	public static class ItemFactory
	{
		private static GameObject _itemPrefab;

		public static Item CreateItem(Tile tile, ItemType itemType, Vector3 pos, Transform parent)
		{
			if (_itemPrefab == null)
			{
				_itemPrefab = Resources.Load("Item") as GameObject;
			}

			GameObject newGo = GameObject.Instantiate(_itemPrefab, pos, Quaternion.identity, parent);

			switch (itemType)
			{
				case ItemType.RedCube:
					return CreateCubeItem(tile, newGo, MatchType.Red);
				case ItemType.GreenCube:
					return CreateCubeItem(tile, newGo, MatchType.Green);
				case ItemType.BlueCube:
					return CreateCubeItem(tile, newGo, MatchType.Blue);
				case ItemType.YellowCube:
					return CreateCubeItem(tile, newGo, MatchType.Yellow);
				case ItemType.PurpleCube:
					return CreateCubeItem(tile, newGo, MatchType.Purple);
				case ItemType.PinkCube:
					return CreateCubeItem(tile, newGo, MatchType.Pink);
			}
			return null;
		}

		public static Item CreateRandomItem(Tile tile, Vector3 pos, Transform parent)
		{
			ItemType itemYTpe = (ItemType)UnityEngine.Random.Range(0, ScriptableContainer.Instance.spritesSC.numberOfColors);
			tile.itemType = itemYTpe;
			return CreateItem(tile, itemYTpe, pos, parent);
		}

		public static Item CreateCubeItem(Tile tile, GameObject go, MatchType matchType)
		{
			var cubeItem = go.AddComponent<CubeItem>();
			cubeItem.Init(tile, matchType);
			return cubeItem;
		}
	}
}