using UnityEngine;
using System.Collections;

public class PuzzraphControl : MonoBehaviour {

    public GameObject PuzzNode;
    public Material[] Mats;
    public GameObject Selected;
    public bool playing;
	// Use this for initialization
	void Start () {
        for(int i=0;i<3;i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Instantiate(PuzzNode, transform.position +new Vector3(-6,.6f,-6)+new Vector3(i*6,0,j*12)+new Vector3(GameControl.singleton.RNG.Next(-2,3),0, GameControl.singleton.RNG.Next(-2, 3))
                    , Quaternion.identity, transform);
            }
        }

        for(int i=0;i<transform.childCount;i++)
        {
            int a = GameControl.singleton.RNG.Next(transform.childCount);
            while(a==i)
                a = GameControl.singleton.RNG.Next(transform.childCount);
            transform.GetChild(i).GetChild(0).transform.LookAt(transform.GetChild(a));
            transform.GetChild(i).GetChild(0).transform.localScale = new Vector3(1f, 1f, Vector3.Magnitude(transform.GetChild(i).position - transform.GetChild(a).position));
            int b = GameControl.singleton.RNG.Next(transform.childCount);
            while (b == i || b==a)
                b = GameControl.singleton.RNG.Next(transform.childCount);
            transform.GetChild(i).GetChild(1).transform.LookAt(transform.GetChild(b));
            transform.GetChild(i).GetChild(1).transform.localScale = new Vector3(1f, 1f, Vector3.Magnitude(transform.GetChild(i).position - transform.GetChild(b).position));

        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 v = transform.GetChild(i).position;
            int a = GameControl.singleton.RNG.Next(transform.childCount);
            while (a == i)
                a = GameControl.singleton.RNG.Next(transform.childCount);
            transform.GetChild(i).position = transform.GetChild(a).position;
            transform.GetChild(a).position = v;
            a = GameControl.singleton.RNG.Next(4);
            transform.GetChild(i).Rotate(new Vector3(0, a * 90, 0));
        }
        Invoke("StartPlay", .1f);

    }

    public void StartPlay()
    {
        playing = true;
    }

public void CheckSolve()
    {
        bool win = true;
        foreach(PuzzraphEdge p in GetComponentsInChildren<PuzzraphEdge>())
        {
            if (!p.Solved)
            {
                win = false;
                break;
            }
        }
        if (win)
        {
            GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0] - 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
