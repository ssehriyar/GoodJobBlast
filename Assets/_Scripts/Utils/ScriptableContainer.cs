using UnityEngine;

namespace GoodJobBlast
{
	public class ScriptableContainer : MonoBehaviour
	{
		public static ScriptableContainer Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		public SpritesSC spritesSC;
		public ParticleSC particleSC;
		public ColorSC colorSC;
	}
}