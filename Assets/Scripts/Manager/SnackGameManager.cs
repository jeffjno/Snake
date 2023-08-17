using UnityEngine;

public class SnakeGameManager : MonoBehaviour
{
    public GameObject blockPrefab; // Referência ao prefab do bloco.
    private Vector2[,] positions;
    private int[,] gameMatrix = new int[10, 20];

    private float startX = -1.596f;
    private float startY =0.211f; // Defina este valor conforme necessário.
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

                // Esta parte é opcional, mas se você quiser visualizar a matriz, você pode instanciar os blocos aqui:
                Instantiate(blockPrefab, positions[x, y], Quaternion.identity).SetActive(true); // Desativado por padrão
            }
        }
    }

    void PlaceInitialSnake()
    {
        // Sua lógica para colocar a cobrinha inicialmente no cenário.
    }

    void PlaceApple()
    {
        // lógica para posicionar a maçã de maneira aleatória.
    }

    // Outros métodos relacionados à lógica do jogo.
}
