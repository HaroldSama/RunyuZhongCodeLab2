﻿using System;
using UnityEngine;
using System.Collections;

public class InputManagerScript : MonoBehaviour {
	private GameManagerScript _gameManager;
	private MoveTokensScript _moveManager;
	private GameObject _selected = null;
	public GameObject indicator;

	public virtual void Start () {
		_moveManager = GetComponent<MoveTokensScript>();
		_gameManager = GetComponent<GameManagerScript>();
	}

	public virtual void SelectToken(){
		if (Input.GetMouseButtonDown(0)){
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			Collider2D collider = Physics2D.OverlapPoint(mousePos);

			if(collider != null){
				if(_selected == null){
					_selected = collider.gameObject;
					indicator.transform.position = _selected.transform.position;
					indicator.SetActive(true);
				} else {
					indicator.SetActive(false);
					Vector2 pos1 = _gameManager.GetPositionOfTokenInGrid(_selected);
					Vector2 pos2 = _gameManager.GetPositionOfTokenInGrid(collider.gameObject);

					if((int)Mathf.Abs(pos1.x - pos2.x) + (int)Math.Abs(pos1.y - pos2.y) == 1){
						_moveManager.SetupTokenExchange(_selected, pos1, collider.gameObject, pos2, true);
					}

					_selected = null;
				}
			}
		}

	}

	public int CommentFunc(int x, int y){
		return x - y;
	}
}
