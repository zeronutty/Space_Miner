using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OreType
{
	Stone,
	Iron,
	Neptunium,
	Palladium,
	Gold,
	Copper,
	Tin,
	Lead,
	Zinc,
	Titanium,
	Aluminium,
	Magnesium
}

[CreateAssetMenu(menuName = "Ore Data", fileName = "New Ore Data")]
public class OreData : ScriptableObject
{
	public OreType OreType;
	public int clicksToBreak;
}
