using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3.Utils
{
    public class Grafo
    {
        private List<string> vertices = new List<string>();
        private List<(string origem, string destino)> arestas = new List<(string, string)>();

        public void InserirVertice(string vertice)
        {
            if (!vertices.Contains(vertice))
            {
                vertices.Add(vertice);
                Console.WriteLine($"Vértice '{vertice}' adicionado.");
            }
            else
            {
                Console.WriteLine($"O vértice '{vertice}' já existe.");
            }
        }

        public void RemoverVertice(string vertice)
        {
            if (vertices.Contains(vertice))
            {
                vertices.Remove(vertice);
                arestas.RemoveAll(a => a.origem == vertice || a.destino == vertice);
                Console.WriteLine($"Vértice '{vertice}' removido.");
            }
            else
            {
                Console.WriteLine($"O vértice '{vertice}' não existe.");
            }
        }

        public void InserirAresta(string origem, string destino, bool naoDirecionado = false)
        {
            if (!vertices.Contains(origem)) 
                InserirVertice(origem);
            if (!vertices.Contains(destino)) 
                InserirVertice(destino);

            if (!arestas.Contains((origem, destino)))
            {
                arestas.Add((origem, destino));
                if (naoDirecionado && !arestas.Contains((destino, origem)))
                {
                    arestas.Add((destino, origem));
                }
                Console.WriteLine($"Aresta {origem} -> {destino} adicionada.");
            }
            else
            {
                Console.WriteLine($"Aresta {origem} -> {destino} já existe.");
            }
        }

        public void RemoverAresta(string origem, string destino, bool naoDirecionado = false)
        {
            if (arestas.Remove((origem, destino)))
            {
                if (naoDirecionado) arestas.Remove((destino, origem));
                Console.WriteLine($"Aresta {origem} -> {destino} removida.");
            }
            else
            {
                Console.WriteLine($"Aresta {origem} -> {destino} não encontrada.");
            }
        }

        public bool ExisteAresta(string origem, string destino)
        {
            return arestas.Contains((origem, destino));
        }

        public List<string> Vizinhos(string vertice)
        {
            List<string> vizinhos = new List<string>();

            foreach (var a in arestas)
            {
                if (a.origem == vertice)
                    vizinhos.Add(a.destino);
            }

            return vizinhos;
        }

        public void ListarVizinhos(string vertice)
        {
            if (!vertices.Contains(vertice))
            {
                Console.WriteLine("Vértice não encontrado.");
                return;
            }

            var vizinho = Vizinhos(vertice);
            if (vizinho.Count == 0)
                Console.WriteLine($"O vértice {vertice} não possui vizinhos.");
            else
                Console.WriteLine($"Vizinhos de {vertice}: {string.Join(", ", vizinho)}");
        }

        public void MostrarGraus()
        {
            foreach (var v in vertices)
            {
                int saida = 0;
                int entrada = 0;

                foreach (var a in arestas)
                {
                    if (a.origem == v)
                    {
                        saida++;
                    }

                    if (a.destino == v)
                    {
                        entrada++;
                    }
                }

                int total = entrada + saida;
                Console.WriteLine(v + ": entrada=" + entrada + ", saída=" + saida + ", total=" + total);
            }
        }

        public bool PercursoValido(List<string> caminho)
        {
            for (int i = 0; i < caminho.Count - 1; i++)
            {
                string u = caminho[i];
                string v = caminho[i + 1];
                if (!ExisteAresta(u, v))
                    return false;
            }
            return true;
        }

        public void Exibir()
        {
            Console.WriteLine("Vértices: " + string.Join(", ", vertices));
            if (arestas.Count == 0)
            {
                Console.WriteLine("Nenhuma aresta registrada.");
                return;
            }

            foreach (var (origem, destino) in arestas)
            {
                Console.WriteLine($"{origem} -> {destino}");
            }
        }
    }
}

