using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_drag;
    public GameObject object_game;
    public Canvas canvas;
    private GameObject objectDragInstance;

    private GameController gameController;

    public void Start(){
        gameController = GameController.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstance.transform.position = Input.mousePosition;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstance = Instantiate(object_drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<ObjectDragging>().card = this;
        gameController.draggingObject = objectDragInstance;
        AudioManager.Play("seedlift");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameController.PlaceObject();
        gameController.draggingObject = null;
        Destroy(objectDragInstance);   
    }
}
