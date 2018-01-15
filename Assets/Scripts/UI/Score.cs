using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score Instance { get; set; }

    [SerializeField]
    private Text label;
    private float score = 0;
    private float lerp = 0;

    void Awake() {
        Instance = this;
    }

    public bool DoneLerping {
        get {
            return lerp == score;
        }
    }

    public void IncrementScore(int amount = 10) {
        bool doneLerping = DoneLerping;
        score += amount;
        if (doneLerping) {
            StartCoroutine(LerpScore());
        }
    }
    
    IEnumerator LerpScore() {
        if (!DoneLerping) {
            lerp = Mathf.Min(lerp + Time.deltaTime * 100f, score);
            label.text = lerp.ToString("0");
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(LerpScore());
        }
    }
}
