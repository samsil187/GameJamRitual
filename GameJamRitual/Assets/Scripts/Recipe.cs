using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recipe : MonoBehaviour {

	public int difficulty; // easy - 4, medium - , hard - , extreme - 

	public float timeLimit; 
	public float currentTimer;

	public int reputationReward;
	public int reputationPenalty;

	public int goldReward;

	public int moodPenalty;
	public int moodReward;

	public int recipeNumber;

	public string recipeName;
	public string recipeDescription;

	public bool isFinished;
	public bool isSuccessful;

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

		//Get recipe Name
		//Get recipe Description

		recipeName = "Love potion";
		recipeDescription = "I need this to help me find that special somebody";

		//Set time limit and start the timer
		timeLimit = 3;
		currentTimer = timeLimit;

		isFinished = false;
		isSuccessful = false;
	}

	void Start () {
		//RandomlyGenerateIngredients (7, 0);
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		
	void RandomlyGenerateIngredients(int numIngredientsNeeded, int numOfSpecialActions){
		
		for (int i = 0; i < numIngredientsNeeded; i++) {
			int num = Random.Range (0, 3);
			finalRecipeList.Add (listOfIngredients[num]);
		}
	}
}
