using UnityEngine;
using System.Collections;

public class CueScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().AddForce((transform.position-GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position)*12f, ForceMode.Impulse);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
