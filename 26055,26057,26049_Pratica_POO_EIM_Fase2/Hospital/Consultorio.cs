using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intervenientes;

namespace Hospital
{
    
    public class Consultorio : Local
    {
        #region ESTADO

        #region ESTADO_CONSULTORIO
        const int MAX = 200; //define o tamanho maximo do array

        public int numero; //identificador  do consultorio
        private Especialidade especialidade; //tipo de especialidade
        public Medico medicoResponsavel; //a
        public Doente doenteConsultorio;
        private int TotMedicos; //total de medicos existentes
        #endregion

        #region ESTADO_CLASSE
        private static int totCon = 0; //Variável de Classe: total de consultótios
        #endregion

        #endregion

        #region METODOS

        #region CONST

        /// <summary>
        /// Construtor por omissão de um consultorio que inicializa propriedades com valores padrão
        /// </summary>
        public Consultorio() //metodo particular
        {
            numero = 1;
            especialidade = Especialidade.PEDIATRIA;
            estado = Estado.OCUPADO;
            //medicoResponsavel = ;
            //doenteConsultorio = ;
            totCon++;
        }

        /// <summary>
        /// construtor que premite uma personalização de alguns propriedades 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="esp"></param>
        /// <param name="est"></param>
        /// <param name="medico"></param>
        public Consultorio(int num, Especialidade esp, Estado est, Medico medico, Doente doente)
        {
            numero = num;
            especialidade = esp;
            estado = est;
            medicoResponsavel = medico;
            doenteConsultorio = doente;
            TotMedicos = 0;
            totCon++;
        }

        /// <summary>
        /// construtor estatico que inicializa a variavel totCon
        /// </summary>
        static Consultorio()
        {
            totCon = 0;
        }

        #endregion

        #region PROPRIEDADES

        #region PROPRIEDADES_INSTÂNCIA
        /// <summary>
        /// propriedade que premite obter ou definir o numero do consultorio
        /// </summary>
        public int Numero
        {
            //inserir valores
            set
            {
                numero = value;
            }
            //manda para fora valores
            get
            {
                return numero;
            }
        }

        /// <summary>
        /// propriedade que premite obter ou definir a especialidade
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
        /// propriedade que premite obter ou definir o estado do consultorio
        /// </summary>
        public Estado Estado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }

        #endregion

        #region PROPRIEDADES_CLASSE
        /// <summary>
        /// propriedade que premite obter o total de consultorios criados
        /// </summary>
        public static int TotCon
        {
            get
            {
                return totCon;
            }
            //set{} //valor apenas controlado internamente
        }

        #endregion

        #endregion

        #region OUTROS
        /// <summary>
        /// metodo que insere um medico no consultorio, verificando se o medico já existe
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public bool InsereMedicoConsultorio(Medico m1)
        {
            //Validações
            if (ExisteMedicoConsultorio(m1)) return false;
            medicoResponsavel = m1;
            TotMedicos++;
            return true;
        }

        /// <summary>
        /// metodo que verifica se um medico ja existe no consultorio
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public bool ExisteMedicoConsultorio(Medico m1)
        {
            return medicoResponsavel != null;
        }

        public bool ExisteDoenteConsultorio()
        {
            return doenteConsultorio != null;
        }

        #endregion

        #region OUTROS
        public void AdicionarMedicoConsultorio(Medico medico)
        {
            if (medicoResponsavel == null)
            {
                medicoResponsavel = medico;
                Console.WriteLine("Médico {medico.nome} atribuído ao consultório {numero}.");
            }
            else
            {
                Console.WriteLine("O consultório {numero} já possui um médico atribuído.");
            }
        }

        public void AdicionarDoenteConsultorio(Doente doente, Medico medico)
        {
            if (doenteConsultorio == null)
            {
                if (medicoResponsavel == medico)
                {
                    doenteConsultorio = doente;
                    Console.WriteLine("Doente {doente.nome} adicionado ao consultório {numero} com o médico {medico.Nome} como responsável.");
                }
                else
                {
                    Console.WriteLine("O médico {medico.nome} não está atribuído ao consultório {Numero}.");
                }
            }
            else
            {
                Console.WriteLine("O consultório {numero} já possui um doente.");
            }
        }

        #endregion

        #region DEST
        /// <summary>
        /// destrutor de classe
        /// </summary>
        ~Consultorio()
        {

        }

        #endregion

        #endregion
    }
}
