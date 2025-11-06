using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercicio1.Utils
{
    public class Menu
    {

        GrafoAdjacencia grafo = new GrafoAdjacencia();
        public void Inicializar()
        {
            while (true)
            {
                Console.WriteLine("\n=== Exercicio 1 ===");
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
                if (opcao == null) opcao = "";

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
                        if (vertice == null) 
                            vertice = "";
                        grafo.InserirVertice(vertice);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Origem: ");
                        string? origem = Console.ReadLine();
                        if (origem == null) origem = "";
                        Console.Write("Destino: ");
                        string? destino = Console.ReadLine();
                        if (destino == null) destino = "";
                        grafo.InserirAresta(origem, destino);
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Vértice a remover: ");
                        string? remover = Console.ReadLine();
                        if (remover == null) remover = "";
                        grafo.RemoverVertice(remover);
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Origem: ");
                        origem = Console.ReadLine();
                        if (origem == null) origem = "";
                        Console.Write("Destino: ");
                        destino = Console.ReadLine();
                        if (destino == null) destino = "";
                        grafo.RemoverAresta(origem, destino);
                        break;

                    case "6":
                        Console.Clear();
                        Console.Write("Vértice: ");
                        vertice = Console.ReadLine();
                        if (vertice == null) 
                            vertice = "";
                        grafo.ListarVizinhos(vertice);
                        break;

                    case "7":
                        Console.Clear();
                        Console.Write("Origem: ");
                        origem = Console.ReadLine();
                        if (origem == null) 
                            origem = "";
                        Console.Write("Destino: ");
                        destino = Console.ReadLine();
                        if (destino == null) 
                            destino = "";

                        if (grafo.ExisteAresta(origem, destino))
                            Console.WriteLine("Aresta existe.");
                        else
                            Console.WriteLine("Aresta não existe.");
                        break;

                    case "8":
                        Console.Clear();
                        grafo.MostrarGraus();
                        break;

                    case "9":
                        Console.Clear();
                        Console.Write("Digite o percurso (separado por espaço): ");
                        string? entrada = Console.ReadLine();
                        if (entrada == null) entrada = "";
                        var caminho = entrada.Split(" ").ToList();

                        if (grafo.PercursoValido(caminho))
                            Console.WriteLine("Percurso é válido.");
                        else
                            Console.WriteLine("Percurso inválido.");
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