using UnityEngine;
using DG.Tweening;

namespace GoodJobBlast
{
	public abstract class Item : MonoBehaviour
	{
		public Tile tile;
		public MatchType matchType;
		public bool HasGroup;
		public Command command;
		public SpriteRenderer spriteRenderer;
		public ScriptableContainer scriptableContainer;
		protected Tweener tweener;
		protected float fallSpeed;

		public virtual void Init(Tile tile, MatchType matchType)
		{
			this.tile = tile;
			this.matchType = matchType;
			command = FindObjectOfType<Command>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			scriptableContainer = FindObjectOfType<ScriptableContainer>();
			tweener = null;
			if (Application.isPlaying)
			{
				fallSpeed = GameConstant.Instance.FallSpeed;
			}
			SetSprite(default);
			SetTile(tile);
			FallToPos(new Vector3(tile.x, tile.y));
		}

		protected virtual void Start()
		{
			fallSpeed = GameConstant.Instance.FallSpeed;
		}

		public abstract void SetSprite(int groupNumber);
		public abstract void Execute();
		public abstract bool CanFall();
		public abstract void Explode();
		public abstract void FallToPos(Vector3 pos);
		public abstract void SetTile(Tile tile);

	}
}