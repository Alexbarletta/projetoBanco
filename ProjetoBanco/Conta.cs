using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBanco.Enums;

namespace ProjetoBanco
{
    internal class Conta
    {
        public Enums.TipoConta TipoConta { get; private set; }

        public int Agencia { get; private set; }

        public int Numero { get; private set; }

        public decimal Saldo { get; set; }


        public Banco Banco { get; private set; }

        public List<Transacao> Transacoes { get; private set; }

        public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;
            Transacoes = new List<Transacao>();
        }

        public void Sacar(decimal valor) //todo metodo é um verbo.
        {
            if (valor <= 0)
                throw new System.Exception("o valor solicitado é invalido");
            if (valor > Saldo)
                throw new System.Exception("saldo insufucuente para saque");

            Debitar("retirada", valor);


            Console.WriteLine("Saque realizado com sucesso");
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("o valor é invalido");

            Creditar("Depositar", valor);

            Console.WriteLine("Deposito realizado com sucesso");

        }

        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Saldo insufucuente para realizar a transferencia");

            var contaDestino = Banco.ObterConta(agencia, numeroConta);

            contaDestino.Creditar("Transferencia", valor); //Orientação a objetos/////////////

            Debitar("transferencia", valor);

            Console.WriteLine("Trasferencia realizado com sucesso");
        }

        public void TirarExtrato()
        {

            if (Transacoes.Count > 0)
            {
                foreach (var transacao in Transacoes)
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Debito ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;
                    var descr = transacao.Descricao.PadRight(20, '-') + transacao.Valor.ToString("C");
                    Console.WriteLine(descr);
                   // Console.WriteLine($"{transacao.Descricao.PadRight(20, '-')}{transacao.Valor.ToString("C")}");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(String.Empty);
                var saldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldoDescricao);
            }
        }

        private void Creditar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);
            Saldo = Saldo + valor;
        }

        private void Debitar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);
            Saldo = Saldo - valor;
        }


    }
}
