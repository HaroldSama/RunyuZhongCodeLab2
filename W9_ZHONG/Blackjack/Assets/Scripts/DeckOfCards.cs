﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DeckOfCards : MonoBehaviour {
	
	public Text cardNumUI;
	public Image cardImageUI;
	public Sprite[] cardSuits;
	public TextMeshProUGUI cardsInDeck;
	public Card nextCard;
	public GameObject nextCardObj;

	public class Card{

		public enum Suit {
			SPADES, 	//0
			CLUBS,		//1
			DIAMONDS,	//2
			HEARTS	 	//3
		};

		public enum Type {
			TWO		= 2,
			THREE	= 3,
			FOUR	= 4,
			FIVE	= 5,
			SIX		= 6,
			SEVEN	= 7,
			EIGHT	= 8,
			NINE	= 9,
			TEN		= 10,
			J		= 11,
			Q		= 12,
			K		= 13,
			A		= 14
		};

		public Type cardNum;
		
		public Suit suit;

		public Card(Type cardNum, Suit suit){
			this.cardNum = cardNum;
			this.suit = suit;
		}

		public override string ToString(){
			return "The " + cardNum + " of " + suit;
		}

		public int GetCardHighValue(){
			int val;

			switch(cardNum){
			case Type.A:
				val = 11;
				break;
			case Type.K:
			case Type.Q:
			case Type.J:
				val = 10;
				break;	
			default:
				val = (int)cardNum;
				break;
			}

			return val;
		}
	}

	public static ShuffleBag<Card> deck;

	// Use this for initialization
	void Awake () {

		if(!IsValidDeck()){
			deck = new ShuffleBag<Card>();

			AddCardsToDeck();
		}

		//Debug.Log("Cards in Deck: " + (deck.cursor + 1));
		cardsInDeck.text = ((deck.cursor + 1) % deck.Count + 1).ToString();
	}

	protected virtual bool IsValidDeck(){
		return deck != null; 
	}

	protected virtual void AddCardsToDeck(){
		foreach (Card.Suit suit in Card.Suit.GetValues(typeof(Card.Suit))){
			foreach (Card.Type type in Card.Type.GetValues(typeof(Card.Type))){
				deck.Add(new Card(type, suit));
			}
		}

        SetNextCard();
	}

	void SetNextCard()
	{
		nextCard = deck.Next();
		nextCardObj.GetComponentInChildren<Text>().text = GetNumberString(nextCard);
		nextCardObj.GetComponentsInChildren<Image>()[1].sprite = GetSuitSprite(nextCard);
		//print("Next: " + nextCard.suit + " " + nextCard.cardNum);		
	}

	public virtual Card DrawCard(bool justPeek = false){
		//Card nextCard = deck.Next();

		Card toReturn = nextCard;
		

		if (!justPeek)
		{
			SetNextCard();
		}

		//deck.Remove(nextCard);
		
		//Debug.Log("Cards in Deck: " + (deck.cursor + 1));
		
		cardsInDeck.text = ((deck.cursor + 1) % deck.Count + 1).ToString();
		return toReturn;
	}

	/*public virtual Card PeekNextCard()
	{
		Card nextCard = deck.Next();

		return nextCard;
	}*/


	public string GetNumberString(Card card){
		if(card.cardNum.GetHashCode() <= 10){
			return card.cardNum.GetHashCode() + "";
		} else {
			return card.cardNum + "";
		}
	}
		
	public Sprite GetSuitSprite(Card card){
		return cardSuits[card.suit.GetHashCode()];
	}
}
