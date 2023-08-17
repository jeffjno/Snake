using UnityEngine;

public class SnakeGameManager : MonoBehaviour
{
    public GameObject blockPrefab; // Refer�ncia ao prefab do bloco.
    private Vector2[,] positions;
    private int[,] gameMatrix = new int[10, 20];

    private float startX = -1.596f;
    private float startY =0.211f; // Defina este valor conforme necess�rio.
    private float offset = 0.211f;

    void Start()
    {
        InitializeMatrix();
        PlaceInitialSnake();
        PlaceApple();
    }

    void InitializeMatrix()
    {
        positions = new Vector2[10, 20];

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                positions[x, y] = new Vector2(startX + x * offset, startY + y * offset);

                // Esta parte � opcional, mas se voc� quiser visualizar a matriz, voc� pode instanciar os blocos aqui:
                Instantiate(blockPrefab, positions[x, y], Quaternion.identity).SetActive(true); // Desativado por padr�o
            }
        }
    }

    void PlaceInitialSnake()
    {
        // Sua l�gica para colocar a cobrinha inicialmente no cen�rio.
    }

    void PlaceApple()
    {
        // l�gica para posicionar a ma�� de maneira aleat�ria.
    }

    // Outros m�todos relacionados � l�gica do jogo.
}
