using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    private Text[] labels;
    //Made card number public so it can be seen in Inspector
    public int cardNumber;
    private Animator animator;
    
    
    

    private void Awake()
    {
        transform.eulerAngles = new Vector3(0, 0, 180);        
        cardNumber = 0;        
        labels = GetComponentsInChildren<Text>();
        animator = GetComponent<Animator>();
        DisableAnimator();
    }
    // Start is called before the first frame update
    void Start()
    {
        
               
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SetValue(int val)
    {
        cardNumber = val;
        foreach(Text label in labels)
        {
            label.text = val.ToString();
        }
    }

    public void Flip()
    {
        EnableAnimator();  
        animator.SetTrigger("OnCardFlipped");        
    }

    public void Discard()
    {
        EnableAnimator();
        animator.SetTrigger("IsDiscarded");
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }

    private void EnableAnimator()
    {
        animator.enabled = true;
    }
    

}
