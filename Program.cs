int i, qtdDias = 0, diasAcima = 0, diasAbaixo = 0;
double consumo, total = 0, media, maior, menor;
double[] consumoOriginal;

Console.Write("Informe a quantidade de dias (7 a 30): ");
qtdDias = int.Parse(Console.ReadLine());

while (qtdDias < 7 || qtdDias > 30)
{
    Console.Write("Valor inválido! Digite entre 7 e 30 dias: ");
    qtdDias = int.Parse(Console.ReadLine());
}

consumoOriginal = new double[qtdDias];

for (i = 0; i < qtdDias; i++)
{
    Console.Write($"Informe o consumo do dia {i + 1} (kWh): ");
    consumo = double.Parse(Console.ReadLine());

    while (consumo < 0)
    {
        Console.Write($"Consumo não pode ser negativo. Digite o dia {i + 1} novamente: ");
        consumo = double.Parse(Console.ReadLine());
    }

    consumoOriginal[i] = consumo;
    total += consumo;
}

media = (double) total / qtdDias;

maior = consumoOriginal[0];
menor = consumoOriginal[0];

for (i = 1; i < qtdDias; i++)
{
    if (consumoOriginal[i] > maior)
        maior = consumoOriginal[i];

    if (consumoOriginal[i] < menor)
        menor = consumoOriginal[i];
}

for (i = 0; i < qtdDias; i++)
{
    if (consumoOriginal[i] > media)
        diasAcima++;
    else if (consumoOriginal[i] < media)
        diasAbaixo++;
}

Console.WriteLine("\n--- RELATÓRIO DE CONSUMO ---");

Console.WriteLine("\na) Consumos registrados:");
for (i = 0; i < qtdDias; i++)
{
    Console.WriteLine($"Dia {i + 1}: {consumoOriginal[i]} kWh");
}

Console.WriteLine($"\nb) Consumo total: {total} kWh");
Console.WriteLine($"c) Consumo médio: {media:F2} kWh");

Console.Write($"d) Maior consumo: {maior} kWh no(s) dia(s): ");
for (i = 0; i < qtdDias; i++)
{
    if (consumoOriginal[i] == maior)
        Console.Write((i + 1) + " ");
}

Console.Write($"\ne) Menor consumo: {menor} kWh no(s) dia(s): ");
for (i = 0; i < qtdDias; i++)
{
    if (consumoOriginal[i] == menor)
        Console.Write((i + 1) + " ");
}

Console.WriteLine($"\nf) Dias acima da média: {diasAcima}");
Console.WriteLine($"g) Dias abaixo da média: {diasAbaixo}");