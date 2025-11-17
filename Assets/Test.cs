using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 1)
            gameObject.transform.Rotate(0, 0, 1);
    }
}
