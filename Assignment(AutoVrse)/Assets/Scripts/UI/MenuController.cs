using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private GameController gameController;

    public Button[] buttons;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(() =>
        {
            gameController.AddCard();
        });
        buttons[1].onClick.AddListener(() =>
        {
            gameController.PopCard();
        });
        buttons[2].onClick.AddListener(() =>
        {
            gameController.Peek();
        });
        buttons[3].onClick.AddListener(() =>
        {
            gameController.Shuffle();
        });
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
