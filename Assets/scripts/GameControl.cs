using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl singleton;
    public GameObject[] Players;
    public int ActivePlayerIndex;
    public System.Random RNG;
    public enum GameState { Playing, inFX, EnemyFreeze };
    public GameState CurrentState;
    public GameObject[] Swords;
    public bool[] MinigameClears;
    public GameObject Honey;
    public int HoneyCount;

    private void Awake()
    {
        singleton = this;
        RNG=new System.Random();
        for (int i = 1; i < Players.Length; i++)
            Players[i].SetActive(false);
    }

    // Use this for initialization
    void Start () {
	
	}

    public void MsgControls()
    {
        GetComponent<MessageControl>().ShowMessage("'Tab' to swap characters.", 3f);
    }

    public void SpawnHoney(int g)
    {
        if(!MinigameClears[g])
        {
            Instantiate(Honey, WorldBuilder.singleton.CurrentFloor.transform.position, Quaternion.identity, WorldBuilder.singleton.CurrentFloor.transform);
            MinigameClears[g] = true;
        }
    }

    public void screenWrap(Vector3 dir)
    {
       TranslateIt t= Camera.main.gameObject.AddComponent<TranslateIt>();
        t.Speed = 1;
        t.Dest = Camera.main.transform.position + dir*20;
        WorldBuilder.singleton.BuildWorld(new int[2] { (int)dir.x, (int)dir.z });
        SetGameState(GameState.inFX, 1f);
    }

    public void SetGameState(GameState g, float counter)
    {
        CurrentState = g;
        Invoke("SetGameStatePlaying", counter);
    }

    public void SetGameStatePlaying()
    {
        CurrentState = GameState.Playing;
    }

    public void CharacterSwap()
    {
        Vector3 v = Players[ActivePlayerIndex].transform.position;
        Players[ActivePlayerIndex].transform.position = new Vector3(-100, -100, -100);
        Players[ActivePlayerIndex].SetActive(false);
        ActivePlayerIndex++;
        if (ActivePlayerIndex > 1)
            ActivePlayerIndex = 0;
        Players[ActivePlayerIndex].transform.position = v;
        Players[ActivePlayerIndex].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            CharacterSwap();
        }
	}
}
