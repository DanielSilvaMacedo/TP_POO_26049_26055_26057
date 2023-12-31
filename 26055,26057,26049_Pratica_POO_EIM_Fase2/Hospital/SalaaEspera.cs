using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intervenientes;

namespace Hospital
{
    public class SalaaEspera : Local
    {
        #region Atributos
        public List<Doente> doente { get; set; }
        public int capacidadeMaxima { get; set; }
        public List<string> recursosDisponiveis { get; set; }

        #endregion

        #region Metodos

        #region Construtores
        public SalaaEspera(int cpMaxima)
        {
            doente = new List<Doente>();
            capacidadeMaxima = cpMaxima;
            estado = Estado.VAZIO;
            recursosDisponiveis = new List<string>();
        }
        #endregion


        #region Outros
        public void AdicionarDoenteSalaEspera(Doente d1)
        {
            doente.Add(d1);
        }

        public int ContarDoentes()
        {
            return doente.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        public void MostrarLugaresOcupados()
        {
            if (doente.Count > 0)
            {
                Console.WriteLine("Lugares ocupados na sala de espera:");
                foreach (var doente in doente)
                {
                    Console.WriteLine($"- {doente.nome}");
                }
            }
            else
            {
                Console.WriteLine("Não há doentes na sala de espera no momento.");
            }
        }



        /// <summary>
        /// Verifica se um doente com o nome e pulseira especificos existe na sala de espera
        /// </summary>
        /// <param name="nome">O nome do doente a ser verificado</param> 
        /// <param name="pulseira">A pulseira do doente a ser verificado</param>
        /// <returns>True se o doente existe, false se não</returns>
        public bool ExisteDoenteSalaEspera()
        {
            return doente.Count > 0;
        }

        /// <summary>
        /// Verifica quantos doentes da mesma pulseira existem na sala de espera
        /// </summary>
        /// <param name="pulseira">A pulseira para a qual contar os doentes</param> 
        /// <returns>O numero de doentes com a pulseira especificada na sala de espera</returns>
        public int QuantosDoentesExistemSalaEspera(Pulseira pulseira)
        {
            return doente.Count(p => p.Pulseira == pulseira);
        }

        public List<Doente> ObterDoentesPorPrioridade()
        {
            return doente.OrderByDescending(p => p.Prioridade).ToList();
        }

        //public void NotificarChegadaDoente(Doente doente)
        //{
        //    // Lógica para notificar a chegada do paciente
        //    Console.WriteLine($"Doente {doente.nome} chegou à sala de espera.");

        //    // Chama o método para inserir o paciente na sala de espera
        //    AdicionarDoenteSalaEspera(doente);
        //}
        #endregion

        #region DEST
        /// <summary>
        /// destrutor de classe
        /// </summary>
        ~SalaaEspera()
        { }
        #endregion

        #endregion
    }
}
