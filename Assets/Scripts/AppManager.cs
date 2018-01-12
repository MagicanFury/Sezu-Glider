using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneUtility;

public class AppManager : MonoBehaviour {

    private static AppManager instance;

    private SceneSwitcher scene;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        scene = new SceneSwitcher();
    }

    void LoadScene(string name) {
        scene.Load(name);
    }
}
