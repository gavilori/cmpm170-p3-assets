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

    [SerializeField] private GameObject spriteA;
    [SerializeField] private GameObject spriteB;
    [SerializeField] private GameObject spriteC;

    public bool perfectCook;

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
        perfectCook = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        hits++;
        if (hits == thresholdA) {
            Debug.Log(name + " (A)");
            spriteA.SetActive(true);
        }
        if (hits == thresholdB) {
            Debug.Log(name + " (B)");
            spriteA.SetActive(false);
            spriteB.SetActive(true);
            perfectCook = true;
        }
        if (hits == thresholdC) {
            Debug.Log(name + " (C)");
            spriteB.SetActive(false);
            spriteC.SetActive(true);
            perfectCook = false;
            Instantiate(burnPrefab, transform.position, Quaternion.identity);

        }
    }
}
