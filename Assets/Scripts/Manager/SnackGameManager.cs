using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeGameManager : MonoBehaviour
{
    public GameObject blockPrefab;
    private Vector2[,] positions;
    private int[,] gameMatrix = new int[10, 20];

    private float startX = -1.596f;
    private float startY = 0.211f;
    private float offset = 0.211f;

    private Snake snake;
    private Vector2Int applePosition;
    private Dictionary<Vector2Int, GameObject> boardBlocks = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        InitializeMatrix();
        InitializeSnake();
        PlaceApple();
        StartCoroutine(SnakeMovementRoutine());
    }

    void InitializeMatrix()
    {
        positions = new Vector2[10, 20];

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                positions[x, y] = new Vector2(startX + x * offset, startY + y * offset);

                GameObject block = Instantiate(blockPrefab, positions[x, y], Quaternion.identity);
                block.SetActive(false); // Desativado por padrão.

                boardBlocks[new Vector2Int(x, y)] = block;
            }
        }
    }

    void InitializeSnake()
    {
        snake = new Snake(new Vector2Int(5, 10), new Vector2Int(1, 0));
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && snake.direction.y == 0)
            snake.direction = new Vector2Int(0, 1);
        if (Input.GetKeyDown(KeyCode.DownArrow) && snake.direction.y == 0)
            snake.direction = new Vector2Int(0, -1);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && snake.direction.x == 0)
            snake.direction = new Vector2Int(-1, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow) && snake.direction.x == 0)
            snake.direction = new Vector2Int(1, 0);
    }

    IEnumerator SnakeMovementRoutine()
    {
        while (true)
        {
            snake.Move();
            CheckCollisions();
            UpdateGameBoard();

            yield return new WaitForSeconds(0.5f); // Velocidade da cobrinha.
        }
    }

    void CheckCollisions()
    {
        Vector2Int headPos = snake.segments[0];

        for (int i = 1; i < snake.segments.Count; i++)
        {
            if (snake.segments[i] == headPos)
            {
                GameOver();
                return;
            }
        }

        if (headPos == applePosition)
        {
            snake.Grow();
            PlaceApple();
        }
    }

    void UpdateGameBoard()
    {
        foreach (var block in boardBlocks.Values)
        {
            block.SetActive(false);
        }

        foreach (Vector2Int pos in snake.segments)
        {
            boardBlocks[pos].SetActive(true);
        }

        boardBlocks[applePosition].SetActive(true);
    }

    void PlaceApple()
    {
        do
        {
            applePosition = new Vector2Int(Random.Range(0, 10), Random.Range(0, 20));
        } while (snake.segments.Contains(applePosition));

        boardBlocks[applePosition].SetActive(true);
    }

    void GameOver()
    {
        StopAllCoroutines();
        // TODO: Implemente a lógica do GameOver aqui. Você pode mostrar uma mensagem, reiniciar o jogo, etc.
    }
}
