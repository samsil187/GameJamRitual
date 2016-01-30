using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider2D))]

public class DeliverVial : MonoBehaviour {

	public PotContents potContents;
	public WeekManager weekManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {

		print ("Recipe Delivered!");
		CompareRecipeToPot ();

	}


	bool CompareRecipeToPot(){

		//bool match = true;

		if (potContents.potIngredients.Count != weekManager.activeRecipe.finalRecipeList.Count) {
			Debug.Log ("WRONG SIZE!");
			return false;
		}

		for (int i = 0; i < potContents.potIngredients.Count; i++) {

			Debug.Log (potContents.potIngredients [i].ingredientName + "  " + weekManager.activeRecipe.finalRecipeList [i]);
			if (potContents.potIngredients [i].ingredientName != weekManager.activeRecipe.finalRecipeList [i]) {
				Debug.Log ("U SUX!");
				//return false;	

			}

		}
		Debug.Log ("MATCHED ITS A MIRACLE!");
		return true;
		//potContents.potIngredients;
		//weekManager.activeRecipe;
	}

}
