using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScreen : MonoBehaviour {

    IEnumerator Start() {
        yield return new WaitForSeconds(1f);
    }
}
