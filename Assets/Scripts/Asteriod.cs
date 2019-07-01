using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
	private int CurrentClickes;

	public OreData oreData;

	public void OnMouseDown()
	{
		Debug.Log("FDGDA");

		CurrentClickes++;

		if (CurrentClickes >= oreData.clicksToBreak)
		{
			Constants.instance.Player.AddOreItem(oreData.OreType, 1);
			CurrentClickes = 0;
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(transform.position, transform.localScale.x / 10);
	}
}
