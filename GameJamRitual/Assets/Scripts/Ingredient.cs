using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {

	public string ingredientName;

	public Vector3 startPosition;
	public DragHandler dragHandler;

	public bool isInPot = false;

	// Use this for initialization
	void Start () {
		startPosition =	gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D coll){
		//Debug.Log ("Entered");
		isInPot = true;	
	}


	void OnTriggerExit2D(Collider2D coll){
		//Debug.Log ("Exitted");
		isInPot = false;	
	}
}
