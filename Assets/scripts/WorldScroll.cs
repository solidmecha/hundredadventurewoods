using UnityEngine;
using System.Collections;

public class WorldScroll : MonoBehaviour {
    public Vector3 dir;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameControl.singleton.screenWrap(dir);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
