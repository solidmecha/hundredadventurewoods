using UnityEngine;
using System.Collections;

public class MultimemControl : MonoBehaviour {

    public bool Playing;
    int flipCount;

	// Use this for initialization
	void Start () {
        Invoke("Begin", .5f);
	}

    void Begin()
    {
        for(int i=0;i<transform.childCount;i++)
        {
         RotateIt r= transform.GetChild(i).gameObject.AddComponent<RotateIt>();
            r.Rot = new Vector3(0, 0, 360);
            r.Speed = 2;
        }

        Invoke("Shuffle", .5f);
        Invoke("Shuffle", 2f);
        Invoke("Shuffle", 3.5f);
        Invoke("Shuffle", 5f);
        Invoke("Shuffle", 6.5f);
        Invoke("SetPlay", 6.5f);
    }

    public void Reset()
    {
        flipCount = 0;
        Playing = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<multimemTile>().hasPineCone && !transform.GetChild(i).GetComponent<multimemTile>().flipped)
            {
                RotateIt r = transform.GetChild(i).gameObject.AddComponent<RotateIt>();
                r.Rot = new Vector3(0, 0, 360);
                r.Speed = 2;
            }
            else if (transform.GetChild(i).GetComponent<multimemTile>().flipped)
                transform.GetChild(i).GetComponent<multimemTile>().flipped = false;
        }
        Invoke("Begin", 1f);
    }

    public void IncFlipCount()
    {
        flipCount++;
        if(flipCount==3)
        {
            GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0]-1);
        }
    }

    public void Shuffle()
    {
        int a = 0;
        int b = 0;
        int c = 0;
        while(a==b || b==c || a==c)
        {
            a = GameControl.singleton.RNG.Next(transform.childCount);
            b = GameControl.singleton.RNG.Next(transform.childCount);
            c = GameControl.singleton.RNG.Next(transform.childCount);
        }

        if(GameControl.singleton.RNG.Next(2)==0)
        {
            TranslateIt t = transform.GetChild(a).gameObject.AddComponent<TranslateIt>();
            t.Dest = transform.GetChild(b).position;
            t.Speed = 1;
            t= transform.GetChild(b).gameObject.AddComponent<TranslateIt>();
            t.Dest= transform.GetChild(c).position;
            t.Speed = 1;
            t = transform.GetChild(c).gameObject.AddComponent<TranslateIt>();
            t.Dest = transform.GetChild(a).position;
            t.Speed = 1;

        }
        else
        {
            TranslateIt t = transform.GetChild(a).gameObject.AddComponent<TranslateIt>();
            t.Dest = transform.GetChild(b).position;
            t.Speed = 1;
            t = transform.GetChild(b).gameObject.AddComponent<TranslateIt>();
            t.Dest = transform.GetChild(a).position;
            t.Speed = 1;
        }

    }

    void SetPlay()
    {
        Playing = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
