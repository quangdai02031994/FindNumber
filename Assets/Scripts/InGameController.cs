using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameController : MonoBehaviour {

    public static InGameController Inst;

    public GameObject boxPrefabs;
    public GameObject Listbox;
    public GameObject buttonGo;
    public GameObject requestNumber;
    public GameObject bestTime;
    public GameObject buttonHint;
    
    private int TrueCount = 0;
    private string best_time;
    private int hintCount = 3;

    private float currentTime = 0f;

    private List<int> list_number = new List<int>();
    private List<Vector3> list_positionBox = new List<Vector3>();
    private List<GameObject> BoxNumber = new List<GameObject>();
    private List<int> list_number_hint = new List<int>();


    private bool check = true;

	void Start () {

        Inst = this;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!buttonGo.activeSelf && check)
        {
            CreatePositionBox();
            CreateNumber();
            CreateListBox();
            ChangRequest();
            ShowListBox();
            check = false;
        }


        buttonHint.GetComponent<UILabel>().text = hintCount.ToString();

        currentTime += Time.deltaTime;

        if (TrueCount >= 99)
        {
            SoundController.Inst.StopGameAudio();
            GameController.Inst.CallGameOver();
        }
        
	}

    void OnDisable()
    {
        ResetGame();
    }

    private void CreatePositionBox()
    {
        Vector3 temp = new Vector3(0, 0, 0);
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                temp.x = -320 + 80f * j;
                temp.y = 305 - 90 * i;
                list_positionBox.Add(temp);
            }
        }
    }

    private void CreateListBox()
    {
        
        for (int i = 0; i < list_positionBox.Count; i++)
        {
            GameObject temp;
            temp = Instantiate(boxPrefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            
            temp.transform.GetComponentInChildren<UILabel>().text = list_number[i].ToString();
            if (i % 2 == 1)
                temp.transform.GetComponentInChildren<UISprite>().color = new Color32(113, 235, 198, 255);
            else
                temp.transform.GetComponentInChildren<UISprite>().color = new Color32(101, 219, 184, 255);

            temp.transform.parent = Listbox.transform;
            temp.transform.localPosition = list_positionBox[i];
            temp.transform.localScale = new Vector2(1, 1);

            BoxNumber.Add(temp);
        }
        
    }


    private void ShowListBox()
    {
            Listbox.gameObject.SetActive(true);
    }

    private void CreateNumber()
    {
        List<int> temp = new List<int>();
        for (int i = 1; i <= 99; i++)
        {
            temp.Add(i);
        }


        while (temp.Count > 0)
        {
            int rand = Random.Range(0, temp.Count);
            list_number.Add(temp[rand]);
            list_number_hint.Add(temp[rand]);
            temp.RemoveAt(rand);
        }
    }

    public List<int> GetListNumber()
    {
        return this.list_number;
    }


    public void ChangRequest()
    {
        int random = Random.Range(0, list_number.Count);
        requestNumber.GetComponent<UILabel>().text = list_number[random].ToString();
        list_number.RemoveAt(random);
    }

    public string ReturnRequest()
    {

        return requestNumber.GetComponent<UILabel>().text;
    }

    public void DisplayHint()
    {
        if (hintCount > 0 && buttonGo.activeSelf == false)
        {
            int hint = int.Parse(requestNumber.GetComponent<UILabel>().text);
            int index = list_number_hint.IndexOf(hint);
            BoxNumber[index].transform.GetComponentInChildren<UISprite>().color = new Color32(220, 220, 0, 255);
            hintCount--;
        }
    }

    public int ReturnTrueCount()
    {
        return TrueCount;
    }

    public void IncreateTrueCount()
    {
        TrueCount++;
    }

    public void ResetGame()
    {
        check = true;
        hintCount = 3;
        TrueCount = 0;
        list_positionBox.Clear();
        list_number.Clear();
        list_number_hint.Clear();
        BoxNumber.Clear();
        int countChild = Listbox.transform.childCount;
        for (int i = 0; i < countChild; i++)
        {
            Destroy(Listbox.transform.GetChild(i).gameObject);
        }
    }


}
