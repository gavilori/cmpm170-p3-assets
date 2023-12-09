using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Thresholds")]
    [SerializeField] private int thresholdA;
    [SerializeField] private int thresholdB;
    [SerializeField] private int thresholdC;
    
    private Canvas mainCanvas;
    [SerializeField] private GameObject burnPrefab;
    private int hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        mainCanvas = FindFirstObjectByType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        hits++;
        // Debug.Log(hits);
        if (hits == thresholdA) {
            Debug.Log(name + " (A)");
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (hits == thresholdB) {
            Debug.Log(name + " (B)");
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (hits == thresholdC) {
            Debug.Log(name + " (C)");
            GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(burnPrefab, transform.position, Quaternion.identity);
        }
    }
}
