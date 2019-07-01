using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
	public Inventory Inventory;

	public void Setup()
	{
		Inventory = new Inventory();
	}
}
