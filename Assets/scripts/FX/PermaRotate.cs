using UnityEngine;
using System.Collections;

public class PermaRotate : MonoBehaviour {

    public Vector3 Rot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Rot * Time.deltaTime);
	}
}
