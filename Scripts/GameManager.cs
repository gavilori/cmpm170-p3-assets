using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool burnSFXPlaying;
    public static GameObject[] allTrees;
    public static GameObject[] allFood;
    public int totalTrees;
    public int burningTrees;
    public int perfectlyCookedFoods;
    [SerializeField] GameObject flameA;
    [SerializeField] GameObject flameB;
    [SerializeField] GameObject flameC;
    [SerializeField] TextMeshProUGUI gameStatusText;
    [SerializeField] GameObject playAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        burnSFXPlaying = false;
        allTrees = GameObject.FindGameObjectsWithTag("Tree");
        allFood = GameObject.FindGameObjectsWithTag("Food");
        totalTrees = allTrees.Length;
        burningTrees = 0;
        perfectlyCookedFoods = 0;
        playAgainButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            checkForTrees();

            checkFood();

            checkScore();
        }

        else
        {
            if (perfectlyCookedFoods == 3)
            {
                gameStatusText.text = "You Win!";
            }
            else
            {
                gameStatusText.text = "You Lose!";
            }
            playAgainButton.SetActive(true);
        }
    }

    private void checkForTrees()
    {
        burningTrees = 0;
        foreach (GameObject tree in allTrees)
        {
            if (tree.GetComponent<Tree>().burnFlag)
            {
                burningTrees += 1;
            }
        }
        if (burningTrees == totalTrees)
        {
            gameOver = true;
        }
    }

    private void checkFood()
    {
        perfectlyCookedFoods = 0;
        foreach (GameObject food in allFood)
        {
            if (food.GetComponent<Food>().perfectCook)
            {
                perfectlyCookedFoods += 1;
            }
        }
        if (perfectlyCookedFoods == 3)
        {
            gameOver = true;
        }
    }

    private void checkScore()
    {
        if (perfectlyCookedFoods == 0)
        {
            flameA.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
            flameB.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
            flameC.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
        }
        if (perfectlyCookedFoods == 1)
        {
            flameA.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            flameB.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
            flameC.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
        }
        if (perfectlyCookedFoods == 2)
        {
            flameB.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            flameB.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            flameC.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
        }
        if (perfectlyCookedFoods == 3)
        {
            flameC.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
