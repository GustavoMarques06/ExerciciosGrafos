using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.Utils
{
    public class GrafoMatriz
    {
        public List<string> Vertices { get; private set; }
        public List<List<int>> Matriz { get; private set; }

        public GrafoMatriz()
        {
            Vertices = new List<string>();
            Matriz = new List<List<int>>();
        }

        public void InserirVertice(string vertice)
        {
            if (Vertices.Contains(vertice))
            {
                Console.WriteLine($"Vértice '{vertice}' já existe.");
                return;
            }

            Vertices.Add(vertice);
            foreach (var linha in Matriz)
            {
                linha.Add(0);
            }

            var novaLinha = new List<int>(new int[Vertices.Count]);
            Matriz.Add(novaLinha);

            Console.WriteLine($"Vértice '{vertice}' adicionado.");
        }

        public void InserirAresta(string origem, string destino, bool naoDirecionado = false)
        {
            if (!Vertices.Contains(origem))
                InserirVertice(origem);
            if (!Vertices.Contains(destino))
                InserirVertice(destino);

            int i = Vertices.IndexOf(origem);
            int j = Vertices.IndexOf(destino);

            Matriz[i][j] = 1;
            if (naoDirecionado)
                Matriz[j][i] = 1;

            Console.WriteLine($"Aresta adicionada: {origem} -> {destino}");
        }

        public void RemoverVertice(string vertice)
        {
            if (!Vertices.Contains(vertice))
            {
                Console.WriteLine($"Vértice '{vertice}' não existe.");
                return;
            }

            int indice = Vertices.IndexOf(vertice);
            Matriz.RemoveAt(indice);

            foreach (var linha in Matriz)
            {
                linha.RemoveAt(indice);
            }

            Vertices.RemoveAt(indice);
            Console.WriteLine($"Vértice '{vertice}' e suas arestas foram removidos.");
        }

        public void RemoverAresta(string origem, string destino, bool naoDirecionado = false)
        {
            if (!Vertices.Contains(origem) || !Vertices.Contains(destino))
            {
                Console.WriteLine("Um dos vértices não existe.");
                return;
            }

            int i = Vertices.IndexOf(origem);
            int j = Vertices.IndexOf(destino);

            Matriz[i][j] = 0;
            if (naoDirecionado)
                Matriz[j][i] = 0;

            Console.WriteLine($"Aresta removida: {origem} -> {destino}");
        }

        public bool ExisteAresta(string origem, string destino)
        {
            if (!Vertices.Contains(origem) || !Vertices.Contains(destino))
                return false;

            int i = Vertices.IndexOf(origem);
            int j = Vertices.IndexOf(destino);
            return Matriz[i][j] == 1;
        }

        public List<string> Vizinhos(string vertice)
        {
            var vizinhos = new List<string>();
            if (!Vertices.Contains(vertice))
                return vizinhos;

            int i = Vertices.IndexOf(vertice);
            for (int j = 0; j < Vertices.Count; j++)
            {
                if (Matriz[i][j] == 1)
                    vizinhos.Add(Vertices[j]);
            }

            return vizinhos;
        }

        public void ListarVizinhos(string vertice)
        {
            if (!Vertices.Contains(vertice))
            {
                Console.WriteLine($"Vértice '{vertice}' não existe.");
                return;
            }

            var vizinhos = Vizinhos(vertice);
            Console.WriteLine($"Vizinhos de {vertice}: {string.Join(", ", vizinhos)}");
        }

        public void MostrarGraus()
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                int saida = Matriz[i].Sum();
                int entrada = 0;

                for (int j = 0; j < Vertices.Count; j++)
                {
                    entrada += Matriz[j][i];
                }

                Console.WriteLine($"{Vertices[i]} -> Entrada: {entrada}, Saída: {saida}, Total: {entrada + saida}");
            }
        }

        public bool PercursoValido(List<string> caminho)
        {
            if (caminho.Count < 2)
                return true;

            for (int i = 0; i < caminho.Count - 1; i++)
            {
                if (!ExisteAresta(caminho[i], caminho[i + 1]))
                    return false;
            }

            return true;
        }

        public void Exibir()
        {
            foreach (var v in Vertices)
                Console.Write($"{v,4}");
            Console.WriteLine();

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write($"{Vertices[i],4}");
                for (int j = 0; j < Vertices.Count; j++)
                {
                    Console.Write($"{Matriz[i][j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}

