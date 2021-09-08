using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankSystemApplication
{
    class Conta
    {
        public long Numero { get; private set; }
        public decimal Saldo { get; private set; }

        public Cliente Titular { get; set; }

        public Conta(int numero, string cpf, List<Cliente> clientes, List<Conta> contas)
        {
            

            if (numero == -666)
            {
                Random randomNumber = new Random();
                numero = Convert.ToInt32(randomNumber.Next(1000, 10000));
            }else
            {

                Conta contaFound = contas.Find(c => c.Numero.Equals(numero));

                if(contaFound == null)
                {
                    throw new System.ArgumentException("Essa conta não existe!");
                }
            }
            
            Cliente titular = clientes.Find(m => m.Cpf.Contains(cpf));

            Titular = titular ?? throw new System.ArgumentException("Não existe nenhum cliente com esse CPF!");

            Numero = numero;

            Console.WriteLine("Conta criada com sucesso!!\n\n*******************************\n\nNúmero da Conta: {0}\nCPF do Titular: {1}\n\n*******************************", numero, titular.Cpf);
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;

            Console.WriteLine("Depósito concluído com sucesso!\nSaldo Atual: {0}", Saldo);
        }

        public bool Sacar(decimal valor)
        {
            if ((Saldo - (valor - 0.1m)) < 0)
            {
                return false;
            }
            Saldo -= (valor + 0.1m);
            return true;
        }

        public bool Transferir(Conta destino, decimal valor)
        {
            
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }
            return false;
        }
    }
}
