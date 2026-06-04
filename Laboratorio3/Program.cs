using System;

class Program
{
    static int TAMANO = 5;
    static int MINAS = 5;

    static void Main()
    {
        int[,] tableroOculto = new int[TAMANO, TAMANO];
        char[,] tableroVisible = new char[TAMANO, TAMANO];

        InicializarTableroVisible(tableroVisible);
        ColocarMinas(tableroOculto);
        CalcularNumeros(tableroOculto);

        bool juegoTerminado = false;

        while (!juegoTerminado)
        {
            MostrarTablero(tableroVisible);

            Console.Write("Fila (1-5): ");
            int fila = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Columna (1-5): ");
            int columna = int.Parse(Console.ReadLine()) - 1;

            if (fila < 0 || fila >= TAMANO ||
                columna < 0 || columna >= TAMANO)
            {
                Console.WriteLine("Coordenadas inválidas.");
                continue;
            }

            if (tableroVisible[fila, columna] != '■')
            {
                Console.WriteLine("Casilla ya descubierta.");
                continue;
            }

            if (tableroOculto[fila, columna] == -1)
            {
                Console.WriteLine("\n¡BOOM! Pisaste una mina.");
                MostrarTableroFinal(tableroOculto);
                juegoTerminado = true;
            }
            else
            {
                DescubrirCasilla(
                    tableroOculto,
                    tableroVisible,
                    fila,
                    columna
                );

                if (VerificarVictoria(tableroVisible))
                {
                    MostrarTablero(tableroVisible);
                    Console.WriteLine("\n¡FELICIDADES! GANASTE.");
                    juegoTerminado = true;
                }
            }
        }

        Console.WriteLine("\nFin del juego.");
        Console.ReadKey();
    }

    static void InicializarTableroVisible(char[,] tablero)
    {
        for (int i = 0; i < TAMANO; i++)
        {
            for (int j = 0; j < TAMANO; j++)
            {
                tablero[i, j] = '■';
            }
        }
    }

    static void ColocarMinas(int[,] tablero)
    {
        Random rnd = new Random();
        int minasColocadas = 0;

        while (minasColocadas < MINAS)
        {
            int fila = rnd.Next(TAMANO);
            int columna = rnd.Next(TAMANO);

            if (tablero[fila, columna] != -1)
            {
                tablero[fila, columna] = -1;
                minasColocadas++;
            }
        }
    }

    static void CalcularNumeros(int[,] tablero)
    {
        for (int fila = 0; fila < TAMANO; fila++)
        {
            for (int columna = 0; columna < TAMANO; columna++)
            {
                if (tablero[fila, columna] == -1)
                    continue;

                tablero[fila, columna] =
                    ContarMinas(tablero, fila, columna);
            }
        }
    }

    static int ContarMinas(int[,] tablero, int fila, int columna)
    {
        int contador = 0;

        for (int i = fila - 1; i <= fila + 1; i++)
        {
            for (int j = columna - 1; j <= columna + 1; j++)
            {
                if (i >= 0 &&
                    i < TAMANO &&
                    j >= 0 &&
                    j < TAMANO &&
                    tablero[i, j] == -1)
                {
                    contador++;
                }
            }
        }

        return contador;
    }

    static void MostrarTablero(char[,] tablero)
    {
        Console.WriteLine();

        Console.Write("  ");
        for (int i = 1; i <= TAMANO; i++)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();

        for (int i = 0; i < TAMANO; i++)
        {
            Console.Write((i + 1) + " ");

            for (int j = 0; j < TAMANO; j++)
            {
                Console.Write(tablero[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void DescubrirCasilla(
        int[,] oculto,
        char[,] visible,
        int fila,
        int columna)
    {
        visible[fila, columna] =
            oculto[fila, columna].ToString()[0];
    }

    static bool VerificarVictoria(char[,] visible)
    {
        int descubiertas = 0;

        for (int i = 0; i < TAMANO; i++)
        {
            for (int j = 0; j < TAMANO; j++)
            {
                if (visible[i, j] != '■')
                    descubiertas++;
            }
        }

        return descubiertas ==
               (TAMANO * TAMANO - MINAS);
    }

    static void MostrarTableroFinal(int[,] tablero)
    {
        Console.WriteLine();

        Console.Write("  ");
        for (int i = 1; i <= TAMANO; i++)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();

        for (int i = 0; i < TAMANO; i++)
        {
            Console.Write((i + 1) + " ");

            for (int j = 0; j < TAMANO; j++)
            {
                if (tablero[i, j] == -1)
                    Console.Write("* ");
                else
                    Console.Write(tablero[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}