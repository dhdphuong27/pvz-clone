using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    public GameController gameController;
    public Image backgroundImage;
    public SpawnPoint spawnPoint;

    private void Start(){
        gameController = GameController.instance;
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if (gameController.draggingObject != null){
            gameController.currentContainer = this.gameObject;
            backgroundImage.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        gameController.currentContainer = null;
        backgroundImage.enabled = false;
    }
}
