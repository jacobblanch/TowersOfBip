using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    public GameObject[] sets;

    public GameObject closestSet;

    public GameObject selectedOrange;

    public GameObject[] greens;

    //public Color c1 = Color.yellow;
    //public Color c2 = Color.red;
    //LineRenderer lineRenderer;

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
        /*lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 0.2f;

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;*/
    }

    public void Update()
    {
        
    }

    public GameObject CheckDistance(GameObject green)
    {
        foreach (GameObject set in sets)
        {
            if (Vector3.Distance(green.transform.position, set.transform.position) < Vector3.Distance(green.transform.position, closestSet.transform.position))
            {
                closestSet = set;
                foreach (Transform orange in closestSet.transform)
                {
                    if (orange.CompareTag(green.tag))
                    {
                        if (Physics.Raycast(transform.position, transform.up, 20f))
                        {
                            Debug.Log("Green above you!");
                            return null;
                        }
                        else
                            selectedOrange = orange.gameObject;

                    }
                        
                }
            }
        }
        if (selectedOrange == null)
            return null;
        else
            return selectedOrange;            
    }
}
