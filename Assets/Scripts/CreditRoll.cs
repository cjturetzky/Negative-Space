using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditRoll : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProComponent;
    public float speed = 10;

    private RectTransform textRectTransform;
    private float scrollPosition = 0;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Awake()
    {
        textRectTransform = TextMeshProComponent.GetComponent<RectTransform>();
    }
    void Start()
    {
        startPosition = textRectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        textRectTransform.position = new Vector3(startPosition.x, scrollPosition, startPosition.z);
        scrollPosition += speed * Time.deltaTime;
    }
}
