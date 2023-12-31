using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervenientes
{
    public enum Pulseira
    {
        VERDE,
        AMARELA,
        VERMELHA,
        NAO_ESPECIFICADA,
    }

    public enum Prioridade
    {
        POUCO_URGENTE,
        URGENTE,
        MUITO_URGENTE,
        NAO_ESPECIFICADO,
    }


    public class Doente : Pessoa
    {
        #region ESTADO

        #region ESTADO_DOENTE
        public int idDoente;
        public int nif; //numero de identificacao fiscal do doente
        public int nutente; //numero de utente do doente
        public Pulseira pulseira; //cor da pulseira do doente
        public Prioridade prioridade;
        public string historico; //historico medico do doente
        public string sintomas; //sintomas do doente
        #endregion

        #region ESTADO_CLASSE
        private static int totDoe = 0; //Variável de Classe: total de doente
        #endregion

        #endregion

        #region METODOS

        #region CONST

        /// <summary>
        /// Construtor por omissão de um doente
        /// Inicializa os valores padrao para um doente
        /// </summary>
        public Doente() //metodo particular
        {
            idDoente = 01;
            nome = "Manel";
            nif = 258369147;
            nutente = 147258369;
            pulseira = Pulseira.VERDE;
            prioridade = Prioridade.POUCO_URGENTE;
            historico = "internado, diabetico";
            sintomas = "tosse";
            totDoe++;
        }

        /// <summary>
        /// construtor que premite a inicializacao personalizada dos atributos do doente
        /// </summary>
        /// <param IdDoente="IdDoente"></param>
        /// <param name="nome"></param>
        /// <param name="nif"></param>
        /// <param name="nutente"></param>
        /// <param name="pul"></param>
        /// <param name="hist"></param>
        public Doente(int Id, string nome, int nif, int nutente, Pulseira pul, Prioridade pri, string hist, string sint)
        {
            idDoente = Id;
            this.nome = nome;
            this.nif = nif;
            this.nutente = nutente;
            pulseira = pul;
            prioridade = pri;
            historico = hist;
            sintomas = sint;
            totDoe++;
        }

        /// <summary>
        /// Construtor estático que inicializa a variavel totDoe
        /// </summary>
        static Doente()
        {
            totDoe = 0;
        }

        #endregion

        #region PROPRIEDADES

        #region PROPRIEDADES_INSTÂNCIA

        /// <summary>
        /// 
        /// </summary>
        public int IdDoente
        { //inserir valores
            set
            {
                idDoente = value;
            }
            //manda para fora valores
            get
            {
                return idDoente;
            }
        }

        /// <summary>
        /// propriedade que premite obter ou definir o nome do doente
        /// </summary>
        public string Nome
        {
            //inserir valores
            set
            {
                nome = value;
            }
            //manda para fora valores
            get
            {
                return nome;
            }
        }


        /// <summary>
        /// propriedade que premite obter ou definir o nif do doente
        /// </summary>
        public int Nif
        {
            set
            {
                nif = value;
            }
            get
            {
                return nif;
            }
        }

        /// <summary>
        /// propriedade que premite obter ou definir o n.utente do doente
        /// </summary>
        public int Nutente
        {
            set
            {
                nutente = value;
            }
            get
            {
                return nutente;
            }
        }

        /// <summary>
        /// propriedade que premite obter ou definir a pulseira do doente
        /// </summary>
        public Pulseira Pulseira
        {
            set
            {
                pulseira = value;
            }
            get
            {
                return pulseira;
            }
        }


        public Prioridade Prioridade
        {
            set
            {
                prioridade = value;
            }
            get
            {
                return prioridade;
            }
        }

        /// <summary>
        /// propriedade que premite obter ou definir o historico do doente
        /// </summary>
        public string Historico
        {
            set
            {
                historico = value;
            }
            get
            {
                return historico;
            }
        }

        /// <summary>
        /// propriedade que premite obter ou definir o sintomas do doente
        /// </summary>
        public string Sintomas
        {
            set
            {
                sintomas = value;
            }
            get
            {
                return sintomas;
            }
        }
        #endregion

        #region PROPRIEDADES_CLASSE
        /// <summary>
        /// propriedade que premite obter o total de doentes criados
        /// </summary>
        public static int TotDoe
        {
            get
            {
                return totDoe;
            }
            //set{} //valor apenas controlado internamente
        }

        #endregion

        #endregion

        #region Overrides
        /// <summary>
        /// Subcreve o metodo ToString par fornecer uma ficha do doente
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Ficha de Doente=> Nome: {0} -  Nif: {1} - N.utente: {2} - Pulseira: {3}- Prioridade: {4} - Historico: {5} - Sintomas: {6}\n", nome, nif, nutente, pulseira, prioridade, historico, sintomas);
            //return base.ToString();
        }

        #endregion

        #region OUTROS
        public void AtualizarHistorico(string historico)
        {
            this.historico += "\n" + historico;
        }


        public string ObterInformacao()
        {
            return $"ID: {idDoente}, Nome: {nome}, Pulseira: {pulseira}, Prioridade:{prioridade} Histórico Médico: {historico}";
        }

        #endregion

        #region DEST
        /// <summary>
        /// destrutor de classe
        /// </summary>
        ~Doente()
        {

        }

        #endregion
        #endregion
    }
}
