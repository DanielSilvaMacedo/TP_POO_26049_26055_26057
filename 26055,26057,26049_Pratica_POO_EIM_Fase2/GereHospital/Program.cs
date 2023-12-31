using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intervenientes;
using Hospital;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace GereHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doente doente = null; // Declare a variável para o doente que será manipulado no menu
            Sistema sistema = new Sistema();
            Medico medico = null; // Declare a variável para o médico que será manipulado no menu
            SalaaEspera salaaEspera = new SalaaEspera(200);

            bool sair = false;

            while (!sair)
            {
                
                Console.WriteLine("=== Menu Principal ===");
                Console.WriteLine("1. Menu do Paciente");
                Console.WriteLine("2. Menu do Medico");
                Console.WriteLine("3. Menu da Sala de Espera");
                Console.WriteLine("4. Sair");

                Console.Write("Escolha uma opcao: ");

                //recebe o que o utilizador colocar e como este pode colocar um numero ou um texto por isso tem que se validar
                string userInput = Console.ReadLine();

               //validar se consegue passar o texto para numero
              bool successful = Int32.TryParse(Console.ReadLine(), out int opcao);

                //não consegue passar para numero mosgtra mensagem ao utilizador
                if (!successful)
                    Console.WriteLine("Nao pode colocar texto");

                switch (opcao)
                {
                    case 1:
                        {
                            while (!sair)
                            {
                                Console.WriteLine("=== Menu do Doente ===");
                                Console.WriteLine("1. Registrar novo doente");
                                Console.WriteLine("2. Atualizar histórico");
                                Console.WriteLine("3. Obter informações do doente");
                                Console.WriteLine("4. Realizar triagem");
                                Console.WriteLine("5. Sair");

                                Console.Write("Escolha uma opcao: ");
                                string userInput1 = Console.ReadLine();

                                //validar se consegue passar o texto para numero
                                bool successful1 = Int32.TryParse(Console.ReadLine(), out int opcao1);


                                //não consegue passar para numero mostra mensagem ao utilizador
                                if (!successful1)
                                {
                                    Console.WriteLine("Nao pode colocar texto");
                                }

                                switch (opcao1)
                                {
                                    case 1:
                                        // Registar novo paciente
                                        sistema.RegistarDoente(1, "João", 258963147, 147258, Pulseira.VERMELHA, Prioridade.MUITO_URGENTE, "diabetes", "dor no peito");
                                        sistema.RegistarDoente(2, "Maria", 231456789, 196347, Pulseira.AMARELA, Prioridade.URGENTE, "hipertensao", "tensao alta");
                                        sistema.RegistarDoente(3, "Pedro", 245698713, 123456, Pulseira.VERDE, Prioridade.POUCO_URGENTE, "diabetes", "febre");
                                        Console.WriteLine("Qual o id do Doente?");
                                        string idprevio = Console.ReadLine();
                                        bool sucessoid = Int32.TryParse(Console.ReadLine(), out int idDoente);
                                        if (!sucessoid)
                                        {
                                            Console.WriteLine("Nao pode colocar texto");
                                        }
                                        Console.WriteLine("Qual o nome do Doente?");
                                        string nomeD = Console.ReadLine();
                                        Console.WriteLine("Qual o nif do Doente?");
                                        string nifprevio = Console.ReadLine();
                                        bool sucessonif = Int32.TryParse(Console.ReadLine(), out int nifDoente);
                                        if (!sucessonif)
                                        {
                                            Console.WriteLine("Nao pode colocar texto");
                                        }
                                        Console.WriteLine("Qual o n.utente do Doente?");
                                        string nuntenteprevio = Console.ReadLine();
                                        bool sucessonutente = Int32.TryParse(Console.ReadLine(), out int nutenteDoente);
                                        if (!sucessonutente)
                                        {
                                            Console.WriteLine("Nao pode colocar texto");
                                        }
                                        Console.WriteLine("Qual a pulseira do Doente?\n 1.Verde\n 2.Amarela\n 3.Vermelha");
                                        string corpulseira = Console.ReadLine();
                                        bool sucessocor = Int32.TryParse(Console.ReadLine(), out int escolha);
                                        if (!sucessocor)
                                        {
                                            Console.WriteLine("Nao pode colocar texto");
                                        }
                                        Pulseira pulseira;
                                        Prioridade prioridade;
                                        switch (escolha)
                                        {
                                            case 1:
                                                pulseira = Pulseira.VERDE;
                                                prioridade = Prioridade.POUCO_URGENTE;
                                                break;
                                            case 2:
                                                pulseira = Pulseira.AMARELA;
                                                prioridade = Prioridade.URGENTE;
                                                break;
                                            case 3:
                                                pulseira = Pulseira.VERMELHA;
                                                prioridade = Prioridade.MUITO_URGENTE;
                                                break;
                                            default:
                                                pulseira = Pulseira.NAO_ESPECIFICADA;
                                                prioridade = Prioridade.NAO_ESPECIFICADO;
                                                break;
                                        }
                                        Console.WriteLine("Qual o historico do Doente?");
                                        string historico = Console.ReadLine();
                                        Console.WriteLine("Qual os sintomas do Doente?");
                                        string sintomas = Console.ReadLine();
                                        sistema.RegistarDoente(idDoente, nomeD, nifDoente, nutenteDoente, pulseira, prioridade, historico, sintomas);
                                        break;

                                    case 2:
                                        // Atualizar histórico
                                        if (doente != null)
                                        {
                                            sistema.AtualizarHistorico(1, "Doente apresentou dor no peito.");
                                            sistema.AtualizarHistorico(2, "Doente teve um acidente de carro.");
                                            Console.WriteLine("Qual o id do Doente?");
                                            string idp = Console.ReadLine();
                                            bool sucessoidp = Int32.TryParse(Console.ReadLine(), out int id);
                                            if (!sucessoidp)
                                            {
                                                Console.WriteLine("Nao pode colocar texto");
                                            }
                                            Console.WriteLine("Qual o historico do Doente?");
                                            string historicoat = Console.ReadLine();
                                            sistema.AtualizarHistorico(id, historicoat);
                                        }
                                        else
                                            Console.WriteLine("Registe um doente primeiro!");
                                        break;

                                    case 3:
                                        // Obter informações do paciente
                                        if (doente != null)
                                        {
                                            string infoDoente = sistema.ObterInformacao(2);
                                            Console.WriteLine(infoDoente);
                                        }
                                        else
                                        {
                                            string infoInvalida = sistema.ObterInformacao(5);
                                            Console.WriteLine(infoInvalida);
                                            Console.WriteLine("Registe um doente primeiro!");
                                        }
                                        break;

                                    case 4:
                                        // Realizar triagem
                                        if (doente != null)
                                            sistema.RealizarTriagem(doente);
                                        else
                                            Console.WriteLine("Registe um doente primeiro!");
                                        break;

                                    case 5:
                                        sair = true;
                                        break;

                                    default:
                                        Console.WriteLine("Opcao invalida. Escolha uma opcao valida.");
                                        break;
                                }
                            }
                            break;
                        }

                    case 2:
                        {

                           
                            while (!sair)
                            {
                                Console.WriteLine("=== Menu do Medico ===");
                                Console.WriteLine("1. Registrar novo medico");
                                Console.WriteLine("2. Atribuir medico a doente");
                                Console.WriteLine("3. Realizar consulta");
                                Console.WriteLine("4. Mostrar ficha do medico");
                                Console.WriteLine("5. Sair");

                                Console.Write("Escolha uma opcao: ");
                                string userInput2 = Console.ReadLine();

                                //validar se consegue passar o texto para numero
                                bool successful2 = Int32.TryParse(Console.ReadLine(), out int opcao2);


                                //não consegue passar para numero mosgtra mensagem ao utilizador
                                if (!successful2)
                                {
                                    Console.WriteLine("Não pode colocar texto");
                                }

                                switch (opcao2)
                                {
                                    case 1:
                                        // Registar novo médico
                                        sistema.RegistarMedico("Daniel", Especialidade.CIRUGIA, 12);
                                        sistema.RegistarMedico("Margarida", Especialidade.PEDIATRIA, 13);
                                        sistema.RegistarMedico("Pedro", Especialidade.ORTOPEDIA, 14);
                                        Console.WriteLine("Qual o nome do Medico?");
                                        string nomeM = Console.ReadLine();
                                        Console.WriteLine("Qual a especialidade do Medico?\n 1.Cardiologia\n 2.Urologia\n 3.Peadiatria\n 4.Cirugia\n 5.Ortopedia\n");
                                        string esp = Console.ReadLine();
                                        bool sucessoesp = Int32.TryParse(Console.ReadLine(), out int escolha1);
                                        if (!sucessoesp)
                                        {
                                            Console.WriteLine("Nao pode colocar texto");
                                        }
                                        Especialidade especialidade;
                                        switch (escolha1)
                                        {
                                            case 1:
                                                especialidade = Especialidade.CARDIOLOGIA;
                                                break;
                                            case 2:
                                                especialidade = Especialidade.UROLOGIA;
                                                break;
                                            case 3:
                                                especialidade = Especialidade.PEDIATRIA;
                                                break;
                                            case 4:
                                                especialidade = Especialidade.CIRUGIA;
                                                break;
                                            case 5:
                                                especialidade = Especialidade.ORTOPEDIA;
                                                break;
                                            default:
                                                especialidade = Especialidade.NAO_ESPECIFICADA;
                                                Console.WriteLine("Especialidade não encontrada");
                                                break;
                                        }
                                        Console.WriteLine("Qual o n.identificacao do Medico?");
                                        string nidprevio = Console.ReadLine();
                                        bool sucessonid = Int32.TryParse(Console.ReadLine(), out int nid);
                                        if (!sucessonid)
                                        {
                                            Console.WriteLine("Nao pode colocar texto");
                                        }
                                        sistema.RegistarMedico(nomeM,especialidade, nid);
                                        break;

                                    case 2:
                                        // Atribuir médico a doente
                                        if (medico != null)
                                        {
                                            sistema.AtribuirMedico(doente.idDoente,medico.nidentificacao );
                                        }
                                        else
                                            Console.WriteLine("Registe um medico primeiro!");
                                        break;

                                    case 3:
                                        // Realizar consulta
                                        if (medico != null)
                                            sistema.RealizarConsulta(doente.idDoente, medico);
                                        else
                                            Console.WriteLine("Registe um medico primeiro!");
                                        break;

                                    case 4:
                                        // Mostrar ficha do médico
                                        if (medico != null)
                                            medico.ToString();
                                        else
                                            Console.WriteLine("Registe um medico primeiro!");
                                        break;

                                    case 5:
                                        sair = true;
                                        break;

                                    default:
                                        Console.WriteLine("Opcao invalida. Escolha uma opcao valida.");
                                        break;
                                }
                            }
                            break;
                        }

                    case 3:
                        while (!sair)
                        {
                            Console.WriteLine("=== Menu da Sala de Espera ===");
                            Console.WriteLine("1. Adicionar um doente à sala de espera");
                            Console.WriteLine("2. Contar doentes na sala de espera");
                            Console.WriteLine("3. Mostrar lugares ocupados na sala de espera");
                            Console.WriteLine("4. Verificar se existe doente na sala de espera");
                            Console.WriteLine("5. Quantos doentes existem de uma determinada pulseira");
                            Console.WriteLine("6. Obter doentes por prioridade");
                            Console.WriteLine("7. Sair");

                            Console.Write("Escolha uma opcao: ");
                            string userInput3 = Console.ReadLine();

                            //validar se consegue passar o texto para numero
                            bool successful3 = Int32.TryParse(Console.ReadLine(), out int opcao3);


                            //não consegue passar para numero mostra mensagem ao utilizador
                            if (!successful3)
                            {
                                Console.WriteLine("Não pode colocar texto");
                            }

                            switch (opcao3)
                            {
                                case 1:
                                    // Adicionar um doente à sala de espera
                                    salaaEspera.AdicionarDoenteSalaEspera(doente);
                                    break;

                                case 2:
                                    // Contar doentes na sala de espera
                                    int quantidadeDoentes = salaaEspera.ContarDoentes();
                                    Console.WriteLine($"Quantidade de doentes na sala de espera: {quantidadeDoentes}");
                                    break;

                                case 3:
                                    // Mostrar lugares ocupados na sala de espera
                                    salaaEspera.MostrarLugaresOcupados();
                                    break;

                                case 4:
                                    // Verificar se existe doente na sala de espera
                                   bool existeDoente = salaaEspera.ExisteDoenteSalaEspera();

                                   if (existeDoente)
                                   {
                                     Console.WriteLine("Existem doentes na sala de espera.");
                                   }
                                   else
                                   {
                                     Console.WriteLine("Não há doentes na sala de espera no momento.");
                                   }
                                   break;

                                case 5:
                                    Console.WriteLine("Qual a pulseira?\n 1.Verde\n 2.Amarela\n 3.Vermelha");
                                    string corpulseira = Console.ReadLine();
                                    bool sucessocor = Int32.TryParse(Console.ReadLine(), out int escolha);
                                    if (!sucessocor)
                                    {
                                        Console.WriteLine("Nao pode colocar texto");
                                    }
                                    Pulseira pulseiraParaContar;
                                    switch (escolha)
                                    {
                                        case 1:
                                            pulseiraParaContar = Pulseira.VERDE;
                                            int quantidadeDoentes1 = salaaEspera.QuantosDoentesExistemSalaEspera(pulseiraParaContar);
                                            Console.WriteLine($"Existe {quantidadeDoentes1} e pulseira verde");
                                            break;
                                        case 2:
                                            pulseiraParaContar = Pulseira.AMARELA;
                                            int quantidadeDoentes2 = salaaEspera.QuantosDoentesExistemSalaEspera(pulseiraParaContar);
                                            Console.WriteLine($"Existe {quantidadeDoentes2} e pulseira amarela");
                                            break;
                                        case 3:
                                            pulseiraParaContar = Pulseira.VERMELHA;
                                            int quantidadeDoentes3 = salaaEspera.QuantosDoentesExistemSalaEspera(pulseiraParaContar);
                                            Console.WriteLine($"Existe {quantidadeDoentes3} e pulseira vermelha");
                                            break;
                                        default:
                                            pulseiraParaContar = Pulseira.NAO_ESPECIFICADA;
                                            Console.WriteLine("Não existe");
                                            break;
                                    }
                                    break;
                                
                                case 6:
                                    // Obter pacientes por prioridade
                                    List<Doente> doentePorPrioridade = salaaEspera.ObterDoentesPorPrioridade();
                                    break;

                                case 7:
                                    sair = true;
                                    break;

                                default:
                                    Console.WriteLine("Opcao invalida. Escolha uma opcao valida.");
                                    break;

                            }
                            break;
                        }
                        break;

                    case 4:
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opcao invalida. Escolha uma opcao valida.");
                        break;
                }
            }
        }
    }
}