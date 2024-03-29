﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManagerScript : MonoBehaviour {
	
	private GameManagerScript _gameManager;
	public int score;
	public Text scoreText;

	public virtual void Start () {
		_gameManager = GetComponent<GameManagerScript>();
	}

	public virtual bool GridHasMatch(){
		bool match = false;
		
		for(int x = 0; x < _gameManager.gridWidth; x++){
			for(int y = 0; y < _gameManager.gridHeight ; y++){
				if(x < _gameManager.gridWidth - 2){
					match = match || GridHasHorizontalMatch(x, y);
				}

				if (y < _gameManager.gridHeight - 2)
				{
					match = match || GridHasVerticalMatch(x, y);
				}
			}
		}
		
		return match;
	}

	public bool GridHasHorizontalMatch(int x, int y){
		GameObject token1 = _gameManager.gridArray[x + 0, y];
		GameObject token2 = _gameManager.gridArray[x + 1, y];
		GameObject token3 = _gameManager.gridArray[x + 2, y];
		
		if(token1 != null && token2 != null && token3 != null){
			SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer>();
			SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer>();
			SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer>();
			
			return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite);
		} else {
			return false;
		}
	}
	
	public bool GridHasVerticalMatch(int x, int y){
		GameObject token1 = _gameManager.gridArray[x, y + 0];
		GameObject token2 = _gameManager.gridArray[x, y + 1];
		GameObject token3 = _gameManager.gridArray[x, y + 2];
		
		if(token1 != null && token2 != null && token3 != null){
			SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer>();
			SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer>();
			SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer>();
			
			return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite);
		} else {
			return false;
		}
	}

	private int _GetHorizontalMatchLength(int x, int y){
		int matchLength = 1;
		
		GameObject first = _gameManager.gridArray[x, y];

		if(first != null){
			SpriteRenderer sr1 = first.GetComponent<SpriteRenderer>();
			
			for(int i = x + 1; i < _gameManager.gridWidth; i++){
				GameObject other = _gameManager.gridArray[i, y];

				if(other != null){
					SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();

					if(sr1.sprite == sr2.sprite){
						matchLength++;
					} else {
						break;
					}
				} else {
					break;
				}
			}
		}
		
		return matchLength;
	}
	
	private int _GetVerticalMatchLength(int x, int y){
		int matchLength = 1;
		
		GameObject first = _gameManager.gridArray[x, y];

		if(first != null){
			SpriteRenderer sr1 = first.GetComponent<SpriteRenderer>();
			
			for(int i = y + 1; i < _gameManager.gridHeight; i++){
				GameObject other = _gameManager.gridArray[x, i];

				if(other != null){
					SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();

					if(sr1.sprite == sr2.sprite){
						matchLength++;
					} else {
						break;
					}
				} else {
					break;
				}
			}
		}
		
		return matchLength;
	}

	public virtual int RemoveMatches(){
		int numRemoved = 0;
		List<GameObject> tokensToBeDestroyed = new List<GameObject>();
		List<Vector2> gridArrayIndex = new List<Vector2>();

		for(int x = 0; x < _gameManager.gridWidth; x++){
			for(int y = 0; y < _gameManager.gridHeight ; y++){
				if(x < _gameManager.gridWidth - 2){

					int horizonMatchLength = _GetHorizontalMatchLength(x, y);

					if(horizonMatchLength > 2){

						for(int i = x; i < x + horizonMatchLength; i++){
							GameObject token = _gameManager.gridArray[i, y]; 
							//Destroy(token);
							if (!tokensToBeDestroyed.Contains(token))
							{
								tokensToBeDestroyed.Add(token);
							}
							

							//_gameManager.gridArray[i, y] = null;
							//numRemoved++;
							Vector2 index = new Vector2(i, y);
							if (!gridArrayIndex.Contains(index))
							{
								gridArrayIndex.Add(index);
							}
						}
					}
				}

				if (y < _gameManager.gridHeight - 2)
				{
					int verticalMatchLength = _GetVerticalMatchLength(x, y);
					
					if(verticalMatchLength > 2){

						for(int i = y; i < y + verticalMatchLength; i++){
							GameObject token = _gameManager.gridArray[x, i]; 
							//Destroy(token);
							if (!tokensToBeDestroyed.Contains(token))
							{
								tokensToBeDestroyed.Add(token);
							}
							

							//_gameManager.gridArray[x, i] = null;
							//numRemoved++;
							Vector2 index = new Vector2(x, i);
							if (!gridArrayIndex.Contains(index))
							{
								gridArrayIndex.Add(index);
							}
						}
					}
				}
			}
		}

		for (int i = 0; i < tokensToBeDestroyed.Count; i++)
		{

			Destroy(tokensToBeDestroyed[i]);
			_gameManager.gridArray[(int)gridArrayIndex[i].x, (int)gridArrayIndex[i].y] = null;
			numRemoved++;
		}

		score += numRemoved;
		
		return numRemoved;
	}

	private void Update()
	{
		scoreText.text = "Score: " + score;
	}
}
