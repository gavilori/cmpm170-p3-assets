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
    public bool burnFlag;
    private float burnRadius;
    [SerializeField] AudioSource burnSFX;

    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        burnRadius = 2.5f;
        onFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onFire && GameManager.allTrees != null) {
            foreach(GameObject tree in GameManager.allTrees) {
                Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 treePos = new Vector2(tree.transform.position.x, tree.transform.position.y);
                float dist = Vector2.Distance(thisPos, treePos);
                if (tree.transform != transform && dist <= burnRadius && tree.GetComponent<Tree>().onFire && !burnFlag) {
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
            GetComponent<SpriteRenderer>().color = new Color32(0xBE, 0xCC, 0x46, 0xFF);
        }
        if (hits == burnThreshold * 2) {
            GetComponent<SpriteRenderer>().color = new Color32(0xAD, 0x3A, 0x18, 0xFF);
        }
        if (hits == burnThreshold * 3) {
            GetComponent<SpriteRenderer>().color = new Color32(0x31, 0x26, 0x1A, 0xFF);
            Instantiate(burnPrefab, transform.position, Quaternion.identity);
            onFire = true;
            burnFlag = true;
        }
    }

    IEnumerator Burn()
    {
        if (!GameManager.burnSFXPlaying)
        {
            GameManager.burnSFXPlaying = true;
            burnSFX.Play();
        }

        yield return new WaitForSeconds(0.5f);

        GetComponent<SpriteRenderer>().color = new Color32(0x31, 0x26, 0x1A, 0xFF);
        Instantiate(burnPrefab, transform.position, Quaternion.identity);
        onFire = true;
    }
}
