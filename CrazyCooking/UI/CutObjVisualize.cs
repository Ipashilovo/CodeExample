using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObjVisualize : MonoBehaviour
{
    [SerializeField] private GameObject _cutVisualPrefab;
    private GameObject _cutVisual;
    private CutVisualCanvas _cutVisualCanvas;
    private FoodCollisionHandler _foodCollisionHandler;
    private Food _food;

    private void OnDisable()
    {
        Unfollow();
    }
    
    private void Start()
    {
        _food = _foodCollisionHandler.Food;
        _cutVisual = Instantiate(_cutVisualPrefab);
        _cutVisualCanvas = _cutVisual.GetComponent<CutVisualCanvas>();
        _cutVisual.SetActive(false);
    }

    private void Update()
    {
        if (_cutVisual.activeSelf)
        {
            float distanceY = 0.2f;
            _cutVisual.transform.position = new Vector3(_foodCollisionHandler.transform.position.x, 
                _foodCollisionHandler.transform.position.y + distanceY, _foodCollisionHandler.transform.position.z);
            _cutVisualCanvas.SetImageFillValue(_food.SlicingСondition);
        }
    }

    public void SetCollisionHandler(FoodCollisionHandler handler)
    {
        if (_foodCollisionHandler != null)
        {
            Unfollow();
        }

        _foodCollisionHandler = handler;
        Follow();
    }

    private void OnHandlerCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<CuttingBoard>() != null)
        {
            _cutVisual.SetActive(false);
        }
    }
    
    private void OnHandlerCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CuttingBoard>() != null)
        {
            _cutVisual.SetActive(true);
        }
    }
    
    private void Follow()
    {
        _foodCollisionHandler.CollisionExit += OnHandlerCollisionExit;
        _foodCollisionHandler.ColisionEnter += OnHandlerCollisionEnter;
    }

    private void Unfollow()
    {
        _foodCollisionHandler.CollisionExit -= OnHandlerCollisionExit;
        _foodCollisionHandler.ColisionEnter -= OnHandlerCollisionEnter;
    }
}
