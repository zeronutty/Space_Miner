using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorGenerator : MonoBehaviour
{
	public bool scaleUsesRange = false;
	public bool useArrayOfAsteroids = false;
	public bool useRandomRotation = true;
	public bool checkForCollider = true;

	public new HideFlags hideFlags = HideFlags.HideInHierarchy;

	public int desiredAsteroids = 100;
	public int desiredPlanets = 1;

	public float innerRadius = 100;
	public float outerRadius = 300;
	public float asteroidScaleMultiplier = 1;
	public float asteroidLowerScale = 1;
	public float asteroidUpperScale = 3;

	public float planetLowerScale = 1;
	public float planetUpperScale = 3;

	public GameObject Planet;

	public GameObject asteroid;
	public GameObject[] asteroids;

	public Transform PlanetParent;
	public Transform AsteriodParent;

	public void Start()
	{
		GenerateField();
	}

	public void GenerateField()
	{
		ClearField();

		for (int i = 0; i < desiredPlanets; i++)
		{
			CreatePlanet();
		}

		for (int i = 0; i < desiredAsteroids; i++)
		{
			CreateAsteroid();
		}
	}

	public void ClearField()
	{
		var l1 = AsteriodParent.Cast<Transform>().ToList();
		var l2 = PlanetParent.Cast<Transform>().ToList();

		foreach (Transform t1 in l2) DestroyImmediate(t1.gameObject);
		foreach (Transform t2 in l1) DestroyImmediate(t2.gameObject);
	}

	private GameObject CreatePlanet()
	{
		Vector3 newScale = GetScale(true);

		GameObject newAsteroid = Instantiate(GetAsteroidGameObject());

		newAsteroid.hideFlags = hideFlags;

		newAsteroid.transform.parent = PlanetParent;
		newAsteroid.transform.localScale = newScale;

		CheckForCollider(newAsteroid, newScale.x);

		var newPosition = FindRandomPosition(newScale.x);

		newAsteroid.transform.SetPositionAndRotation(newPosition, Quaternion.identity);

		return asteroid;
	}

	private GameObject CreateAsteroid()
	{
		Vector3 newScale = GetScale(false);

		GameObject newAsteroid = Instantiate(GetAsteroidGameObject());

		newAsteroid.hideFlags = hideFlags;

		newAsteroid.transform.parent = AsteriodParent;
		newAsteroid.transform.localScale = newScale;

		CheckForCollider(newAsteroid, newScale.x);

		var newPosition = FindRandomPosition(newScale.x);

		newAsteroid.transform.position = newPosition;

		return asteroid;
	}

	private GameObject GetAsteroidGameObject()
	{
		if (useArrayOfAsteroids)
		{
			int randomIndex = Random.Range(0, asteroids.Length);
			return asteroids[randomIndex];
		}

		else
		{
			return asteroid;
		}
	}

	private Vector3 FindRandomPosition(float boundsSize)
	{
		Vector2 newPosition = Vector2.zero;
		Vector2 position = new Vector2(transform.position.x, transform.position.y);

		for (int i = 0; i < 50; i++)
		{
			newPosition = position + (Random.insideUnitCircle * Random.Range(innerRadius, outerRadius));

			if (!Physics2D.OverlapCircle(newPosition, boundsSize / 10))
			{
				break;
			}
		}

		return newPosition;
	}

	private Quaternion GetRotation()
	{
		return useRandomRotation ? Random.rotation : Quaternion.identity;
	}

	private Vector3 GetScale(bool planet)
	{
		Vector3 newScale = Vector3.one;

		if (planet)
		{
			if (scaleUsesRange)
			{
				newScale *= Random.Range(planetLowerScale, planetUpperScale);
			}

		}
		else
		{
			if (scaleUsesRange)
			{
				newScale *= Random.Range(asteroidLowerScale, asteroidUpperScale);
			}

			else
			{
				newScale *= asteroidScaleMultiplier;
			}
		}
		newScale.z = 1;

		return newScale;
	}

	private void CheckForCollider(GameObject asteroid, float scale)
	{
		CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
		collider.radius = .1f;
	}
}
