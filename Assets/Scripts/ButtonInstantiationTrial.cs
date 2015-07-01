using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;



public class ButtonInstantiationTrial : MonoBehaviour {

	//public GameObject buttonPrefab;
	//public GameObject canvas;
	public Button itemPrefab;

	public int itemCount = 10, columCount = 1;

	List<int> lista = new List<int>();

	// Use this for initialization
	void Start () {
		//canvas = GameObject.FindGameObjectWithTag("Canvas");
		lista.Add(0);
		lista.Add(1);
		lista.Add(2);
		lista.Add(3);
		lista.Add(4);
		lista.Add(5);
		lista.Add(6);
		lista.Add(7);
		lista.Add(8);
		lista.Add(9);

		RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
		RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

		//Calculate the width and height of each child item.
		float width = containerRectTransform.rect.width / columCount;
		float ratio = width / rowRectTransform.rect.width;
		float height = rowRectTransform.rect.height*ratio;
		int rowCount = itemCount/columCount;
		if(itemCount % rowCount > 0)
			rowCount++;

		float scrollHeight = height * rowCount;
		containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
		containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);

		int j = 0;

		for(int i = 0; i < itemCount; i++){
			if(i % columCount == 0)
				j++;

			Button newItem = Instantiate(itemPrefab) as Button;
			newItem.GetComponentInChildren<Text>().text = "Valinta " + i;
			newItem.name = gameObject.name + " Item at (" + i + "," + j + ")";
			newItem.transform.parent = gameObject.transform;
			int index = i;
			newItem.GetComponent<Button>().onClick.AddListener(() => {
				string vastaus = "Valinta " + lista[index] + " valittu.";
				Debug.Log(vastaus);

			});

			RectTransform rectTransform = newItem.GetComponent<RectTransform>();

			//Move and size the new item
			float x = -containerRectTransform.rect.width / 2 + width * (i % columCount);
			float y = containerRectTransform.rect.height / 2 - height * j;
			rectTransform.offsetMin = new Vector2(x, y);

			x = rectTransform.offsetMin.x + width;
			y = rectTransform.offsetMin.y + height;
			rectTransform.offsetMax = new Vector2(x,y);

		}


		/*
		GameObject instance = Instantiate(buttonPrefab) as GameObject;
		instance.transform.parent = gameObject.transform;
		*/
	}


	// Update is called once per frame
	void Update () {
	
	}




	/*
	void CreateButton(GameObject prefab){

//		instance.transform = new Vector3(0,0,0);
//		instance.transform.SetParent(canvas);


	}
	*/


	

}
