using Microsoft.EntityFrameworkCore;
using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Aluno ConsultaCpf(string cpf)
        {
            Aluno aluno_ = context.Set<Aluno>().Where(x => x.cpf == cpf && x.alunoTreinos.Any(at => at.aluno_codigo == x.codigo))
                                  .Include(a => a.alunoTreinos).AsNoTracking().FirstOrDefault();
            context.Entry(aluno_).State = EntityState.Detached;
            return aluno_;
        }


        //Essa consulta consiste em retornar a classe Aluno e todas suas entidades filhas
        public Aluno ConsultaCompleta(Aluno aluno)
        {            
            Aluno aluno_ = context.Set<Aluno>().Include(a => a.alunoTreinos).FirstOrDefault();
            return aluno_;
        }

        //Essa listagem consiste em retornar a classe Aluno e todas suas entidades filhas
        public List<Aluno> ListagemCompleta()
        {
            List<Aluno> alunos = context.Set<Aluno>().Include(a => a.alunoTreinos).ToList();
            return alunos;
        }

    }
}
