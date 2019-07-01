using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
	[SerializeField]
	private int money;

	public Dictionary<OreType, int> OreDictionary = new Dictionary<OreType, int>();

	#region Methods
	public int GetMoney()
	{
		return money;
	}

	public bool AddMoney(int value)
	{
		if (value == 0)
			return false;

		money += value;

		return true;
	}

	public bool RemoveMoney(int value)
	{
		if (value == 0)
			return false;

		money -= value;

		return true;
	}

	public string GetMoneyString()
	{
		return "Money: " + money;
	}

	public string GetOreString(OreType type)
	{
		if(OreDictionary.TryGetValue(type, out int value))
		{
			return type.ToString() + ": " + value.ToString();
		}

		return type.ToString() + ": " + 0;
	}

	public bool RemoveOre(OreType type, int value)
	{
		if (OreDictionary.ContainsKey(type))
		{
			if (OreDictionary[type] > value)
			{
				OreDictionary[type] -= value;
				return true;
			}
			else if(OreDictionary[type] == value)
			{
				OreDictionary.Remove(type);
				return true;
			}
			else
			{
				return false;
			}
		}

		return false;
	}

	public bool AddOre(OreType type, int value)
	{
		if (value == 0)
			return false;

		if(OreDictionary.ContainsKey(type))
		{
			OreDictionary[type] += value;
		}
		else
		{
			OreDictionary.Add(type, value);
		}

		return true;
	}

	public void FromJson(string json)
	{

	}
	#endregion
}