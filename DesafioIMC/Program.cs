using System;
using System.Globalization;

namespace DesafioIMC
{
    internal class Program
    {
        //declaração das variáveis da classe  (assim poderão ser utilizadas por qualquer método da classe)
        private static string nome = "";
        private static string sexo = "";
        private static int idade = 0;
        private static double altura = 0;
        private static double peso = 0;
        
        //declaração das constantes da classe (assim poderão ser utilizadas por qualquer método da classe)
        private const double IDADE_MAX = 130;
        private const double ALTURA_MAX = 2.6;
        private const double PESO_MAX = 600.0;

        static void Main(string[] args)
        {
            ImprimeCabecalho();

            ImprimeBoasVindas();

            SolicitaDados();
        }

        /// <summary>
        /// Método que mostra no console o cabeçalho do sistema
        /// </summary>
        private static void ImprimeCabecalho()
        {
            Console.Clear();

            ImprimeLinhaDivisoria();

            Console.BackgroundColor = ConsoleColor.White;   //altera cor de fundo 
            Console.ForegroundColor = ConsoleColor.Black;   //altera cor do texto

            Console.Write(CentralizaTexto("DIAGNÓSTICO PRÉVIO PARA O PROGRAMA DE EMAGRECIMENTO"));

            Console.ResetColor();   //volta as cores para o padrão normal

            ImprimeLinhaDivisoria();
        }

        /// <summary>
        /// Método que mostra no console informações sobre o programa para o usuário saber o que o programa faz
        /// </summary>
        private static void ImprimeBoasVindas()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Olá, seja bem vindo ao nosso programa\n");
            Console.WriteLine("Faremos agora um diagnóstico prévio da sua saúde\n");
            Console.WriteLine("Para isso precisamos de algumas informações =>");
        }

        /// <summary>
        /// Método que solicita algumas informações para o usuário (nome, sexo, idade, altura, peso) e faz suas validações
        /// </summary>
        private static void SolicitaDados()
        {
            Console.WriteLine(" ");

            //*** Nome ***
            //Validação: não pode ficar em branco
            do
            {
                Console.Write("Por favor informe seu nome: ");
                nome = Console.ReadLine().Trim();
            } while (nome == "");


            //*** Sexo ***
            //Validação: só aceita [F] ou [M]
            do
            {
                Console.Write("Por favor informe seu sexo (digite [F] para Feminino ou [M] para Masculino): ");
                sexo = Console.ReadLine().ToUpper();
            } while (sexo != "F" && sexo != "M");


            //*** Idade ***
            //Validação: tem que ser maior que 0 e menor que a idade máxima estipulada na constante
            do
            {
                Console.Write("Por favor informe sua idade: ");
                int.TryParse(Console.ReadLine(), out idade);

                if (idade <= 0 || idade > IDADE_MAX) { Console.WriteLine($"Idade inválida: {idade} (tem que ser número inteiro maior que 0 e menor que {IDADE_MAX})"); }
            } while (idade <= 0 || idade > IDADE_MAX);


            //*** Altura ***
            //Validação: tem que ser maior que 0 e menor que a altura máxima estipulada na constante
            //Obs: separador decimal aceita '.' ou ','
            do
            {
                Console.Write("Por favor informe sua altura em metros: ");
                double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);

                altura = Math.Round(altura, 2);

                if (altura <= 0 || altura > ALTURA_MAX) { Console.WriteLine($"Altura inválida: {altura} (A altura tem que ser maior que 0 e menor que {ALTURA_MAX})"); }
            } while (altura <= 0 || altura > ALTURA_MAX);


            //*** Peso ***
            //Validação: tem que ser maior que 0 e menor que o peso máximo estipulado na constante
            //Obs: separador decimal aceita '.' ou ','
            do
            {
                Console.Write("Por favor informe seu peso em kg: ");
                double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);

                peso = Math.Round(peso, 1);

                if (peso <= 0 || peso > PESO_MAX) { Console.WriteLine($"Peso inválido: {peso} (O peso tem que ser maior que 0 e menor que {PESO_MAX})"); }
            } while (peso <= 0 || peso > PESO_MAX);

            ConfirmaDados();
        }

        /// <summary>
        /// Método que gera o diagnóstico prévio baseado nas informações fornecidas pelo usuário
        /// e mostra as informações no console
        /// </summary>
        private static void GeraDiagnostico()
        {
            double imc;
            string[] dadosIMC = new string[3];

            //calcula IMC
            imc = CalculaIMC();

            //seta os detalhes de acordo com o IMC
            dadosIMC = SetaDetalhesDoDiagnostico(imc);
            
            ImprimeCabecalho();

            ImprimeDadosPessoais();

            Console.WriteLine($"Categoria: {PegaCategoria()}\n");

            Console.WriteLine($"IMC Desejável: entre 20 e 24\n");

            Console.WriteLine($"Resultado IMC: {imc} ({dadosIMC[0]})\n");

            Console.WriteLine($"Riscos: {dadosIMC[1]}\n");

            Console.WriteLine($"Recomendação inicial: {dadosIMC[2]}");

            Console.WriteLine();

            ImprimeRodape();

            VerificaSeDesejaNovoDiagnostico();
        }

        /// <summary>
        /// Método que mostra no console os dados pessoais fornecidos pelo usuário
        /// </summary>
        private static void ImprimeDadosPessoais()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Nome:   {nome}");
            Console.WriteLine($"Sexo:   {(sexo == "F" ? "Feminino" : "Masculino")}");
            Console.WriteLine($"Idade:  {idade} anos");
            Console.WriteLine($"Altura: {altura} m");
            Console.WriteLine($"Peso:   {peso} kg\n\n");
        }

        /// <summary>
        /// Método que pergunta para o usuário se deseja fazer um novo diagnóstico
        /// ([Sim] - Solicita os dados novamente
        ///  [Não] - Finaliza o programa)
        /// </summary>
        private static void VerificaSeDesejaNovoDiagnostico()
        {
            string opcao;

            Console.WriteLine(" ");

            do
            {
                Console.Write($"Deseja fazer um novo diagnóstico ? (Digite [S] para Sim ou [N] para Não) ");
                opcao = Console.ReadLine().ToUpper();   //ToUpper - transforma todo texto em maiúsculo
            } while (opcao != "S" && opcao != "N");

            if (opcao == "S")
            {
                ImprimeCabecalho();

                SolicitaDados();
            }
            else
            {
                Console.WriteLine(" ");

                Console.WriteLine("Ok, o programa será encerrado");

                Environment.Exit(0);    //finaliza o programa
            }
        }

        /// <summary>
        /// Método que pergunta para o usuário se os dados informados estão corretos,
        /// ([Sim] - Gera o diagnóstico
        ///  [Não] - Pergunta se deseja informar novamente)
        /// </summary>
        private static void ConfirmaDados()
        {
            string opcao;

            Console.Clear();

            ImprimeCabecalho();

            ImprimeDadosPessoais();

            do
            {
                Console.Write($"Os dados estão corretos ? (Digite [S] para Sim ou [N] para Não) ");
                opcao = Console.ReadLine().ToUpper();   //ToUpper - transforma todo texto em maiúsculo
            } while (opcao != "S" && opcao != "N");

            if (opcao == "S")
            {
                GeraDiagnostico();
            } else
            {
                ConfirmaReentradaDosDados();
            } 
        }

        /// <summary>
        /// Método que pergunta para o usuário se deseja informar novamente os dados,
        /// ([Sim] - Solicita novamente os dados
        ///  [Não] - Finaliza o programa)
        /// </summary>
        private static void ConfirmaReentradaDosDados()
        {
            string opcao;

            Console.WriteLine(" ");

            do
            {
                Console.Write($"Deseja informá-los novamente ? (Digite [S] para Sim ou [N] para Não) ");
                opcao = Console.ReadLine().ToUpper();   //ToUpper - transforma todo texto em maiúsculo
            } while (opcao != "S" && opcao != "N");

            if (opcao == "S")
            {
                ImprimeCabecalho();

                SolicitaDados();
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Ok, o programa será encerrado");

                Environment.Exit(0);    //finaliza o programa
            }
        }

        /// <summary>
        /// Função que centraliza no console, o texto passado como parâmetro
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Texto centralizado</returns>
        private static string CentralizaTexto(string texto)
        {
            //pega a largura do console
            int tamanho = Console.WindowWidth;

            //faz esse cálculo pra saber quantos espaços precisa ter a direita e a esquerda do texto informado
            tamanho = (tamanho - texto.Length) / 2;

            //acrescenta espaços a diretia do texto
            for (int i = 0; i < tamanho; i++)
            {
                texto += ' ';
            }

            //acrescenta espaços à esquerda do texto para atingir a largura total [WindowWidth]
            texto = texto.PadLeft(Console.WindowWidth, ' ');

            return texto;
        }

        /// <summary>
        /// Método que mostra no console o rodapé do sistema
        /// </summary>
        private static void ImprimeRodape()
        {
            ImprimeLinhaDivisoria();

            Console.BackgroundColor = ConsoleColor.White;   //altera cor de fundo 
            Console.ForegroundColor = ConsoleColor.Black;   //altera cor do texto

            Console.Write(CentralizaTexto("*******************"));

            Console.ResetColor();   //volta as cores para o padrão normal

            ImprimeLinhaDivisoria();
        }

        /// <summary>
        /// Função que calcula o IMC de acordo com o peso e a altura informados
        /// </summary>
        /// <returns>IMC</returns>
        private static double CalculaIMC()
        {
            double imc;

            imc = peso / Math.Pow(altura, 2);

            return Math.Round(imc,2);
        }

        /// <summary>
        /// Função que seta a categoria de acordo com a idade informada
        /// </summary>
        /// <returns>Categoria</returns>
        private static string PegaCategoria()
        {
            switch (idade)
            {
                case <= 12: return "Infantil";
                case <= 20: return "Juvenil";
                case <= 65: return "Adulto";
                default:    return "Idoso";                    
            }
        }

        /// <summary>
        /// Função que seta detalhes do diagnóstico de acordo com o IMC informado
        /// </summary>
        /// <returns>string[]</returns>
        private static string[] SetaDetalhesDoDiagnostico(double imc)
        {
            string[] dadosIMC = new string[3];

            if (imc < 20)
            {   
                dadosIMC[0] = "Abaixo do Peso Ideal";
                dadosIMC[1] = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.";
                dadosIMC[2] = "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional.";
            }
            else if (imc < 25)
            {
                dadosIMC[0] = "Peso Normal";
                dadosIMC[1] = "Seu peso está ideal para suas referências.";
                dadosIMC[2] = "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }
            else if (imc < 30)
            {
                dadosIMC[0] = "Excesso de Peso";
                dadosIMC[1] = "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";
                dadosIMC[2] = "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante.";
            }
            else if (imc <= 35)
            {
                dadosIMC[0] = "Obesidade";
                dadosIMC[1] = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";
                dadosIMC[2] = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista(endócrino).";
            }
            else
            {
                dadosIMC[0] = "Super Obesidade";
                dadosIMC[1] = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
                dadosIMC[2] = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista(endócrino).";
            }

            return dadosIMC;
        }

        /// <summary>
        /// Método que preenche todo uma linha do console com um determinado caracter
        /// </summary>
        private static void ImprimeLinhaDivisoria()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }
    }
}
