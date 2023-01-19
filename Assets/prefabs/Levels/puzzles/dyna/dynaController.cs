using UnityEngine;
using System.Collections.Generic;

public class dynaController : MonoBehaviour {

    public Sprite[] NumSprites;
    public int CurrentVal;
    public int CheckedVal;
    public Vector3 LastBlockPos;
    public bool Playing;

	// Use this for initialization
	void Start () {

        List<int> n = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        for(int i=0;i<9;i++)
        {
            int r = GameControl.singleton.RNG.Next(n.Count);
            transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = NumSprites[n[r]];
            transform.GetChild(i).GetComponent<ValHolder>().Val = n[r] + 1;
            n.RemoveAt(r);
        }
	
	}

    public void CheckNum()
    {
        if (CurrentVal == CheckedVal)
        {
            CurrentVal++;
            Playing = true;
            if(CurrentVal==10)
                GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0] - 1);
        }
        else
            ResetBoard();
    }

    public void ResetBoard()
    {
        CurrentVal = 0;
        CheckedVal = 0;
        for(int i=0;i<9;i++)
        {
           if(transform.GetChild(i).GetComponent<dynaHelper>().Flipped)
            {
                transform.GetChild(i).GetComponent<dynaHelper>().flip();
            }
        }
        int s = GameControl.singleton.RNG.Next(4);
        if (s == 0)
            Shuffle(s, new Vector3(-3, 0f, LastBlockPos.z));
        else if (s == 1)
            Shuffle(s, new Vector3(3, 0f, LastBlockPos.z));
        else if (s == 2)
            Shuffle(s, new Vector3(LastBlockPos.x, 0f, 3));
        else if (s == 3)
            Shuffle(s, new Vector3(LastBlockPos.x, 0f, -3));

        Invoke("CheckNum", .5f);
    }

    public void MoveCube(Vector3 Pos, Vector3 dir)
    {
        GameObject g=null;
        for(int i=0;i<9;i++)
        {
            if(Vector3.SqrMagnitude(transform.GetChild(i).localPosition-Pos)<.1f)
            {
                g = transform.GetChild(i).gameObject;
                break;
            }
        }
        TranslateIt t = g.AddComponent<TranslateIt>();
        t.Dest = transform.parent.position+Pos + dir * 3+new Vector3(0,.6f,0);
        t.Speed = 2;
    }

    public void Shuffle(int ShuffleType, Vector3 StartPos)
    {
        switch(ShuffleType)
        {
            case 0:
                MoveCube(StartPos, Vector3.right);
                MoveCube(StartPos+Vector3.right*3, Vector3.right);
                MoveCube(StartPos + Vector3.right*6, Vector3.left*2);
                break;
            case 1:
                MoveCube(StartPos, Vector3.left);
                MoveCube(StartPos + Vector3.left * 3, Vector3.left);
                MoveCube(StartPos + Vector3.left * 6, Vector3.right * 2);
                break;
            case 2:
                MoveCube(StartPos, Vector3.back);
                MoveCube(StartPos + Vector3.back * 3, Vector3.back);
                MoveCube(StartPos + Vector3.back * 6, Vector3.forward * 2);
                break;
            case 3:
                MoveCube(StartPos, Vector3.forward);
                MoveCube(StartPos + Vector3.forward * 3, Vector3.forward);
                MoveCube(StartPos + Vector3.forward * 6, Vector3.back * 2);
                break;
        }
    }



    // Update is called once per frame
    void Update () {
	
	}
}
