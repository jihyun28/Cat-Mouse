using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCheese : MonoBehaviour
{
    //cg : 치즈게이지
    public int cg = 5;
    public GameObject cheese;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public GameObject EatenText;
    public void EatenCheese(int eaten)
    {
        //GameObject eatText = Instantiate(EatenText);
        //eatText.GetComponent<Eating>().eaten = eaten;
        if (cg > 0)
        {
            cg = cg - eaten;
        }
        else
        {
            cg = 0;
            Destroy(cheese);
        }
    }
}