
using Exercicio3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio_3.Utils
{
    public class Menu
    {
        Grafo grafo = new Grafo();

        public void Inicializar()
        {
            while (true)
            {
                Console.WriteLine("\n=== Exercicio 3 ===");
                Console.WriteLine("1 - Mostrar o Grafo");
                Console.WriteLine("2 - Inserir Vértice");
                Console.WriteLine("3 - Inserir Aresta");
                Console.WriteLine("4 - Remover Vértice");
                Console.WriteLine("5 - Remover Aresta");
                Console.WriteLine("6 - Listar Vizinhos");
                Console.WriteLine("7 - Verificar Existência de Aresta");
                Console.WriteLine("8 - Mostrar Grau dos Vértices");
                Console.WriteLine("9 - Verificar Percurso");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        grafo.Exibir();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Nome do vértice: ");
                        string? vertice = Console.ReadLine();
                        grafo.InserirVertice(vertice);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Origem: ");
                        string? origem = Console.ReadLine();
                        Console.Write("Destino: ");
                        string? destino = Console.ReadLine();
                        grafo.InserirAresta(origem, destino);
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Vértice a remover: ");
                        string? verticeRemover = Console.ReadLine();
                        grafo.RemoverVertice(verticeRemover);
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Origem: ");
                        string? origemRemover = Console.ReadLine();
                        Console.Write("Destino: ");
                        string? destinoRemover = Console.ReadLine();
                        grafo.RemoverAresta(origemRemover, destinoRemover);
                        break;

                    case "6":
                        Console.Clear();
                        Console.Write("Vértice: ");
                        string? verticeVizinho = Console.ReadLine();
                        grafo.ListarVizinhos(verticeVizinho);
                        break;

                    case "7":
                        Console.Clear();
                        Console.Write("Origem: ");
                        string? origemVerifica = Console.ReadLine();
                        Console.Write("Destino: ");
                        string? destinoVerifica = Console.ReadLine();

                        bool existe = grafo.ExisteAresta(origemVerifica, destinoVerifica);
                        if (existe)
                        {
                            Console.WriteLine("Aresta existe.");
                        }
                        else
                        {
                            Console.WriteLine("Aresta NÃO existe.");
                        }
                        break;

                    case "8":
                        Console.Clear();
                        grafo.MostrarGraus();
                        break;

                    case "9":
                        Console.Clear();
                        Console.Write("Digite o percurso (separado por espaço): ");
                        string entrada = Console.ReadLine();
                        List<string> caminho = entrada.Split(" ").ToList();

                        bool valido = grafo.PercursoValido(caminho);
                        if (valido)
                        {
                            Console.WriteLine("Percurso é válido.");
                        }
                        else
                        {
                            Console.WriteLine("Percurso inválido.");
                        }
                        break;

                    case "0":
                        Console.Clear();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
