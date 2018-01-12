using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

namespace SceneUtility {
    public class SceneSwitcher {

        public Stopwatch Timer { private set; get; }
        public Color Color { private set; get; }
        public float FadeSpeed { private set; get; }

        private string scene;
        private GameObject fader;

        public SceneSwitcher(float fadeSpeed = 2f) {
            Timer = new Stopwatch();
            Color = Color.black;
            FadeSpeed = fadeSpeed;
            fader = null;
        }

        public SceneSwitcher(Color color, float fadeSpeed = 2f) {
            Timer = new Stopwatch();
            Color = color;
            FadeSpeed = fadeSpeed;
            fader = null;
        }

        public void Load(string scene) {
            if (fader != null) return;
            this.scene = scene;
            Timer.Start();

            fader = new GameObject("ScreenFader");
            fader.AddComponent<ScreenFader>().Init(FadeSpeed, Color, Toggle);
        }

        private void Toggle() {
            Timer.Stop();
            Timer.Reset();
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}