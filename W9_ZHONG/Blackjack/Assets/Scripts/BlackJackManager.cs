using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BlackJackManager : MonoBehaviour {

	public Text statusText;
	public GameObject tryAgain;
	public string loadScene;
	public GameObject playerHand;
	public GameObject dealerHand;
	public Text playerHandText;
	public Text dealerHandText;
	public GameObject hitButton;
	public GameObject stayButton;
	public GameObject cheatBoard;
	public Skills skills;
	

	public void PlayerBusted(){
		HidePlayerButtons();
		GameOverText("YOU BUST", Color.red);
		BetManager.Instance.WinMoney(false);
	}

	public void DealerBusted(){
		GameOverText("DEALER BUSTS!", Color.green);
		BetManager.Instance.WinMoney();
	}
		
	public void PlayerWin(){
		GameOverText("YOU WIN!", Color.green);
		BetManager.Instance.WinMoney();
	}
		
	public void PlayerLose(){
		GameOverText("YOU LOSE.", Color.red);
		BetManager.Instance.WinMoney(false);
	}


	public void BlackJack(){
		GameOverText("Black Jack!", Color.green);
		HidePlayerButtons();
		BetManager.Instance.WinMoney();
	}

	public void GameOverText(string str, Color color){
		statusText.text = str;
		statusText.color = color;

		tryAgain.SetActive(true);
	}

	public void HidePlayerButtons(){
		hitButton.SetActive(false);
		stayButton.SetActive(false);
		cheatBoard.SetActive(false);
	}

	public void TryAgain()
	{
		statusText.text = "";
		playerHandText.text = "You:";
		dealerHandText.text = "Dealer:";
		
		tryAgain.SetActive(false);
		foreach (Transform card in playerHand.transform)
		{
			Destroy(card.gameObject);
		}

		foreach (Transform card in dealerHand.transform)
		{
			Destroy(card.gameObject);
		}

		playerHand.GetComponent<BlackJackHand>().handVals = 0;
		dealerHand.GetComponent<DealerHand>().handVals = 0;
		dealerHand.GetComponent<DealerHand>().reveal = false;
		
		BetManager.Instance.ResetGameState(true);

		skills.mP = Mathf.Clamp(skills.mP + 1, 0, 10);
	}

	public virtual int GetHandValue(List<DeckOfCards.Card> hand){
		int handValue = 0;
		int timesAcesCountAs11 = 0;

		foreach(DeckOfCards.Card handCard in hand){
			
			handValue += handCard.GetCardHighValue();
			
			if (handCard.cardNum == DeckOfCards.Card.Type.A)
			{
				timesAcesCountAs11++;
			}

			while (handValue > 21 && timesAcesCountAs11 > 0)
			{
				handValue -= 10;
				timesAcesCountAs11 -= 1;
			}
		}
		return handValue;
	}
}
