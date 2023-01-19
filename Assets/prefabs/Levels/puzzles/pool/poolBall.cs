using UnityEngine;
using System.Collections;

public class poolBall : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if(collision.collider.CompareTag("goal"))
        {
            transform.parent.GetComponent<PoolControl>().Sink();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
