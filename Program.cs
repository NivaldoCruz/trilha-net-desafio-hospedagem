using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Console.WriteLine("Bem vindo ao sistema de hospedagem.");

Console.WriteLine("Informe o tipo da suíte");
string tipoSuite = Console.ReadLine();

Console.WriteLine("Informe a capacidade da suíte");
int capacidade = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Informe o valor da diária");
decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

//Cria a lista de hospédes
List<Pessoa> hospedes = new List<Pessoa>();

bool continuar = true;
int numero;
string nome;
while (continuar)
{   
    Console.WriteLine("Digite o nome do hóspede");
    nome = Console.ReadLine();
    Pessoa pessoa = new Pessoa(nome);
    hospedes.Add(pessoa);
    Console.WriteLine("Deseja adicionar outro hóspede?");
    Console.WriteLine("Precione 1 para adicionar mais um hóspede ou 2 para prosseguir.");

    numero = Convert.ToInt32(Console.ReadLine());
     switch(numero)
    {
        case 1:
        Console.WriteLine("Adicionando outro hóspede");
        break;

        case 2:
        continuar = false;
        break;

        default:
        Console.WriteLine("Opção inválida");
        break;
    }
}

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.WriteLine("Efetuando a reserva, informe o número de dias reservados.");
int diasReservados = Convert.ToInt32(Console.ReadLine());
Reserva reserva = new Reserva(diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"A suíte {tipoSuite} possui, {reserva.ObterQuantidadeHospedes()} hóspedes");
reserva.ListarHospedes();
decimal valorDaDiaria = reserva.CalcularValorDiaria();
Console.WriteLine($"Valor da diária: {valorDaDiaria:F2}");