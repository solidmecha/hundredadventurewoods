using UnityEngine;
using System.Collections;

public class TranslateIt : MonoBehaviour {

    public Vector3 Dest;
    public Vector3 Dir;
    public float Speed;
    public float counter;

	// Use this for initialization
	void Start () {
        Dir = Dest - transform.position;
        counter = 1f / Speed;
	
	}
	
	// Update is called once per frame
	void Update () {
        counter -= Time.deltaTime;
        transform.Translate(Dir * Speed*Time.deltaTime, Space.World);
        if(counter<=0)
        {
            transform.position = Dest;
            Destroy(this);
        }
	
	}
}
