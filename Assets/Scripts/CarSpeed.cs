using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarSpeed : MonoBehaviour
{

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject speedGraphic;
    [SerializeField] private GameObject speedGraphicParent;
    [SerializeField] private TMP_Text spedometer;

    private Rigidbody carRigidBody;
    private RectTransform speedGraphicRect;
    private double topSpeed = 150;
    private float speedGraphicParentWidth;
    private int kph;
    private float originalPositionX;
    

    private void Start()
    {
        carRigidBody = car.GetComponent<Rigidbody>();
        speedGraphicParentWidth = speedGraphicParent.GetComponent<RectTransform>().rect.width;
        speedGraphicRect = speedGraphic.GetComponent<RectTransform>();
        originalPositionX = speedGraphicRect.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        kph = Convert.ToInt32(carRigidBody.velocity.magnitude * 3.6);
        spedometer.text = kph.ToString();
        float width = calculateSpeedPercentage();
        speedGraphicRect.sizeDelta = new Vector2(width, speedGraphicRect.rect.height);

        Vector3 position = speedGraphicRect.position;
        speedGraphicRect.position = new Vector3(originalPositionX + (width * 0.056f), position.y, position.z);
    }

    private float calculateSpeedPercentage()
    {
        float speedPercentage = Convert.ToSingle(kph / topSpeed);
        return speedGraphicParentWidth * speedPercentage;
    }
}
