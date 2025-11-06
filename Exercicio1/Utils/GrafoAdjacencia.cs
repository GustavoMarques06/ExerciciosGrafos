namespace Exercicio1.Utils
{
    public class GrafoAdjacencia
    {
        private Dictionary<string, List<string>> adjacencias = new();

        public void InserirVertice(string vertice)
        {
            if (!adjacencias.ContainsKey(vertice))
                adjacencias[vertice] = new List<string>();
            else
                Console.WriteLine("Vértice já existe!");
        }

        public void InserirAresta(string origem, string destino)
        {
            if (!adjacencias.ContainsKey(origem) || !adjacencias.ContainsKey(destino))
            {
                Console.WriteLine("Um dos vértices não existe!");
                return;
            }

            if (!adjacencias[origem].Contains(destino))
                adjacencias[origem].Add(destino);
        }

        public void RemoverVertice(string vertice)
        {
            if (!adjacencias.Remove(vertice))
            {
                Console.WriteLine("Vértice não encontrado!");
                return;
            }

            foreach (var lista in adjacencias.Values)
                lista.Remove(vertice);
        }

        public void RemoverAresta(string origem, string destino)
        {
            if (adjacencias.ContainsKey(origem))
                adjacencias[origem].Remove(destino);
        }

        public void ListarVizinhos(string vertice)
        {
            if (!adjacencias.ContainsKey(vertice))
            {
                Console.WriteLine("Vértice não encontrado!");
                return;
            }

            Console.WriteLine($"Vizinhos de {vertice}: {string.Join(", ", adjacencias[vertice])}");
        }

        public bool ExisteAresta(string origem, string destino)
        {
            return adjacencias.ContainsKey(origem) && adjacencias[origem].Contains(destino);
        }

        public void MostrarGraus()
        {
            foreach (var v in adjacencias)
                Console.WriteLine($"{v.Key}: Grau = {v.Value.Count}");
        }

        public bool PercursoValido(List<string> caminho)
        {
            for (int i = 0; i < caminho.Count - 1; i++)
                if (!ExisteAresta(caminho[i], caminho[i + 1]))
                    return false;
            return true;
        }

        public void Exibir()
        {
            Console.WriteLine("\n=== GRAFO ===");
            foreach (var v in adjacencias)
                Console.WriteLine($"{v.Key} -> {string.Join(", ", v.Value)}");
        }
    }
}
