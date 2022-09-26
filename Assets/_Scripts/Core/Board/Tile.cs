using UnityEngine;

namespace GoodJobBlast
{
	public class Tile : MonoBehaviour
	{
		public int x;
		public int y;
		public Tile[] neighbourTiles;
		public ItemType itemType;
		public Item item;

		public void Init(Tile[] neigbours, int x, int y)
		{
			this.x = x;
			this.y = y;
			neighbourTiles = neigbours;
		}

		public bool HasItem => item != null;
		public Tile GetNeigbour()
		{
			for (int i = 0; i < neighbourTiles.Length; i++)
			{
				if (neighbourTiles[i] != null)
				{
					return neighbourTiles[i];
				}
			}
			return null;
		}

		// Editor function
		public void ApplyItemType()
		{
			Item temp;
			switch (itemType)
			{
				case ItemType.RedCube:
					temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Red);
					DestroyImmediate(item);
					item = temp;
					break;
				case ItemType.GreenCube:
					temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Green);
					DestroyImmediate(item);
					item = temp;
					break;
				case ItemType.BlueCube:
					temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Blue);
					DestroyImmediate(item);
					item = temp;
					break;
				case ItemType.YellowCube:
					temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Yellow);
					DestroyImmediate(item);
					item = temp;
					break;
				case ItemType.PurpleCube:
					temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Purple);
					DestroyImmediate(item);
					item = temp;
					break;
				case ItemType.PinkCube:
					temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Pink);
					DestroyImmediate(item);
					item = temp;
					break;
			}
		}
	}
}