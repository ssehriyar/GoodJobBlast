using UnityEngine;
using UnityEditor;

namespace GoodJobBlast
{
	[CustomEditor(typeof(Board))]
	public class BoardEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			Board board = FindObjectOfType<Board>();

			if (GUILayout.Button("Generate Grid"))
			{
				board.GenerateBoard();
			}

			if (GUILayout.Button("Clear Grid"))
			{
				board.ClearBoard();
			}
		}
	}
}