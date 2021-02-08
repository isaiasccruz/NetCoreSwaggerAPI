using System;

namespace ConsoleCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            bool mostraMenu = true;
            while (mostraMenu)
            {
                mostraMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            try
            {
                double num1, num2;
                int resul = 0;

                Console.WriteLine("Calculadora");

                Console.WriteLine("Para somar digite 1");
                Console.WriteLine("Para subtrair digite 2");
                Console.WriteLine("Para dividir digite 3");
                Console.WriteLine("Para multiplicar digite 4");
                Console.WriteLine("Para verificar número primo digite 5");
                Console.WriteLine("Para calcular os divisores digite 6");
                Console.WriteLine("Para calcular os divisores primos digite 7");
                Console.WriteLine("Para sair digite 0");
                Console.Write("\nDigite o numero correspondente à opção: ");
                resul = int.Parse(Console.ReadLine());
                Console.Clear();


                while (resul < 8)
                {
                    RequestNetCoreSwaggerAPI request = new RequestNetCoreSwaggerAPI();

                    if (resul == 0)
                    {
                        Environment.Exit(0);
                    }
                    if (resul == 1)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o primeiro numero: "));
                        num2 = double.Parse(ValidaDigito("\nDigite o segundo numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.Soma.ToString(), num1, num2));
                        break;
                    }
                    if (resul == 2)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o primeiro numero: "));
                        num2 = double.Parse(ValidaDigito("\nDigite o segundo numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.Subtracao.ToString(), num1, num2));
                        break;
                    }
                    if (resul == 3)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o primeiro numero: "));
                        num2 = double.Parse(ValidaDigito("\nDigite o segundo numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.Divisao.ToString(), num1, num2));
                        break;
                    }
                    if (resul == 4)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o primeiro numero: "));
                        num2 = double.Parse(ValidaDigito("\nDigite o segundo numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.Multiplicacao.ToString(), num1, num2));
                        break;
                    }
                    if (resul == 5)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.NumeroPrimo.ToString(), num1, null));
                        break;
                    }
                    if (resul == 6)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.Divisores.ToString(), num1, null));
                        break;
                    }
                    if (resul == 6)
                    {
                        num1 = double.Parse(ValidaDigito("Digite o numero: "));

                        Console.WriteLine(request.ExecutaRequestAPIProcessadoraDeNumeros(EnumeratorMetodo.DivisoresPrimos.ToString(), num1, null));
                        break;
                    }
                }
                Console.ReadLine();
                Console.Clear();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.ReadLine();
                Console.Clear();
                return true;
            }
        }

        static string ValidaDigito(string mensagem)
        {
            try
            {
                double val = 0;
                string num = "";
                Console.Write(mensagem);
                ConsoleKeyInfo chr;
                do
                {
                    chr = Console.ReadKey(true);
                    if (chr.Key != ConsoleKey.Backspace)
                    {
                        bool control = double.TryParse(chr.KeyChar.ToString(), out val);
                        if (control)
                        {
                            num += chr.KeyChar;
                            Console.Write(chr.KeyChar);
                        }
                    }
                    else

                    {
                        if (chr.Key == ConsoleKey.Backspace && num.Length > 0)
                        {
                            num = num.Substring(0, (num.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                while (chr.Key != ConsoleKey.Enter);

                return num;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
