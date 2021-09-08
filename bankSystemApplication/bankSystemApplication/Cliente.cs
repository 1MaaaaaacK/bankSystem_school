using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankSystemApplication
{
    class Cliente
    {   

        public string Nome { get; private set; }
        public string Email { get; set; }
        public int AnoNascimento { get; private set; }
        public string Cpf { get; private set; }

        public List<Cliente> clientes = new List<Cliente>();

        public Cliente(string nome, string email, int anoNascimento, string cpf)
        {
            Int32 dataAtual = Int32.Parse(DateTime.Now.ToString("yyyy"));

            if (dataAtual - anoNascimento < 18)
                
            {
                throw new System.ArgumentNullException("O cliente deve ter mais de 18 anos!");
            }
            if(cpf.Length != 11)
            {
                throw new System.ArgumentException("O cpf deve possuir 11 dígitos!");
            }
            Nome = nome;
            AnoNascimento = anoNascimento;
            Cpf = cpf;
            Email = email;

            Console.WriteLine("\nCliente cadastrado com sucesso!\n\n*******************************\n\nNome: {0}\nIdade: {1} anos\nCPF: {2}\nEmail: {3}\n\n*******************************", nome, dataAtual - anoNascimento, cpf, email);
        }

    }
}
