using UnityEngine;
using System.Collections;

public class StopGoScript : MonoBehaviour {

    Vector3 PlayerPos;
    public Material[] Mats;
    float counter;
    bool looking;
    bool Failed;
    public GameObject BlueDrop;

	// Use this for initialization
	void Start () {
        transform.position = GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position;
        transform.rotation=GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.rotation;
        transform.position += transform.forward * 17;
        counter = GameControl.singleton.RNG.Next(2, 6);

    }

    private void OnDestroy()
    {
        if(!Failed)
        {
            GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0]-1);
          GameObject g=  Instantiate(BlueDrop, WorldBuilder.singleton.CurrentFloor.transform.position+Vector3.up*.3f, Quaternion.identity) as GameObject;
            g.transform.SetParent(WorldBuilder.singleton.CurrentFloor.transform);
        }
    }

    void StopLight()
    {
        RotateIt r=gameObject.AddComponent<RotateIt>();
        r.Rot = new Vector3(0, 360, 0);
        r.Speed = 2;
        Invoke("TurnRed", .5f);
    }

    void GoLight()
    {
        RotateIt r = gameObject.AddComponent<RotateIt>();
        r.Rot = new Vector3(0, 360, 0);
        r.Speed = 2;
        Invoke("TurnGreen", .5f);
    }

    void TurnRed()
    {
        transform.GetChild(0).GetComponent<Renderer>().material = Mats[0];
        looking = true;
        PlayerPos = GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position;
    }

    void TurnGreen()
    {
        transform.GetChild(0).GetComponent<Renderer>().material = Mats[1];
        looking = false;
    }

    void Caught()
    {
        Failed = true;
        gameObject.AddComponent<WoozScript>();
        Destroy(this);
    }
	
	// Update is called once per frame
	void Update () {
        counter -= Time.deltaTime;
        if(counter<=0 && !looking)
        {
            counter = GameControl.singleton.RNG.Next(2, 6);
            StopLight();
        }
        else if(counter<=0)
        {
            counter = GameControl.singleton.RNG.Next(2, 6);
            GoLight();
        }
        if(looking)
        {
            if(Vector3.SqrMagnitude(PlayerPos- GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position)>.1f)
            {
                Caught();
            }
        }

	
	}
}
