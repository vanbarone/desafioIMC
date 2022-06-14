﻿using System;

namespace DesafioIMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaração das variáveis
            string nome = "";
            string sexo = "";
            int idade = 0;
            double altura = 0;
            double peso = 0;

            Console.WriteLine("Olá");
            Console.WriteLine("Faremos agora um diagnóstico prévio da sua saúde\n");
            Console.WriteLine("Para isso preciso de algumas informações =>");

            //leitura das informações
            Console.Write("Por favor informe seu nome: ");
            nome = Console.ReadLine();

            do
            {
                Console.Write("Por favor informe seu sexo (digite 'F' para Feminino e 'M' para Masculino): ");
                sexo = Console.ReadLine().ToUpper();
            } while (sexo != "F" && sexo != "M");

            do
            {
                Console.Write("Por favor informe sua idade: ");
                int.TryParse(Console.ReadLine(), out idade);

                if (idade <= 0) { Console.WriteLine("Idade inválida"); }
            } while (idade <= 0);

            do
            {
                Console.Write("Por favor informe sua altura: ");
                double.TryParse(Console.ReadLine(), out altura);

                if (altura <= 0) { Console.WriteLine("Altura inválida"); }
            } while (altura <= 0);

            do
            {
                Console.Write("Por favor informe seu peso: ");
                double.TryParse(Console.ReadLine(), out peso);

                if (peso <= 0) { Console.WriteLine("Peso inválido"); }
            } while (peso <= 0);



        }
    }
}
