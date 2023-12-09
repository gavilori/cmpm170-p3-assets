using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("Thresholds")]
    [SerializeField] private int thresholdA;
    [SerializeField] private int thresholdB;
    [SerializeField] private int thresholdC;
    private int hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        hits++;
        if (hits == thresholdA) {
            Debug.Log(name + " (A)");
            GetComponent<SpriteRenderer>().color = new Color32(0xBE, 0xCC, 0x46, 0xFF);
        }
        if (hits == thresholdB) {
            Debug.Log(name + " (B)");
            GetComponent<SpriteRenderer>().color = new Color32(0xAD, 0x3A, 0x18, 0xFF);
        }
        if (hits == thresholdC) {
            Debug.Log(name + " (C)");
            GetComponent<SpriteRenderer>().color = new Color32(0x31, 0x26, 0x1A, 0xFF);
        }
    }
}
