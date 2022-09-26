using UnityEngine;

public class GameConstant : MonoBehaviour
{
	public static GameConstant Instance { get; private set; }
	public float FallSpeed = 0.3f;

	private void Awake()
	{
		Instance = this;
	}
}