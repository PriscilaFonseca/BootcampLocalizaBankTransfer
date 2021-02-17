using System;
using BootcampLocalizaProjetoBank.Contas;
using BootcampLocalizaProjetoBank.Enums;
using System.Collections.Generic;

namespace BootcampLocalizaProjetoBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                try
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarContas();
                            break;
                        case "2":
                            InserirConta();
                            break;
                        case "3":
                            Transferir();
                            break;
                        case "4":
                            Sacar();
                            break;
                        case "5":
                            Depositar();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Argumento Invalido, tente novamente!\n");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada por utilizar nossos serviços");
            Console.ReadLine();
        }
        private static void Depositar()
        {
            Console.Write("Digite o numero da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[idConta].Depositar(valorDeposito);
        }
        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int origem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int destino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser trasferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[origem].Transferir(valorTransferencia, listContas[destino]);
        }
        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[idConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas:");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            int i = 0;
            foreach (Conta obj in listContas)
            {
                Console.WriteLine($"#{i} {obj}" );
                i++;
            }
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta:");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o limite de crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome, saldo, credito, tipoConta: (TipoConta) tipoConta );

            listContas.Add(novaConta);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Bank a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair\n");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
