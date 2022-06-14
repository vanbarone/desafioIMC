using System;
using System.Globalization;

namespace DesafioIMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaração das variáveis e constantes
            string nome = "";
            string sexo = "";
            int idade = 0;
            double altura = 0;
            double peso = 0;
            double imc = 0;

            const double IDADE_MAX = 130;
            const double ALTURA_MAX = 2.5;
            const double PESO_MAX = 200.0;


            //informa o usuário sobre o objetivo do programa
            Console.WriteLine("Olá");
            Console.WriteLine("Faremos agora um diagnóstico prévio da sua saúde\n");
            Console.WriteLine("Para isso precisamos de algumas informações =>");


            //leitura das informações do usuário
            Console.Write("Por favor informe seu nome: ");
            nome = Console.ReadLine();

            do
            {
                Console.Write("Por favor informe seu sexo (digite 'F' para Feminino ou 'M' para Masculino): ");
                sexo = Console.ReadLine().ToUpper();
            } while (sexo != "F" && sexo != "M");

            do
            {
                Console.Write("Por favor informe sua idade: ");
                int.TryParse(Console.ReadLine(), out idade);

                if (idade <= 0 || idade > IDADE_MAX) { Console.WriteLine("Idade inválida"); }
            } while (idade <= 0 || idade > IDADE_MAX);

            do
            {
                Console.Write("Por favor informe sua altura em metros: ");
                double.TryParse(Console.ReadLine(), out altura);
                //double.TryParse(Console.ReadLine(),NumberStyles.AllowDecimalPoint, new CultureInfo("pt-br"), out altura)

                altura = Math.Round(altura, 2);

                if (altura <= 0 || altura > ALTURA_MAX) { Console.WriteLine("Altura inválida"); }
            } while (altura <= 0 || altura > ALTURA_MAX);


            do
            {
                Console.Write("Por favor informe seu peso em kg: ");
                double.TryParse(Console.ReadLine(), out peso);
                peso = Math.Round(peso, 1);

                if (peso <= 0 || peso > PESO_MAX) { Console.WriteLine("Peso inválido"); }
            } while (peso <= 0 || peso > PESO_MAX);

            
            //calcula IMC
            imc = CalculaIMC(altura, peso);


            //mostra as informações para o usuário
            Console.Clear();
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {(sexo == "F" ? "Feminino": "Masculino")}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"Peso: {peso}\n");

            Console.WriteLine($"Categoria: {PegaCategoria(idade)}\n");
            Console.WriteLine($"IMC Desejável: entre 20 e 24\n");

            Console.WriteLine($"Resultado IMC: {imc} ({PegaDescricaoIMC(imc)})\n");

            Console.WriteLine($"Riscos: {AvaliaRisco(imc)}\n");
            Console.WriteLine($"Recomendação inicial: {SugereRecomendacao(imc)}");
            Console.WriteLine("=========================================================================================");
        }

        private static double CalculaIMC(double altura, double peso)
        {
            double imc;

            imc = peso / Math.Pow(altura, 2);

            return Math.Round(imc,2);
        }

        private static string PegaCategoria(int idade)
        {
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

    }
}
