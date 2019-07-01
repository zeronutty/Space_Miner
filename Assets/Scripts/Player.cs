using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	bool isFirstTime = true;

	public PlayerData playerData;

	#region Events

	public event EventHandler OnInventoryChanged;

	#endregion

	public void Awake()
	{
		if(isFirstTime)
		{
			isFirstTime = false;

			playerData = new PlayerData();
			playerData.Setup();
			playerData.Inventory.AddMoney(Constants.STARTING_MONEY);
			OnInventoryChanged?.Invoke(this, new EventArgs());
		}
	}

	public void AddOreItem(OreType type, int amount)
	{
		if(playerData.Inventory.AddOre(type, amount))
		{
			OnInventoryChanged?.Invoke(this, new EventArgs());
		}
	}

	public void AddMoney(int amount)
	{
		if (playerData.Inventory.AddMoney(amount))
		{
			OnInventoryChanged?.Invoke(this, new EventArgs());
		}
	}

	public void RemoveOreItem(OreType type, int amount)
	{
		if (playerData.Inventory.RemoveOre(type, amount))
		{
			OnInventoryChanged?.Invoke(this, new EventArgs());
		}
	}

	public void RemoveMoney(int amount)
	{
		if (playerData.Inventory.RemoveMoney(amount))
		{
			OnInventoryChanged?.Invoke(this, new EventArgs());
		}
	}

	public Inventory GetInventory()
	{
		return playerData.Inventory;
	}
}
