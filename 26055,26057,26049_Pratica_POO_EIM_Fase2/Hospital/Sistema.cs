using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intervenientes;

namespace Hospital
{
    public class Sistema
    {
        private List<Doente> listaDeEspera { get; }
        private List<Medico> listaDeMedicos { get; }
        private List<Consultorio> consultorios { get; }


        public Sistema()
        {
            listaDeEspera = new List<Doente>();
            listaDeMedicos = new List<Medico>();
        }

        // Função para registar um novo doente na lista de espera do hospital
        public void RegistarDoente(int id, string nome, int nif, int nutente, Pulseira pulseira, Prioridade prioridade, string historico, string sintomas)
        {
            Doente novoDoente = new Doente(id, nome, nif, nutente, pulseira, prioridade, historico, sintomas);
            listaDeEspera.Add(novoDoente);
            Console.WriteLine("Doente {id} registado com pulseira {pulseira} na lista de espera.");

            EncaminharParaTriagem(novoDoente); // Chamando função para encaminhar o paciente para triagem
        }

        public void RegistarMedico(string nomeMedico, Especialidade especialidade, int nidentificacao)
        {
            Medico novoMedico = new Medico(nomeMedico, especialidade, nidentificacao);
            listaDeMedicos.Add(novoMedico);
            Console.WriteLine($"Médico {nomeMedico} registado com especialidade {especialidade}.");
        }

        private void EncaminharParaTriagem(Doente doente)
        {
            switch (doente.Pulseira)
            {
                case Pulseira.VERMELHA:
                    Console.WriteLine($"O doente {doente.Nome} (urgência muito alta) foi encaminhado para a triagem prioritária.");
                    break;
                case Pulseira.AMARELA:
                    Console.WriteLine($"O doente {doente.Nome} (urgência alta) foi encaminhado para a triagem.");
                    // Lógica específica para doentes com pulseira laranja (urgente)
                    break;
                case Pulseira.VERDE:
                    Console.WriteLine($"O doente {doente.Nome} (não urgente) foi encaminhado para a triagem normal.");
                    // Lógica específica para doentes com pulseira verde (não urgente)
                    break;
                default:
                    Console.WriteLine("Pulseira inválida para o doente {doente.Nome}.");
                    break;
            }
        }

        public void AtualizarHistorico(int id, string historico)
        {
            Doente doente = listaDeEspera.Find(d => d.idDoente == id);

            if (doente != null)
            {
                doente.AtualizarHistorico(historico);
                Console.WriteLine($"Histórico atualizado para o doente {doente.Nome} (ID: {doente.idDoente}).");
            }
            else
            {
                Console.WriteLine($"Doente com ID {id} não encontrado na lista de espera.");
            }
        }

        public string ObterInformacao(int id)
        {

            Doente doente = listaDeEspera.Find(d => d.idDoente == id);

            if (doente != null)
            {
                return doente.ObterInformacao();
            }
            else
            {
                return $"Doente com ID {id} não encontrado na lista de espera.";
            }
        }

        public void AtribuirMedico(int idDoente, int nid)
        {
            Doente doente = listaDeEspera.Find(d => d.idDoente == idDoente);
            Medico medico = listaDeMedicos.Find(m => m.nidentificacao == nid);

            if (doente != null && medico != null)
            {
                // Aqui você pode adicionar lógica para atribuir o médico ao paciente, se necessário
                Console.WriteLine($"Médico {medico.Nome} atribuído ao doente {doente.Nome}.");
            }
            else
            {
                Console.WriteLine("Doente ou médico não encontrado.");
            }
        }

        public void RealizarConsulta(int id, Medico medico)
        {
            Doente doente = listaDeEspera.Find(d => d.idDoente == id);

            if (doente != null)
            {
                Consultorio consultorioDisponivel = consultorios.FirstOrDefault(c => c.ExisteMedicoConsultorio(medico) && c.ExisteDoenteConsultorio() == null);

                if (consultorioDisponivel != null)
                {
                    Medico medicoResponsavel = consultorioDisponivel.medicoResponsavel;

                    // Simulação de realização da consulta
                    Console.WriteLine($"Consulta realizada para o doente {doente.nome} no consultório {consultorioDisponivel.numero} com o médico {medicoResponsavel.nome}.");

                    // Associar o doente ao consultório após a consulta
                    consultorioDisponivel.doenteConsultorio = doente;
                }
                else
                {
                    Console.WriteLine("Não há consultórios disponíveis para realizar a consulta.");
                }
            }
            else
            {
                Console.WriteLine($"Doente com ID {id} não encontrado na lista de espera.");
            }
        }

        public void RealizarTriagem(Doente doente)
        {
            SalaaEspera salaEspera = new SalaaEspera(200);
            switch (doente.Pulseira)
            {
                case Pulseira.VERMELHA:
                    doente.Prioridade = Prioridade.MUITO_URGENTE;
                    break;
                case Pulseira.AMARELA:
                    doente.Prioridade = Prioridade.URGENTE;
                    break;
                case Pulseira.VERDE:
                    doente.Prioridade = Prioridade.POUCO_URGENTE;
                    break;
                default:
                    doente.Prioridade = Prioridade.NAO_ESPECIFICADO;
                    break;
            }
            EncaminharParaSalaEspera(doente, salaEspera);

            // Mensagem simulada de triagem
            Console.WriteLine($"Triagem realizada para o paciente {doente.nome}. Prioridade: {doente.prioridade}");

            // Adicionar o doente à lista de espera após a triagem
            listaDeEspera.Add(doente);
        }

        public void EncaminharParaSalaEspera(Doente doente, SalaaEspera salaEspera)
        {
            // Realizar procedimentos de triagem
            RealizarTriagem(doente);

            // Após a triagem, encaminhar o doente para a sala de espera
            salaEspera.AdicionarDoenteSalaEspera(doente);
            Console.WriteLine($"Doente {doente.nome} encaminhado para a sala de espera.");
        }
    }
}
