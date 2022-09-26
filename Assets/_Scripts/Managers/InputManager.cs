using UnityEngine;

namespace GoodJobBlast
{
	public class InputManager : MonoBehaviour
	{
		private void Start()
		{
			GameManager.Instance.OnGameStateChanged += OnGameStateChange;
		}

		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
				if (hit)
				{
					hit.transform.GetComponent<Tile>().item.Execute();
				}
			}
		}

		public void SetActivity(bool b)
		{
			enabled = b;
		}

		private void OnGameStateChange(GameState gameState)
		{
			if (gameState != GameState.Play)
			{
				enabled = false;
			}
			else
			{
				enabled = true;
			}
		}

		private void OnDestroy()
		{
			GameManager.Instance.OnGameStateChanged -= OnGameStateChange;
		}
	}
}