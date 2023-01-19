using UnityEngine;
using System.Collections.Generic;

public class FlipperControl : MonoBehaviour {
    public bool playing;
    public Material[] Mats;
    public FlipperScript[][] Board;
    public GameObject icon;

	// Use this for initialization
	void Start () {
        Board = new FlipperScript[4][];
        for(int i=0;i<4;i++)
        {
            Board[i] = new FlipperScript[4];
        }
        for(int i=0;i<transform.childCount;i++)
        {
            Board[i % 4][i / 4] = transform.GetChild(i).GetComponent<FlipperScript>();
        }
	
	}

    public void CheckWin()
    {
        bool win = true;
        bool check = Board[0][0].flipped;
        foreach(FlipperScript[] fs in Board)
        {
            foreach(FlipperScript f in fs)
            {
                if (f.flipped != check)
                {
                    win = false;
                    break;
                }
            }
        }
        if(win)
            GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0] - 1);
    }

    public void HandleFlip(List<int[]> flips, int[] start)
    {
        foreach (int[] f in flips)
        {
            for (int i = 0; i < 4; i++)
            {
                int x =start[0]+ i * f[0];
                int y = start[1]+i * f[1];
                if(!(x>3 || y>3) && (x > -1 && y > -1))
                {
                    Board[x][y].Flip();
                }
               // if (i != 0)
               // {
                    x = start[0] + i * f[0] * -1;
                    y = start[1] + i * f[1] * -1;
                    if (!(x > 3 || y > 3) && x > -1 && y > -1)
                    {
                        Board[x][y].Flip();
                    }
                //}

            }
        }
        CheckWin();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
