using UnityEngine;
using DG.Tweening;

namespace GoodJobBlast
{
	public class CubeItem : Item
	{
		public override void SetSprite(int groupNumber = 0)
		{
			spriteRenderer.sprite = scriptableContainer.spritesSC.GetSprite(matchType, groupNumber);
		}

		public override void Execute()
		{
			command.DestroyMatchedTiles(ref command.MathcSearch(tile));
		}

		public override bool CanFall()
		{
			return true;
		}

		public override void Explode()
		{
			CreateParticle();
			DestroyObject();
		}

		public override void FallToPos(Vector3 pos)
		{
			tweener = transform.DOMove(pos, fallSpeed);
		}

		public void CreateParticle()
		{
			Particle p = Instantiate(scriptableContainer.particleSC.particle, transform.position, Quaternion.identity).GetComponent<Particle>();
			p.SetParticleColor(scriptableContainer.colorSC.GetColorByMatchType(matchType));
		}

		public override void SetTile(Tile tile)
		{
			this.tile = tile;
			spriteRenderer.sortingOrder = tile.y;
		}

		public void DestroyObject()
		{
			if (tweener.IsActive())
			{
				tweener.Kill(true);
			}
			Destroy(gameObject);
		}
	}
}