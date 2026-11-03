int i, qtdDias = 0, diasAcima = 0, diasAbaixo = 0;
double consumo, total = 0, media, maior, menor, redução = 0, totalReduzido=0, diferença, reducaoPercentual;
double[] consumoOriginal, consumoSimulado;

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


/////////////////////////////////////////////////////



// MÉDIA E SIMULAÇÃO - RAYSSA

Console.WriteLine("");
Console.WriteLine("SIMULAÇÃO DE REDUÇÃO NA CONTA");
Console.WriteLine("");

while(redução <= 0 || redução > 51)
{
    Console.Write($"Digite o percentual de redução (maior que 0% e menor ou igual a 50%):");
    redução = double.Parse(Console.ReadLine());
    Console.WriteLine("");
}

consumoSimulado = new double [qtdDias];

for (i = 0; i < qtdDias; i++)
{
    consumoSimulado[i] = consumoOriginal[i];
}

for(i=0;i<consumoOriginal.Length;i++)
{
    if(consumoOriginal[i] < media * 0.8)
    {
        Console.WriteLine($"Dia {i + 1}: {consumoOriginal[i]} kWh - Baixo consumo;");
    }
    else if(consumoOriginal[i] < media * 1.2)
    {
        Console.WriteLine($"Dia {i + 1}: {consumoOriginal[i]} kWh - Consumo Normal;");
    }
    else
    {
        Console.WriteLine($"Dia {i + 1}: {consumoOriginal[i]} kWh - Alto consumo;");

        consumoSimulado[i] = consumoOriginal[i] * (1 - redução / 100);
    }

    consumo = consumoSimulado[i];
    totalReduzido +=consumo;
}

diferença = total - totalReduzido;
reducaoPercentual = diferença / total * 100;

//RELATÓRIO

Console.WriteLine("");
Console.WriteLine("--- RELATÓRIO DE CONSUMO REDUZIDO ---");
Console.WriteLine("");
Console.WriteLine("");



Console.WriteLine("Novo consumo por dia:");
Console.WriteLine("");
for (i = 0; i < consumoSimulado.Length; i++)
{
    Console.WriteLine($"Dia {i + 1}: {consumoSimulado[i]} kWh");
}
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine($"Consumo total reduzido {totalReduzido} kwh");
Console.WriteLine("");
Console.WriteLine($"Quantidade de KWs economizados: {diferença} kwh");
Console.WriteLine("");
Console.WriteLine($"Percentual obtido de redução em relação ao consumo total original: {reducaoPercentual} %");
