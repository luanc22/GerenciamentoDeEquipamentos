using System;

namespace GerenciamentoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool fecharApp = false;
            while (fecharApp == false)
            {
                Cabecalho();

                Console.Write("Digite seu nome: ");
                string nomeLogin = Console.ReadLine();
                string opcaoEscolhida = "";
                opcaoEscolhida = Menu(nomeLogin, opcaoEscolhida);
                string opcaoEscolhidaMenus = "";

                if (opcaoEscolhida == "1")
                {
                    opcaoEscolhidaMenus = MenuControleDeEquipamentos(opcaoEscolhidaMenus);
                }
                else if (opcaoEscolhida == "2")
                {
                    opcaoEscolhidaMenus = MenuControleDeChamados(opcaoEscolhidaMenus);
                }
            }
        }

        #region Methods. [WIP]
        static void Cabecalho()
        {
            Console.WriteLine("===== Gestão de Equipamentos =====");
            Console.WriteLine("");
            Console.WriteLine(" Programa criado para com o objetivo de gerenciar e manusear inventário de equipamentos e chamados.");
            Console.WriteLine("");
            Console.WriteLine("===================================");
            Console.WriteLine("");
        }

        static string Menu(string nomeLogin, string opcaoEscolhida)
        {
            bool opcaoValida = false;
            while (opcaoValida == false)
            {


                Console.Clear();
                Cabecalho();
                Console.WriteLine("Seja bem-vindo, {0}!", nomeLogin);
                Console.WriteLine("");
                Console.WriteLine("Escolha uma das opcoes a baixo para prosseguir.");
                Console.WriteLine("");
                Console.WriteLine("[1] - Controle de Equipamentos.");
                Console.WriteLine("[2] - Controle de Chamados.");
                Console.WriteLine("");
                Console.Write("Opcao escolhida: ");
                opcaoEscolhida = Console.ReadLine();
                opcaoEscolhida = opcaoEscolhida.Replace(" ", "");

                if (opcaoEscolhida == "1")
                {
                    opcaoValida = true;
                }
                else if (opcaoEscolhida == "2")
                {
                    opcaoValida = true;
                }
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcao invalida! Por favor, tente novamente com uma opcao valida!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                }

            }
            return opcaoEscolhida;
        }

        static string MenuControleDeEquipamentos(string opcaoEscolhidaMenus)
        {
            Console.Clear();
            Cabecalho();
            Console.WriteLine("[1] - Registrar equipamentos.");
            Console.WriteLine("[2] - Mostrar equipamentos do inventario.");
            Console.WriteLine("[3] - Editar equipamentos.");
            Console.WriteLine("[4] - Excluir equipamentos.");
            Console.WriteLine("[5] - Voltar ao menu.");
            Console.WriteLine("");
            Console.Write("Opcao escolhida: ");
            opcaoEscolhidaMenus = Console.ReadLine();
            opcaoEscolhidaMenus = opcaoEscolhidaMenus.Replace(" ", "");

            return opcaoEscolhidaMenus;

        }

        static string MenuControleDeChamados(string opcaoEscolhidaMenus)
        {
            Console.Clear();
            Cabecalho();
            Console.WriteLine("[1] - Registrar chamado.");
            Console.WriteLine("[2] - Mostrar chamados registrados.");
            Console.WriteLine("[3] - Editar detalhes de chamado.");
            Console.WriteLine("[4] - Excluir chamados.");
            Console.WriteLine("[5] - Voltar ao menu.");
            Console.WriteLine("");
            Console.Write("Opcao escolhida: ");
            opcaoEscolhidaMenus = Console.ReadLine();
            opcaoEscolhidaMenus = opcaoEscolhidaMenus.Replace(" ", "");

            return opcaoEscolhidaMenus;

        }

        static void Creditos()
        {
            Console.WriteLine("Criação, programação e manutenção: Luan do Vale Cabral.");
        }
        #endregion

    }
}
