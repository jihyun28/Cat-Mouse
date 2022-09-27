using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public CatMove player;
    public GameObject[] Stages;

    //생쥐 채력관리
    public int totalPoint;
    public int stagePoint;
    public int health;
    public Image[] UIHealth;

    public void NextStage(Vector3 pos, string type) // portal Type
    {
        switch (type)
        {
            // 일반 교실 IN
            case "InClass":
                Stages[0].SetActive(false);
                Stages[1].SetActive(true);
                PlayerReposition(pos);
                break;
            case "InClass2f":
                Stages[0].SetActive(false);
                Stages[3].SetActive(true);
                PlayerReposition(pos);
                break;
            case "InClass3f":
                Stages[0].SetActive(false);
                Stages[5].SetActive(true);
                PlayerReposition(pos);
                break;
            case "InClass4f":
                Stages[0].SetActive(false);
                Stages[7].SetActive(true);
                PlayerReposition(pos);
                break;
            case "InClass5f":
                Stages[0].SetActive(false);
                Stages[9].SetActive(true);
                PlayerReposition(pos);
                break;

                // 특정 교실 IN
            case "InArtRoom":
                Stages[0].SetActive(false);
                Stages[2].SetActive(true);
                PlayerReposition(pos);
                break;
            case "InMusicRoom":
                Stages[0].SetActive(false);
                Stages[6].SetActive(true);
                PlayerReposition(pos);
                break;

            // 일반 교실 OUT
            case "OutClass":
                Stages[1].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutClass2f":
                Stages[3].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutClass3f":
                Stages[5].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutClass4f":
                Stages[7].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutClass5f":
                Stages[9].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;

                // 특정 교실 OUT
            case "OutArt":
                Stages[2].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutMusic":
                Stages[6].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(3, 5, 0);
            player.VelocityZero();
        }
    }

    void PlayerReposition(Vector3 pos)
    {
        player.transform.position = pos;
        player.VelocityZero();
    }

    //생쥐 체력관리
    public void HealthDown()
    {
        if (health > 0)
        {
            health--;
            Destroy(UIHealth[health]);
        }
        else
        {
            Debug.Log("Mouse Out");
        }
    }
}
