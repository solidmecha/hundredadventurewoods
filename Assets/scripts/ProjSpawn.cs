using UnityEngine;
using System.Collections;

public class ProjSpawn : MonoBehaviour {

    public float[] delay;
    public GameObject Proj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        delay[0] -= Time.deltaTime;
        if(delay[0]<=0)
        {
            delay[0] = delay[1];
            Instantiate(Proj, transform.position, transform.root.rotation);
        }
	
	}
}
