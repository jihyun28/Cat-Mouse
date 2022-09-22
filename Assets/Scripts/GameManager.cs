using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public CatMove player;
    public GameObject[] Stages;

    public void NextStage(Vector3 pos, string type) // portal Type
    {
        switch (type)
        {
            // 각 교실 포탈
            case "InClass":
                Stages[0].SetActive(false);
                Stages[1].SetActive(true);
                PlayerReposition(pos);
                break;
            case "InArtRoom":
                Stages[0].SetActive(false);
                Stages[2].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutClass":
                Stages[1].SetActive(false);
                Stages[0].SetActive(true);
                PlayerReposition(pos);
                break;
            case "OutArt":
                Stages[2].SetActive(false);
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
}
