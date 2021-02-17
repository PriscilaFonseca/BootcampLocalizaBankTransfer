using System;
using BootcampLocalizaProjetoBank.Enums;

namespace BootcampLocalizaProjetoBank.Contas
{
    class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
            TipoConta = tipoConta;
        }
        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente\n");
            }
                       
            Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo:F2}\n");
            
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;

            Console.WriteLine($"Salado atual da conta de {Nome} é {Saldo:F2}\n");
        }
        public void Transferir(double valorTransferencia, Conta constaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                constaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            return $"Tipo Conta {TipoConta} |Nome {Nome} |Saldo {Saldo:F2} |Credito {Credito:F2}";
        }
    }
}

