using UnityEngine;
using System.Collections;

public class WoozScript : MonoBehaviour {

    float counter;
    public float speed;
    Vector3 target;

	// Use this for initialization
	void Start () {
        speed = 0;
	}

    void LookPlace()
    {
        if (GameControl.singleton.RNG.Next(5) == 4)
        {
            Vector3 Offset = new Vector3((float)GameControl.singleton.RNG.Next(-30, 31) / 30f, -.5f, (float)GameControl.singleton.RNG.Next(-30, 31) / 30f);
            Vector3 v = new Vector3(GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position.x, 0, GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position.z);
            transform.LookAt(v+Offset);
        }
        else
           transform.LookAt(WorldBuilder.singleton.CurrentFloor.transform.position+new Vector3((float)GameControl.singleton.RNG.Next(-2, 3), .1f, (float)GameControl.singleton.RNG.Next(-2, 3)));
        speed = GameControl.singleton.RNG.Next(9);
    }
	
	// Update is called once per frame
	void Update () {

        counter -= Time.deltaTime;
        if(counter<=0)
        {
            counter = 2;
            LookPlace();
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        
	
	}
}
