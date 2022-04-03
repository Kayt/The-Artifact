using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{

    [SerializeField]
    private float harvestTime = 0.4f;

    private PlayerMovement playerMovement;
    private PlayerBackpack backPack;
    private AudioSource audioSource;
    private Collider2D collideBush;
    private BushFruits hitbush;
    private bool canHarvestFruits;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        backPack = GetComponent<PlayerBackpack>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryHarvestFruit();
        }
    }

    void TryHarvestFruit()
    {
        if (!canHarvestFruits)
            return;

        if(collideBush != null)
        {
            hitbush = collideBush.GetComponent<BushFruits>();

            if (hitbush.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                backPack.AddFruits(hitbush.HarvestFruit());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush")) {
            canHarvestFruits = true;
            collideBush = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits = false;
            collideBush = null;
        }
    }

} // class
