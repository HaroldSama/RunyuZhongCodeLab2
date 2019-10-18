using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RandomGridScript : GridScript
{

	public static readonly float rockPercentage = 0.2f; 		// 20% chance of rocks
	public static readonly float forestPercentage = 0.05f;		// 5% chance of forest
	public static readonly float waterPercentage = 0.1f;		// 10% chance of water

	string[] gridString;

	private void Awake()
	{
		gridString = new string[gridHeight];
		// Make the grid be generated into gridString at random w/ the above percentages.
		for (int i = 0; i < gridHeight; i++)
		{
			gridString[i] = RandomizeLine(gridWidth);
		}

		start.x = Random.Range(0, gridWidth);
		start.y = Random.Range(0, gridHeight);
		goal.x = Random.Range(0, gridWidth);
		goal.y = Random.Range(0, gridHeight);
	}
	
	String RandomizeLine(int length)
	{
		string line = "";

		for (int i = 0; i < length; i++)
		{
			int randomNumber = Random.Range(0, 100);

			if (randomNumber < 20)
			{
				line += 'd';
			}
			else if (randomNumber >= 20 && randomNumber < 25)
			{
				line += 'w';
			}
			else if (randomNumber >= 25 && randomNumber < 35)
			{
				line += 'r';
			}
			else
			{
				line += '-';
			}
		}

		print(line);
		return line;
	}

	protected override Material GetMaterial(int x, int y){

		var c = gridString[y].ToCharArray()[x];

		Material mat;

		switch(c){
			case 'd': 
				mat = mats[1];
				break;
			case 'w': 
				mat = mats[2];
				break;
			case 'r': 
				mat = mats[3];
				break;
			default: 
				mat = mats[0];
				break;
		}
	
		return mat;
	}
}
