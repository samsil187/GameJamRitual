using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]

public class AcceptButton : MonoBehaviour {

	public WeekManager weekManager;
	public int buttonNumber;

	// Use this for initialization
	void Start () {
		weekManager = FindObjectOfType<WeekManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {

		//disable button, can't click it twice in a row

		weekManager.activeRecipe = weekManager.recipeList [buttonNumber - 1];
		weekManager.isThereAnActiveRecipe = true;
		weekManager.whichRecipeIsActive = buttonNumber - 1;

		print ("Recipe Accepted!" + weekManager.recipeList [buttonNumber-1].finalRecipeList[0]);
	}

}
