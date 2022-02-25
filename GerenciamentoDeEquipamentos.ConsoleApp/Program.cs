using System;

namespace GerenciamentoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool fecharApp = false;
            bool primeiraVez = true;
            string nomeLogin = "";
            string[] nomeEquipamento = new string[100];
            double[] precoEquipamento = new double[100];
            string[] numeroSerieEquipamento = new string[100];
            string[] dataFabricacaoEquipamento = new string[100];
            string[] fabricanteEquipamento = new string[100];
            int totalDeEquipamentos = 0;
            int totalDeEquipamentosAtual = 0;

            while (fecharApp == false)
            {
                Cabecalho();

                if (primeiraVez == true)
                {
                    Console.Write("Digite seu nome: ");
                    nomeLogin = Console.ReadLine();
                }

                string opcaoEscolhida = "";
                opcaoEscolhida = Menu(nomeLogin, opcaoEscolhida);

                bool opcaoValida = false;
                string opcaoEscolhidaMenus = "";
                if (opcaoEscolhida == "1")
                {
                    opcaoEscolhidaMenus = MenuControleDeEquipamentos(opcaoEscolhidaMenus);

                    while (opcaoValida == false)
                    {
                        if (opcaoEscolhidaMenus == "1")
                        {
                            opcaoValida = true;
                            totalDeEquipamentos = RegistrarEquipamento(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, totalDeEquipamentos);
                            totalDeEquipamentosAtual = totalDeEquipamentosAtual + totalDeEquipamentos;
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "2")
                        {
                            opcaoValida = true;
                            MostrarInventario(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, totalDeEquipamentosAtual);
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "3")
                        {
                            //Continuar aqui
                            opcaoValida = true;

                        }
                        else if (opcaoEscolhidaMenus == "4")
                        {
                            opcaoValida = true;

                        }
                        else if (opcaoEscolhidaMenus == "5")
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
                }
                else if (opcaoEscolhida == "2")
                {
                    opcaoEscolhidaMenus = MenuControleDeChamados(opcaoEscolhidaMenus);

                    while (opcaoValida == false)
                    {
                        if (opcaoEscolhidaMenus == "1")
                        {
                            opcaoValida = true;
                        }
                        else if (opcaoEscolhidaMenus == "2")
                        {
                            opcaoValida = true;

                        }
                        else if (opcaoEscolhidaMenus == "3")
                        {
                            opcaoValida = true;

                        }
                        else if (opcaoEscolhidaMenus == "4")
                        {
                            opcaoValida = true;

                        }
                        else if (opcaoEscolhidaMenus == "5")
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
                }
            }
        }

        #region Methods Menu. [WIP]
        static void Cabecalho()
        {
            Console.WriteLine("===== Gestão de Equipamentos =====");
            Console.WriteLine("");
            Console.WriteLine("Programa criado para com o objetivo de gerenciar e manusear inventário de equipamentos e chamados.");
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

        #region Metodos Equipamentos. [WIP]

        static string[] RetornarNome(string[] nomeEquipamento)
        {
            return nomeEquipamento;
        }

        static double[] RetornarPreco(double[] precoEquipamento)
        {
            return precoEquipamento;
        }

        static string[] RetornarNDeSerie(string[] numeroSerieEquipamento)
        {
            return numeroSerieEquipamento;
        }

        static string[] RetornarDataFabricacao(string[] dataFabricacaoEquipamento)
        {
            return dataFabricacaoEquipamento;
        }

        static string[] RetornarFabricante(string[] fabricanteEquipamento)
        {
            return fabricanteEquipamento;
        }

        static int RegistrarEquipamento(string[] nomeEquipamento, double[] precoEquipamento, string[] numeroSerieEquipamento, string[] dataFabricacaoEquipamento, string[] fabricanteEquipamento, int totalDeEquipamentos)
        {
            Console.Clear();
            Cabecalho();

            string equipamentosParaRegistrar = "0";
            bool numeroValido;
            int i = 0;

            bool verificarNumerosARegistrar = false;
            while (verificarNumerosARegistrar == false)
            {
                Console.Write("Quantos equipamentos deseja registrar: ");
                equipamentosParaRegistrar = Console.ReadLine();
                numeroValido = int.TryParse(equipamentosParaRegistrar, out _);


                if (numeroValido == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digito invalido! Por favor, digite um numero!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                }
                else
                {
                    verificarNumerosARegistrar = true;
                }
            }

            int equipamentosRegistrar = int.Parse(equipamentosParaRegistrar);

            Console.WriteLine("");

            int contadorTotal = 0;

            if(totalDeEquipamentos == 0)
            {
               contadorTotal = 0;
            }
            else
            {
                contadorTotal = totalDeEquipamentos;
            }
            int contador = 0;

            string confirmarRegistro;
            string precoEquipamentoString;
            bool opcaoValida;
            for (i = 0; i < equipamentosRegistrar; i++)
            {
                Console.Clear();
                Cabecalho();

                opcaoValida = false;
                Console.WriteLine("===== Registro do equipamento {0} =====", contadorTotal+1);
                Console.WriteLine("");

                Console.Write("Digite o nome do equipamento: ");
                nomeEquipamento[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");

                Console.Write("Digite o preco do equipamento: ");
                precoEquipamentoString = Console.ReadLine();
                precoEquipamento[contadorTotal] = double.Parse(precoEquipamentoString);

                Console.WriteLine("");

                Console.Write("Digite o numero de serie do equipamento: ");
                numeroSerieEquipamento[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");

                Console.Write("Digite a data de fabricacao do equipamento: ");
                dataFabricacaoEquipamento[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");

                Console.Write("Digite a fabricante do equipamento: ");
                fabricanteEquipamento[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("Voce confirmar as informacoes digitadas? Digite 'Sim' ou 'Nao'.");
                Console.Write("Opcao escolhida: ");
                confirmarRegistro = Console.ReadLine();
                confirmarRegistro = confirmarRegistro.ToUpper();
                contador++;
                contadorTotal++;

                while (opcaoValida == false)
                {


                    if (confirmarRegistro == "SIM")
                    {
                        break;
                    }
                    else if (confirmarRegistro == "NAO")
                    {
                        opcaoValida = true;
                        Console.WriteLine("");
                        Console.Write("Aperte ENTER para realizar o registro do equipamento novamente.");
                        Console.ReadLine();
                        i--;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcao invalida! Por favor, tente novamente com uma das opcoes validas!");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Aperte ENTER para prosseguir.");
                        Console.ReadLine();
                        Console.WriteLine("Voce confirmar as informacoes digitadas? Digite 'Sim' ou 'Nao'.");
                        Console.Write("Opcao escolhida: ");
                        confirmarRegistro = Console.ReadLine();
                        confirmarRegistro = confirmarRegistro.ToUpper();
                    }
                }
            }

            RetornarNome(nomeEquipamento);
            RetornarPreco(precoEquipamento);
            RetornarNDeSerie(numeroSerieEquipamento);
            RetornarDataFabricacao(dataFabricacaoEquipamento);
            RetornarFabricante(fabricanteEquipamento);
            totalDeEquipamentos = contador;
            return totalDeEquipamentos;
        }
        
        static void MostrarInventario(string[] nomeEquipamento, double[] precoEquipamento, string[] numeroSerieEquipamento, string[] dataFabricacaoEquipamento, string[] fabricanteEquipamento, int totalDeEquipamentos)
        {
            Console.Clear();
            Cabecalho();

            Console.WriteLine("===== Inventario de Equipamentos =====");
            Console.WriteLine("");
            Console.WriteLine("Total de itens: " + totalDeEquipamentos);

            if(totalDeEquipamentos == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Nao existem equipamentos cadastrados.");
                Console.WriteLine("");
                Console.Write("Aperte ENTER para prosseguir.");
                Console.ReadLine();
                return;
            }
            
            for(int i = 0; i < totalDeEquipamentos; i++)
            {
                Console.WriteLine("=============== Equipamento {0} ===============", i+1);
                Console.WriteLine("");
                Console.WriteLine("Nome do Produto: " + nomeEquipamento[i]);
                Console.WriteLine("");
                Console.WriteLine("Preco do Produto: " + precoEquipamento[i]);
                Console.WriteLine("");
                Console.WriteLine("Numero de Serie do Produto: " + numeroSerieEquipamento[i]);
                Console.WriteLine("");
                Console.WriteLine("Data de Fabricacao do Produto: " + dataFabricacaoEquipamento[i]);
                Console.WriteLine("");
                Console.WriteLine("Fabricante do Produto: " + fabricanteEquipamento[i]);
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
        #endregion

    }
}
