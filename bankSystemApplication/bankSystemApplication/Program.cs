using System;
using System.Collections.Generic;
namespace bankSystemApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();
            List<Conta> contas = new List<Conta>();

            bool saida = false;
            do
            {

                Console.WriteLine("(1) - Cadastrar Cliente");
                Console.WriteLine("(2) - Criar Conta");
                Console.WriteLine("(3) - Listar Clientes");
                Console.WriteLine("(4) - Listar Contas");
                Console.WriteLine("(5) - Sacar");
                Console.WriteLine("(6) - Depositar");
                Console.WriteLine("(7) - Transferir");
                Console.WriteLine("(8) - Saldo Geral");
                Console.WriteLine("(0) - Encerrar Aplicação");

                char firstOptionValue = Convert.ToChar(Console.ReadLine());
                string[] clientValue = new string[4];

                switch (firstOptionValue)
                {//nao estava conseguindo por as funções separadas, por isso ficou essa "bagunça". depois tentarei arrumar isso, para ficar um código melhor.
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Qual seu nome?");
                        clientValue[0] = Console.ReadLine();
                        Console.WriteLine("Qual seu email?");
                        clientValue[1] = Console.ReadLine();
                        Console.WriteLine("Em que ano você nasceu?");
                        clientValue[2] = Console.ReadLine();
                        Console.WriteLine("Qual seu cpf?");
                        clientValue[3] = Console.ReadLine();
                        Cliente cliente = new Cliente(clientValue[0], clientValue[1], Convert.ToInt32(clientValue[2]), clientValue[3]);

                        clientes.Add(cliente);

                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Qual seu nome?");
                        clientValue[0] = Console.ReadLine();
                        Console.WriteLine("Qual seu cpf?");
                        clientValue[1] = Console.ReadLine();
                        Conta conta = new Conta(-666, clientValue[1], clientes, contas);
                        contas.Add(conta);
                        break;
                    case '3':
                        Console.Clear();
                        if (clientes.Count > 0)
                        {
                            clientes.ForEach(m =>
                            {
                                Console.WriteLine("Nome: {0}\nEmail: {1}\nAno de Nascimento: {2}\nCPF: {3}\nTotal de Contas: {4}\n\n********************\n",
                                    m.Nome, m.Email, m.AnoNascimento, m.Cpf, contas.FindAll(c => c.Titular.Cpf.Contains(m.Cpf)).Count);
                            });
                        }
                        else
                        {
                            Console.WriteLine("Nenhum cliente cadastrado!");
                        }

                        break;
                    case '4':
                        Console.Clear();
                        if (contas.Count > 0)
                        {
                            contas.ForEach(m =>
                            {
                                Console.WriteLine("Nome: {0}\nNúmero da Conta: {1}\nCPF do Titular: {2}\n\n********************\n",
                                    m.Titular.Nome, m.Numero, m.Titular.Cpf);
                            });
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma conta cadastrada!");
                        }
                        break;
                    case '5':
                        Console.Clear();
                        Console.WriteLine("Qual o número da sua conta?");
                        clientValue[0] = Console.ReadLine();
                        Console.WriteLine("Qual seu cpf?");
                        clientValue[1] = Console.ReadLine();
                        Console.WriteLine("Qual valor você deseja sacar?");
                        clientValue[2] = Console.ReadLine();

                        Conta contaSacar = contas.Find(c => c.Numero.Equals(Convert.ToInt32(clientValue[0])) && c.Titular.Cpf.Contains(clientValue[1]));
                        if (contaSacar == null)
                        {
                            Console.WriteLine("Nenhuma conta foi encontrada");
                        }
                        else
                        {

                            if (contaSacar.Sacar(Convert.ToDecimal(clientValue[2])))
                            {
                                Console.WriteLine("Você sacou {0} som sucesso!\n Saldo Atual: {1}", clientValue[2], contaSacar.Saldo);

                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente!");
                            }
                        }


                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine("Qual o número da sua conta?");
                        clientValue[0] = Console.ReadLine();
                        Console.WriteLine("Qual seu cpf?");
                        clientValue[1] = Console.ReadLine();
                        Console.WriteLine("Qual valor você deseja depositar?");
                        clientValue[2] = Console.ReadLine();

                        Conta contaDepositar = contas.Find(c => c.Numero.Equals(Convert.ToInt32(clientValue[0])) && c.Titular.Cpf.Contains(clientValue[1]));

                        if (contaDepositar == null)
                        {
                            Console.WriteLine("Nenhuma conta foi encontrada");
                        }
                        else
                        {
                            contaDepositar.Depositar(Convert.ToDecimal(clientValue[2]));

                        }


                        break;
                    case '7':
                        Console.Clear();
                        Console.WriteLine("Qual o número da sua conta?");
                        clientValue[0] = Console.ReadLine();
                        Console.WriteLine("Qual seu cpf?");
                        clientValue[1] = Console.ReadLine();
                        Console.WriteLine("Qual o número da conta de destino?");
                        clientValue[2] = Console.ReadLine();
                        Console.WriteLine("Qual valor você deseja depositar?");
                        clientValue[3] = Console.ReadLine();

                        Conta contaTransferir = contas.Find(c => c.Numero.Equals(Convert.ToInt32(clientValue[0])) && c.Titular.Cpf.Contains(clientValue[1]));

                        if (contaTransferir == null)
                        {
                            Console.WriteLine("Nenhuma conta foi encontrada");
                        }
                        else
                        {
                            Conta contaDestino = contas.Find(c => c.Numero.Equals(Convert.ToInt32(clientValue[2])));
                            if (contaDestino == null)
                            {
                                Console.WriteLine("Conta de destino não foi encontrada!");
                            }
                            else
                            {
                                if (contaTransferir.Transferir(contaDestino, Convert.ToDecimal(clientValue[3])))
                                {
                                    Console.WriteLine("Você transferiu {0} reais para {1}\n Saldo Atual: {2}", clientValue[3], contaTransferir.Titular.Nome, contaDestino.Saldo);
                                }
                            }

                        }
                        break;
                    case '8':
                        Console.Clear();
                        Console.WriteLine("Qual o número da sua conta?");
                        clientValue[0] = Console.ReadLine();
                        Console.WriteLine("Qual seu cpf?");
                        clientValue[1] = Console.ReadLine();

                        Conta contaSaldo = contas.Find(c => c.Numero.Equals(Convert.ToInt32(clientValue[0])) && c.Titular.Cpf.Contains(clientValue[1]));


                        if (contaSaldo == null)
                        {
                            Console.WriteLine("Nenhuma conta foi encontrada");
                        }
                        else
                        {
                            Console.WriteLine("Saldo Atual: {0}", contaSaldo.Saldo);

                        }

                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("**************************************\n\nAplicação Encerrada!\n\n**************************************");
                
                        saida = true;
                        break;
                    default:
                        Console.WriteLine("Você escolheu a opção errada!");
                        break;

                }
                Console.WriteLine("Clique em qualquer tecla para continuar!");
                if (Console.ReadLine() != null) Console.Clear();

            } while (!saida);

            /*try
            {
                Conta conta1 = new Conta(123456, client1);
                conta1.Titular = client1;
                conta1.Depositar(1000);
                Console.WriteLine("O saldo inicial da conta {0} é {1}", conta1.Numero, conta1.Saldo);

                Console.WriteLine("O cliente da conta {0} é {1}", conta1.Numero, conta1.Titular.Nome);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }*/



        }
    }
}
