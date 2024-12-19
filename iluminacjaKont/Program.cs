namespace iluminacjaKont
{
    internal class Program
    {
        static char[,] nastepnyCykl(char[,] swatelka, int size)
        {
            char[,] swatelkaPoCylku = swatelka.Clone() as char[,];

            for(int i =0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    int wlaczoneCount = 0;

                    if((i-1) >= 0)
                    {
                        if((j-1) >= 0 && swatelka[i-1, j-1] == '#')
                            wlaczoneCount++;
                        if (swatelka[i - 1, j] == '#')
                            wlaczoneCount++;
                        if ((j + 1) < size && swatelka[i - 1, j + 1] == '#')
                            wlaczoneCount++;
                    }
                    if((i+1) < size)
                    {
                        if((j-1) >= 0 && swatelka[i+1, j-1] == '#')
                            wlaczoneCount++;
                        if (swatelka[i + 1, j] == '#')
                            wlaczoneCount++;
                        if((j+1) < size && swatelka[i+1, j+1] == '#')
                            wlaczoneCount++;
                    }
                    if ((j - 1) >= 0 && swatelka[i, j - 1] == '#')
                        wlaczoneCount++;
                    if ((j + 1) < size && swatelka[i, j + 1] == '#')
                        wlaczoneCount++;


                    if (swatelka[i, j] == '.' && wlaczoneCount == 3)
                        swatelkaPoCylku[i, j] = '#';
                    else if (swatelka[i, j] == '#' && !(wlaczoneCount == 2 || wlaczoneCount == 3))
                        swatelkaPoCylku[i, j] = '.';
                }
            }

            return swatelkaPoCylku;
        }

        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int n);
            char[,] swiatelka = new char[n, n];
            for(int i = 0;i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for(int j = 0; j < n; j++)
                {
                    swiatelka[i,j] = input[j];
                }

            }

            for(int k = 0; k < 3; k++)
            {
                swiatelka = nastepnyCykl(swiatelka, n);

                Console.WriteLine("\n");
                for (int i = 0; i < n; i++)
                {
                    string line = "";
                    for (int j = 0; j < n; j++)
                    {
                        line += swiatelka[i, j];
                    }
                    Console.WriteLine(line);
                }
            }
        }
    }
}
