﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class launch : MonoBehaviour {

	public string sceneName;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) ){
			SceneManager.LoadScene(sceneName);
			
		}
	}
}
