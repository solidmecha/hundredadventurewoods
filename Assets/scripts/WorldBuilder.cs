using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour {

    public static WorldBuilder singleton;
    public int[] WorldPosition=new int[2];
    public string[][] WorldNotation;
    public GameObject Floor;
    public GameObject CurrentFloor;
    public GameObject Tree;
    public GameObject[] Puzzles;
    public GameObject Shop;
    public GameObject[] Collectibles;
    public GameObject LavaFloor;
    public GameObject woozle;
    public GameObject Heffalump;
    public GameObject Pooh;


    private void Awake()
    {
        singleton = this;
        WorldNotation = new string[10][];
        for(int i=0;i<10;i++)
        {
            WorldNotation[i] = new string[10];
            for(int j=0;j<10;j++)
            {
                int w = GameControl.singleton.RNG.Next(8);
                for(int x=0;x<w;x++)
                    WorldNotation[i][j] += "W";
                int h = GameControl.singleton.RNG.Next(9);
                for (int x = 0; x < h; x++)
                    WorldNotation[i][j] += "H";
                int t = GameControl.singleton.RNG.Next(11);
                for (int x = 0; x < t; x++)
                    WorldNotation[i][j] += "T";
                if (i == j)
                    WorldNotation[i][j] = "D";
               if (i == 0 && j == 0)
                    WorldNotation[i][j] = "P";
            }
        }
    }

    public void BuildWorld(int[] delta)
    {
        WorldPosition[0] += delta[0];
        WorldPosition[1] += delta[1];
        if (WorldPosition[0] < 0)
            WorldPosition[0] = 9;
        else if (WorldPosition[0] == 10)
            WorldPosition[0] = 0;
        if (WorldPosition[1] < 0)
            WorldPosition[1] = 9;
        else if (WorldPosition[1] == 10)
            WorldPosition[1] = 0;
        Vector3 p = CurrentFloor.transform.position;
        p += new Vector3(delta[0] * 20, 0, delta[1] * 20);
        Destroy(CurrentFloor);
        CurrentFloor=Instantiate(Floor, p, Quaternion.identity) as GameObject;
        BuildLevel(p);
    }

    public void BuildLevel(Vector3 pos)
    {
        foreach(char c in WorldNotation[WorldPosition[0]][WorldPosition[1]])
        {
            switch(c)
            {
                case 'D':
                    GameObject g=Instantiate(Puzzles[WorldPosition[0]-1], pos+Vector3.up*.6f, Quaternion.identity) as GameObject;
                    g.transform.SetParent(CurrentFloor.transform);
                    break;
                case 'A':
                    Instantiate(Collectibles[0]);
                    break;
                case 'S':
                    Instantiate(Shop, pos, Quaternion.identity, CurrentFloor.transform);
                    break;
                case 'L':
                    Instantiate(LavaFloor, pos, Quaternion.identity, CurrentFloor.transform);
                    break;
                case 'W':
                    WoozleSpawn();
                    break;
                case 'H':
                    HeffaSapwn();
                    break;
                case 'T':
                    TreeSpawn();
                    break;
                case 'P':
                    g = Instantiate(Pooh);
                    g.transform.SetParent(CurrentFloor.transform);
                    break;
            }
        }

    }

    public void WoozleSpawn()
    {

            Vector3 offset = new Vector3(GameControl.singleton.RNG.Next(-9, 10), .1f, GameControl.singleton.RNG.Next(-9, 10));
           GameObject g= Instantiate(woozle, CurrentFloor.transform.position+offset, Quaternion.identity) as GameObject;
        g.transform.SetParent(CurrentFloor.transform);
    }

    public void HeffaSapwn()
    {
        Vector3 offset = new Vector3(GameControl.singleton.RNG.Next(-7, 8), .1f, GameControl.singleton.RNG.Next(-7, 8));
       GameObject g= Instantiate(Heffalump, CurrentFloor.transform.position + offset, Quaternion.identity) as GameObject;
        g.transform.SetParent(CurrentFloor.transform);
    }

    public void BackSonSpawn()
    {

    }

    public void TreeSpawn()
    {
        Vector3 offset = new Vector3(GameControl.singleton.RNG.Next(-7, 8), .6f, GameControl.singleton.RNG.Next(-7, 8));
        GameObject t=Instantiate(Tree, CurrentFloor.transform.position + offset, Quaternion.identity) as GameObject;
        t.transform.localScale = new Vector3(GameControl.singleton.RNG.Next(1, 4), GameControl.singleton.RNG.Next(1, 7), GameControl.singleton.RNG.Next(1, 4));
        t.transform.SetParent(CurrentFloor.transform);
        t = Instantiate(Collectibles[0], CurrentFloor.transform.position + offset+Vector3.up*(t.transform.localScale.y/10f+.3f), Quaternion.identity) as GameObject;
        t.transform.SetParent(CurrentFloor.transform);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
