using UnityEngine;

namespace SceneUtility {
    public class ScreenFader : MonoBehaviour {

        public delegate void Callback();
        private Callback callback;

        private Texture2D fadeTexture;
        private int drawDepth = -1000;

        private float alpha = 0.0f;
        private int fadeDir = 1;
        private float fadeSpeed;
        private Color color;

        public void Init(float fadeSpeed, Color color, Callback callback) {
            this.fadeSpeed = fadeSpeed;
            this.color = color;
            this.callback = callback;
            fadeTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            fadeTexture.SetPixels(new Color[] { color });
            fadeTexture.Apply();
        }

        void Awake() {
            DontDestroyOnLoad(this);
        }

        void Update() {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);
            if (alpha == 0 && fadeDir < 0) {
                Destroy(gameObject);
            } else if (alpha == 1 && fadeDir > 0) {
                fadeDir *= -1;
                callback();
            }
        }

        void OnGUI() {
            Color c = GUI.color;
            c.a = alpha;
            GUI.color = c;

            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture, ScaleMode.StretchToFill);
        }
    }
}