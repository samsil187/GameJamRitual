using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeekManager : MonoBehaviour {

	public int weekNumber; //1st, 2nd, 3rd, etc

	public int totalNumberOfRecipesWeek1;
	public int totalNumberOfRecipesWeek2;
	public int totalNumberOfRecipesWeek3;
	public int totalNumberOfRecipesWeek4;
	public int totalNumberOfRecipesWeek5;

	public int currentRecipeNum;

	public Text recipeText;

	public Recipe activeRecipe;

	private List<Recipe> recipeList = new List<Recipe>();

	// Use this for initialization
	void Start () {

		StartWeek ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartWeek(){
		if (weekNumber == 1) {			

			//Timer
			for (int i = 0; i < totalNumberOfRecipesWeek1; i++) {
				recipeList.Add(new Recipe (4));
			}	

			//Gameloop timer (can be randomized)

			activeRecipe = recipeList [0];

			//foreach (var recipe in recipeList) {						
				foreach (var item in activeRecipe.finalRecipeList) {
					recipeText.text += item + System.Environment.NewLine;
					//recipeText.text += item;

				}
			//}

		}

//		foreach (var recipe in recipeList) {
//			foreach (var item in recipe.finalRecipeList) {
//				Debug.Log (item);
//			}
//		}
	}

	//Remade orders

}
