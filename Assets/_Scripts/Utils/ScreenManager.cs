using UnityEngine;

namespace GoodJobBlast
{
	public class ScreenManager : MonoBehaviour
	{
		[SerializeField] private Board _board;
		[SerializeField] private float _offset;

		private void Awake()
		{
			PrepareCamera();
		}

		private void PrepareCamera()
		{
			var cam = GetComponent<Camera>();
			cam.orthographicSize = (_board.GetGrid.columns + _offset) / cam.aspect / 2;
		}
	}
}