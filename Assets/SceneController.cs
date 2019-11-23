﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour { 
    public void SceneLoad(string sceneName) {   //씬 이름(문자열)을 통해 씬을 로드
        SceneManager.LoadScene(sceneName);
    }
    public void SceneLoad(int sceneNum) {   //씬 번호(숫자)를 통해 씬을 로드
        SceneManager.LoadScene(sceneNum);
    }
}
