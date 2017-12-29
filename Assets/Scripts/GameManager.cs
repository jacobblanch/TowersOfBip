using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public GameObject[] oranges;
    public GameObject closestOrange;

    void Awake () {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject CheckDistance(GameObject green)
    {
        foreach (GameObject orange in oranges)
        {
            if (Vector3.Distance(green.transform.position, orange.transform.position) < Vector3.Distance(green.transform.position, closestOrange.transform.position))
            {
                closestOrange = orange;
            }
        }
        if (closestOrange == null)
            return null;
        else
            return closestOrange;
    }
}
