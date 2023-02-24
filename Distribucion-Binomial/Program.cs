using Distribucion_Binomial.Class;
const int PORCENTAJE = 100;
Console.Clear();
Console.Write("Valor de n: ");
int n = Convert.ToInt16(Console.ReadLine());
Console.Write("Valor de x: ");
int x = Convert.ToInt16(Console.ReadLine());
int p = 0, q = 0;
Console.Write("La probalidad de exito y fracaso estan en 1) decimal o 2) fraccion");
int op = Convert.ToInt16(Console.ReadLine());
if(op == 1 )
{
    Console.Write("Probalidad de exito: ");
    p = Convert.ToInt16(Console.ReadLine());

    Console.Write("Probalidad de fracaso: ");
    q = Convert.ToInt16(Console.ReadLine());
}
else
{
    p = (x/n);
    q = ((n-x)/n);
}

double ncr = DistribucionBinomial.nCx(n,x);

Console.Write($"{n}C{x} * ({p})^{x} *  {q}^({n}-{x}) * {PORCENTAJE} = disBin%");
Console.ReadKey();
Console.Clear();