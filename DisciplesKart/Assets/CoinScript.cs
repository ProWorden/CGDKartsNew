using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameHandler GH;
    public AudioClip goldsound;
    // Start is called before the first frame update
    void Start()
    {
        GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "HandKart R")
        {
            GH.coinright++;
            AudioSource.PlayClipAtPoint(goldsound, transform.position);
        }

        if (other.name == "HandKart L")
        {
            GH.coinleft++;
            AudioSource.PlayClipAtPoint(goldsound, transform.position);
        }
        Destroy(gameObject);
    }

}
