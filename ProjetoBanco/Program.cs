using System;

namespace ProjetoBanco
{
    internal class Program
    {
        private static readonly Banco banco = new Banco();
        private static readonly Conta contaDestino;

        static Program()
        {
            var cidade = new Cidade("jund", "SP");
            var endereco = new Endereco("rua UM", "Centro", "12456-000", 100, cidade);
            var cliente = new Cliente("Alex", "123000123", new DateTime(1975, 6, 23), endereco);

            contaDestino = banco.AbrirConta(cliente);

        }

        private static void Main(string[]args)
        {
            try
            {
                var cidade = new Cidade("jund", "SP");
                var endereco = new Endereco("rua DOIS ", "BairroVelho", "12456-001", 200, cidade);
                var cliente = new Cliente("Barletta", "456000456", new DateTime(1975, 07, 25), endereco);

                var contaBarletta = banco.AbrirConta(cliente);

                contaBarletta.Depositar(2500);

                contaBarletta.Sacar(500);

                contaBarletta.TirarExtrato();

                contaBarletta.Transferir(1, 1, 1000);

                contaBarletta.TirarExtrato();

                contaDestino.TirarExtrato();

                
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ResetColor();
            //Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("pressione qualquer tecla para sair");
            Console.ReadKey();
        }

          
    }
}
