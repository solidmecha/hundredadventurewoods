using UnityEngine;
using System.Collections.Generic;

public class DicerControl : MonoBehaviour {
	public GameObject pip;
    public Material[] Mats;
	// Use this for initialization
	void Start () {
		List<int> ints= new List<int> {6,6,6,6,6,6,5,5,5,5,5,4,4,4,4,3,3,3,2,2,1,1,1,1};
		while(ints.Count<36)
		{
			int r;
			if (36 - ints.Count >= 6)
				r=GameControl.singleton.RNG.Next(1, 7);
			else
				r= GameControl.singleton.RNG.Next(1, 36-ints.Count);
			for (int i = 0; i < r; i++)
				ints.Add(r);
		}
	 for(int y=0;y<6;y++)
		{
			for(int x=0;x<6;x++)
			{
				int r = GameControl.singleton.RNG.Next(ints.Count);
                GameObject g = transform.GetChild(y * 6 + x).gameObject;
                g.GetComponent<DicerScript>().Val = ints[r];
                transform.GetChild(y * 6 + x).GetComponent<DicerScript>().ShowPips();
                ints.RemoveAt(r);
			}
		}
	
	}

	public void VerticalMoveDown(int index)
	{
        Vector3[] V = new Vector3[6];
        V[0] = new Vector3(-3 + index * 1.1f, 0, -3f + 5 * 1.1f);
        for (int i = 0; i < 5; i++)
            V[i + 1] = new Vector3(-3 + index * 1.1f, 0, -3f + i * 1.1f);
        Transform[] T = new Transform[6];
        for (int i = 0; i < 6; i++)
        {
            T[i] = GetBlockAtPosition(new Vector3(-3 + index * 1.1f, 0, -3f + i * 1.1f));
        }
        for (int i = 0; i < 6; i++)
        {
            T[i].position = V[i];
        }
        ScoreBlocks();
    }

	public void VerticalMoveUp(int index)
	{
        
        Vector3[] V = new Vector3[6];
        V[5] = new Vector3(-3 + index * 1.1f, 0, -3f + 0 * 1.1f);
        for (int i = 5; i > 0; i--)
            V[i - 1] = new Vector3(-3 + index * 1.1f, 0, -3f + i * 1.1f);
        Transform[] T=new Transform[6];
        for (int i = 0; i < 6; i++)
        {
            T[i] = GetBlockAtPosition(new Vector3(-3 + index * 1.1f, 0, -3f + i * 1.1f));    
        }
        for (int i = 0; i < 6; i++)
        {
            T[i].position = V[i];
        }
        ScoreBlocks();
    }

    public void ScoreBlocks()
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                DicerScript D = GetBlockAtPosition(new Vector3(-3 + x * 1.1f, 0, -3f + y * 1.1f)).GetComponent<DicerScript>();
                if (!D.Checked)
                {
                    D.Checked = true;
                    List<DicerScript> CheckList = new List<DicerScript>();
                    List<DicerScript> ScoreList = new List<DicerScript>();
                    int Val = D.Val;
                    CheckList.Add(D);
                    while (CheckList.Count > 0)
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                    Transform t = GetBlockAtPosition(
                                        new Vector3(CheckList[0].transform.localPosition.x + i * 1.1f, 0, CheckList[0].transform.localPosition.z + j * 1.1f));
                                    if (t != null)
                                    {
                                        DicerScript ds = t.GetComponent<DicerScript>();
                                        if (ds.Val == Val && !ds.Checked)
                                        {
                                            ds.Checked = true;
                                            CheckList.Add(ds);
                                        }
                                    }
                            }
                        }
                        ScoreList.Add(CheckList[0]);
                        CheckList.RemoveAt(0);
                    }
                    if (ScoreList.Count == Val)
                    {
                        foreach (DicerScript d in ScoreList)
                        {
                            d.Scored = true;
                        }
                    }
                    else
                    {
                        foreach (DicerScript d in ScoreList)
                        {
                            d.Scored = false;
                        }
                    }
                }
            }
        }
        int counter = 0;
        foreach (DicerScript d in GetComponentsInChildren<DicerScript>())
        {
            if (d.Scored)
            {
                counter++;
                d.GetComponent<Renderer>().material = Mats[1];
            }
            else
                d.GetComponent<Renderer>().material = Mats[0];

            d.Checked = false;
        }
        if (counter == 36)
            GameControl.singleton.SpawnHoney(8);
    }

    public Transform GetBlockAtPosition(Vector3 pos)
    {
        pos += transform.position;
        for(int i=0;i<36;i++)
        {
            if((transform.GetChild(i).position-pos).sqrMagnitude<.1f)
                return transform.GetChild(i);
        }
        return null;
    }

    public void HorizontalMoveRight(int index)
    {
        Vector3[] V = new Vector3[6];
        V[5] = new Vector3(-3f, 0, -3f + index * 1.1f);
        for (int i = 5; i > 0; i--)
            V[i - 1] = new Vector3(-3 + i * 1.1f, 0, -3f + index * 1.1f);
        Transform[] T = new Transform[6];
        for (int i = 0; i < 6; i++)
        {
            T[i] = GetBlockAtPosition(new Vector3(-3 + i * 1.1f, 0, -3f + index * 1.1f));
        }
        for (int i = 0; i < 6; i++)
        {
            T[i].position = V[i];
        }
        ScoreBlocks();
    }
        
    public void HorizontalMoveLeft(int index)
    {
        Vector3[] V = new Vector3[6];
        V[0] = new Vector3(2.5f, 0, -3f + index * 1.1f);
        for (int i = 0; i < 5; i++)
            V[i + 1] = new Vector3(-3 + i * 1.1f, 0, -3f + index * 1.1f);
        Transform[] T = new Transform[6];
        for (int i = 0; i < 6; i++)
        {
            T[i] = GetBlockAtPosition(new Vector3(-3 + i * 1.1f, 0, -3f + index * 1.1f));
        }
        for (int i = 0; i < 6; i++)
        {
            T[i].position = V[i];
        }
        ScoreBlocks();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
