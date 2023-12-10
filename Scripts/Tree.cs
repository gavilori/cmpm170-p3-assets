using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("Thresholds")]
    [SerializeField] private int burnThreshold;
    [SerializeField] private GameObject burnPrefab;
    private int hits;
    public bool onFire;
    private bool burnFlag;
    private GameObject[] allTrees;
    private float burnRadius;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        burnRadius = 2.5f;
        onFire = false;
        allTrees = GameObject.FindGameObjectsWithTag("Tree");
    }

    // Update is called once per frame
    void Update()
    {
        if (!onFire && allTrees != null) {
            foreach(GameObject tree in allTrees) {
                Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 treePos = new Vector2(tree.transform.position.x, tree.transform.position.y);
                // float dist = Mathf.Sqrt(Mathf.Pow(thisPos.x - treePos.x, 2) + Mathf.Pow(thisPos.y - treePos.y, 2));
                float dist = Vector2.Distance(thisPos, treePos);
                if (tree.transform != transform && dist <= burnRadius && tree.GetComponent<Tree>().onFire && !burnFlag) {
                    // Debug.Log(dist);
                    burnFlag = true;
                    StartCoroutine("Burn");
                }
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (onFire) return;

        hits++;
        if (hits == burnThreshold) {
            Debug.Log(name + " (A)");
            GetComponent<SpriteRenderer>().color = new Color32(0xBE, 0xCC, 0x46, 0xFF);
        }
        if (hits == burnThreshold * 2) {
            Debug.Log(name + " (B)");
            GetComponent<SpriteRenderer>().color = new Color32(0xAD, 0x3A, 0x18, 0xFF);
        }
        if (hits == burnThreshold * 3) {
            Debug.Log(name + " (C)");
            GetComponent<SpriteRenderer>().color = new Color32(0x31, 0x26, 0x1A, 0xFF);
            Instantiate(burnPrefab, transform.position, Quaternion.identity);
            onFire = true;
        }
    }

    IEnumerator Burn() {
        
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = new Color32(0x31, 0x26, 0x1A, 0xFF);
        Instantiate(burnPrefab, transform.position, Quaternion.identity);
        onFire = true;
    }
}
