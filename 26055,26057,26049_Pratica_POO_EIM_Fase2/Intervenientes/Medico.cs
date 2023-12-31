using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervenientes
{
    public enum Especialidade
    {
        CARDIOLOGIA,
        UROLOGIA,
        PEDIATRIA,
        CIRUGIA,
        ORTOPEDIA,
        NAO_ESPECIFICADA,
    }

    public class Medico : Pessoa
    {
        #region ESTADO

        #region ESTADO_MEDICO
        public Especialidade especialidade; //especialide do medico
        public int nidentificacao; //numero de identificacao do medico dentro do hospital
        #endregion

        #region ESTADO_CLASSE
        private static int totMed = 0; //Variável de Classe: total de médicos
        #endregion

        #endregion

        #region METODOS
        #region CONST

        /// <summary>
        /// Construtor por omissão de um medico
        /// inicializa os valores padrao de um medico
        /// </summary>
        public Medico() //metodo particular
        {
            nome = "Joaquim";
            especialidade = Especialidade.PEDIATRIA;
            nidentificacao = 25;
            totMed++;
        }

        /// <summary>
        /// construtor que premite a inicializacao personalizada dos atributos do medico
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="esp"></param>
        /// <param name="nidentificacao"></param>
        /// <param name="horaent"></param>
        /// <param name="horasaida"></param>
        public Medico(string nome, Especialidade esp, int nidentificacao)
        {
            this.nome = nome;
            especialidade = esp;
            this.nidentificacao = nidentificacao;
            totMed++;
        }

        /// <summary>
        /// Construtor estático que inicializa a variavel totmed
        /// </summary>
        static Medico()
        {
            totMed = 0;
        }

        #endregion

        #region PROPRIEDADES

        #region PROPRIEDADES_INSTÂNCIA
        /// <summary>
        /// propriedade que premite obter ou definir o nome do medico
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
        /// propriedade que premite obter ou definir a especialidade do medico
        /// </summary>
        public Especialidade Especialidade
        {
            set
            {
                especialidade = value;
            }
            get
            {
                return especialidade;
            }
        }


        /// <summary>
        /// propriedade que premite obter ou definir o numero de identificacao do medico
        /// </summary>
        public int NIfentificacao
        {
            set
            {
                nidentificacao = value;
            }
            get
            {
                return nidentificacao;
            }
        }
        #endregion

        #region PROPRIEDADES_CLASSE
        /// <summary>
        /// propriedade que premite obter o total de medicos criados
        /// </summary>
        public static int TotMed
        {
            get
            {
                return totMed;
            }
            //set{} //valor apenas controlado internamente
        }

        #endregion

        #endregion


        #region Overrides
        /// <summary>
        /// Subcreve o metodo ToString par fornecer uma ficha do medico
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Ficha de Medico=> Nome: {0} - Especialidade: {1} - Número de identificacao: {2}\n", nome, especialidade, nidentificacao);
            //return base.ToString();
        }

        #endregion

        #region DEST
        /// <summary>
        /// destrutor de classe
        /// </summary>
        ~Medico()
        {

        }
        #endregion

        #endregion
    }
}
