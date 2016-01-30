using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recipe : MonoBehaviour {

	public int difficulty; // easy - 4, medium - , hard - , extreme - 

	public int timeLimit; 
	public int currentTimer;

	public int reputationReward;
	public int reputationPenalty;

	public int goldReward;

	public int moodPenalty;
	public int moodReward;

	public int recipeNumber;

	public string recipeName;
	public string recipeDescription;

	public List <string> listOfIngredients = new List<string>{	"Eye of Newt",
		"Hair of Virgin",
		"Wing of Bat"};

//		,
//		"Petal of Rose",
//		"Leg of Frog",
//		"Wyvern's Scale",
//		"Tooth of Wolf",
//		"Plume of Swan",
//		"Dragon's Heart",
//		"Unicorn's Blood", 
//		"Tears of Saint"};

	public List <string> finalRecipeList = new List<string>();

	public Recipe(int difficulty ) {

		this.difficulty = difficulty;

		RandomlyGenerateIngredients (difficulty, 0);


	}

	void Start () {
		//RandomlyGenerateIngredients (7, 0);
			
//		foreach (var item in finalRecipeList) {
//			Debug.Log (item);
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		
	void RandomlyGenerateIngredients(int numIngredientsNeeded, int numOfSpecialActions){
		
		for (int i = 0; i < numIngredientsNeeded; i++) {
			int num = Random.Range (0, 2);
			finalRecipeList.Add (listOfIngredients[num]);
		}
	}
}
