using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    public static CardController Instance { get; private set; }
    
    // scdh order: spades, clubs, diamonds, hearts
    public Sprite[] cardFaces;
    public Sprite[] cardBacks;

    public int cardBackIndex = 0;
    
    public Sprite GetCardSprite(Card card) {
        int cardIndex = (int)card.rank - 2;
        return cardFaces[(int)card.suit * 13 + cardIndex];
    }
    
    public Sprite GetCardBackSprite() {
        return cardBacks[cardBackIndex];
    }
    
    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
}
