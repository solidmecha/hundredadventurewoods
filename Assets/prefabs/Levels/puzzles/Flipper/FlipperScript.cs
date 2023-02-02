using UnityEngine;
using System.Collections.Generic;

public class FlipperScript : MonoBehaviour {

    public bool flipped;
    public List<int[]> Flips;
    public List<int[]> FlippedFlips;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && transform.parent.GetComponent<FlipperControl>().playing)
        {
            int[] loc=new int[2] { (int)(transform.localPosition.x + 2.66f) / 3, 
                (int)(transform.localPosition.z + 4.19f) / 3 };
            if(!flipped)
                transform.parent.GetComponent<FlipperControl>().HandleFlip(Flips, loc);
            else
                transform.parent.GetComponent<FlipperControl>().HandleFlip(FlippedFlips,loc);
        }
    }

    public void Flip()
    {
        flipped = !flipped;
        transform.Rotate(new Vector3(0, 0, 180));
        if(flipped)
        {
            GetComponent<Renderer>().material = transform.parent.GetComponent<FlipperControl>().Mats[1];
        }
        else
        {
            GetComponent<Renderer>().material = transform.parent.GetComponent<FlipperControl>().Mats[0];
        }
    }

    // Use this for initialization
    void Start () {
        Flips = new List<int[]> { };
        FlippedFlips = new List<int[]> { };
        AddFlip(GameControl.singleton.RNG.Next(4));
        AddFlipFlips(GameControl.singleton.RNG.Next(4));
        if (GameControl.singleton.RNG.Next(2) == 0)
            Flip();
	}

    void AddFlip(int ID)
    {
        GameObject g = Instantiate(transform.parent.GetComponent<FlipperControl>().icon, transform.position, Quaternion.identity, transform) as GameObject;
        g.transform.localPosition = new Vector3(0, 0.5f, 0);
       switch(ID)
        {
            case 0:
                Flips.Add(new int[2] { 0, 1 });
                break;
            case 1:
                Flips.Add(new int[2] { 1, 0 });
                g.transform.Rotate(new Vector3(0, 90, 0));
                break;
            case 2:
                Flips.Add(new int[2] { 1, 1});
                g.transform.Rotate(new Vector3(0, 45, 0));
                break;
            case 3:
                Flips.Add(new int[2] { 1, -1 });
                g.transform.Rotate(new Vector3(0, -45, 0));
                break;
        }
    }

    void AddFlipFlips(int ID)
    {
        GameObject g = Instantiate(transform.parent.GetComponent<FlipperControl>().icon, transform.position, Quaternion.identity, transform) as GameObject;
        g.transform.localPosition = new Vector3(0, -0.5f, 0);
        switch (ID)
        {
            case 0:
                FlippedFlips.Add(new int[2] { 0, 1 });
                break;
            case 1:
                FlippedFlips.Add(new int[2] { 1, 0 });
                g.transform.Rotate(new Vector3(0, 90, 0));
                break;
            case 2:
                FlippedFlips.Add(new int[2] { 1, 1 });
                g.transform.Rotate(new Vector3(0, -45, 0));
                break;
            case 3:
                FlippedFlips.Add(new int[2] { 1, -1 });
                g.transform.Rotate(new Vector3(0, 45, 0));
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
