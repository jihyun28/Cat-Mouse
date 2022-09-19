using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public CatMove player;
    public GameObject[] Stages;

    public void NextStage()
    {
        Stages[stageIndex].SetActive(false);
        stageIndex++;
        Stages[stageIndex].SetActive(true);
        PlayerReposition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerReposition();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(3, 5, 0);
        player.VelocityZero();
    }

}
