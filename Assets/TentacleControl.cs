using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControl : MonoBehaviour
{
    public List<GameObject> tentacles = new List<GameObject>();
    int index = 0;
    public Camera mainCamera;
    Vector3 cameraPosition;
    float timeElapsed = 0;
    float moveDuration = 0.4f;
    Coroutine cameraCoroutine;
    bool isCameraMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCameraMoving)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right key was pressed.");
            if (index < tentacles.Count - 1)
            {
                index++;
                UpdateCameraPoistion(index);
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left key was pressed.");
            if (index > 0)
            {
                index--;
                UpdateCameraPoistion(index);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 scaleChange = new Vector3(0, 0.5f);
            tentacles[index].transform.Translate(Vector3.up * 0.5f);
            tentacles[index].transform.localScale += scaleChange;
        }
    }

    void UpdateCameraPoistion(int index)
    {
        isCameraMoving = true;
        timeElapsed = 0;
        float startValue = mainCamera.transform.position.x;
        float endValue = tentacles[index].transform.position.x;
        cameraCoroutine = StartCoroutine(MoveCamera(startValue, endValue));
    }

    IEnumerator MoveCamera(float startValue, float endValue)
    {
        while (timeElapsed < moveDuration)
        {
            cameraPosition.x = Mathf.Lerp(startValue, endValue, timeElapsed / moveDuration);
            mainCamera.transform.position = cameraPosition;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        cameraPosition.x = endValue;
        mainCamera.transform.position = cameraPosition;
        isCameraMoving = false;
    }

}
