using UnityEngine;

namespace GoodJobBlast
{
	[CreateAssetMenu(fileName = "Sprites", menuName = "Scriptables/Sprites")]
	public class SpritesSC : ScriptableObject
	{
		public int firstIconNumber;
		public int secondIconNumber;
		public int thirdIconNumber;
		public int numberOfColors;
		public CubeType[] cubes;

		public Sprite GetSprite(MatchType matchType, int groupNumber)
		{
			for (int i = 0; i < numberOfColors; i++)
			{
				if (cubes[i].matchType == matchType)
				{
					return cubes[i].icon[GetIconNumber(groupNumber)];
				}
			}
			return null;
		}

		public int GetIconNumber(int groupNumber)
		{
			if (groupNumber <= firstIconNumber)
			{
				return 0;
			}
			else if (groupNumber <= secondIconNumber)
			{
				return 1;
			}
			else if (groupNumber <= thirdIconNumber)
			{
				return 2;
			}
			else if (groupNumber > thirdIconNumber)
			{
				return 3;
			}
			return 0;
		}
	}
}