using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Suit {
    Spades = 0,
    Clubs = 1,
    Diamonds = 2,
    Hearts = 3,
}

public enum Rank {
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,  
    Queen = 12, 
    King = 13, 
    Ace = 14,
}

[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour {
    
    private SpriteRenderer spriteRenderer;

    public bool isFaceUp = true;
    public Rank rank = Rank.Two;
    public Suit suit = Suit.Clubs;


    private bool scheduledRefresh;
    
    private void Start() {
        ShowFront();
    }
    
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        suit = (Suit) Random.Range(0, 4);
        rank = (Rank) Random.Range(2, 15);
    }

    private void Update() {
        if (scheduledRefresh) {
            RefreshCard();
            scheduledRefresh = false;
        }
    }

    private void ShowFront() {
        Sprite cardFront = CardController.Instance.GetSpriteByCard(this);
        spriteRenderer.sprite = cardFront;
    }

    private void ShowBack() {
        Sprite cardBack = CardController.Instance.GetCardBack();
        spriteRenderer.sprite = cardBack;
    }
    
    public void RefreshCard() {
        if (isFaceUp) {
            ShowFront();
        }
        else {
            ShowBack();
        }
    }

    private void OnValidate() {
        scheduledRefresh = true;
    }

    private void OnMouseOver () {
        if (Input.GetMouseButtonDown(1)) {
            isFaceUp = !isFaceUp;
            RefreshCard();
        }
    }

    
}
