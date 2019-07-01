using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
	public static Constants instance;
	public static int STARTING_MONEY = 500;

	[HideInInspector]
	public UIManager UIManager;

	public Player Player;

	public PlayerData InitPlayerData;

	public void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Debug.LogError("Can not have two instances of the Constants class in the scene at once");

		UIManager = GetComponent<UIManager>();
	}
}
