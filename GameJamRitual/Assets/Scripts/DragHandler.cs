﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class DragHandler : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	//private Vector3 startPosition;
	public PotContents potContents;

	void OnMouseDown() {
		
		//startPosition =	gameObject.transform.position;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag()
	{
		Debug.Log (Random.Range (0, 10));
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

		
	public void OnMouseUp(){
		Ingredient ingredient = GetComponent<Ingredient> ();

		if (ingredient.isInPot == true) {
			potContents.AddToPot (ingredient);
			Debug.Log(GetComponent<Ingredient> ().ingredientName + System.Environment.NewLine);
		}

		transform.position = GetComponent<Ingredient> ().startPosition;
	}
}