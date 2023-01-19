using UnityEngine;
using System.Collections;

public class FloatBall : MonoBehaviour {
    Rigidbody R;
    public GameObject Goal;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            R.AddForce(Vector3.up*9+ GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.forward/2f, ForceMode.Impulse);
        }
        else if(collision.collider.CompareTag("goal"))
        {
            GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0] - 1);
        }
    }

    // Use this for initialization
    void Start () {
        R = GetComponent<Rigidbody>();
        R.AddForce(Vector3.up * 9 + (GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position - transform.position).normalized*3
            , ForceMode.Impulse);
       GameObject g= Instantiate(Goal, WorldBuilder.singleton.CurrentFloor.transform) as GameObject;
        g.transform.localPosition = Vector3.zero;
        g.transform.GetChild(0).localPosition = new Vector3(GameControl.singleton.RNG.Next(-12, 13), 0, GameControl.singleton.RNG.Next(-12, 13));
    }
	
	// Update is called once per frame
	void Update () {
        if (R.velocity.y < -3)
            R.velocity = new Vector3(R.velocity.x, -2f, R.velocity.z);

    }
}
