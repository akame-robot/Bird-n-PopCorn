using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopcornControll : MonoBehaviour
{
    public GameObject popCorn;

    public bool invoking;

    private float currentWave;
    private float nextSpawnTime;
    private int time;
    public TextMeshProUGUI point;

    private void OnEnable()
    {
        StartCoroutine(SpawnPopCorn());           
    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }

    IEnumerator SpawnPopCorn()
    {
        while (invoking)
        {
            time = Random.Range(1, 4);
            yield return new WaitForSeconds(time);
            float x = Random.Range(-11, 11);
            float y = 6f;
            Vector2 spawnObject = new Vector2(x, y);
            Instantiate(popCorn, spawnObject, Quaternion.identity);
        }
    }

    public void Score()
    {
        point.text = "Score: " + PopCornScript.score.ToString();
    }
}
