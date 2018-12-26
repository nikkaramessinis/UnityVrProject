﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (MeshFilter))]
[RequireComponent(typeof (MeshRenderer))]

public class NewBehaviourScript : MonoBehaviour {

	Color32[] cube_colors = {
		new Color32(0, 0, 0, 255),  // black
		new Color32(255,0, 0, 255),  // red
		new Color32(255, 255, 0, 255),  // yellow
		new Color32(0, 255, 0, 255),  // green
		new Color32(0, 0, 255, 255),  // blue
		new Color32(255, 0, 255, 255),  // magenta
		new Color32(255, 255, 255, 255),  // white
		new Color32(0, 255, 255, 255)   // cyan
	};

	void Start () {
		CreateCube ();
	}

	private void CreateCube () {
		Vector3[] vertices = {
			new Vector3 (0, 0, 0),
			new Vector3 (1, 0, 0),
			new Vector3 (1, 1, 0),
			new Vector3 (0, 1, 0),
			new Vector3 (0, 1, 1),
			new Vector3 (1, 1, 1),
			new Vector3 (1, 0, 1),
			new Vector3 (0, 0, 1),
		};

		int[] triangles = {
			0, 2, 1, //face front
			0, 3, 2,
			2, 3, 4, //face top
			2, 4, 5,
			1, 2, 5, //face right
			1, 5, 6,
			0, 7, 4, //face left
			0, 4, 3,
			5, 4, 7, //face back
			5, 7, 6,
			0, 6, 7, //face bottom
			0, 1, 6
		};

		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.colors32 = cube_colors;
		mesh.RecalculateNormals();
	}

}