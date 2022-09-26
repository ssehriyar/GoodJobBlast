using System;
using UnityEngine;

[Serializable]
public struct MyGrid
{
	[Range(2, 10)]
	public int rows;
	[Range(2, 10)]
	public int columns;
}