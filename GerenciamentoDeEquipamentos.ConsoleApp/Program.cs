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
            string[] nomeEquipamento = new string[1000];
            double[] precoEquipamento = new double[1000];
            string[] numeroSerieEquipamento = new string[1000];
            string[] dataFabricacaoEquipamento = new string[1000];
            string[] fabricanteEquipamento = new string[1000];
            string[] tituloChamado = new string[1000];
            string[] descricaoChamado = new string[1000];
            string[] dataAberturaChamado = new string[1000];
            int[] numeroEquipamentoChamado = new int[1000];
            int totalDeEquipamentosCont = 0;
            int totalDeEquipamentosAtual = 0;
            int totalDeChamadosCont = 0;
            int totalDeChamadosAtual = 0;

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
                            totalDeEquipamentosCont = RegistrarEquipamento(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, totalDeEquipamentosAtual);
                            totalDeEquipamentosAtual = totalDeEquipamentosAtual + totalDeEquipamentosCont;
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
                            opcaoValida = true;
                            EditarInventario(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, totalDeEquipamentosAtual);
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "4")
                        {
                            opcaoValida = true;
                            totalDeEquipamentosCont = ExcluirEquipamento(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, numeroEquipamentoChamado, totalDeEquipamentosAtual);
                            totalDeEquipamentosAtual = totalDeEquipamentosAtual - totalDeEquipamentosCont;
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "5")
                        {
                            opcaoValida = true;
                            primeiraVez = false;
                            Console.Clear();

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
                            totalDeChamadosCont = RegistrarChamado(tituloChamado, descricaoChamado, dataAberturaChamado, numeroEquipamentoChamado, totalDeChamadosAtual);
                            totalDeChamadosAtual = totalDeChamadosAtual + totalDeChamadosCont;
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "2")
                        {
                            opcaoValida = true;
                            MostrarChamados(tituloChamado, descricaoChamado, dataAberturaChamado, numeroEquipamentoChamado, nomeEquipamento, totalDeChamadosAtual);
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "3")
                        {
                            opcaoValida = true;
                            EditarChamados(tituloChamado, descricaoChamado, dataAberturaChamado, numeroEquipamentoChamado, totalDeChamadosAtual);
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "4")
                        {
                            opcaoValida = true;
                            totalDeChamadosCont = ExcluirChamados(tituloChamado, descricaoChamado, dataAberturaChamado, numeroEquipamentoChamado, totalDeChamadosAtual);
                            totalDeChamadosAtual = totalDeChamadosAtual - totalDeChamadosCont;
                            primeiraVez = false;
                            Console.Clear();
                        }
                        else if (opcaoEscolhidaMenus == "5")
                        {
                            opcaoValida = true;
                            primeiraVez = false;
                            Console.Clear();

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

        #region Methods Menu. [OK]
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

        #region Metodos Equipamentos. [OK]

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
                    Console.WriteLine("ERRO!");
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

            if (totalDeEquipamentos == 0)
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
                Console.WriteLine("===== Registro do equipamento {0} =====", contadorTotal + 1);
                Console.WriteLine("");

                Console.Write("Digite o nome do equipamento: ");
                nomeEquipamento[contadorTotal] = Console.ReadLine();

                if (nomeEquipamento[contadorTotal].Length <= 6)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Nome do equipamento deve conter no minimo 6 caracteres!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    i--;
                    continue;
                }

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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine("Equipamento adicionado com sucesso!");
                        Console.WriteLine("");
                        Console.ResetColor();
                        Console.Write("Aperte ENTER para prosseguir.");
                        Console.ReadLine();
                        break;
                    }
                    else if (confirmarRegistro == "NAO")
                    {
                        opcaoValida = true;
                        Console.WriteLine("");
                        Console.Write("Aperte ENTER para realizar o registro do equipamento novamente.");
                        Console.ReadLine();
                        contadorTotal--;
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
            Console.WriteLine("");

            if (totalDeEquipamentos == 0)
            {
                Console.WriteLine("Nao existem equipamentos cadastrados.");
                Console.WriteLine("");
                Console.Write("Aperte ENTER para prosseguir.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=============== Equipamentos ===============");
            Console.WriteLine("");
            Console.WriteLine("{0, -10} | {1, -55} | {2, -35}", "ID", "Nome do Equipamento", "Fabricante");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < totalDeEquipamentos; i++)
            {
                Console.Write("{0, -10} | {1, -55} | {2, -35}", i+1, nomeEquipamento[i], fabricanteEquipamento[i]);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.Write("Aperte ENTER para prosseguir.");
            Console.ReadLine();
        }

        static void EditarInventario(string[] nomeEquipamento, double[] precoEquipamento, string[] numeroSerieEquipamento, string[] dataFabricacaoEquipamento, string[] fabricanteEquipamento, int totalDeEquipamentos)
        {
            if (totalDeEquipamentos == 0)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO!");
                Console.WriteLine("Nao existem equipamentos registrados, registre pelo menos um equipamento!");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Aperte ENTER para prosseguir.");
                Console.ReadLine();
                return;
            }

            bool opcaoValida = false;
            int equipamentoAEditar = 0;
            while (opcaoValida == false)
            {
                MostrarInventario(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, totalDeEquipamentos);

                Console.WriteLine("");
                Console.WriteLine("Qual equipamento deseja editar?");
                Console.Write("Numero do equipamento: ");
                string inputEquipamento = Console.ReadLine();
                int numeroEquipamento;
                bool validaEquipamento = int.TryParse(inputEquipamento, out numeroEquipamento);
                int contador = 0;

                if (validaEquipamento == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Digito invalido! Por favor, digite um numero!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                }
                else
                {
                    for (int i = 1; i <= totalDeEquipamentos; i++)
                    {
                        if (numeroEquipamento == i)
                        {
                            equipamentoAEditar = i;
                            opcaoValida = true;
                            break;
                        }
                        else if (contador == totalDeEquipamentos - 1)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERRO!");
                            Console.WriteLine("Equipamento nao encontrado! Digite um numero de equipamento valido.");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("Aperte ENTER para prosseguir.");
                            Console.ReadLine();
                        }
                        contador++;
                    }
                }
            }

            Console.Clear();
            Cabecalho();

            equipamentoAEditar = equipamentoAEditar - 1;

            Console.WriteLine("===== Equipamento {0} =====", equipamentoAEditar + 1);
            Console.WriteLine("");
            Console.WriteLine("Nome do Equipamento: " + nomeEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Preco do Equipamento: " + precoEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Numero de Serie do Equipamento: " + numeroSerieEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Data de Fabricacao do Equipamento: " + dataFabricacaoEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Fabricante do Equipamento: " + fabricanteEquipamento[equipamentoAEditar]);
            Console.WriteLine("");

            Console.WriteLine("O que deseja editar?");
            Console.WriteLine("[1] - Nome.");
            Console.WriteLine("[2] - Preco.");
            Console.WriteLine("[3] - Numero de Serie.");
            Console.WriteLine("[4] - Data de Fabricao.");
            Console.WriteLine("[5] - Fabricante.");
            Console.WriteLine("");
            Console.Write("Opcao escolhida: ");
            string inputOpcaoEditar = Console.ReadLine();
            Console.WriteLine("");
            //fazer tratamento de erro depois se tiver tempo

            int opcaoEditar = int.Parse(inputOpcaoEditar);

            switch (opcaoEditar)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome para o equipamento.");
                    Console.Write("Editar: ");
                    nomeEquipamento[equipamentoAEditar] = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Digite o novo preco para o equipamento.");
                    Console.Write("Editar: ");
                    string novoPreco = Console.ReadLine();
                    precoEquipamento[equipamentoAEditar] = double.Parse(novoPreco);
                    break;
                case 3:
                    Console.WriteLine("Digite o novo numero de serie para o equipamento.");
                    Console.Write("Editar: ");
                    numeroSerieEquipamento[equipamentoAEditar] = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Digite a nova data de fabricacao para o equipamento.");
                    Console.Write("Editar: ");
                    dataFabricacaoEquipamento[equipamentoAEditar] = Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Digite o novo fabricante para o equipamento.");
                    Console.Write("Editar: ");
                    fabricanteEquipamento[equipamentoAEditar] = Console.ReadLine();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Equipamento editado com sucesso!");
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write("Aperte ENTER para prosseguir.");
            Console.ReadLine();

            Console.Clear();
            Cabecalho();

            Console.WriteLine("===== Equipamento {0} apos edicao =====", equipamentoAEditar + 1);
            Console.WriteLine("");
            Console.WriteLine("Nome do Equipamento: " + nomeEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Preco do Equipamento: " + precoEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Numero de Serie do Equipamento: " + numeroSerieEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Data de Fabricacao do Equipamento: " + dataFabricacaoEquipamento[equipamentoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Fabricante do Equipamento: " + fabricanteEquipamento[equipamentoAEditar]);
            Console.WriteLine("");

            Console.ReadLine();
        }

        static int ExcluirEquipamento(string[] nomeEquipamento, double[] precoEquipamento, string[] numeroSerieEquipamento, string[] dataFabricacaoEquipamento, string[] fabricanteEquipamento, int[] numeroEquipamentoChamado, int totalDeEquipamentos)
        {
            bool opcaoValida = false;
            int equipamentoAExcluir = 0;
            string[] novaArrayNome = new string[1000];
            double[] novaArrayPreco = new double[1000];
            string[] novaArrayNumeroSerie = new string[1000];
            string[] novaArrayDataFabricacao = new string[1000];
            string[] novaArrayFabricante = new string[1000];
            while (opcaoValida == false)
            {
                MostrarInventario(nomeEquipamento, precoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento, totalDeEquipamentos);

                if (totalDeEquipamentos == 0)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Nao existem equipamentos registrados, registre pelo menos um equipamento!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    return totalDeEquipamentos + 1;
                }

                Console.WriteLine("");
                Console.WriteLine("Qual equipamento deseja excluir?");
                Console.Write("Numero do equipamento: ");
                string inputEquipamento = Console.ReadLine();
                int numeroEquipamento;
                bool validaEquipamento = int.TryParse(inputEquipamento, out numeroEquipamento);
                int contador = 0;

                if (validaEquipamento == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Digito invalido! Por favor, digite um numero!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                }
                else
                {
                    for (int i = 1; i <= totalDeEquipamentos; i++)
                    {
                        if (numeroEquipamento == i)
                        {
                            equipamentoAExcluir = i;
                            opcaoValida = true;
                            break;
                        }
                        else if (contador == totalDeEquipamentos - 1)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERRO!");
                            Console.WriteLine("Equipamento nao encontrado! Digite um numero de equipamento valido.");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("Aperte ENTER para prosseguir.");
                            Console.ReadLine();
                        }
                        contador++;
                    }
                }
            }

            Console.Clear();
            Cabecalho();

            equipamentoAExcluir = equipamentoAExcluir - 1;

            Console.WriteLine("===== Equipamento {0} =====", equipamentoAExcluir + 1);
            Console.WriteLine("");
            Console.WriteLine("Nome do Equipamento: " + nomeEquipamento[equipamentoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Preco do Equipamento: " + precoEquipamento[equipamentoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Numero de Serie do Equipamento: " + numeroSerieEquipamento[equipamentoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Data de Fabricacao do Equipamento: " + dataFabricacaoEquipamento[equipamentoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Fabricante do Equipamento: " + fabricanteEquipamento[equipamentoAExcluir]);
            Console.WriteLine("");

            Console.WriteLine("Tem certeza que deseja excluir essa equipamento? Digite 'Sim' ou 'Nao'.");
            Console.Write("Opcao escolhida: ");
            string confirmacaoExclusao = Console.ReadLine();
            confirmacaoExclusao = confirmacaoExclusao.ToUpper();
            int j = 0;
            
            for(int i = 0; i < numeroEquipamentoChamado.Length; i++)
            {
                if(numeroEquipamentoChamado[i] == equipamentoAExcluir + 1)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Equipamento esta vinculado a um chamado! Exclua o chamado primeiro.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    return totalDeEquipamentos + 1;
                }
            }

            equipamentoAExcluir = equipamentoAExcluir + 1;

            if (confirmacaoExclusao == "SIM")
            {
                for (int i = 0; i < totalDeEquipamentos; i++)
                {
                    if (i == equipamentoAExcluir - 1)
                    {
                        j++;
                        novaArrayNome[i] = nomeEquipamento[j];
                        novaArrayPreco[i] = precoEquipamento[j];
                        novaArrayNumeroSerie[i] = numeroSerieEquipamento[j];
                        novaArrayDataFabricacao[i] = dataFabricacaoEquipamento[j];
                        novaArrayFabricante[i] = fabricanteEquipamento[j];
                        j++;
                        continue;
                    }
                    else
                    {
                        novaArrayNome[i] = nomeEquipamento[j];
                        novaArrayPreco[i] = precoEquipamento[j];
                        novaArrayNumeroSerie[i] = numeroSerieEquipamento[j];
                        novaArrayDataFabricacao[i] = dataFabricacaoEquipamento[j];
                        novaArrayFabricante[i] = fabricanteEquipamento[j];
                        j++;
                    }
                }

                for (int i = 0; i < 1000; i++)
                {
                    nomeEquipamento[i] = novaArrayNome[i];
                    precoEquipamento[i] = novaArrayPreco[i];
                    numeroSerieEquipamento[i] = novaArrayNumeroSerie[i];
                    dataFabricacaoEquipamento[i] = novaArrayDataFabricacao[i];
                    fabricanteEquipamento[i] = novaArrayFabricante[i];
                }

                totalDeEquipamentos = totalDeEquipamentos - 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("Equipamento excluido com sucesso!");
                Console.WriteLine("");
                Console.ResetColor();
                Console.Write("Aperte ENTER para prosseguir.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Retorne ao menu e tente novamente.");
                Console.WriteLine("");
                Console.Write("Aperte ENTER para prosseguir.");
                Console.ReadLine();
                return totalDeEquipamentos + 1;
            }

            return totalDeEquipamentos + 1;
        }
        #endregion

        #region Metodos Chamados. [OK]

        static string[] RetornarTitulo(string[] tituloChamado)
        {
            return tituloChamado;
        }

        static int[] RetornarNumeroEquipamentoChamado(int[] numeroEquipamentoChamado)
        {
            return numeroEquipamentoChamado;
        }

        static string[] RetornarDescricao(string[] descricaoChamado)
        {
            return descricaoChamado;
        }

        static string[] RetornarDataAbertura(string[] dataAberturaChamado)
        {
            return dataAberturaChamado;
        }

        static int RegistrarChamado(string[] tituloChamado, string[] descricaoChamado, string[] dataAberturaChamado, int[] numeroEquipamentoChamado, int totalDeChamados)
        {
            Console.Clear();
            Cabecalho();

            string chamadosParaRegistrar = "0";
            bool numeroValido;
            int i = 0;

            bool verificarNumerosARegistrar = false;
            while (verificarNumerosARegistrar == false)
            {
                Console.Write("Quantos chamados deseja registrar: ");
                chamadosParaRegistrar = Console.ReadLine();
                numeroValido = int.TryParse(chamadosParaRegistrar, out _);


                if (numeroValido == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
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

            int chamadosRegistrar = int.Parse(chamadosParaRegistrar);

            Console.WriteLine("");

            int contadorTotal = 0;

            if (totalDeChamados == 0)
            {
                contadorTotal = 0;
            }
            else
            {
                contadorTotal = totalDeChamados;
            }
            int contador = 0;

            string confirmarRegistro;
            string equipamentoChamadoString;
            bool opcaoValida;
            for (i = 0; i < chamadosRegistrar; i++)
            {
                Console.Clear();
                Cabecalho();

                opcaoValida = false;
                Console.WriteLine("===== Registro do chamado {0} =====", contadorTotal + 1);
                Console.WriteLine("");

                Console.Write("Digite o titulo do chamado: ");
                tituloChamado[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");

                Console.Write("Digite a descricao do chamado: ");
                descricaoChamado[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");

                Console.Write("Digite o numero do equipamento do chamado: ");
                equipamentoChamadoString = Console.ReadLine();
                numeroEquipamentoChamado[contadorTotal] = int.Parse(equipamentoChamadoString);

                Console.WriteLine("");

                Console.Write("Digite a data de abertura do chamado: ");
                dataAberturaChamado[contadorTotal] = Console.ReadLine();

                Console.WriteLine("");

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
                        contadorTotal--;
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

            RetornarTitulo(tituloChamado);
            RetornarNumeroEquipamentoChamado(numeroEquipamentoChamado);
            RetornarDescricao(descricaoChamado);
            RetornarDataAbertura(dataAberturaChamado);
            totalDeChamados = contador;
            return totalDeChamados;
        }

        static void MostrarChamados(string[] tituloChamado, string[] descricaoChamado, string[] dataAberturaChamado, int[] numeroEquipamentoChamado, string[] nomeEquipamento, int totalDeChamados)
        {
            Console.Clear();
            Cabecalho();

            Console.WriteLine("===== Registros de Chamados =====");
            Console.WriteLine("");
            Console.WriteLine("Total de itens: " + totalDeChamados);
            Console.WriteLine("");

            if (totalDeChamados == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Nao existem chamados cadastrados.");
                Console.WriteLine("");
                Console.Write("Aperte ENTER para prosseguir.");
                Console.ReadLine();
                return;
            }

            int numeroDoEquipamento;
            string nomeDoEquipamento;
            string dataSimples;
            int[] diferencaDeDatas = new int[1000];
            
            for (int i = 0; i < totalDeChamados; i++)
            {
                dataSimples = dataAberturaChamado[i];
                string[] dataQuebrada = dataSimples.Split("/");

                int dia = int.Parse(dataQuebrada[0]);
                int mes = int.Parse(dataQuebrada[1]);
                int ano = int.Parse(dataQuebrada[2]);

                DateTime dataCriacaoChamado = new DateTime(ano, mes, dia);

                DateTime dataAtual = DateTime.Now;

                TimeSpan periodoAberto = dataAtual - dataCriacaoChamado;

                diferencaDeDatas[i] = periodoAberto.Days;
            }



            for (int i = 0; i < totalDeChamados; i++)
            {
                Console.WriteLine("=============== Chamado {0} ===============", i + 1);
                Console.WriteLine("");
                Console.WriteLine("Titulo do Chamado: " + tituloChamado[i]);
                Console.WriteLine("");
                Console.WriteLine("Descricao do Chamado: " + descricaoChamado[i]);
                Console.WriteLine("");
                Console.WriteLine("Data Abertura do Chamado: " + dataAberturaChamado[i]);
                Console.WriteLine("");
                numeroDoEquipamento = numeroEquipamentoChamado[i];
                nomeDoEquipamento = nomeEquipamento[numeroDoEquipamento - 1];
                Console.WriteLine("Equipamento: " + nomeDoEquipamento);
                Console.WriteLine("");
                Console.WriteLine("Numero de dias do chamado em aberto: " + diferencaDeDatas[i]);
                Console.WriteLine("");

                Console.WriteLine("");
            }

            Console.ReadLine();
        }
       
        static void EditarChamados(string[] tituloChamado, string[] descricaoChamado, string[] dataAberturaChamado, int[] numeroEquipamentoChamado, int totalDeChamados)
        {
            bool opcaoValida = false;
            int chamadoAEditar = 0;
            while (opcaoValida == false)
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine("Qual chamado deseja editar?");
                Console.Write("Numero do chamado: ");
                string inputChamado = Console.ReadLine();
                int numeroChamado;
                bool validaChamado = int.TryParse(inputChamado, out numeroChamado);
                int contador = 0;

                if (validaChamado == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Digito invalido! Por favor, digite um numero!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                }
                else if (totalDeChamados == 0)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Nao existem chamados registrados, registre pelo menos um chamado!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    for (int i = 1; i <= totalDeChamados; i++)
                    {
                        if (numeroChamado == i)
                        {
                            chamadoAEditar = i;
                            opcaoValida = true;
                            break;
                        }
                        else if (contador == totalDeChamados - 1)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERRO!");
                            Console.WriteLine("Chamado nao encontrado! Digite um numero de chamado valido.");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("Aperte ENTER para prosseguir.");
                            Console.ReadLine();
                        }
                        contador++;
                    }
                }
            }

            chamadoAEditar = chamadoAEditar - 1;

            Console.WriteLine("");
            Console.WriteLine("===== Chamado {0} =====", chamadoAEditar + 1);
            Console.WriteLine("");
            Console.WriteLine("Titulo do Chamado: " + tituloChamado[chamadoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Descricao do Chamado: " + descricaoChamado[chamadoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Equipamento do Chamado: " + numeroEquipamentoChamado[chamadoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Data de abertura do Chamado: " + dataAberturaChamado[chamadoAEditar]);

            Console.WriteLine("");
            Console.WriteLine("O que deseja editar?");
            Console.WriteLine("[1] - Titulo.");
            Console.WriteLine("[2] - Descricao.");
            Console.WriteLine("[3] - Equipamento.");
            Console.WriteLine("[4] - Data de Abertura.");
            Console.WriteLine("");
            Console.Write("Opcao escolhida: ");
            string inputOpcaoEditar = Console.ReadLine();
            Console.WriteLine("");
            //fazer tratamento de erro depois se tiver tempo

            int opcaoEditar = int.Parse(inputOpcaoEditar);

            switch (opcaoEditar)
            {
                case 1:
                    Console.WriteLine("Digite o novo titulo para o chamado.");
                    Console.Write("Editar: ");
                    tituloChamado[chamadoAEditar] = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Digite a nova descricao para o chamado.");
                    Console.Write("Editar: ");
                    descricaoChamado[chamadoAEditar] = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Digite o novo equipamento para atrelar ao chamado.");
                    Console.Write("Editar: ");
                    string novoEquipamento= Console.ReadLine();
                    numeroEquipamentoChamado[chamadoAEditar] = int.Parse(novoEquipamento);
                    break;
                case 4:
                    Console.WriteLine("Digite a nova data de abertura a ser registrada no chamado.");
                    Console.Write("Editar: ");
                    dataAberturaChamado[chamadoAEditar] = Console.ReadLine();
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("===== Chamado {0} apos edicao =====", chamadoAEditar + 1);
            Console.WriteLine("");
            Console.WriteLine("Titulo do Chamado: " + tituloChamado[chamadoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Descricao do Chamado: " + descricaoChamado[chamadoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Equipamento do Chamado: " + numeroEquipamentoChamado[chamadoAEditar]);
            Console.WriteLine("");
            Console.WriteLine("Data de abertura do Chamado: " + dataAberturaChamado[chamadoAEditar]);
            Console.WriteLine("");

            Console.ReadLine();
        }

        static int ExcluirChamados(string[] tituloChamado, string[] descricaoChamado, string[] dataAberturaChamado, int[] numeroEquipamentoChamado, int totalDeChamados)
        {
            bool opcaoValida = false;
            int chamadoAExcluir = 0;
            string[] novaArrayTitulo = new string[1000];
            int[] novaArrayNumeroChamado = new int[1000];
            string[] novaArrayDescricao = new string[1000];
            string[] novaArrayDataAbertura = new string[1000];

            while (opcaoValida == false)
            {
                Console.Clear();
                Cabecalho();
                Console.WriteLine("Qual chamado deseja excluir?");
                Console.Write("Numero do chamado: ");
                string inputChamado = Console.ReadLine();
                int numeroChamado;
                bool validaChamado = int.TryParse(inputChamado, out numeroChamado);
                int contador = 0;

                if (validaChamado == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Digito invalido! Por favor, digite um numero!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                }
                else if (totalDeChamados == 0)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Nao existem chamados registrados, registre pelo menos um chamado!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    return totalDeChamados + 1;
                }
                else
                {
                    for (int i = 1; i <= totalDeChamados; i++)
                    {
                        if (numeroChamado == i)
                        {
                            chamadoAExcluir = i;
                            opcaoValida = true;
                            break;
                        }
                        else if (contador == totalDeChamados - 1)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERRO!");
                            Console.WriteLine("Chamado nao encontrado! Digite um numero de chamado valido.");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("Aperte ENTER para prosseguir.");
                            Console.ReadLine();
                        }
                        contador++;
                    }
                }
            }

            chamadoAExcluir = chamadoAExcluir - 1;

            Console.WriteLine("");
            Console.WriteLine("===== Chamado {0} =====", chamadoAExcluir + 1);
            Console.WriteLine("");
            Console.WriteLine("Titulo do Chamado: " + tituloChamado[chamadoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Descricao do Chamado: " + descricaoChamado[chamadoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Numero de Equipamento do Chamado: " + numeroEquipamentoChamado[chamadoAExcluir]);
            Console.WriteLine("");
            Console.WriteLine("Data de Abertura do Chamado: " + dataAberturaChamado[chamadoAExcluir]);
            Console.WriteLine("");

            Console.WriteLine("Tem certeza que deseja excluir essa equipamento? Digite 'Sim' ou 'Nao'.");
            Console.Write("Opcao escolhida: ");
            string confirmacaoExclusao = Console.ReadLine();
            confirmacaoExclusao = confirmacaoExclusao.ToUpper();
            int j = 0;

            chamadoAExcluir = chamadoAExcluir + 1;

            if (confirmacaoExclusao == "SIM")
            {
                for (int i = 0; i < totalDeChamados; i++)
                {
                    if (i == chamadoAExcluir - 1)
                    {
                        j++;
                        novaArrayTitulo[i] = tituloChamado[j];
                        novaArrayNumeroChamado[i] = numeroEquipamentoChamado[j];
                        novaArrayDescricao[i] = descricaoChamado[j];
                        novaArrayDataAbertura[i] = dataAberturaChamado[j];
                        j++;
                        continue;
                    }
                    else
                    {
                        novaArrayTitulo[i] = tituloChamado[j];
                        novaArrayNumeroChamado[i] = numeroEquipamentoChamado[j];
                        novaArrayDescricao[i] = descricaoChamado[j];
                        novaArrayDataAbertura[i] = dataAberturaChamado[j];
                        j++;
                    }
                }

                for (int i = 0; i < 1000; i++)
                {
                    tituloChamado[i] = novaArrayTitulo[i];
                    numeroEquipamentoChamado[i] = novaArrayNumeroChamado[i];
                    descricaoChamado[i] = novaArrayDescricao[i];
                    dataAberturaChamado[i] = novaArrayDataAbertura[i];
                }

                totalDeChamados = totalDeChamados - 1;
            }
            else
            {
                Console.WriteLine("Retorne ao menu e tente novamente.");
                Console.WriteLine("");
                Console.Write("Aperte ENTER para prosseguir.");
                Console.ReadLine();
                return totalDeChamados + 1;
            }

            return totalDeChamados;
        }
        #endregion
    }
}

