using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Inventory inventory;

	public Text MoneyText;
	public Text StoneText;
	public Text IronText;
	public Text Neptunium;
	public Text Palladium;
	public Text Gold;
	public Text Copper;
	public Text Tin;
	public Text Lead;
	public Text Zinc;
	public Text Titanium;
	public Text Aluminium;
	public Text Magnesium;

	public void Start()
	{
		Constants.instance.Player.OnInventoryChanged += OnUpdate;
		OnUpdate(this, null);
	}

	public void OnUpdate(object sender, System.EventArgs e)
	{
		inventory = Constants.instance.Player.GetInventory();
		UpdateUI();
	}

	public void UpdateUI()
	{
		MoneyText.text = inventory.GetMoneyString();
		StoneText.text = inventory.GetOreString(OreType.Stone);
		IronText.text = inventory.GetOreString(OreType.Iron);
		Neptunium.text = inventory.GetOreString(OreType.Neptunium);
		Palladium.text = inventory.GetOreString(OreType.Palladium);
		Gold.text = inventory.GetOreString(OreType.Gold);
		Copper.text = inventory.GetOreString(OreType.Copper);
		Tin.text = inventory.GetOreString(OreType.Tin);
		Lead.text = inventory.GetOreString(OreType.Lead);
		Zinc.text = inventory.GetOreString(OreType.Zinc);
		Titanium.text = inventory.GetOreString(OreType.Titanium);
		Aluminium.text = inventory.GetOreString(OreType.Aluminium);
		Magnesium.text = inventory.GetOreString(OreType.Magnesium);
	}
}
