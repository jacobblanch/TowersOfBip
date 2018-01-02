using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public GameObject[] oranges;
    public GameObject closestOrange;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    LineRenderer lineRenderer;

    void Awake()
    {
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

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 0.2f;

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;
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
        {
            lineRenderer.SetPosition(0, green.transform.position);
            lineRenderer.SetPosition(1, closestOrange.transform.position);
            return closestOrange;
        }
            
    }
}
