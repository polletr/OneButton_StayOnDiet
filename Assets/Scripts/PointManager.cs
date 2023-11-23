using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;

    public GameObject pointAGameObject;
    public GameObject pointBGameObject;

    public Transform PointA { get; private set; }
    public Transform PointB { get; private set; }

    private void Awake()
    {
        // Garante que apenas uma instância exista
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Obtém as transformadas dos objetos na cena
            PointA = pointAGameObject.transform;
            PointB = pointBGameObject.transform;
        }
        else
        {
            // Destroi instâncias adicionais
            Destroy(gameObject);
        }
    }
}
