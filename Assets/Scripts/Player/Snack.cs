using System.Collections.Generic;
using UnityEngine;

public class Snake
{
    public List<Vector2Int> segments = new List<Vector2Int>();
    public Vector2Int direction;

    public Snake(Vector2Int initialPosition, Vector2Int initialDirection)
    {
        segments.Add(initialPosition); // Inicialmente, a cobrinha tem um segmento (a cabeça).
        direction = initialDirection;
    }

    public void Move()
    {
        // Move a cabeça na direção atual.
        Vector2Int newHeadPosition = segments[0] + direction;

        // Adiciona o novo segmento da cabeça na lista.
        segments.Insert(0, newHeadPosition);

        // Remove o último segmento (a "cauda") - isso simula o movimento.
        // Se a cobrinha crescer (comer uma maçã), nós não queremos remover o último segmento neste movimento.
        // Isso faz parecer que a cobrinha cresceu por um segmento.
        if (willGrow)
        {
            willGrow = false; // Reseta a flag.
        }
        else
        {
            segments.RemoveAt(segments.Count - 1);
        }
    }

    private bool willGrow = false;

    public void Grow()
    {
        willGrow = true; // A próxima vez que a cobrinha se mover, ela não perderá seu último segmento.
    }
}
