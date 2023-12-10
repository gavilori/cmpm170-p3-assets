using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Food : MonoBehaviour
{
    [Header("Thresholds")]
    [SerializeField] private int thresholdA;
    [SerializeField] private int thresholdB;
    [SerializeField] private int thresholdC;
    
    private Canvas mainCanvas;
    private Camera cam;
    [SerializeField] private GameObject burnPrefab;
    [SerializeField] private GameObject barPrefab;
    private int hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        mainCanvas = FindFirstObjectByType<Canvas>();
        cam = FindFirstObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        hits++;
        // Debug.Log(hits);
        if (hits == 1) {
            // FIXME: spawn a burn meter UI element
            /*
            GameObject barUI = Instantiate(barPrefab);
            barUI.transform.SetParent(mainCanvas.transform, false);
            barUI.transform.localPosition = transform.position;
            */
        }
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
