using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBanco
{
    internal class Banco
    {
        public string Nome { get; private set; }

        public short Numero { get; private set; }

       //public Endereco Endereco { get; private set; }

        public List<Conta> Contas { get; private set; }

        public Banco()
        {
            Contas = new List<Conta>();

        }

        public Conta AbrirConta(Cliente cliente)
        {
            
            var numeroConta = Contas.Count + 1;

            var conta = new Conta(Enums.TipoConta.Corrente, 1, numeroConta, this);

            Contas.Add(conta);

            return conta;
        }

        public Conta ObterConta(int agencia, int numeroConta)
        {
            var conta = Contas.FirstOrDefault(c => c.Agencia == agencia && c.Numero == numeroConta);
            //var saldo = conta?.Saldo;
            if (conta == null)
                throw new Exception("conta não encontada");
            return conta;
        }

        public void FecharConta(Conta conta)
        {
            Contas.Remove(conta);
        }
    }
}
