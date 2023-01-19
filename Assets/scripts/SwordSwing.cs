using UnityEngine;
using System.Collections;

public class SwordSwing : MonoBehaviour {

    public GameObject Sword;
    public float CDcounter;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CDcounter >= 0)
            CDcounter -= Time.deltaTime;
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Sword, transform.position, transform.rotation, transform);
            CDcounter = .8f;
        }
	
	}
}
