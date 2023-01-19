using UnityEngine;
using System.Collections;

public class heffalumpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int a = 1;
        int b = GameControl.singleton.RNG.Next(1, 3);
        if (GameControl.singleton.RNG.Next(2) == 1)
            a = -1;
        GetComponent<PermaRotate>().Rot = new Vector3(0, b * 30 * a, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
