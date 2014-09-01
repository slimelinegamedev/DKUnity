﻿using UnityEngine;
using System.Collections;

public class BarrelSpawner : MonoBehaviour {

	Animator anim;
	Transform barrelPos;
	bool spawnerActive = true;

	void Start () {

		anim = gameObject.GetComponent<Animator>();
		barrelPos = gameObject.transform.FindChild("BarrelPos");
		StartCoroutine(SpawnBarrel(1.0f));
	}
	
	IEnumerator SpawnBarrel(float delay) {

		yield return new WaitForSeconds(delay);

		if (spawnerActive) {
			anim.SetTrigger("ThrowBarrel");

			StartCoroutine(SpawnBarrel(6.0f));
		}
	}

	public void ReleaseBarrel() {

		GameObject barrel = Instantiate(Resources.Load ("BarrelPrefab")) as GameObject;
		barrel.transform.parent = transform;
		barrel.transform.localPosition = barrelPos.localPosition;
		barrel.name = "Barrel";
	}

	public void Stop() {
		spawnerActive = false;
	}
}