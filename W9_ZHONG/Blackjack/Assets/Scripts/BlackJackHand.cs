using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BlackJackHand : MonoBehaviour {

	public Text total;
	public float xOffset;
	public float yOffset;
	public GameObject handBase;
	public int handVals;

	protected DeckOfCards deck;
	protected List<DeckOfCards.Card> hand;
	bool stay = false;

	// Use this for initialization
	void OnEnable () {
		SetupHand();
	}

	protected virtual void SetupHand(){
		deck = GameObject.Find("Deck").GetComponent<DeckOfCards>();
		hand = new List<DeckOfCards.Card>();
		HitMe();
		HitMe();

		if (handVals == 21)
		{
			BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();
			manager.BlackJack();
			//manager.HidePlayerButtons();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void HitMe(){
		if(!stay){
			DeckOfCards.Card card = deck.DrawCard();

			GameObject cardObj = Instantiate(Resources.Load("prefab/Card")) as GameObject;

			ShowCard(card, cardObj, hand.Count);

			hand.Add(card);

			ShowValue();
		}
	}

	protected void ShowCard(DeckOfCards.Card card, GameObject cardObj, int pos){
		cardObj.name = card.ToString();

		cardObj.transform.SetParent(handBase.transform);

		List<GameObject> cardList = new List<GameObject>();

		foreach (Transform cardTransform in handBase.transform)
		{
			cardList.Add(cardTransform.gameObject);
		}
		
		cardObj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
		/*cardObj.GetComponent<RectTransform>().anchoredPosition = 
			new Vector2(
				xOffset + pos * 110, 
				yOffset);*/

		cardObj.GetComponentInChildren<Text>().text = deck.GetNumberString(card);
		cardObj.GetComponentsInChildren<Image>()[1].sprite = deck.GetSuitSprite(card);

		for (int i = 0; i < cardList.Count; i++)
		{
			float spacing = Mathf.Clamp(110, 0, 330 / Mathf.Clamp(cardList.Count - 1, 1, Mathf.Infinity));

			cardList[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(spacing * (i - (cardList.Count - 1) / 2f), yOffset);
		}
	}

	protected virtual void ShowValue(){
		handVals = GetHandValue();
			
		total.text = "You: " + handVals;

		if(handVals > 21){
			GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>().PlayerBusted();
		}
	}

	public int GetHandValue(){
		BlackJackManager manager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();

		return manager.GetHandValue(hand);
	}
}
