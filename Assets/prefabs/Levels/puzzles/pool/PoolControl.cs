using UnityEngine;
using System.Collections;

public class PoolControl : MonoBehaviour {

    int count;

    public void Sink()
    {
        count++;
        if(count==6)
        {
            GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0] - 1);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
