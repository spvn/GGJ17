using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingLayer : MonoBehaviour {

	public string sortingLayer;
	public int sortingOrder;

	private Renderer renderer;

	void Start () {
		renderer = GetComponent<Renderer> ();

		renderer.sortingLayerName = sortingLayer;
		renderer.sortingOrder = sortingOrder;
	}

}
