using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeekManager : MonoBehaviour {

	public int weekNumber; //1st, 2nd, 3rd, etc

	public float weekTotalTime;
	public float weekTimeCount;

	public float maxDelayToAddNext;
	public float delayCounter;

	public int totalRecipesToAddThisWeek;
	public int recipesAddedThisWeekCount;

	public int totalNumberOfRecipesWeek1;
	public int totalNumberOfRecipesWeek2;
	public int totalNumberOfRecipesWeek3;
	public int totalNumberOfRecipesWeek4;
	public int totalNumberOfRecipesWeek5;

	//Week difficulty arrays

	public GameObject acceptButton1;
	public GameObject acceptButton2;
	public GameObject acceptButton3;
	public GameObject acceptButton4;
	public GameObject acceptButton5;
	public GameObject acceptButton6;
	public GameObject acceptButton7;
	public GameObject acceptButton8;

	public int currentRecipeNum;

	public Text recipeText;

	public bool isThereAnActiveRecipe;
	public int whichRecipeIsActive;
	public Recipe activeRecipe;

	public GameObject recipePanel;

	public List<RecipePanel> panelList = new List<RecipePanel> ();
	public List<Recipe> recipeList = new List<Recipe>();
	private List<int> weekDifficultyList = new List<int>();

	// Use this for initialization
	void Start () {
		StartWeek ();
		weekTimeCount = weekTotalTime;

		acceptButton1 = GameObject.Find ("AcceptButton1");
		acceptButton1.SetActive (false);
		isThereAnActiveRecipe = false;
	}

	void CreateNewPanel(Recipe r){
		Transform location = GameObject.Find("PanelStartPosition").transform;
		GameObject panel = (GameObject)Instantiate(recipePanel,new Vector3(location.position.x + 1, location.position.y),location.rotation);

		//Text panelNameText = 
		panel.transform.Find ("PanelName").GetComponent<Text> ().text = r.recipeName;
		//panelNameText.text= r.recipeName;
		//RecipePanel rp = (RecipePanel) panel;

		panelList.Add (panel);
	}

	void DestroyPanel(int panelNumber){
		RecipePanel rp = panelList [panelNumber];
		Destroy(rp);
		panelList.RemoveAt(panelNumber);
	}

	// Update is called once per frame
	void Update () {

		weekTimeCount -= Time.deltaTime;

		if (weekTimeCount <= 0) {
			Debug.Log ("Week Over!");
		}

		//The delay before adding another recipe
		delayCounter -= Time.deltaTime;
		if (delayCounter <= 0 && recipesAddedThisWeekCount < totalRecipesToAddThisWeek) {

			//Get new value off weekDifficultyList
			Recipe r = AddRecipeToWeek (4);
			CreateNewPanel (r);
		}
			


		for (int i = 0; i < recipeList.Count; i++) {
			recipeList[i].currentTimer -= Time.deltaTime;

			//Reposition Panels
	
			//Timer ran out on a task
			if (recipeList [i].currentTimer <= 0) {
				recipeList [i].isFinished = true;
				recipeList [i].isSuccessful = false;

				//If this is the active recipe, remove it from activeRecipe
				if (whichRecipeIsActive == i) {

					//Clear Text
					recipeText.text = "";

					//Add failure animation
					isThereAnActiveRecipe = false;
				}

				//Disable accept button
				//Feedback that a task failed
				//After a set time Remove from List
				if (recipeList [i].currentTimer <= -4) {
					recipeList.RemoveAt(i); //WARNING: POSSIBLE ISSUES HERE
					DestroyPanel(i);
				}
			}
		}

		if (isThereAnActiveRecipe) {
			recipeText.text = "";
			foreach (var item in activeRecipe.finalRecipeList) {
				recipeText.text += item + System.Environment.NewLine;
			}
		}

		//Update changes on GUI
		OnGUI ();
	}

	void OnGUI()
	{		
		var textArea = new Rect(200,0,Screen.width, Screen.height);
		GUI.Label (textArea, "Time Left: " + weekTimeCount);

		for(int i = 0; i < recipeList.Count; i++){

			textArea = new Rect(0,i * 50,Screen.width, Screen.height);
			GUI.Label (textArea, "recipe #" + i + " time left: " + recipeList[i].currentTimer); //recipeList[i].finalRecipeList[0] + "\n" + recipeList[i].recipeDescription);

			if (!recipeList [i].isSuccessful && recipeList [i].isFinished) {
				textArea = new Rect (0, (i * 50) + 25, Screen.width, Screen.height);
				GUI.Label (textArea, "FAILED!");
			}

			//THis needs logic
			acceptButton1.SetActive (true);

		}
	}

	Recipe AddRecipeToWeek(int difficulty){
		Recipe r = new Recipe (difficulty);
		recipeList.Add(r);
		recipesAddedThisWeekCount += 1;
		delayCounter = maxDelayToAddNext;
		return r;
	}

	void StartWeek(){
		if (weekNumber == 1) {			

			recipesAddedThisWeekCount = 0;

			//Set Timers			 
			weekTotalTime = 500;
			maxDelayToAddNext = 2;

			//DelayVarianceValue?

			delayCounter = maxDelayToAddNext;

			totalRecipesToAddThisWeek = totalNumberOfRecipesWeek1;

			//Generate all recipes for this week
			//for (int i = 0; i < totalNumberOfRecipesWeek1; i++) {
				//recipeList.Add(new Recipe (4));
			//}

			//Add special story recipes

			foreach (var nextRecipe in recipeList) {


			}
				
			//TODO: Move this to Recipe Panel (activate a currentRecipe)
			//activeRecipe = recipeList [0];

			//foreach (var recipe in recipeList) {						
//				foreach (var item in activeRecipe.finalRecipeList) {
//					recipeText.text += item + System.Environment.NewLine;
//					//recipeText.text += item;
//
//				}
			//}

		}
	}

	//Remade orders

}


//			if (recipeList [i].isFinished && !recipeList [i].isSuccessful) {
//				GUI.Label (textArea, "FAILED");
//			}			 //.GetComponent<Rigidbody2D>();	
//acceptButton1.transform.position = new Vector3(-640.03f, -237.75f, 0f);

//Destroy(acceptButton1);

//Position button/sprite to accept recipe as ActiveRecipe
//acceptButton1.transform.position(); 
//acceptButton1.transform.position.y = i * 50;
//		foreach(var recipe in recipeList){
//			recipe.currentTimer -= Time.deltaTime;
//
//			//Timer ran out on a task
//			if (recipe.currentTimer <= 0) {
//				recipe.isFinished = true;
//				recipe.isSuccessful = false;
//
//				//Disable accept button
//				//Feedback that a task failed
//				//After a set time Remove from List
//				if (recipe.currentTimer <= -4) {
//
//				}
//
//			}
//
//		}