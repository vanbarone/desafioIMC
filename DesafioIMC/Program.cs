using System;
using System.Globalization;

namespace DesafioIMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region "Declaração das variáveis e constantes"
            //declaração das variáveis 
            string nome = "";
            string sexo = "";
            int idade = 0;
            double altura = 0;
            double peso = 0;
            double imc = 0;

            //declaração das constantes
            const double IDADE_MAX = 130;
            const double ALTURA_MAX = 2.6;
            const double PESO_MAX = 600.0;
            #endregion 

            //imprime no console informações sobre o programa para o usuário saber o que ele irá fazer
            Console.WriteLine("Olá");
            Console.WriteLine("Faremos agora um diagnóstico prévio da sua saúde\n");
            Console.WriteLine("Para isso precisamos de algumas informações =>\n");

            //leitura das informações do usuário, com validação dos dados
            #region "entrada dos dados"

            //nome não pode ficar em branco
            do
            {
                Console.Write("Por favor informe seu nome: ");
                nome = Console.ReadLine().Trim();
            } while (nome == "");

            //sexo tem que ser 'F/f' ou 'M/m'
            do
            {
                Console.Write("Por favor informe seu sexo (digite 'F/f' para Feminino ou 'M/m' para Masculino): ");
                sexo = Console.ReadLine().ToUpper();
            } while (sexo != "F" && sexo != "M");

            //idade tem que ser maior que 0 e menor que a idade máxima estipulada acima
            do
            {
                Console.Write("Por favor informe sua idade: ");
                int.TryParse(Console.ReadLine(), out idade);

                if (idade <= 0 || idade > IDADE_MAX) { Console.WriteLine($"Idade inválida: {idade} (tem que ser número inteiro maior que 0 e menor que {IDADE_MAX})"); }
            } while (idade <= 0 || idade > IDADE_MAX);

            //altura tem que ser maior que 0 e menor que a altura máxima estipulada acima (separador decimal aceita '.' ou ',')
            do
            {
                Console.Write("Por favor informe sua altura em metros: ");
                double.TryParse(Console.ReadLine().Replace(",","."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);
                
                altura = Math.Round(altura, 2);

                if (altura <= 0 || altura > ALTURA_MAX) { Console.WriteLine($"Altura inválida: {altura} (A altura tem que ser maior que 0 e menor que {ALTURA_MAX})"); }
            } while (altura <= 0 || altura > ALTURA_MAX);

            //peso tem que ser maior que 0 e menor que o peso máximo estipulado acima (separador decimal aceita '.' ou ',')
            do
            {
                Console.Write("Por favor informe seu peso em kg: ");
                double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);

                peso = Math.Round(peso, 1);

                if (peso <= 0 || peso > PESO_MAX) { Console.WriteLine($"Peso inválido: {peso} (O peso tem que ser maior que 0 e menor que {PESO_MAX})"); }
            } while (peso <= 0 || peso > PESO_MAX);
            #endregion 

            //calcula IMC
            imc = CalculaIMC(altura, peso);

            //imprime no console as informações para o usuário
            #region "impressão do resultado do diagnóstico"
            Console.Clear();

            ImprimeLinha();
            Console.WriteLine();
            Console.WriteLine("DIAGNÓSTICO PRÉVIO");
            ImprimeLinha();

            Console.WriteLine("\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {(sexo == "F" ? "Feminino": "Masculino")}");
            Console.WriteLine($"Idade: {idade} anos");
            Console.WriteLine($"Altura: {altura} m");
            Console.WriteLine($"Peso: {peso} kg\n\n");
            
            Console.WriteLine($"Categoria: {PegaCategoria(idade)}\n");

            Console.WriteLine($"IMC Desejável: entre 20 e 24\n");

            Console.WriteLine($"Resultado IMC: {imc} ({PegaDescricaoIMC(imc)})\n");

            Console.WriteLine($"Riscos: {AvaliaRisco(imc)}\n");

            Console.WriteLine($"Recomendação inicial: {SugereRecomendacao(imc)}");

            Console.WriteLine();
            ImprimeLinha();
            #endregion
        }

        private static double CalculaIMC(double altura, double peso)
        {
            //função que calcula o IMC de uma pessoa, dada sua altura e seu peso

            double imc;

            imc = peso / Math.Pow(altura, 2);

            return Math.Round(imc,2);
        }

        private static string PegaCategoria(int idade)
        {
            //função que seta a categoria de acordo com a idade

            if (idade <= 12)
            {
                return "Infantil";
            }
            else if (idade <= 20)
            {
                return "Juvenil";
            }
            else if (idade <= 65)
            {
                return "Adulto";
            }
            else
            {
                return "Idoso";
            }
        }

        private static string PegaDescricaoIMC(double imc)
        {
            //função que seta a descrição da faixa de peso de acordo com o IMC

            if (imc < 20)
            {
                return "Abaixo do Peso Ideal";
            }
            else if (imc <= 24)
            {
                return "Peso Normal";
            }
            else if (imc <= 29)
            {
                return "Excesso de Peso";
            }
            else if (imc <= 35)
            {
                return "Obesidade";
            }
            else
            {
                return "Super Obesidade";
            }
        }

        private static string AvaliaRisco(double imc)
        {
            //função que seta o risco de acordo com o IMC

            if (imc < 20)
            {
                return "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso";
            }
            else if (imc <= 24)
            {
                return "Seu peso está ideal para suas referências";
            }
            else if (imc <= 29)
            {
                return "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares";
            }
            else if (imc <= 35)
            {
                return "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade";
            }
            else
            {
                return "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas";
            }
        }

        private static string SugereRecomendacao(double imc)
        {
            //função que seta a recomendação de acordo com o IMC

            if (imc < 20)
            {
                return "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional";
            }
            else if (imc <= 24)
            {
                return "Mantenha uma dieta saudável e faça seus exames periódicos";
            }
            else if (imc <= 29)
            {
                return "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante";
            }
            else if (imc <= 35)
            {
                return "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista(endócrino)";
            }
            else
            {
                return "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista(endócrino)";
            }
        }

        private static void ImprimeLinha()
        {
            //método que preenche todo uma linha do console com um determinado caracter

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }
    }
}
