﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    private Quaternion windDirection = new Quaternion();
    public Quaternion WindDirection { get { return windDirection; } private set { windDirection = value; } }

    private float windRotation = 0;

    private float lastWindRotation;

    private float nextWindRotation;

    private float t;

    [SerializeField]
    private float windRotationSpeed = 0.25f;

    void Start()
    {
        StartCoroutine(nameof(ChangeWindRotation));
    }

    void FixedUpdate()
    {
        windRotation = Mathf.Lerp(lastWindRotation, nextWindRotation, t);

        if (t < 1)
            t += windRotationSpeed * Time.deltaTime;

        windDirection = Quaternion.AngleAxis(windRotation, Vector3.up);

        transform.rotation = windDirection;
    }

    private IEnumerator ChangeWindRotation()
    {
        t = 0;
        lastWindRotation = windDirection.eulerAngles.y;
        nextWindRotation = lastWindRotation + Random.Range(-50f, 50f);

        yield return new WaitForSeconds(Random.Range(10, 60));

        StartCoroutine(nameof(ChangeWindRotation));
    }
}
