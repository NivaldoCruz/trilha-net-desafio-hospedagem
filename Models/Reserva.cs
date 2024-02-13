namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                //Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("O número de hóspedes não pode exceder a capacidade da suíte.");
                
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            //Retorna a quantidade de hóspedes
            int numeroHospedes = Hospedes.Count;
            return numeroHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            //Retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            //Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor = valor * 0.9M;
            }

            return valor;
        }

        public void ListarHospedes()
        {
            foreach (Pessoa hospede in Hospedes)
            {
                Console.WriteLine(hospede.Nome);
            }
        }
    }
}